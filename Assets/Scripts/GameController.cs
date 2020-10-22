using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;

    private GameObject battleMenu;

    public Text battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("ActionMenu");
    }

    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Hero");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats .CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        currentFighterStats = enemy.GetComponent<FighterStats>();
        currentFighterStats .CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);
        fighterStats.Sort();
        this.battleMenu.SetActive(false);

        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if (currentUnit.tag == "Hero")
            {
                this.battleMenu.SetActive(true);
            } else
            { //I needed to change this to match the names I'm using
                this.battleMenu.SetActive(false);
                int rand = Random.Range(0, 3);
                if ( rand == 0)
                {
                    string WeaponType =  "bow";
                    currentUnit.GetComponent<FighterAction>().SelectWeapon(WeaponType);
                } else if (rand == 1)
                {
                    string WeaponType =  "axe";
                    currentUnit.GetComponent<FighterAction>().SelectWeapon(WeaponType);
                } else if (rand == 2)
                {
                    string WeaponType =  "gavalin";
                    currentUnit.GetComponent<FighterAction>().SelectWeapon(WeaponType);
                }
            }
        } else
        {
            NextTurn();
        }
    }
}
