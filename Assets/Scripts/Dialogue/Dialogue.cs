using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    private DialogueNode _FirstNode;

    public DialogueNode FirstNode => _FirstNode;

    public int whichQuest = -1;
    public QuestState whichState;

    public bool completeGame;
}
