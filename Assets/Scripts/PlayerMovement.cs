﻿using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheckLocation;
    public float groundDist = 1f;
    public LayerMask groundMask;
    public CinemachineVirtualCamera vcam;
    public GameObject followTarget; // we will use this for slight Y axis camera rotation
    public HealthBar healthBar;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Input playerInput;
    private Vector2 mouseVec;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Vector2 moveVec;
    private Vector3 prevVec;
    private Vector3 movement;

    private bool isJumping = false;
    private bool isGrounded = false;

    private float gravity = -9.8f;

    private float sensitivity = 10.0f;
    private float moveSpeed = 10.0f;
    private float jumpHeight = 1.0f;


    //attack
    [SerializeField]
    private WeaponTrigger hitbox;
    private float attackTime = 0.0f;
    private bool isAttacking = false;

    [SerializeField]
    private int maxHP = 150;
    [SerializeField]
    private int HP = 150;

    //logger variables
    [SerializeField] private StatsLogger _stats;
    public bool hitDetection = false;


    private Subject subject;
    private Vector2 prevRotation;
    private Vector3 prevPosition;

    //reset rotations upon respawn from death
    public void ResetRotations()
    {
        xRotation = 0.0f;
        yRotation = 0.0f;
    }

    public void OnHit(int damage)
    {
        HP -= damage;
        healthBar.SetHealth(HP);
        if (HP <= 0) {
            this.transform.position = GameObject.Find("DeathPlane").transform.position;
        }
    }
    public void ResetHealth() {
        HP = maxHP;
        healthBar.SetHealth(HP);
    }


    private void Awake()
    {
        healthBar.SetMaxHealth(HP);
        playerInput = new Input();

        playerInput.Gameplay.Move.performed += ctx => moveVec = ctx.ReadValue<Vector2>();
        playerInput.Gameplay.Move.canceled += ctx => moveVec = Vector2.zero;

        playerInput.Gameplay.Camera.performed += ctx => mouseVec = ctx.ReadValue<Vector2>();
        playerInput.Gameplay.Camera.canceled += ctx => mouseVec = Vector2.zero;

        playerInput.Gameplay.Jump.performed += ctx => Jump();
        playerInput.Gameplay.BasicAttack.performed += ctx => BasicAttack();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        subject = this.GetComponent<Subject>();
        HP = maxHP;
        healthBar.SetMaxHealth(maxHP);

    }

    private Vector3 GetMoveVector()
    {
        Vector3 direction = new Vector3(moveVec.x, 0.0f, moveVec.y);
        direction = transform.TransformDirection(direction);
        direction.y = 0.0f;

        movement = direction * moveSpeed * Time.deltaTime;

        if (isGrounded && movement.y < 0.0f)
        {
            movement.y = 0.0f;
        }

        return movement;
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckLocation.position, groundDist, groundMask);
    }

    private void Jump()
    {
        if (!isJumping && isGrounded)
        {
            isJumping = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            //Debug.Log("Jump");
            _stats.OnJump();
            subject.Notify(QuestAction.Jump);
        }
    }

    private void BasicAttack()
    {
        if (hitbox.gameObject.activeSelf == false && isAttacking == false)
        {
            isAttacking = true;
            Quaternion rot = Quaternion.LookRotation(transform.position);
            hitbox.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = mouseVec.x * sensitivity * Time.deltaTime;
        float mouseY = mouseVec.y * sensitivity * Time.deltaTime;

        xRotation += mouseX;
        yRotation -= mouseY;

        if (prevRotation.x != xRotation || prevRotation.y != yRotation) {
            subject.Notify(QuestAction.Look);
        }

        // clamp y rotation here so you cant look upside down with a broken neck
        yRotation = Mathf.Clamp(yRotation, 0.0f, 25.0f);

        transform.localRotation = Quaternion.Euler(0.0f, xRotation, 0.0f);
        followTarget.transform.localRotation = Quaternion.Euler(yRotation, 0.0f, 0.0f);

        Vector3 curMoveVector = GetMoveVector();
        controller.Move(curMoveVector);

        if (prevPosition != this.gameObject.transform.position) {
            subject.Notify(QuestAction.Move);
        }

        GroundCheck();
        if (isJumping && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            isJumping = false;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        if(playerVelocity.y < 0.0f && isGrounded)
        {
            playerVelocity.y = 0.0f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

        prevVec = curMoveVector;

        if (isAttacking)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= 1.0f)
            {
                hitbox.gameObject.SetActive(false);
                attackTime = 0.0f;
                isAttacking = false;

                _stats.OnAttack();
                if (hitDetection == true) { 
                    _stats.OnHit();
                }
                hitDetection = false;
            }
        }

        // force camera update; this seems to fix the flickering position of the vcam
        // when the camera is angled all the way down
        vcam.InternalUpdateCameraState(followTarget.transform.up, Time.deltaTime);
        prevRotation = new Vector2(xRotation, yRotation);
        prevPosition = this.gameObject.transform.position;
    }

}
