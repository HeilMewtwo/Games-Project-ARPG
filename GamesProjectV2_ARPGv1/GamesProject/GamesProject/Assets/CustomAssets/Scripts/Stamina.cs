using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider StaminaBar;
    public float RegenRate = 20;
    public float RegenDelay = 2.0f;
    public bool ShouldRegen = true;

    // Use this for initialization
    void Start()
    {
        StaminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();
        StaminaBar.value = 100;
        StartCoroutine("Regeneration");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            StaminaBar.value -= 0.5f;
            StopCoroutine("Regeneration");
            ShouldRegen = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ShouldRegen = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ShouldRegen = false;
            StopCoroutine("Regeneration");
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ShouldRegen = true;
        }

        if (ShouldRegen)
        {
            StartCoroutine("Regeneration");
        }
    }

    public IEnumerator Regeneration()
    {
        yield return new WaitForSeconds(RegenDelay);
        StaminaBar.value += RegenRate * Time.deltaTime;
        StartCoroutine("Regeneration");
    }
}