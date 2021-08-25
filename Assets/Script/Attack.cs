using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour

{
    private AudioSource audioSource;

    void Start ()
    {
        audioSource = transform.gameObject.GetComponent<AudioSource>();
    }

    public void ReproducirSonido()
    {
        audioSource.Play();
    }
}