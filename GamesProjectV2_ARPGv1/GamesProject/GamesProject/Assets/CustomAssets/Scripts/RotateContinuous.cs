using UnityEngine;
using System.Collections;

public class RotateContinuous : MonoBehaviour {

    public float RotationSpeed;
    public Transform Target;

    private Quaternion _lookRotation;
    private Vector3 _direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// rotates object continuously on the X axis every 10 seconds
	void Update () {
        /* transform.Rotate(0, 36 * Time.deltaTime, 0);*/
	    Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _direction = (Target.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
	}
}
