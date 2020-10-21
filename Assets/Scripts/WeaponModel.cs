using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public GameObject owner;

    [Header("Attributes")]
    public string weaponName;
    public double baseDamage;
    public string multiplier; //get corresponding Playerstat
    public double dodge;

    private FighterStats attackerStats;
    private FighterStats targetStats;

    public void Action(GameObject target)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = target.GetComponent<FighterStats>();
    }

    public void Damage(GameObject target)
    {
        targetStats;
    }
}


// if(health < 1)
//     {
//         dead = true;
//         gameObject.tag = "Dead";
//         Destroy(healthFill);
//         Destroy(gameObject);
//     }