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

    [SerializeField]
    private GameObject magicFill;

    [Header("Stats")]
    public float health;
    public float magic;
    public float action; //strength of action
    public float defense; //strength of defense
    public float range; //strength of range action
    public float speed; //move order, extra turns
    // public float experience;

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextTurn;

    private bool dead = false;

    //Resizing health and magic bar ---> transformers
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private GameObject GameControllerObj;

    void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = magicFill.GetComponent<RectTransform>();
        magicScale = magicFill.transform.localScale;

        startHealth = health;
        startMagic = magic;

        GameControllerObj = GameObject.Find("GameControllerObject");
    }

    public void ReceiveDamage(float damage)
    {
        animator.Play("damage");
        health -= damage;

        //damage text

        if(health < 1)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        } else if (damage > 0)
        {
            xNewHealthScale = healthScale.x  * (health/startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }

        GameControllerObj.GetComponent<GameController>().battleText.gameObject.SetActive(true);
        GameControllerObj.GetComponent<GameController>().battleText.text = damage.ToString();

        Invoke("ContinueGame", 2);
    }

    public void updateMagicFill(float cost)
    {
        if (cost > 0)
        {
            xNewMagicScale = magicScale.x * (magic/startMagic);
            magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
            magic -= cost;
        }
    }

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
