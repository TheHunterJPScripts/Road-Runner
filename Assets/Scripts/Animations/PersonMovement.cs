using UnityEngine;
using OwnCode.DataManagement;

/*
 *author: Mikel Jauregui
 * last update: 24/01/2019
 * 
 * description: Este codigo se encarga de
 * mover el objeto mientras se ejecuta
 * la animacion.
 */

namespace OwnCode.Animation {
    public class PersonMovement : StateMachineBehaviour {
        public float speed;
        private float direction;
        private float lastTime;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            direction = Mathf.Sign(Random.Range(-1, 1));
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (!GlobalData.pause) {
                Vector3 v = Vector3.right * direction * speed * Time.deltaTime;

                animator.transform.parent.Translate(v);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetBool("StopIdle", false);
        }
    }
}