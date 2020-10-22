using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    public GameObject owner;

    [Header("Attributes")]
    public string weaponName;
    public double baseDamage;
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

        owner.GetComponent<Animator>().Play(weaponName);
        if (owner.name == "Mage" && weaponName == "Sword")
        {
        owner.GetComponent<Animator>().Play("Bow");
        }

        if (Random.Range(0, 10) <= dodge)
        {
            damage = 3;
        } else if (multiplier == "Dexterity")
        {
            damage = (int)(baseDamage * (double)(attackerStats.Dexterity/100.00));
        } else if (multiplier == "Strength")
        {
            damage =  (int)(baseDamage * (double)(attackerStats.Strength/100.00));
        } else
        {
            Debug.Log("Something went wrong...");
        }

        target.GetComponent<Animator>().Play("damage");
        targetStats.Health -= damage;
        targetStats.UpdateHealthBar();



        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();

        Invoke("ContinueGame", 1);
    }

    void ContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
}