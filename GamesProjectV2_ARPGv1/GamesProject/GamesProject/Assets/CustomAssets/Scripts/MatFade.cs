using UnityEngine;
using System.Collections;

public class MatFade : MonoBehaviour
{

    private bool fade;

    void Update()
    {
        if (fade == false)
        {
            StartCoroutine(FadeTo(0.0f, 1.0f));
        }
        if (fade == true)
        {
            StartCoroutine(FadeTo(1.0f, 1.0f));
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        fade = false;
        float alpha = transform.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<Renderer>().material.color = newColor;
            yield return null;
            StartCoroutine(FadeTo(1.0f, 1.0f));

        }
    }
}

/*[SerializeField]
private float fadePerSecond = 2.5f;

private void Update()
{
    var material = GetComponent<Renderer>().material;
    var color = material.color;

    material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
}
}*/
