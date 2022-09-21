using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticles;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        //Get the enemies in the scene
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        //Which enemy is the closest
        Transform closestTarget = null;
        // Set closest distance
        float maxDistance = Mathf.Infinity;


        // Look over the enemies
        foreach (Enemy enemy in enemies)
        {
            //find the distance between tower and enemy
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            //if the new target closer 
            if (targetDistance < maxDistance)
            {
                //sets the closest enemy
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }

        }

        target = closestTarget;
    }
    void AimWeapon()
    {
        //is the tower in range of the enemy
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        if (targetDistance < range)
        {

            Attack(true);
        }
        else {
            Attack(false);
        }


    }
    void Attack(bool isActive)
    {
        var emisionModule = projectileParticles.emission;
        emisionModule.enabled = isActive;

    }
}
