using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRock3 : MonoBehaviour
{
     private Rigidbody2D rb;
    private Animator anim;

    public Transform toppoint, bottompoint;
    private float topy, bottomy;
    private float Speed = 13;

    private float Runingtimer = 1.0f;    
    private float RockWaitTime;
    private bool Rocktop = true;
    private bool Rockbottom = true;
    private bool AnimOn = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        topy = toppoint.position.y;
        bottomy = bottompoint.position.y;
        Destroy(toppoint.gameObject);
        Destroy(bottompoint.gameObject);
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
        if(transform.position.y <= bottomy) 
        {
            rb.velocity = new Vector2(0, 0);
            if(AnimOn)
            {
                if(Rockbottom)
                {
                    anim.SetBool("bottom hitting",true);
                    Rockbottom = false;
                }else{
                    Invoke("RockBottomOff",0.25f);
                }
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= Runingtimer)
            {
                RockTop();
                RockWaitTime = 0;
                Rocktop = true;
                Runingtimer = 1.2f;
            }
        }
        if(transform.position.y >= topy) 
        {
            rb.velocity = new Vector2(0, 0);
            if(Rocktop)
            {
                anim.SetBool("top hitting",true);
                Rocktop = false;
            }else{
                Invoke("RockTopOff",0.25f);
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= Runingtimer)
            {
                RockBottom();
                RockWaitTime = 0;
                Rockbottom = true;
                AnimOn = true;
            }
        }
    }
    void RockTop()
    {
        rb.velocity = new Vector2(0, Speed);
    }
    void RockBottom()
    {
        rb.velocity = new Vector2(0, -Speed);
    }
    void RockTopOff(){
        anim.SetBool("top hitting", false);
    }
     void RockBottomOff(){
        anim.SetBool("bottom hitting", false);
    }
}
