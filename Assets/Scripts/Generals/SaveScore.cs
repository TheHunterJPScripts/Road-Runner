using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * guardar la puntuacion del nivel.
 */

namespace OwnCode.Generals {
    public class SaveScore : MonoBehaviour {

        public Score score;

        public void SaveIfNecessary() {
            // Hacemos que el tiempo vuelva a fluir.
            GlobalData.pause = false;

            // Si la puntuacion es un nuevo record guardarla.
            int current_score = score.GetScore();
            if (current_score > GlobalData.score) {
                GlobalData.score = current_score;
            }
        }
    }
}