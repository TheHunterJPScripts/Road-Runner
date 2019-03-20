using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * reactivar la pausa para seguir con el nivel.
 */

namespace OwnCode.Generals {
    public class Continue : MonoBehaviour {
        public void Resume() {
            GlobalData.pause = false;
        }
    }
}