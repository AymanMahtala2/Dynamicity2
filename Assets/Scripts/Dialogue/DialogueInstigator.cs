using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueInstigator : MonoBehaviour
{
    [SerializeField]
    private DialogueChannel _DialogueChannel;

    private DialogueSequencer _DialogueSequencer;

    [SerializeField]
    private Dialogue dialogue;

    private void Awake()
    {
        _DialogueSequencer = new DialogueSequencer();

        _DialogueSequencer.OnDialogueStart += OnDialogueStart;
        _DialogueSequencer.OnDialogueEnd += OnDialogueEnd;
        _DialogueSequencer.OnDialogueNodeStart += _DialogueChannel.RaiseDialogueNodeStart;
        _DialogueSequencer.OnDialogueNodeEnd += _DialogueChannel.RaiseDialogueNodeEnd;

        _DialogueChannel.OnDialogueRequested += _DialogueSequencer.StartDialogue;
        _DialogueChannel.OnDialogueNodeRequested += _DialogueSequencer.StartDialogueNode;
    }

    private void OnDestroy()
    {
        _DialogueChannel.OnDialogueNodeRequested -= _DialogueSequencer.StartDialogueNode;
        _DialogueChannel.OnDialogueRequested -= _DialogueSequencer.StartDialogue;

        _DialogueSequencer.OnDialogueNodeEnd -= _DialogueChannel.RaiseDialogueNodeEnd;
        _DialogueSequencer.OnDialogueNodeStart -= _DialogueChannel.RaiseDialogueNodeStart;
        _DialogueSequencer.OnDialogueEnd -= OnDialogueEnd;
        _DialogueSequencer.OnDialogueStart -= OnDialogueStart;

        _DialogueSequencer = null;
    }

    private void OnDialogueStart(Dialogue dialogue)
    {
        PlayerInput.instance.canAttack = false;
        vcam.Priority = 12;
        _DialogueChannel.RaiseDialogueStart(dialogue);
    }

    private void OnDialogueEnd(Dialogue dialogue)
    {
        _DialogueChannel.RaiseDialogueEnd(dialogue);
        PlayerInput.instance.canAttack = true;
        vcam.Priority = 1;
    }

    private bool inRange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
        }
    }
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                _DialogueChannel.RaiseRequestDialogue(dialogue);
            }
        }
    }
}
