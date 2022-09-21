using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int difficultyRamp = 1;

    [Tooltip("Adds amount to maxHitPoints when enemy dies")]

    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        //set default health
        currentHitPoints = maxHitPoints;
    }
    void OnParticleCollision(GameObject hit)
    {
        int hitPoints = 1;
        ProcessHit(hitPoints);
    }
    void TriggerDeath()
    {
        gameObject.SetActive(false);
        enemy.RewardGold();
        maxHitPoints += difficultyRamp;
    }
    void ProcessHit(int hitpoints)
    {
        currentHitPoints -= hitpoints;
        Debug.Log($"Taking a hit of {hitpoints}");
    }
    void Update()
    {
        if (currentHitPoints <= 0)
        {
            TriggerDeath();

        }
    }
}
