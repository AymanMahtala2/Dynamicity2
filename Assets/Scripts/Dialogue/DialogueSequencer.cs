using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSequencer
{
    public delegate void DialogueCallback(Dialogue dialogue);
    public delegate void DialogueNodeCallback(DialogueNode node);

    public DialogueCallback OnDialogueStart;
    public DialogueCallback OnDialogueEnd;
    public DialogueNodeCallback OnDialogueNodeStart;
    public DialogueNodeCallback OnDialogueNodeEnd;

    private Dialogue _CurrentDialogue;
    private DialogueNode _CurrentNode;

    public void StartDialogue(Dialogue dialogue)
    {
        if(_CurrentDialogue == null)
        {
            _CurrentDialogue = dialogue;
            OnDialogueStart?.Invoke(_CurrentDialogue);
            StartDialogueNode(dialogue.FirstNode);
        }
    }

    public void EndDialogue(Dialogue dialogue)
    {
        if(_CurrentDialogue == dialogue)
        {
            StopDialogueNode(_CurrentNode);
            OnDialogueEnd?.Invoke(_CurrentDialogue);
            _CurrentDialogue = null;
        }
    }

    private bool CanStartNode(DialogueNode node)
    {
        return (_CurrentNode == null || node == null || _CurrentNode.CanBeFollowedByNode(node));
    }

    public void StartDialogueNode(DialogueNode node)
    {
        if (CanStartNode(node))
        {
            StopDialogueNode(_CurrentNode);

            _CurrentNode = node;

            if(_CurrentNode != null)
            {
                OnDialogueNodeStart?.Invoke(_CurrentNode);
            } else
            {
                EndDialogue(_CurrentDialogue);
            }
        }
    }

    private void StopDialogueNode(DialogueNode node)
    {
        if (_CurrentNode == node)
        {
            OnDialogueNodeEnd?.Invoke(_CurrentNode);
            _CurrentNode = null;
        }
    }
}
