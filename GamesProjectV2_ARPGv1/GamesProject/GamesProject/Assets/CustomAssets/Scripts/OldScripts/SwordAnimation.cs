using UnityEngine;
using System.Collections;

public class SwordAnimation : MonoBehaviour
{
    public float _Angle;
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
            transform.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        if (Input.GetMouseButtonDown(0))
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
            transform.localRotation = Quaternion.Euler(new Vector3(phase * _Angle, 0, 0));
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        wait = true;
    }
}
