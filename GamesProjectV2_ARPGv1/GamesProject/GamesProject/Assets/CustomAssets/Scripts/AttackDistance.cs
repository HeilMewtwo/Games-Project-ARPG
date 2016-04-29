using UnityEngine;
using System.Collections;

public class AttackDistance : MonoBehaviour {

    public GameObject Player;
    public float PlayerFloat;
    public GameObject AttackArea;

    private bool _inRange;

	// Use this for initialization
	void Start ()
	{
    }
	
	// Update is called once per frame
	void Update ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerFloat = Vector3.Distance(Player.transform.position, transform.position);
	    CheckForPlayer();
    }

    void CheckForPlayer()
    {
        if (PlayerFloat <= 30 && !_inRange)
        {
            _inRange = true;
            gameObject.GetComponent<ParticleExplosionAttack>().enabled = true;
            gameObject.GetComponent<RotateContinuous>().enabled = true;
            AttackArea.GetComponent<EnemyAttack>().Extend = true;
        }
        if (PlayerFloat > 30 && _inRange)
        {
            _inRange = false;
            gameObject.GetComponent<ParticleExplosionAttack>().enabled = false;
            gameObject.GetComponent<RotateContinuous>().enabled = false;
            AttackArea.GetComponent<EnemyAttack>().Extend = false;
        }
    }
}
