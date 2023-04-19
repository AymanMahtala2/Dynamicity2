using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField]
    private List<AIEnemy> currentEnemies;

    public MovingCharacter currentEnemy;

    private void Start()
    {
        instance = this;
    }

    public void HitConnected()
    {
        Invoke("AttackAgain", 0.6f);
    }

    private void AttackAgain()
    {
        currentEnemy.Attack();
    }
}
