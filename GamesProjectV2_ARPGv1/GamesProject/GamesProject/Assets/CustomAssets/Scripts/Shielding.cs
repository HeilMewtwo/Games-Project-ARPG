using UnityEngine;
using System.Collections;

public class Shielding : MonoBehaviour
{
    public GameObject ShieldArea;
    public GameObject Player;

    private GameObject _instantiatedShield;

	// Use this for initialization
	void Start ()
    {
	    Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector3 targetPosition = new Vector3(0, 0, 2);
            Vector3 targetRotation = new Vector3(0, Player.transform.localEulerAngles.y, 0);
            _instantiatedShield = Instantiate(ShieldArea, Vector3.zero, Quaternion.Euler(targetRotation)) as GameObject;
            _instantiatedShield.transform.parent = Player.transform;
            _instantiatedShield.transform.localPosition = targetPosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
	    {
            Destroy(_instantiatedShield);
	    }
	}
}
