using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pies : MonoBehaviour
{

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.gameObject.GetComponent<AudioSource>();
    }

    public void ReproducirSonido()
    {
        audioSource.Play();
    }
}
