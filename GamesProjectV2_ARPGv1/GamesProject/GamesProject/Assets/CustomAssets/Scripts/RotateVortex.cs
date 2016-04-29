using UnityEngine;
using System.Collections;

public class RotateVortex : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 32 * Time.deltaTime, 0);
	}
}
