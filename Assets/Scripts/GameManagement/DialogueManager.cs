using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    [SerializeField]
    private CinemachineTargetGroup targetGroup;

    public Transform currentlyConversingWith;

    private void Start()
    {
        instance = this;
    }

    public void StartDialogue(Transform currentTalker)
    {
        targetGroup.AddMember(currentTalker, 1, 1.5f);
    }

    public void StopDialogue(Transform currentTalker)
    {
        targetGroup.RemoveMember(currentTalker);
    }
}
