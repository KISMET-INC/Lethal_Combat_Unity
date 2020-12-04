using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FighterStats : MonoBehaviour
{
    [SerializeField]
    private GameObject healthFill;

    // private Animator animator;

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
            GetComponent<Animator>().Play("Die");
            tag = "Dead";
            Destroy(healthFill);
            Invoke("Deactivate", 1);
            Debug.Log("DEATH");
        }else
        {
            xNewHealthScale = healthScale.x  * ((float)Health/(float)startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
