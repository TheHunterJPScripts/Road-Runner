using UnityEngine;
using UnityEngine.UI;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * actualizar la informacion en el menu de
 * opciones.
 */

namespace OwnCode.Generals {
    public class SetOptionMenu : MonoBehaviour {
        public Toggle persons;
        public Slider sound;
        public Slider music;
        public Toggle fullscreen;

        private void OnEnable() {
            persons.isOn = GlobalData.personActives;
            sound.value = GlobalData.sound;
            music.value = GlobalData.music;
            fullscreen.isOn = GlobalData.fullScreen;
        }

        private void Update() {
            GlobalData.personActives = persons.isOn;
            GlobalData.sound = sound.value;
            GlobalData.music = music.value;
            GlobalData.fullScreen = fullscreen.isOn;
            Screen.fullScreen = GlobalData.fullScreen;
        }
    }
}