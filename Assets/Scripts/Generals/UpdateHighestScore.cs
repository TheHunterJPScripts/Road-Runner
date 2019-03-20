using UnityEngine;
using OwnCode.DataManagement;
using TMPro;
/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo se encarga de
 * actualizar la puntuacion maxima
 * en el menu principal.
 */

namespace OwnCode.Generals {
    public class UpdateHighestScore : MonoBehaviour {
        void Start() {
            GetComponent<TextMeshProUGUI>().text = GlobalData.score.ToString();
        }
    }
}