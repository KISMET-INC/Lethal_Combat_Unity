using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kristens Script
public class Selection_Script : MonoBehaviour
{
    // Start is called before the first frame update
   
public GameObject bowman_prefab;
public GameObject mage_prefab;
public GameObject panel_text_select;
public GameObject mage_select;
public GameObject bowman_select;

public GameObject bowman_pad;
public GameObject mage_pad;


    public void youClickedKim() {

        Debug.Log("You ClickedKim the bowman as your hero");
        this.gameObject.GetComponent<GameController>().Hero = bowman_prefab.name.ToString();
        bowman_prefab.GetComponent<SpriteRenderer>().enabled = true;
        mage_prefab.GetComponent<SpriteRenderer>().enabled = true;
        bowman_pad.SetActive(true);

        panel_text_select.SetActive(false);
        mage_select.SetActive(false);
        bowman_select.SetActive(false);
        
        this.GetComponent<GameController>().StartBattle(bowman_prefab, mage_prefab);
    }

    public void youClickedKristen() {

        Debug.Log("You Clicked Kristen the mage as your hero");
        this.gameObject.GetComponent<GameController>().Hero = mage_prefab.name.ToString();
        bowman_prefab.GetComponent<SpriteRenderer>().enabled = true;
        mage_prefab.GetComponent<SpriteRenderer>().enabled = true;
        mage_pad.SetActive(true);

        bowman_prefab.gameObject.tag = "Enemy";
        mage_prefab.gameObject.tag = "Hero";

        panel_text_select.SetActive(false);
        mage_select.SetActive(false);
        bowman_select.SetActive(false);

        this.GetComponent<GameController>().StartBattle(mage_prefab,bowman_prefab);
    }
}
