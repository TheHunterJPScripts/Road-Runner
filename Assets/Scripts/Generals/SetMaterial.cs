using UnityEngine;

/*
 *author: Mikel Jauregui
 * last update: 24/01/2019
 * 
 * description: Este codigo se encarga de
 * cambiar el material de un objeto.
 */

namespace OwnCode.Generals {
    public class SetMaterial : MonoBehaviour {
        // Objeto que queremos cambiar.
        public GameObject objectToChange;

        public void ChangeMaterial(Material material) {
            // Cambiamos el material.
            objectToChange.GetComponent<Renderer>().material = material;
        }
    }
}