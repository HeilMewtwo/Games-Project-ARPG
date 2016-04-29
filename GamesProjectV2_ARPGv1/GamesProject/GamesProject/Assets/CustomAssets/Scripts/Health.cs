using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    public Slider healthBar;
    public float HealthValue = 100;
    public GameObject DeathText;
    public float FadeSpeed = 1.5f;
    public RawImage ScreenFade;

    private bool _fadeToBlack, _fadeToClear;
    private float _lastHealthValue;
    private bool _damagedLately;

	// Use this for initialization
	void Start ()
	{
	    healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        healthBar.value = HealthValue;
	    _lastHealthValue = 100;
        DeathText = GameObject.FindGameObjectWithTag("DeathText");
	    ScreenFade = GameObject.FindGameObjectWithTag("ScreenFader").GetComponent<RawImage>();
	    _fadeToClear = true;
	}

	// Update is called once per frame
	void Update ()
	{
	    healthBar.value = HealthValue;

	    if (HealthValue <= 0)
	    {
	        StartCoroutine(Death());
	    }
	    if (HealthValue > 100)
	    {
	        HealthValue = 100;
	    }

	    CheckForDamage();
	    CheckForFade();
	}

    IEnumerator Death()
    {
        DeathText.GetComponent<Text>().text = "You Died";
        _fadeToBlack = true;
        yield return new WaitForSeconds(3);
        DeathText.GetComponent<Text>().text = " ";
        _fadeToBlack = false;
        Destroy(gameObject);
    }

    void CheckForDamage()
    {
        if (_lastHealthValue != HealthValue)
        {
            if (_lastHealthValue > HealthValue && !_damagedLately)
            {
                _damagedLately = true;
                ScreenFade.color = new Color(255, 0, 0, 0.5f);
                StartCoroutine(CheckForDamageLately());
            }

            _lastHealthValue = HealthValue;
        }
    }

    IEnumerator CheckForDamageLately()
    {
        yield return new WaitForSeconds(1);
        _damagedLately = false;
    }

    void CheckForFade()
    {
        if (_fadeToClear)
        {
            ScreenFade.color = Color.Lerp(ScreenFade.color, Color.clear, FadeSpeed * Time.deltaTime);
        }
        if (_fadeToBlack)
        {
            ScreenFade.color = Color.Lerp(ScreenFade.color, Color.black, FadeSpeed * Time.deltaTime);
        }
    }
}
