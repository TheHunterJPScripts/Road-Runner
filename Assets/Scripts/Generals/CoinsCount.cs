using UnityEngine;
using TMPro;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * exponer la puntuacion en el menu de muerte.
 */

namespace OwnCode.Generals {

    public class CoinsCount : MonoBehaviour {

        public TextMeshProUGUI score;
        public TextMeshProUGUI scoreShadow;
        public TextMeshProUGUI coins;
        public TextMeshProUGUI coinsShadow;
        public TextMeshProUGUI total;
        public TextMeshProUGUI totalShadow;

        public GameObject highestScore;
        public Score scoreData;

        // Update is called once per frame
        void Update() {
            string s = scoreData.GetDistance().ToString();
            string c = "+ " + scoreData.GetCoins().ToString();
            string t = scoreData.GetScore().ToString();
            score.text = s;
            scoreShadow.text = s;
            coins.text = c;
            coinsShadow.text = c;
            total.text = t;
            totalShadow.text = t;
            highestScore.SetActive(GlobalData.score < scoreData.GetScore());
        }
    }
}