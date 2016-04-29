using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerPrefab;

	// Use this for initialization
	void Start ()
    {
	    if (PlayerPrefs.GetInt("Load") == 0)
	    {
            PlayerPrefs.SetFloat("Player X Position", 0.0F);
	        PlayerPrefs.SetFloat("Player Y Position", 1.8F);
	        PlayerPrefs.SetFloat("Player Z Position", 0.0F);
	    }
    }
	
	// Update is called once per frame
	void Update ()
    { 
        Player = GameObject.FindGameObjectWithTag("Player");

	    if (Player == null)
	    {
	        Vector3 targetPosition = new Vector3(PlayerPrefs.GetFloat("Player X Position"), PlayerPrefs.GetFloat("Player Y Position"), PlayerPrefs.GetFloat("Player Z Position"));
	        Instantiate(PlayerPrefab, targetPosition, Quaternion.Euler(Vector3.zero));
	    }
	}
}
