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

    [SerializeField]
    private Dialogue dialogueSecond;

    public bool startsImmediately;

    [SerializeField]
    private Character character;

    public bool talkedToOnce;

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
        if(this.dialogue == dialogue)
        {
            DialogueManager.instance.StartDialogue(character.transform);
            PlayerInput.instance.CannotMoveOrAttack();
            PlayerController.instance.SwitchToTalkingCam(true);
            _DialogueChannel.RaiseDialogueStart(dialogue);
        }
    }
    public bool startFight = false;
    private void OnDialogueEnd(Dialogue dialogue)
    {
        if(this.dialogue == dialogue)
        {
            _DialogueChannel.RaiseDialogueEnd(dialogue);
            PlayerInput.instance.CanMoveOrAttack();
            DialogueManager.instance.StopDialogue(character.transform);
            PlayerController.instance.SwitchToTalkingCam(false);
            startsImmediately = false;
            talkedToOnce = true;
            this.dialogue = dialogueSecond;

            if (startFight)
            {
                PlayerController.instance.di.transform.parent.GetComponent<Character>().FightingMode();
            }
        }
    }

    public void StartTalking()
    {
        _DialogueChannel.RaiseRequestDialogue(dialogue);
    }
    
    //private void Update()
    //{
    //    if (inRange)
    //    {
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            _DialogueChannel.RaiseRequestDialogue(dialogue);
    //        }
    //    }
    //}
}
