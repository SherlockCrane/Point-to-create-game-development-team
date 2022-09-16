using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRock4 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float Speed = 13;

    public Transform leftpoint, rightpoint, toppoint, bottompoint;
    private float leftx, lefty, rightx, righty, topx, topy, bottomx, bottomy;

    private float timer = 1.0f;    
    private float RockWaitTime;
    private bool Rockleft = true;
    private bool Rockright = true;
    private bool Rocktop = true;
    private bool Rockbottom = true;
    private bool AnimOn = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftx = leftpoint.position.x;
        lefty = leftpoint.position.y;

        rightx = rightpoint.position.x;
        righty = rightpoint.position.y;

        topx = toppoint.position.x;
        topy = toppoint.position.y;

        bottomx = bottompoint.position.x;
        bottomy = bottompoint.position.y;

        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        Destroy(toppoint.gameObject);
        Destroy(bottompoint.gameObject);
        // StartCoroutine("RockOn");
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
        if(transform.position.y >= topy && transform.position.x <= topx) 
        {
            if(AnimOn) 
            {
                if(Rocktop)
                {
                    anim.SetBool("top hitting",true);
                    rb.velocity = new Vector2(0, 0);
                    Rocktop = false;
                }else{
                    Invoke("RockTopOff",0.25f);
                }
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= 1.5f)
            {
                RockRight();
                RockWaitTime = 0;
                Rockright = true;
            }
        }
        if(transform.position.x >= rightx && transform.position.y >= righty) 
        {
            if(Rockright)
            {
                anim.SetBool("right hitting",true);
                rb.velocity = new Vector2(0, 0);
                Rockright = false;
            }else{
                Invoke("RockRightOff",0.25f);
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= 1.0f)
            {
                RockBottom();
                RockWaitTime = 0;
                Rockbottom = true;
                AnimOn = true;
            }
        }
        if(transform.position.y <= bottomy && transform.position.x >= bottomx) 
        {
            if(Rockbottom)
            {
                anim.SetBool("bottom hitting",true);
                rb.velocity = new Vector2(0, 0);
                Rockbottom = false;
            }else{
                Invoke("RockBottomOff",0.25f);
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= 1.5f)
            {
                RockLeft();
                RockWaitTime = 0;
                Rockleft = true;
            }
        }
        if(transform.position.x <= leftx && transform.position.y <= lefty) 
        {
            if(Rockleft)
            {
                anim.SetBool("left hitting",true);
                rb.velocity = new Vector2(0, 0);
                Rockleft = false;
            }else{
                Invoke("RockLeftOff",0.25f);
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= 1.0f)
            {
                RockTop();
                RockWaitTime = 0;
                Rocktop = true;
            }
        }
    }
    void RockLeft()
    {
        rb.velocity = new Vector2(-Speed, 0);
    }
    void RockRight()
    {
        rb.velocity = new Vector2(Speed, 0);
    }
    void RockTop()
    {
        rb.velocity = new Vector2(0, Speed);
    }
    void RockBottom()
    {
        rb.velocity = new Vector2(0, -Speed);
    }
    void RockLeftOff(){
        anim.SetBool("left hitting", false);
    }
    void RockRightOff(){
        anim.SetBool("right hitting", false);
    }
    void RockTopOff(){
        anim.SetBool("top hitting", false);
    }
    void RockBottomOff(){
        anim.SetBool("bottom hitting", false);
    }
}
