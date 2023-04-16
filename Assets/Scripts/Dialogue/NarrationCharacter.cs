using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField]
    private string _CharacterName;

    public string CharacterName => _CharacterName;
}
