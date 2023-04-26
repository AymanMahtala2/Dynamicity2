using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private Collider2D shieldCollider;

    public void RaiseShield()
    {
        shieldCollider.enabled = true;
    }

    public void LowerShield()
    {
        shieldCollider.enabled = false;
    }
}
