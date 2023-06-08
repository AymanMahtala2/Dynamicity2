using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Character
{

    private void Start()
    {
        health = 100;
        speed = 2;

        if (GameManager.instance.NPCGuide[NPCNumber] == GameManager.State.Dead)
        {
            Destroy(gameObject);
        }
    }

    public override void Die()
    {
        AudioController.instance.PlaySFX(2);
        ChangeAnimationState("die");
        dead = true;
        Destroy(GetComponent<AIEnemy>());
        Destroy(GetComponent<Collider2D>());
        rb.bodyType = RigidbodyType2D.Static;
        GameManager.instance.LogDeath(NPCNumber, GameManager.State.Dead);
        GameManager.instance.LogQuest(2, GameManager.QuestState.Succeeded);
        BattleManager.instance.KilledEnemy();
        //collider false
        Destroy(this);
    }
}
