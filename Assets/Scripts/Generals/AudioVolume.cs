using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * regular el volumen del objeto acorde
 * con el resto (para poder bajar o subir 
 * el volumen desde el menu). 
 */

namespace OwnCode.Generals {

    [RequireComponent(typeof(AudioSource))]
    public class AudioVolume : MonoBehaviour {
        public enum SoundType { Music, Sound };

        [Tooltip("Que volumen tendra que tener en cuenta.")]
        public SoundType type;

        AudioSource audioSource;
        float volume;
       
        void Start() {
            audioSource = GetComponent<AudioSource>();
            volume = audioSource.volume;
        }

        void Update() {
            switch (type) {
                case SoundType.Music:
                    audioSource.volume = volume * GlobalData.music;
                    break;
                case SoundType.Sound:
                    audioSource.volume = volume * GlobalData.sound;
                    break;
                default:
                    break;
            }
        }
    }
}