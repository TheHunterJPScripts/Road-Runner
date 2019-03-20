using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * pausar/reiniciar el tiempo si se llama.
 */

namespace OwnCode.Generals {
    public class PauseButton : MonoBehaviour {
        public void Pause() {
            GlobalData.pause = !GlobalData.pause;
        }
    }
}