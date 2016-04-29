using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject ButtonContainer;

    private bool _isMenuUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        MenuSwap();
	    }

        ButtonContainer.SetActive(_isMenuUp);
	}

    public void MenuSwap()
    {
        _isMenuUp = !_isMenuUp;
    }
}
