using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIEnemy : MonoBehaviour
{
    private MovingCharacter mc;
    public bool isShielding;

    public bool isFighting;
    private bool inAttackRange;
    private bool inFightingRange;
    [SerializeField]
    private State state;
    private void Start()
    {
        AudioController.instance.StopMusic(0);
        AudioController.instance.music[1].Play();
        state = State.Chasing;
        mc = GetComponent<MovingCharacter>();
        mc.fightingMode = true;
        BattleManager.instance.currentEnemy = mc;
        StartCoroutine(AttackPattern());
        StartCoroutine(MovePattern());
    }

    private IEnumerator MovePattern()
    {
        while(true)
        {
            if(state == State.Chasing)
            {
                if (PlayerController.instance.transform.position.x > mc.transform.position.x)
                {
                    mc.direction = 1;
                }
                else
                {
                    mc.direction = -1;
                }

                if(inAttackRange)
                {
                    state = State.Fighting;
                }
                yield return new WaitForSeconds(0.2f);
            } else if(state == State.Fighting)
            {
                yield return new WaitForSeconds(Random.Range(0, 0.5f));
                int i = Random.Range(-1, 2);
                mc.direction = i;
            }
        }

    }
    private IEnumerator AttackPattern()
    {
        //while (true)
        //{
        //    if (inAttackRange)
        //    {
        //        mc.Attack();
        //        yield return new WaitForSeconds(1);
        //    }
        //}
        while(true)
        {
            if(inAttackRange)
            {
                mc.Attack();
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 1.25f));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBody")
        {
            inAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBody")
        {
            inAttackRange = false;
        }
    }

    public enum State
    {
        Chasing,
        Fighting,
        Tactical
    }
}
