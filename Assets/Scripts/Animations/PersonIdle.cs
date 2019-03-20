using UnityEngine;

/*
 *author: Mikel Jauregui
 * last update: 24/01/2019
 * 
 * description: Este codigo se encarga de
 * determinar cuanto pasa antes de poder
 * pasar a  la siguiente animacion.
 */

namespace OwnCode.Animation {
    public class PersonIdle : StateMachineBehaviour {
        public float minTime;
        public float maxTime;

        private float nextTime;
        private float timer;
        private float lastTime;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            lastTime = Time.time;
            timer = 0;
            nextTime = Random.Range(minTime, maxTime);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            timer += Time.deltaTime;
            if (lastTime + maxTime < lastTime + timer) {
                animator.SetBool("StopIdle", true);
            }
        }
    }
}