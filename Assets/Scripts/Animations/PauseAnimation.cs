using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OwnCode.DataManagement;

public class PauseAnimation : MonoBehaviour
{
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if(GlobalData.pause) {
            anim.speed = 0;
        } else {
            anim.speed = 1;
        }
    }
}
