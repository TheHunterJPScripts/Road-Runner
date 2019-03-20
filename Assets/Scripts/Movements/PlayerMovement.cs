using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 24/01/2019
 * 
 * description: Este codigo se encarga del
 * movimiento lateral del personaje.
 */

namespace OwnCode.Movement {
    public class PlayerMovement : MonoBehaviour {
        // Objeto que se modificara.
        public Transform car;
        // Velocidad de movimiento.
        public float speed;
        // Maxima distancia a la que
        // se puede alejar de 0.
        public float maxSideDistance;

        // Update is called once per frame
        void Update() {
            if (!GlobalData.pause) {
                // Input.
                float axis = Input.GetAxis("Horizontal");
                // Si al aplicarle la velocidad no se sale de su limite.
                if (Mathf.Abs(transform.position.z + -axis * speed * Time.deltaTime) < maxSideDistance) {
                    // Si esta muy cerca de los bordes.
                    if (( transform.position.z > maxSideDistance - .2f && -axis > 0 ) || ( transform.position.z < -maxSideDistance + .2f && -axis < 0 )) {
                        // Enderezamos.
                        car.rotation = Quaternion.RotateTowards(car.rotation, Quaternion.identity, 2.5f);
                    } else {

                        // Rotamos segun los inputs.
                        Vector3 t = transform.position;
                        t.z = transform.position.z + -axis * speed * Time.deltaTime;
                        transform.position = t;

                        Vector3 direction = new Vector3(axis, 0, 1);
                        car.rotation = Quaternion.LookRotation(direction, Vector3.up);
                    }
                } else {
                    // Enderezamos.
                    car.rotation = Quaternion.RotateTowards(car.rotation, Quaternion.identity, 2.5f);
                }
            }
        }

        private void OnDrawGizmosSelected() {
            float axis = -Input.GetAxis("Horizontal");

            // Direccion en la que se mueve.
            Vector3 direction = new Vector3();
            direction.x = 1;
            direction.z = axis;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(car.position, car.position + direction * 10);

            // Espacio por el que puede moverse.
            Vector3 center = transform.position;
            center.z = 0;
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(center, new Vector3(3, 3, maxSideDistance * 2));
        }
    }
}