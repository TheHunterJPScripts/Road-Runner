using UnityEngine;
using OwnCode.DataManagement;
using UnityEngine.UI;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * activar y desactivar el raton.
 * {NOTA: En el editor al pulsar esc se
 * reactiva solo. pero en el juego compilado no pasa.}
 */

namespace OwnCode.Generals {
    public class CursorManager : MonoBehaviour {
        public bool alwaysActive;

        void Update() {
            Cursor.visible = alwaysActive ? true : GlobalData.pause;
        }
    }
}