using UnityEngine;
using System.Collections;

public class ParticleExplosionAttack : MonoBehaviour
{
    public bool shoot;
    public GameObject AttackArea;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("ParticleExplosion");
	}

    void Update()
    {
        if (shoot)
        {
            gameObject.GetComponent<ParticleSystem>().Emit(1);
            AttackArea.SetActive(true);
        }
        if (!shoot)
        {
            AttackArea.transform.localScale = new Vector3(3, 3, 0);
            AttackArea.SetActive(false);
        }
    }
	
	// Update is called once per frame
	public IEnumerator ParticleExplosion ()
    {
        gameObject.GetComponent<RotateContinuous>().RotationSpeed = 0;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<RotateContinuous>().RotationSpeed = 2f;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<RotateContinuous>().RotationSpeed = 4f;
        shoot = true;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);
        shoot = false;
        GetComponent<AudioSource>().Stop();
        StartCoroutine("ParticleExplosion");
    }
}
