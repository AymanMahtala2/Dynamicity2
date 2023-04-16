using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueNode : ScriptableObject
{
    [SerializeField]
    private NarrationLine _DialogueLine;

    public NarrationLine DialogueLine => _DialogueLine;

    public abstract bool CanBeFollowedByNode(DialogueNode node);

    public abstract void Accept(DialogueNodeVisitor visitor);
}
