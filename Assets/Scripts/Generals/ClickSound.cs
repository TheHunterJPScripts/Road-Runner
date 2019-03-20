using UnityEngine;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * activar el sonido de este objeto cada vez
 * que se hace click con el raton.
 */

[RequireComponent(typeof(AudioSource))]
public class ClickSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            audioSource.Play();
        }
    }
}
