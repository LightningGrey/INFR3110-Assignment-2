using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> Quests = new List<Quest>(6);
    public int completedQuests;
    void Start()
    {
        foreach (var quest in Quests) {
            quest.gameObject.SetActive(false);
        }
        Quests[0].gameObject.SetActive(true);
    }

    void NextQuest() {
        Quests[completedQuests-1].Complete();
        if (completedQuests != 6) {
            Quests[completedQuests].gameObject.SetActive(true);
        }
    }
}
