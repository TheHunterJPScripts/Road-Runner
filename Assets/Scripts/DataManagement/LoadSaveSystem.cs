using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo contiene las
 * funciones necesarias para guardar y cargar
 * informacion de archiivos de guardado.
 */

namespace OwnCode.DataManagement {
    public static class LoadSaveSystem {
        public static void SavePlayerData(string path, GlobalData data) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData player = new PlayerData(data);
            formatter.Serialize(stream, player);
            stream.Close();
        }

        public static PlayerData LoadPlayerData(string path) {
            if (File.Exists(path)) {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData playerData = (PlayerData)formatter.Deserialize(stream);
                stream.Close();

                return playerData;
            } else {
                Debug.LogError("File not found on load.");
                return null;
            }
        }
    }
}