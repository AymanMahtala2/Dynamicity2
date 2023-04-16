using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    private DialogueNode _FirstNode;

    public DialogueNode FirstNode => _FirstNode;
}
