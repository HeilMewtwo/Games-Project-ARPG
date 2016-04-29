using UnityEngine;
using System.Collections;

public class ShieldAnimation : MonoBehaviour
{
    public float _Period;
    private float _Time;
    public bool isSwinging, wait;
    public float speed = 0.1f;
    public float phase;

    // Update is called once per frame
    void Update()
    {
        if (phase < 0.1 && wait)
        {
            isSwinging = false;
            transform.position = new Vector3(4, 0f, 4f);
        }

        if (Input.GetMouseButtonDown(1))
        {
            isSwinging = true;
            wait = false;
            phase = 0;
            StartCoroutine("Delay");
        }
        if (isSwinging)
        {
            _Time = _Time + Time.deltaTime * speed;
            phase = Mathf.Abs(Mathf.Sin(_Time / _Period));
            transform.position = new Vector3(0, 0, 4f);
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        wait = true;
    }
}