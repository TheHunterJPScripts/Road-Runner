using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * las resoluciones diisponibles.
 */


namespace OwnCode.Generals {

    [RequireComponent(typeof(TMP_Dropdown))]
    public class ResolutionCode : MonoBehaviour {

        Resolution[] resolutions;
        // Start is called before the first frame update
        void Start() {
            resolutions = Screen.resolutions;
            TMP_Dropdown dropd = GetComponent<TMP_Dropdown>();
            dropd.ClearOptions();
            List<string> options = new List<string>();
            int curren_resolution_index = 0;
            for (int i = 0; i < resolutions.Length; i++) {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].width == GlobalData.resolution.x && resolutions[i].height == GlobalData.resolution.y) {
                    curren_resolution_index = i;
                }
            }
            dropd.AddOptions(options);
            dropd.value = curren_resolution_index;
            dropd.RefreshShownValue();
        }
        public void SetResolution(int resolutionIndex) {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            GlobalData.resolution.x = resolution.width;
            GlobalData.resolution.y = resolution.height;
        }
    }
}