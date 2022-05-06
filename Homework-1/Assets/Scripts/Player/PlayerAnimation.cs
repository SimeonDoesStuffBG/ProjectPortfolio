using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerControler controler;
    // Start is called before the first frame update
    void Start(){
        anim = gameObject.GetComponent<Animator>();
        controler = gameObject.GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update(){
        anim.SetBool("Jumping", controler.Jumps());
        //Debug.Log(controler.Jumps());
        anim.SetFloat("Walk/Run", (controler.isMoving() ? 1 : 0));
        anim.SetBool("IsHurt", controler.gameObject.GetComponent<LevelManager>().GetHurt());
    }
}
