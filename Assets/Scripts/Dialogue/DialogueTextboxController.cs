using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTextboxController : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField]
    private TextMeshProUGUI _SpeakerText;
    [SerializeField]
    private TextMeshProUGUI _DialogueText;

    [SerializeField]
    private RectTransform _ChoicesBoxTransform;
    [SerializeField]
    private DialogueChoiceController _ChoiceControllerPrefab;

    [SerializeField]
    private DialogueChannel _DialogueChannel;

    private bool _ListenToInput = false;
    private DialogueNode _NextNode = null;

    private void Awake()
    {
        _DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        _DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;

        gameObject.SetActive(false);
        _ChoicesBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        _DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }

    private void Update()
    {
        if (_ListenToInput && Input.GetKeyDown(KeyCode.E))
        {
            _DialogueChannel.RaiseRequestDialogueNode(_NextNode);
        }
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);

        _DialogueText.text = node.DialogueLine.Text;
        _SpeakerText.text = node.DialogueLine.Speaker.CharacterName;

        node.Accept(this);
    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        _NextNode = null;
        _ListenToInput = false;
        _DialogueText.text = "";
        _SpeakerText.text = "";

        foreach (Transform child in _ChoicesBoxTransform)
        {
            Destroy(child.gameObject);
        }
        gameObject.SetActive(false);
        
        _ChoicesBoxTransform.gameObject.SetActive(false);
    }
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    public void Visit(BasicDialogueNode node)
    {
        _ListenToInput = true;
        _NextNode = node.NextNode;
    }

    public void Visit(ChoiceDialogueNode node)
    {
        StartCoroutine(FadeChoicesIn(node));
    }

    private IEnumerator FadeChoicesIn(ChoiceDialogueNode node)
    {
        yield return new WaitForSeconds(2f);
        _ChoicesBoxTransform.gameObject.SetActive(true);
        int i = 0;
        foreach (DialogueChoice choice in node.Choices)
        {
            DialogueChoiceController newChoice = Instantiate(_ChoiceControllerPrefab, _ChoicesBoxTransform);
            newChoice.Choice = choice;
            newChoice.gameObject.GetComponent<RectTransform>().position -= new Vector3(0, 35 * i);
            i++;
        }
    }
}
