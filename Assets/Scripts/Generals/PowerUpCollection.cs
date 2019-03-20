using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 02/03/2019
 * 
 * description: Este codigo se encarga de
 * detectar cuando se colisiona con un 
 * powerup y de hacer las acciones pertinentes.
 */

namespace OwnCode.Generals {
    public class PowerUpCollection : MonoBehaviour {
        public GameObject particles;
        public Animator anim;
        public float timeActive = 5;
        float timer = 0;
        bool idle;

        private void Update() {
            // Si aun le queda tiempo en
            // el timer reducirlo.
            if (!GlobalData.pause)
                if (timer > 0)
                    timer -= Time.deltaTime;
            if (timer <= 0.1f && idle == false) {
                anim.SetBool("tiny", false);
                idle = true;
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.transform.tag == "PowerUp") {
                timer = timeActive;
                anim.SetBool("tiny", true);
                idle = false;
                if (particles != null) {
                    GameObject part = Instantiate(particles);
                    part.transform.position = other.transform.position + Vector3.up * 0.45f;
                    part.transform.parent = transform;
                }
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}