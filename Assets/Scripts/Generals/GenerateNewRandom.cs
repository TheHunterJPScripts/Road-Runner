using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 31/01/2019
 * 
 * description: Este codigo se encarga de
 * de permitirnos acceder a la funcion de
 * cambiar el generador de numeros aleatorios
 * desde la UI.
 */

public class GenerateNewRandom : MonoBehaviour
{
    public void GenerateNew() {
        // TODO: Que se pueda pasar una custom seed.
        GlobalData.Change();
    }
}
