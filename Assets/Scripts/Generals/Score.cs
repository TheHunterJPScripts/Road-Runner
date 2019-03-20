using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 *author: Mikel Jauregui
 * last update: 24/01/2019
 * 
 * description: Este codigo se encarga de
 * la puntuacion y de plasmarla en pantalla.
 */

namespace OwnCode.Generals {
    public class Score : MonoBehaviour {
        // Cuanto se añade por segundo.
        public float scorePerSecond = 1;
        // Puntuacion.
        private float score;
        // Texto donde se muestra.
        private Text text;
        private int distance;
        private int coins;
        public TextMeshPro distanceDisplay;
        public TextMeshPro coinsDisplay;

        private void Start() {
            text = GetComponent<Text>();
        }

        void Update() {
            distance = (int)( transform.position.x * scorePerSecond);
            if(distance < 10000) {
                distanceDisplay.text = distance.ToString() + " m";
            } else {
                distanceDisplay.text = ((int)((float)distance / 1000.0f)).ToString() + " km";
            }
            coinsDisplay.text = "+" + coins.ToString();
        }
        public int GetScore() {
            return distance + coins;
        }
        public int GetDistance() {
            return distance;
        }
        public int GetCoins() {
            return coins;
        }
        public void AddScore(int add) {
            coins += add;
        }
    }
}