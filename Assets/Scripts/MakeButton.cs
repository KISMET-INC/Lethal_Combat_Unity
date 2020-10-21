using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private GameObject WeaponPreFab;

    private GameObject Player1;

    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        Player1 = GameObject.FindGameObjectWithTag("Player1");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("AxeButton") == 0)
        {
            Player1.GetComponent<FighterAction>().SelectAction("axe");
        }else if (btn.CompareTo("BowButton") == 0)
        {
            Player1.GetComponent<FighterAction>().SelectAction("bow");
        }else if (btn.CompareTo("GavalinButton") == 0)
        {
            Player1.GetComponent<FighterAction>().SelectAction("gavalin");
        }

    }
}
