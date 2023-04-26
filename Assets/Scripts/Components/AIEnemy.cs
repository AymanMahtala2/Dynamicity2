using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIEnemy : MonoBehaviour
{
    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
        BattleManager.instance.AddToListOfEnemies(this);
        StartCoroutine(AttackPattern());
        StartCoroutine(MovePattern());
    }

    private IEnumerator MovePattern()
    {
        yield return new WaitForSeconds(Random.Range(0, 0.5f));
        //character.direction = -1;

    }
    private IEnumerator AttackPattern()
    {
        while(true)
        {
            character.Attack();
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBody")
        {
            //inAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBody")
        {
            //inAttackRange = false;
        }
    }

    public enum State
    {
        Chasing,
        Fighting,
        Tactical
    }
}
