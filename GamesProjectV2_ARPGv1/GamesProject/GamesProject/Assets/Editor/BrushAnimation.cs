using UnityEngine;
using System.Collections;

public class BrushAnimation : MonoBehaviour {

	private Vector3 pos1;
	private Vector3 pos2;
	private Quaternion rot1; 
	private Quaternion rot2; 
	private GameObject BeginPos; 
	private GameObject EndPos;
	
	public float moveSpeed = 0.2f;
	public float animSpeed = 0.2f;
	
	void Start ()
	{
		BeginPos = GameObject.Find ("SwordParent"); 
		EndPos = GameObject.Find ("SwordAnimationPosition"); 
	}
	
	void Update ()
	{
		pos1 = BeginPos.transform.position; 
		pos2 = EndPos.transform.position;
		rot1 = BeginPos.transform.rotation; 
		rot2 = EndPos.transform.rotation; 
		
		if (Input.GetMouseButton(0)) {
			transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin (moveSpeed * Time.time) + 1.0f) / 2.0f);
			transform.rotation = Quaternion.Lerp (rot1, rot2, (Mathf.Sin (animSpeed * Time.time) + 1.0f) / 2.0f); 
		}
		
		if (Input.GetMouseButtonUp (0)) {
			transform.position = pos1;
			transform.rotation = rot1; 
		}
	}
}
