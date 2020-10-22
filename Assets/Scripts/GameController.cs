using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;

    public GameObject start_end_canvas;
    public Text start_end_text;

    private GameObject panel_text;
    private GameObject mage_select;
    private GameObject bowman_select;

    public string Hero;

    private GameObject battleMenu;

    public Text battleText;

    public bool heroTurn = true;

    private GameObject enemy;
    private GameObject hero;

    private void Awake()
    {
        battleMenu = GameObject.Find("ActionMenu");
        panel_text = start_end_canvas.transform.GetChild(0).gameObject;
        mage_select = start_end_canvas.transform.GetChild(1).gameObject;
        bowman_select = start_end_canvas.transform.GetChild(2).gameObject;
    }


    public void GameOver(GameObject loser){
        panel_text.SetActive(true);
        Debug.Log(Hero);

        if (loser.name == Hero){
            start_end_text.text= $"You Lost! The {enemy.name} is the winner";
            enemy.SetActive(false);
            hero.SetActive(false);

        } else {
            start_end_text.text= $"You Won! The {Hero} is the winner";
            hero.SetActive(false);
            enemy.SetActive(false);

        }

        //Activate winner Avatar
        if (loser.name == "Mage"){
            bowman_select.SetActive(true);
        } else {
            mage_select.SetActive(true);
        }
    }

    public void NextTurn(){
        Debug.Log("NextTurn");

        if(!enemy.activeSelf){
            Debug.Log("Enemy is dead");
            GameOver(enemy);

        } else if(!hero.activeSelf){
            Debug.Log("Hero is dead");
            GameOver(hero);

        } else if(heroTurn){
            this.battleMenu.SetActive(true);
            heroTurn = false;

        } else {
            this.battleMenu.SetActive(false);
            int rand = Random.Range(0, 3);
                if ( rand == 0)
                {
                    string WeaponType =  "bow";
                    enemy.GetComponent<FighterAction>().SelectWeapon(WeaponType);
                } else if (rand == 1)
                {
                    string WeaponType =  "axe";
                    enemy.GetComponent<FighterAction>().SelectWeapon(WeaponType);
                } else if (rand == 2)
                {
                    string WeaponType =  "sword";
                    enemy.GetComponent<FighterAction>().SelectWeapon(WeaponType);
                }
            heroTurn = true;
        }
    }


    public void StartBattle(GameObject hero, GameObject enemy){
        this.hero = hero;
        this.enemy = enemy;
        battleText.gameObject.SetActive(true);
        battleText.text= $"You chose the {hero.name}!\n FIGHT!";
        heroTurn = true;
        NextTurn();
    }
}
