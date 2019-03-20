using UnityEngine;
using OwnCode.Generals;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo se encarga de
 * hacer que los edificios aparezcan.
 */

namespace OwnCode.Spawners {
    public class BuildingSpawner : MonoBehaviour {
        public Transform[] positions;
        public GameObject[] prefabs;

        private void Start() {
            // Sanity Check
            if (positions.Length <= 0) {
                Debug.LogWarning("Lista de posiciones en [BuildingSpawner] esta vacia");
                return;
            }
            // Sanity Check
            if (prefabs.Length <= 0) {
                Debug.LogWarning("Lista de prefabs en [BuildingSpawner] esta vacia");
                return;
            }

            // Para cada spawner.
            for (int i = 0; i < positions.Length; i++) {
                // Escogemos un indice aleatorio dentro del array.
                int j =  GlobalData.rnd.Next(0, prefabs.Length);

                // Instanciamos ese modelo
                GameObject obj = Instantiate(prefabs[j], positions[i]);
                obj.transform.position = positions[i].position;

                // Escogemos aleatoriamente si el modelo recibira
                // un Flip.
                int r = GlobalData.rnd.Next(0, 2);
                if (r == 1) {
                    Vector3 s = obj.transform.localScale;
                    s.x *= -1;
                    obj.transform.localScale = s;
                }
            }
        }
    }
}