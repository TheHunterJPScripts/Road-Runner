using UnityEngine;
using System.IO;

/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo se encarga de
 * guardar, cargar y contener las puntuaciones
 * que tendran que mantenerse de una partida a otra.
 */

namespace OwnCode.DataManagement {
    public class GlobalData : MonoBehaviour {
        private static bool created = false;

        private string path;

        public static System.Random rnd;
        public static bool pause;
        public static int score;
        public static int coins;
        public static bool personActives = true;
        public static Vector2Int resolution;
        public static bool fullScreen;
        // De 0 a 1.
        public static float sound;
        public static float music;



        private void Awake() {
            if (!created) {
                // Create an instance of the Globals.
                DontDestroyOnLoad(transform.gameObject);
                path = Application.persistentDataPath + "/data.er";
                rnd = new System.Random();
                personActives = true;
                sound = 1.0f;
                music = 1.0f;
                resolution = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
                if (File.Exists(path)) {
                    Load();
                }
                created = true;
            } else
                // Make sure there is only one instance.
                Destroy(this.gameObject);
        }

        private void OnApplicationQuit() {
            Save();
        }

        public void Save() {
            LoadSaveSystem.SavePlayerData(path, this.GetComponent<GlobalData>());
        }
        public void Load() {
            PlayerData data = LoadSaveSystem.LoadPlayerData(path);
            score = data.score;
            coins = data.coins;
            sound = data.sound;
            music = data.music;
            personActives = data.persons;
            fullScreen = data.fullscreen;
            resolution = new Vector2Int(data.width, data.height);
        }
        public static void Change() {
            rnd = new System.Random();
        }
    }
}