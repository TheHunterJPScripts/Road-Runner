using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 07/02/2019
 * 
 * description: Este codigo se encarga de
 * detectar si las condiciones de fracaso
 * se cumplen, y contiene las funciones
 * con lo que hay que hacer a continuacion.
 */

namespace OwnCode.Generals {
    public class FailCondition : MonoBehaviour {
        // Menu que se mostrata al morir.
        public GameObject menu;
        public AudioSource deathAudio;
        // Sirve para que otros objetos
        // tambien sepan cuando estas muerto.
        public bool dead;
        private void OnTriggerEnter(Collider other) {
            // Si no esta invulnerable y choca
            // con un enemigo.
            if (other.transform.tag == "Enemy") {
                deathAudio.Play();
                dead = true;
                // Muestra el menu de muerte.
                menu.SetActive(true);

                menu.GetComponent<Animator>().Play("Animate");

                // Paramos el tiempos del juego.
                GlobalData.pause = true;
            }
        }
    }
}