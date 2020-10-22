using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterStats : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject healthFill;

    [Header("Stats")]
    public int Health;
    public int Dexterity;
    public int Strength;
    public int speed;

    private int startHealth;

    [HideInInspector]
    public int nextTurn;

    private bool dead = false;

    //Resizing health and magic bar ---> transformers
    private Transform healthTransform;

    private Vector2 healthScale;

    private float xNewHealthScale;

    void Awake()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        startHealth = Health;
    }

    public void UpdateHealthBar()
    {
        if(Health < 1)
        {
            tag = "Dead";
            Destroy(healthFill);
            gameObject.SetActive(false);
            Debug.Log("DEATH");
        }else
        {
            xNewHealthScale = healthScale.x  * ((float)Health/(float)startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
    }

    public bool GetDead()
    {
        return gameObject.tag == "Dead";
    }
}
