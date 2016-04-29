using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log(hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Pickup")
                {
                    Vector3 pickupPosition = hitInfo.transform.position;
                    Quaternion pickupRotation = hitInfo.transform.rotation;

                    Transform children = gameObject.transform.GetChild(0);
                    foreach (Transform child in children)
                    {
                        if (child.CompareTag("Pickup"))
                        {
                            Vector3 targetPosition = child.transform.position;
                            Quaternion targetRotation = child.transform.rotation;

                            child.GetComponent<WeaponAttack>().enabled = false;
                            child.transform.parent = null;
                            child.transform.position = pickupPosition;
                            child.transform.rotation = pickupRotation;

                            hitInfo.transform.parent = children;
                            hitInfo.transform.position = targetPosition;
                            hitInfo.transform.rotation = targetRotation;
                            hitInfo.transform.gameObject.GetComponent<WeaponAttack>().enabled = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
