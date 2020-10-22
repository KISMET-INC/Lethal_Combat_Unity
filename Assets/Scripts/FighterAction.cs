using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;

    [SerializeField]
    private GameObject AxePreFab;

    [SerializeField]
    private GameObject BowPreFab;

    [SerializeField]
    private GameObject SwordPreFab;

    /*[SerializeField]
    private Sprite faceIcon; //for changing face/profile icon ex. dead, grimace, etc. NOT NECESSARY */

    // private GameObject currentAction;

    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectWeapon(string btn)
    {
        GameObject target = hero;
        if (tag == "Hero")
        {
            target = enemy;
        }
        if (btn.CompareTo("axe") == 0)
        {
            AxePreFab.GetComponent<WeaponScript>().Damage(target);
        } else if (btn.CompareTo("bow") == 0)
        {
            BowPreFab.GetComponent<WeaponScript>().Damage(target);
        } else if (btn.CompareTo("sword") == 0)
        {
            SwordPreFab.GetComponent<WeaponScript>().Damage(target);
        }

    }

}
