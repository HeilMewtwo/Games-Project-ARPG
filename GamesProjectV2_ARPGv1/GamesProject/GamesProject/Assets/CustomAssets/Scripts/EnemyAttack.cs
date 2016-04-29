using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float Damage;
    public bool Extend;
    public float ExtendRate = 10;
    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
            
        if (Extend)
	    {
            gameObject.transform.localScale += new Vector3(0, 0, ExtendRate) * Time.deltaTime;
        }
	    if (!Extend)
	    {
            gameObject.transform.localScale -= new Vector3(0, 0, ExtendRate) * Time.deltaTime;
        }

	    if (gameObject.transform.localScale.z < 0)
	    {
	        Extend = true;
	    }
	    if (gameObject.transform.localScale.z > 30)
	    {
	        Extend = false;
	    }
	}

    void OnTriggerExit(Collider other)
    {
        Extend = true;
    }

    void OnTriggerStay(Collider other)
    {
        Extend = false;

        if (other.gameObject.tag == "Player")
        {
            Player.GetComponent<Health>().HealthValue -= Damage;
        }
        if (other.gameObject.tag == "Shield")
        {
            Player.GetComponent<Stamina>().StaminaBar.value -= Damage * 3;
        }
    }
}
