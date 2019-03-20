using UnityEngine;
using OwnCode.Movement;
using OwnCode.Generals;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 07/02/2019
 * 
 * description: Este codigo se encarga de
 * instanciar objetos en la escena.
 */

namespace OwnCode.Spawners {
    public class Spawner : MonoBehaviour {

        // TODO: Pulir y comentar este codigo.

        [System.Serializable]
        public struct Prefab {
            public bool randomColor;
            [Range(0, 1)]
            public float spawnPercent;
            public GameObject prefab;
        }

        public Transform[] spawnerPos;
        public Color gizmoSpawnerColor;
        public Transform[] dispawnerPos;
        public Color gizmoDispawnerColor;
        public Prefab[] prefab;
        public float prefabMinSpeed;
        public ConstantMovement car;
        private float prefabMaxSpeed;
        public bool allowDiactivation;

        private float minAmount = 0;

        private float lastCheckedTime;
        public float timeBetweenSpawns;
        public float minTime;
        public float timeDecrease;
        int prev = 0;

        void Update() {
            GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");
            foreach (var person in persons) {
                person.transform.GetChild(0).gameObject.SetActive(GlobalData.personActives);
            }
            if (!GlobalData.pause) {

                if (!allowDiactivation || ( allowDiactivation && GlobalData.personActives )) {
                    if (Time.time > lastCheckedTime + timeBetweenSpawns) {
                        if (minTime < timeBetweenSpawns - timeDecrease)
                            timeBetweenSpawns -= timeDecrease;
                        if (minAmount + timeDecrease < spawnerPos.Length - 1)
                            minAmount += timeDecrease;

                        int amount = 0;
                        int skip = 0;
                        int summon = 0;
                        if (prev < 2) {
                            int min = Mathf.FloorToInt(minAmount) > 2 ? Mathf.FloorToInt(minAmount) : 2;
                            amount = GlobalData.rnd.Next(min, spawnerPos.Length);
                        } else if (prev == spawnerPos.Length - 1) {
                            amount = GlobalData.rnd.Next(Mathf.FloorToInt(minAmount), spawnerPos.Length - 1);
                        } else {
                            amount = GlobalData.rnd.Next(Mathf.FloorToInt(minAmount), spawnerPos.Length);
                        }

                        for (int i = 0; i < spawnerPos.Length; i++) {
                            bool spawn = false;
                            if (summon == amount) {
                                // Skip
                                skip++;
                            } else if (amount + skip == spawnerPos.Length) {
                                // Spawn.
                                spawn = true;
                                summon++;
                            } else {
                                // Random.
                                int choise = GlobalData.rnd.Next(0, 2);
                                if (choise == 0) {
                                    skip++;
                                } else if (choise == 1) {
                                    spawn = true;
                                    summon++;
                                }
                            }
                            if (spawn) {
                                float percent = (float)GlobalData.rnd.NextDouble();
                                foreach (var item in prefab) {
                                    if (item.spawnPercent > percent) {
                                        GameObject obj = Instantiate(item.prefab);
                                        obj.transform.position = spawnerPos[i].position;
                                        if (item.randomColor) {
                                            Material material = new Material(Shader.Find("Shader Graphs/LandCurvature"));
                                            material.SetFloat("Vector1_6DBD6DBE", 0.0007f);
                                            Color color = new Color();
                                            color.r = (float)GlobalData.rnd.NextDouble();
                                            color.b = (float)GlobalData.rnd.NextDouble();
                                            color.g = (float)GlobalData.rnd.NextDouble();
                                            material.SetColor("Color_85E369DF", color);
                                            obj.GetComponent<SetMaterial>().ChangeMaterial(material);
                                        }
                                        ConstantMovement mov = obj.GetComponent<ConstantMovement>();
                                        if (mov != null && mov.GetModify()) {
                                            prefabMaxSpeed = car.GetSpeed();
                                            float lerp = (float)GlobalData.rnd.NextDouble();
                                            mov.SetSpeed(Mathf.Lerp(10, 20, lerp));
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        lastCheckedTime = Time.time;
                        prev = amount;
                    }
                }
                for (int i = 0; i < dispawnerPos.Length; i++) {
                    Collider[] col = Physics.OverlapBox(dispawnerPos[i].position + Vector3.up * 1, new Vector3(2, 2, 2));
                    foreach (var item in col) {
                        if (item.tag == "Enemy" || item.tag == "Person") {
                            GameObject.Destroy(item.gameObject);
                        }
                    }
                }
            }
        }

        private void OnDrawGizmosSelected() {
            // Dibuja los lugares de aparicion.
            if (spawnerPos.Length != 0) {
                for (int i = 0; i < spawnerPos.Length; i++) {
                    Gizmos.color = gizmoSpawnerColor;
                    Gizmos.DrawCube(spawnerPos[i].position + Vector3.up * 1, new Vector3(2, 2, 2));
                }
            }
            // Dibuja los lugares de eliminacion.
            if (dispawnerPos.Length != 0) {
                for (int i = 0; i < dispawnerPos.Length; i++) {
                    Gizmos.color = gizmoDispawnerColor;
                    Gizmos.DrawCube(dispawnerPos[i].position + Vector3.up * 1, new Vector3(2, 2, 2));
                }
            }
        }
    }
}