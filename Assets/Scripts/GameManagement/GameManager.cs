using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Dictionary<int, State> NPCGuide;
    public Dictionary<int, QuestState> QuestGuide;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void LogDeath(int NPC, State newState)
    {
        NPCGuide[NPC] = newState;
        PlayerPrefs.SetInt(NPC.ToString(), (int) newState);
    }

    public void LogQuest(int quest, QuestState newState)
    {
        QuestGuide[quest] = newState;
        PlayerPrefs.SetInt(quest.ToString(), (int) newState);

    }

    public enum State
    {
        Neutral,
        Favorable,
        Unfavorable,
        Dead
    }

    public enum QuestState
    {
        Started,
        Step1,
        Step2,
        Succeeded,
        Failed
    }
}
