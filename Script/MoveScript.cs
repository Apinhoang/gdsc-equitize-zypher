using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveScript : MonoBehaviour{
    public float move_speed = 5f;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    private void UpdateAnimationAndMove(){
        if (change != Vector3.zero){
            MoveChar();
            animator.SetFloat("moveX",change.x);
            animator.SetFloat("moveY",change.y);
            animator.SetBool("moving",true);
        }
        else{
            animator.SetBool("moving",false);
        }
    }
    void MoveChar(){
        myRigidbody.MovePosition(
            transform.position + move_speed * Time.deltaTime * change
        );
    }
}
