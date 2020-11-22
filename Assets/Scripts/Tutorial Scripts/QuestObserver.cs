using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestAction {

}

public class QuestObserver : Observer
{
    private void Start() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Subject>().AddObserver(this);
    }

    public override void OnNotify()
    {
        
    }

    
}
