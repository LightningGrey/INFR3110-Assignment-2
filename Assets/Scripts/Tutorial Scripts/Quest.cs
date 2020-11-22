using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Desc;
    void Start()
    {
        this.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Complete() {
        this.transform.GetChild(1).gameObject.SetActive(true);
        Name.text = "<s>" + Name.text + "</s>";
        if (Desc != null) {
            Desc.text = "<s>" + Desc.text + "</s>";
        }
    }
}
