using UnityEngine;
using System.Collections;

public class CollisionAudio : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Weakpoint")
        {
            GetComponent<AudioSource>().Play();
        }
        else {
            GetComponent<AudioSource>().Stop();
        }
    }
}