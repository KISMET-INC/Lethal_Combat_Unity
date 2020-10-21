using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private bool magicAction;

    [SerializeField]
    private float magicCost;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private float minActionMultiplier;

    [SerializeField]
    private float maxActionMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;

    public void Action(GameObject target)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = target.GetComponent<FighterStats>();

        if(attackerStats.magic >= magicCost)
        {
            float multiplier = Random.Range(minActionMultiplier, maxActionMultiplier);

            damage = multiplier * attackerStats.action;

            if (magicAction)
            {
                damage = multiplier * attackerStats.range; //range actions are magic
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            owner.GetComponent<Animator>().Play(animationName);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.updateMagicFill(magicCost);
        } else
        {
            // Invoke("ContinueGame", 2);
        }
    }
    // void ContinueGame(){
    // GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    // }
}
