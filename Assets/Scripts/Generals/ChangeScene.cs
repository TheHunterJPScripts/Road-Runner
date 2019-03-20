using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo se encarga de
 * proporcionar una funcion que cambia
 * la escena.
 */

namespace OwnCode.Generals {
    public class ChangeScene : MonoBehaviour {
        // Escena a la que queremos cambiar.
        public int sceneIndex;

        public void Change() {
            // Cambiamos la escena.
            SceneManager.LoadScene(sceneIndex);
        }
    }
}