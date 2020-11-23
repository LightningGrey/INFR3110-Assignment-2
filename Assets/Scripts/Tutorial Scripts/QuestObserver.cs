using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestAction {
    Look = 0,
    Move = 1,
    Jump = 2,
    Break = 3,
    Defeat = 4,
    Leave = 5
}

public class QuestObserver : Observer
{
    private QuestManager questManager;

    private void Start() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Subject>().AddObserver(this);
        
        questManager = this.GetComponent<QuestManager>();
    }

    public override void OnNotify(QuestAction questType)
    {
        int qt = (int)questType;
        if (qt == questManager.completedQuests) {
            questManager.NextQuest();
        }
        
    }

    
}
