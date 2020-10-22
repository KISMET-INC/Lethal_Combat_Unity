using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Text narration_text;

    public bool heroTurn = true;

    private GameObject enemy;
    private GameObject hero;


    public void NextTurn(){

        if(!enemy.activeSelf){
            GameOver(enemy);

        } else if(!hero.activeSelf){
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
                } 
                else if (rand == 1)
                {
                    string WeaponType =  "axe";
                    enemy.GetComponent<FighterAction>().SelectWeapon(WeaponType);
                } 
                else if (rand == 2)
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
        if(hero.name == "Mage"){
            battleText.text= $"You Chose Kristen the {hero.name}!\n FIGHT!";
        } else {
            battleText.text= $"You Chose Kim the {hero.name}!\n FIGHT!";
        }

        heroTurn = true;
        NextTurn();
    }


    
    private void Awake()
    {
        battleMenu = GameObject.Find("ActionMenu");
        panel_text = start_end_canvas.transform.GetChild(0).gameObject;
        mage_select = start_end_canvas.transform.GetChild(1).gameObject;
        bowman_select = start_end_canvas.transform.GetChild(2).gameObject;
    }


    public void GameOver(GameObject loser){
        
        panel_text.SetActive(true);
<<<<<<< HEAD

        string playerName = loser.name == "Bowman" ? "Kristen" : "Kim";
        if (loser.name == Hero){
            start_end_text.text= $"You Lost!\n{playerName} is the winner";
        
        } else {
            start_end_text.text= $"You Won!\n{playerName} is the winner";
=======
        Debug.Log(Hero);

        if (loser.name == Hero){
            start_end_text.text= $"You Lost! The {enemy.name} is the winner";
            enemy.SetActive(false);
            hero.SetActive(false);

        } else {
            start_end_text.text= $"You Won! The {Hero} is the winner";
            hero.SetActive(false);
            enemy.SetActive(false);
>>>>>>> parent of 6b22a38... Updated Narration text as well as player names (kim and kristen) added
        }

        //Activate winner Avatar
        if (loser.name == "Mage"){
            bowman_select.SetActive(true);

        } else {
            mage_select.SetActive(true);   
        }

        GameObject mage_pad = this.GetComponent<Selection_Script>().mage_pad;
        GameObject bowman_pad = this.GetComponent<Selection_Script>().bowman_pad;

        enemy.SetActive(false);
        hero.SetActive(false);
        mage_pad.SetActive(false);
        bowman_pad.SetActive(false);

        Invoke("Restart",3);
    }
    
    private void Restart() {
        SceneManager.LoadScene("SampleScene");
    }

}
