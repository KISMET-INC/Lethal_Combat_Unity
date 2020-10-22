using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterStats : MonoBehaviour, IComparable
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    // [SerializeField]
    // private GameObject magicFill;

    [Header("Stats")]
    public int Health;
    public int Dexterity;
    public int Strength;
    public int speed;

    private int startHealth;
    // private int startMagic;

    [HideInInspector]
    public int nextTurn;

    private bool dead = false;

    //Resizing health and magic bar ---> transformers
    private Transform healthTransform;
    // private Transform magicTransform;

    private Vector2 healthScale;
    // private Vector2 magicScale;

    private float xNewHealthScale;
    // private float xNewMagicScale;

    void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        // magicTransform = magicFill.GetComponent<RectTransform>();
        // magicScale = magicFill.transform.localScale;

        startHealth = Health;
        // startMagic = Magic;
    }

    public void UpdateHealthBar()
    {
        if(Health < 1)
            {
                tag = "Dead";
                Destroy(healthFill);
                // Destroy(gameObject);
            }else
            {
                xNewHealthScale = healthScale.x  * (Health/startHealth);
                healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
            }

        Invoke("ContinueGame", 2);
    }

    // public void updateMagicFill(float cost)
    // {
    //     if (cost > 0)
    //     {
    //         xNewMagicScale = magicScale.x * (magic/startMagic);
    //         magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
    //         magic -= cost;
    //     }
    // }

    public bool GetDead()
    {
        return gameObject.tag == "Dead";
    }

    void ContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }

    public void CalculateNextTurn(int currentTurn)
    {
        nextTurn = currentTurn + Mathf.CeilToInt(100f/speed);
    }

    public int CompareTo(object otherStat)
    {
        int nex = nextTurn.CompareTo(((FighterStats)otherStat).nextTurn);
        return nex;
    }

}
