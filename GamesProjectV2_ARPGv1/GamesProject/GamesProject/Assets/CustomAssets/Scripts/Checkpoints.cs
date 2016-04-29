using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public float RegenRate = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().HealthValue += RegenRate * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("Player X Position", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("Player Y Position", 1.8F);
            PlayerPrefs.SetFloat("Player Z Position", gameObject.transform.position.z);
        }
    }
}
