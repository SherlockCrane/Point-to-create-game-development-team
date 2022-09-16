using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRock : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public Transform leftpoint, rightpoint;
    private float leftx, rightx;
    private float Speed = 13;

    private float timer = 1.0f;    
    private float RockWaitTime;
    private bool Rockleft = true;
    private bool Rockright = true;
    private bool AnimOn = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){
       RockOn();
    }
     void RockOn()
    {
        if(transform.position.x >= rightx) 
        {
            rb.velocity = new Vector2(0, 0);
            if(AnimOn)
            {
                if(Rockright)
                {
                    anim.SetBool("right hitting",true);
                    Rockright = false;
                }else{
                    Invoke("RockRightOff",0.25f);
                }
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= 1.0f)
            {
                RockRight();
                RockWaitTime = 0;
                Rockleft = true;
            }
        }
        if(transform.position.x <= leftx) 
        {
            rb.velocity = new Vector2(0, 0);
            if(Rockleft)
            {
                anim.SetBool("left hitting",true);
                Rockleft = false;
            }else{
                Invoke("RockLeftOff",0.25f);
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= 1.0f)
            {
                RockLeft();
                RockWaitTime = 0;
                Rockright = true;
                AnimOn = true;
            }
        }
    }
    void RockLeft()
    {
        rb.velocity = new Vector2(Speed, 0);
    }
    void RockRight()
    {
        rb.velocity = new Vector2(-Speed, 0);
    }
    void RockLeftOff(){
        anim.SetBool("left hitting", false);
    }
     void RockRightOff(){
        anim.SetBool("right hitting", false);
    }
}
