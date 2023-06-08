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

            NPCGuide = new Dictionary<int, State>();
            QuestGuide = new Dictionary<int, QuestState>();

            NPCGuide[0] = State.Neutral;
            NPCGuide[1] = State.Neutral;
            NPCGuide[2] = State.Neutral;
            NPCGuide[3] = State.Neutral;
            NPCGuide[4] = State.Neutral;
            NPCGuide[5] = State.Neutral;
            NPCGuide[6] = State.Neutral;
            NPCGuide[7] = State.Neutral;
            NPCGuide[8] = State.Neutral;

            QuestGuide[0] = QuestState.Started;
            QuestGuide[1] = QuestState.NotStarted;
            QuestGuide[2] = QuestState.NotStarted;
            QuestGuide[2] = QuestState.NotStarted;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.Save();
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
        NotStarted,
        Started,
        Step1,
        Step2,
        Succeeded,
        Failed
    }
}
