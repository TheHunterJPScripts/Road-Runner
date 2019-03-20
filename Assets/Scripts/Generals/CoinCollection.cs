using UnityEngine;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * verificar si se ha colisionado con una
 * moneda y hacer las acciones pertinentes
 * (Aparicion de las particulas y sumar
 * el valor a la puntuacion).
 */

namespace OwnCode.Generals {

    [RequireComponent(typeof(BoxCollider))]
    public class CoinCollection : MonoBehaviour {

        public Score score;
        public GameObject particles;
        public int coinValue;

        private void OnTriggerEnter(Collider other) {
            if (other.transform.tag == "Coin") {
                score.AddScore(coinValue);
                if (particles != null) {
                    GameObject part = Instantiate(particles);
                    part.transform.position = other.transform.position + Vector3.up * 0.45f;
                    part.transform.parent = transform;
                }
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}