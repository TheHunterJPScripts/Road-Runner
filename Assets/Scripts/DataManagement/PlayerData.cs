/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo se encarga de
 * ofrecer una manera de guardar los
 * datos de la partida para poder 
 * guardarlo en un archivo.
 */

namespace OwnCode.DataManagement {
    [System.Serializable]
    public class PlayerData {
        public int score;
        public int coins;
        public float sound;
        public float music;
        public bool persons;
        public bool fullscreen;
        public int width;
        public int height;

        public PlayerData(GlobalData data) {
            this.score = GlobalData.score;
            this.coins = GlobalData.coins;
            this.sound = GlobalData.sound;
            this.music = GlobalData.music;
            this.persons = GlobalData.personActives;
            this.fullscreen = GlobalData.fullScreen;
            this.width = GlobalData.resolution.x;
            this.height = GlobalData.resolution.y;
        }
    }
}