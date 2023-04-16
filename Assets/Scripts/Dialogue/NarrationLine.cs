using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Line")]

public class NarrationLine : ScriptableObject
{
    [SerializeField]
    private NarrationCharacter _Speaker;
    [SerializeField, TextArea(2, 4)]
    private string _Text;

    public NarrationCharacter Speaker => _Speaker;
    public string Text => _Text;
}
