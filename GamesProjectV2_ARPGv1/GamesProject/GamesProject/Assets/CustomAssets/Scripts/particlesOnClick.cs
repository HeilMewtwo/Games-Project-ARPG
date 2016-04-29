using UnityEngine;
using System.Collections;

public class particlesOnClick : MonoBehaviour {

    public GameObject swordParticles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            swordParticles.GetComponent<ParticleSystem>().Emit(1);
        }

        else {
            swordParticles.GetComponent<ParticleSystem>().Emit(0);
        }
    }
}
