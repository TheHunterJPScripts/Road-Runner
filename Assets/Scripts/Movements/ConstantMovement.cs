using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 07/02/2019
 * 
 * description: Este codigo se encarga de
 * hacer que un objeto se mueva.
 */

namespace OwnCode.Movement {
    [RequireComponent(typeof(Transform))]
    public class ConstantMovement : MonoBehaviour {
        // Direccion.
        public Way way = Way.Forward;
        // Velocidad del objeto.
        public float speed = 10;
        // Si queremos que la velocidad
        // varie con el tiempo.
        public bool constant = true;
        // Cantidad de velocidad que
        // aumentara.
        public float SpeedIncrease = 0.01f;
        // Limite de velocidad.
        public float speedLimit = 50f;
        // Veriable que determina si otras
        // classes pueden moficar la velocidad.
        public bool letModify = true;

        [Space()]

        // Centro del cuadrado que detecta
        // el vehiculo de delante.
        public Vector3 positionDetection;
        // Dimensiones del cuadrado que detecta
        // el vehiculo de delante.
        public Vector3 detectionSize;

        public void SetSpeed(float speed) {
            this.speed = speed;
        }
        public float GetSpeed() {
            return speed;
        }
        public bool GetModify() {
            return letModify;
        }

        void Update() {
            if (!GlobalData.pause) {

                // Lista de objetos deteectados por delante.
                Collider[] col = Physics.OverlapBox(transform.position + positionDetection, detectionSize);
                foreach (var item in col) {
                    // Si es un coche.
                    if (item.tag == "Enemy") {
                        // Le aplicamos a este objeto la velocidad
                        // del de delante para que no lo atraviese.
                        ConstantMovement mov = item.GetComponent<ConstantMovement>();
                        if (mov != null) {
                            speed = item.GetComponent<ConstantMovement>().speed;
                            break;
                        }
                    }
                }
                // Si la velocidad intenta superar el limite.
                if (speed < speedLimit && !constant)
                    speed += SpeedIncrease;

                // Aplicamos el cambio de posicion.
                transform.Translate(Vector3.right * (int)way * speed * Time.deltaTime);
            }
        }
        private void OnDrawGizmosSelected() {
            // Enseñamos la hitbox de
            // deteccion del veehiculo de delante.
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + positionDetection, detectionSize / 2);
        }
    }
    public enum Way { Forward = 1, BackWard = -1 }
}