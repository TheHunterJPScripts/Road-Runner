using UnityEngine;

/*
 *author: Mikel Jauregui
 * last update: 24/01/2019
 * 
 * description: Este codigo se encarga de
 * hacer que un objeto siga a otro.
 */

namespace OwnCode.Generals {
    [RequireComponent(typeof(Transform))]
    public class Follow : MonoBehaviour {
        // Objeto a seguir;
        public Transform follow;

        float x;
        float y;
        float z;

        void Start() {
            // Sanity Check.
            if(follow == null) {
                throw new System.Exception(transform.name + "/CameraFollow : variable follow no asignada.");
            }

            // Guardamos la posicion relativa al objeto
            // a seguir.
            x = transform.position.x - follow.position.x;
            y = transform.position.y;
            z = transform.position.z;
        }

        void Update() {
            // Aplicamos la posicion relativa de x
            // a la posicion del objeto a seguir
            // para obtener la posicion deseada.
            float n_x = follow.position.x + x;
            transform.position = new Vector3(n_x, y, z);
        }
    }
}