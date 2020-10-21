using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    public GameObject owner;

    [Header("Attributes")]
    public string weaponName;
    public int baseDamage;
    public string multiplier;
    public int dodge;

    private int damage;
    private FighterStats attackerStats;
    private FighterStats targetStats;
    private GameObject GameControllerObj;

    void Awake()
    {
        GameControllerObj = GameObject.Find("GameControllerObject");
    }

    public void Damage(GameObject target)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = target.GetComponent<FighterStats>();

        if (Random.Range(0, 10) >= dodge) //switch back to less than
        {
            damage = 5;
            // damage = 0;
        // } else if (multiplier == "Dexterity")
        // {
        //     damage = baseDamage * (attackerStats.Dexterity/100);
        // } else if (multiplier == "Strength")
        // {
        //     damage = baseDamage * (attackerStats.Strength/100);
        } else
        {
            Debug.Log("PLAYER DODGED! D:");
        }

        targetStats.health -= damage;

        if(targetStats.health < 1)
            {
                target.tag = "Dead";
                // Destroy(healthFill);  Leave these two for Stat script..?
                // Destroy(gameObject);
            }

        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();

    }
}