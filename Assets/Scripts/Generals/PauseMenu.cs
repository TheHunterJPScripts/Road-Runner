using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * activar el menu de pausa y de contener
 * todas la funciones que necesita.
 */

namespace OwnCode.Generals {
    public class PauseMenu : MonoBehaviour {

        public GameObject menu;
        public FailCondition fail;

        // Update is called once per frame
        void Update() {
            if (fail.dead)
                return;

            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (GlobalData.pause) {
                    // Muestra el menu de muerte.
                    menu.SetActive(false);

                    // Paramos el tiempos del juego.
                    GlobalData.pause = false;
                } else {
                    // Muestra el menu de muerte.
                    menu.SetActive(true);
                    menu.GetComponent<Animator>().Play("Animate");

                    // Paramos el tiempos del juego.
                    GlobalData.pause = true;
                }
            }
        }
        public void QuitingLevel() {
            // Hacemos que el tiempo vuelva a fluir.
            GlobalData.pause = false;
        }
    }
}