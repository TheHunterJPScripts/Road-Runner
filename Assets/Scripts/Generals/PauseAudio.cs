using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * silenciar el sonido de este objeto
 * al pausar el juego.
 */

namespace OwnCode.Generals {

    [RequireComponent(typeof(AudioSource))]
    public class PauseAudio : MonoBehaviour {

        AudioSource audioSource;

        private void Start() {
            audioSource = GetComponent<AudioSource>();
        }
        void Update() {
            audioSource.mute = GlobalData.pause;
        }
    }
}