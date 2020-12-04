using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject hero;
      private enum State{
        Standing,
        Charging,
        Returning,
    }
    private State state;

    [SerializeField]
    private GameObject AxePreFab;

    [SerializeField]
    private GameObject BowPreFab;

    [SerializeField]
    private GameObject SwordPreFab;

    public void SelectWeapon(string btn)
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        GameObject target = hero;
        if (tag == "Hero")
        {
            target = enemy;

        }
        if (btn.CompareTo("axe") == 0)
        {
            state = State.Charging;
            AxePreFab.GetComponent<WeaponScript>().Damage(target);
        } else if (btn.CompareTo("bow") == 0)
        {
            BowPreFab.GetComponent<WeaponScript>().Damage(target);
        } else if (btn.CompareTo("sword") == 0)
        {
            state = State.Charging;
            SwordPreFab.GetComponent<WeaponScript>().Damage(target);
        }
    }


    private void Awake(){
        state = State.Standing;
    }
    public void Update(){
        

        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        GameObject target = hero;
        if (tag == "Hero")
        {
            target = enemy;

        }

        if(hero == null || enemy == null){
        
        } else {
            float speed = 10f;


            switch(state){
                case State.Standing:
                    break;

                case State.Charging:        
                    Vector3 chargeVect = target.name == "Kim" ? new Vector3(1.5f,transform.position.y,transform.position.z) : new Vector3(-1.5f,transform.position.y,transform.position.z);

                    this.transform.position  += (chargeVect - transform.position)*speed*Time.deltaTime;

                    if(Vector3.Distance(chargeVect, this.transform.position) < 2f){
                        Invoke("returning",1f);

                    }
                    break;

                case State.Returning:   
                Vector3 retVect = target.name == "Kim" ? new Vector3(-3.5f,transform.position.y,transform.position.z) : new Vector3(3.2f,transform.position.y,transform.position.z);

                Debug.Log(transform.position);
                this.transform.position  += (retVect - transform.position)*speed*Time.deltaTime;
                if(Vector3.Distance(retVect, this.transform.position) < 1f){
                    state = State.Standing;  
                }
                break;
            }
        }

    }

    public void returning(){
        Debug.Log("returning");
        state = State.Returning;
    }
}
