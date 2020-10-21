using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    [SerializeField]
    private GameObject meleePreFab;

    [SerializeField]
    private GameObject rangePreFab;

    // [SerializeField]
    // private GameObject healPreFab;

    /*[SerializeField]
    private Sprite faceIcon; //for changing face/profile icon ex. dead, grimace, etc. NOT NECESSARY */

    private GameObject currentAction;

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAction(string btn)
    {
        GameObject target = hero;
        if (tag == "Hero")
        {
            target = enemy;
        }
        if (btn.CompareTo("melee") == 0)
        {
            meleePreFab.GetComponent<ActionScript>().Action(target);
        } else if (btn.CompareTo("range") == 0)
        {
            rangePreFab.GetComponent<ActionScript>().Action(target);
        } else
        {
            Debug.Log("Healed self!");
            // healAction.GetComponent<ActionScript>().Action(target);
        }
    }
}
