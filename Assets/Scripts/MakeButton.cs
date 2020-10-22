using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    private GameObject Player1;

    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        // Player1 = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        Player1 = GameObject.FindGameObjectWithTag("Hero");

        if (btn.CompareTo("AxeButton") == 0)
        {
            Player1.GetComponent<FighterAction>().SelectWeapon("axe");
        }else if (btn.CompareTo("BowButton") == 0)
        {
            Player1.GetComponent<FighterAction>().SelectWeapon("bow");
        }else if (btn.CompareTo("SwordButton") == 0)
        {
            Player1.GetComponent<FighterAction>().SelectWeapon("sword");
        }

    }
}
