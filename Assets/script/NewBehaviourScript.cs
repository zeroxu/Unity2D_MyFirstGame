using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public float moveSpeed = 3.5f;
    public float jump = 750.0f;
    public bool isGround = false;
    public GameObject groundObj;
    Rigidbody2D rb2;
    Vector2 v2;
    Animator am;
    SpriteRenderer sr;
    void Start()
    {
        // GetComponent<Transform>().localPosition = new Vector3(5,-0.5f,0);
        rb2 = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        am.SetBool("stand",isGround);
        // transform.localPosition += new Vector3(2,0,0)* Time.deltaTime;
        // rb2.velocity = new Vector2(3,0);
        if(Input.GetKey(KeyCode.RightArrow)){//按著右
            v2.x = moveSpeed;
            am.SetFloat("move",1);
            sr.flipX = false;
        }

        if(Input.GetKey(KeyCode.LeftArrow)){//按著左
            v2.x = -moveSpeed;
            am.SetFloat("move",1);
            sr.flipX = true;//面向左
        }
        

        if(Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow)){
            v2.x = 0;//放開左右
            am.SetFloat("move",0);

        }

        if(Input.GetKeyDown(KeyCode.Space)){//按下上
            rb2.AddForce(Vector2.up*jump);
            am.SetTrigger("Jump");
        }
    

        v2.y = rb2.velocity.y;
        rb2.velocity = v2;
        // if(Input.GetKeyUp(KeyCode.UpArrow)){
        //     rb2.velocity =Vector2.zero;
        // }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("ground")){
            foreach(ContactPoint2D element in other.contacts){
                if(element.normal.y>0.1f){
                    groundObj = other.gameObject;
                    isGround = true;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject == groundObj){
            groundObj = null;
            isGround = false;
        }
    }
}
