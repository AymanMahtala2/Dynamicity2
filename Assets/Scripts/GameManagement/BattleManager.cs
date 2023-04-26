using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField]
    private List<AIEnemy> currentEnemies;

    public AIEnemy currentEnemy;
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    [SerializeField]
    private CinemachineTargetGroup targetGroup;

    private bool battleStarted;
    private void Start()
    {
        instance = this;
        currentEnemies = new List<AIEnemy>();
    }

    public void AddToListOfEnemies(AIEnemy enemy)
    {
        currentEnemies.Add(enemy);
        if(!battleStarted)
        {
            PlayerController.instance.FightingMode();
            StartBattle();
        }
    }

    public void StartBattle()
    {
        currentEnemy = currentEnemies[0];
        currentEnemies.RemoveAt(0);
        AudioController.instance.PlayMusic(1);
        targetGroup.AddMember(currentEnemy.transform, 1, 1.5f);
        vcam.Priority = 11;
    }
    public void KilledEnemy()
    {
        if(currentEnemies.Count == 0)
        {
            EndBattle();
        }
    }

    public void EndBattle()
    {
        vcam.Priority = 1;
        PlayerController.instance.IdleMode();
        AudioController.instance.PlayMusic(0);
    }


    public void Yield()
    {

    }
}
