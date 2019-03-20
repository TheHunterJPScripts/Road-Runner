using System.Collections.Generic;
using UnityEngine;

/*
 *author: Mikel Jauregui
 * last update: 24/01/2019
 * 
 * description: Este codigo se encarga de
 * generar la carretera.
 */

public class GenerateRoad : MonoBehaviour {
    // Lista de las carreteras en la escena.
    private Queue<GameObject> road = new Queue<GameObject>();
    public GameObject roadPrefab;
    // Dimensiones en x de la carretera.
    private float roadSize;
    // Cantidad de carreteras por delante.
    public float roadForward;
    public GameObject player;

    private int actualTile = 0;

    private void Start() {
        roadSize = roadPrefab.GetComponentInChildren<MeshRenderer>().bounds.size.x;

        // Generamos la carretera para que el 
        // personaje no salga flotando.
        for (int i = -1; i < roadForward; i++) {
            GameObject new_road = Instantiate(roadPrefab);
            new_road.transform.position = new Vector3(i * roadSize, 0, 0);
            new_road.transform.parent = this.transform;
            road.Enqueue(new_road);
        }
    }
    private void Update() {
        Vector3 position = player.transform.position;
        // Calculamos en que tile esta.
        int r = Mathf.FloorToInt(( position.x + roadSize / 2 ) / roadSize);
        // Si esta en un nuevo tile. borra el de
        // detras y genera uno delante.
        if (r > actualTile) {
            for (int i = 0; i < r - actualTile; i++) {
                GameObject new_road = Instantiate(roadPrefab);
                new_road.transform.position = new Vector3(( actualTile + roadForward ) * roadSize, 0, 0);
                new_road.transform.parent = this.transform;
                road.Enqueue(new_road);
                GameObject.Destroy(road.Dequeue());
            }
            actualTile = r;
        }
    }
}
