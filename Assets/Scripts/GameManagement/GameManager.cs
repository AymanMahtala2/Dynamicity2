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

            QuestGuide[0] = QuestState.Started; //main quest
            QuestGuide[1] = QuestState.NotStarted; //find keys
            QuestGuide[2] = QuestState.NotStarted; //kill thief
            QuestGuide[3] = QuestState.NotStarted;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("hasSavedGame", 1);
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
    public Transporter lockedDoor;
    public Character drunkman;
    public Dialogue dialogueDrunkCompleted;
    public void OpenDoor()
    {
        lockedDoor.locked = false;
        drunkman.di.dialogue = dialogueDrunkCompleted;
        drunkman.di.dialogueSecond = dialogueDrunkCompleted;

    }

    public Character Rendall;
    public Dialogue dialogueKilledThiefNoStartQuest;
    public Dialogue dialogueKilledThief;

    public void QuestDeathImpact(int NPC)
    {
        switch(NPC)
        {
            case 2:
                {
                    QuestGuide[2] = QuestState.Failed;
                }
                break;
            case 8:
                {
                    if (QuestGuide[2] == QuestState.NotStarted)
                    {
                        QuestGuide[2] = QuestState.SucceededWithoutStarting;
                    } else if (QuestGuide[2] == QuestState.Started)
                    {
                        QuestGuide[2] = QuestState.Succeeded;
                    }
                }
                break;
        }
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
        SucceededWithoutStarting,
        Step2,
        Succeeded,
        Failed
    }
}
