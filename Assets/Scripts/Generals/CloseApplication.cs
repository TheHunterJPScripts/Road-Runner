using UnityEngine;

/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo se encarga de
 * cerrar la aplicacion.
 */

namespace OwnCode.Generals {
    public class CloseApplication : MonoBehaviour {
        public void Quit() {
            Application.Quit();
        }
    }
}