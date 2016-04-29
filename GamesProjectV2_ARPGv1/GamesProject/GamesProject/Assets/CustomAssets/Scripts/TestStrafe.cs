using UnityEngine;
using System.Collections;

public class TestStrafe : MonoBehaviour
{
    public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.RotateAround(Target.transform.position, Vector3.up, Input.GetAxis("Horizontal"));
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Input.GetAxis("Vertical") * 10 * Time.deltaTime);

    }
}
