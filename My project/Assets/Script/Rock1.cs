using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public Transform rockleftpoint, rockrightpoint, rockuppoint, rockdownpoint, leftpoint, rightpoint;
    private float leftx, rightx;
    private float Speed = 13;

    private bool isTouchPlayerLeft;
    private bool isTouchGroundLeft;

    private bool isTouchPlayerRight;
    private bool isTouchGroundRight;

    private bool isTouchPlayerUp;
    private bool isTouchGroundUp;

    private bool isTouchPlayerDown;
    private bool isTouchGroundDown;

    public LayerMask player;
    public LayerMask ground;

    public float timer = 1.0f;    
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
        // StartCoroutine("RockOn");
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }
    private void FixedUpdate(){
        isTouchPlayerLeft = Physics2D.OverlapCircle(rockleftpoint.position,0,player);
        isTouchGroundLeft = Physics2D.OverlapCircle(rockleftpoint.position,0,ground);

        isTouchPlayerRight = Physics2D.OverlapCircle(rockrightpoint.position,0,player);
        isTouchGroundRight = Physics2D.OverlapCircle(rockrightpoint.position,0,ground);

        isTouchPlayerUp = Physics2D.OverlapCircle(rockuppoint.position,0,player);
        isTouchGroundUp = Physics2D.OverlapCircle(rockuppoint.position,0,ground);

        isTouchPlayerDown = Physics2D.OverlapCircle(rockdownpoint.position,0,player);
        isTouchGroundDown = Physics2D.OverlapCircle(rockdownpoint.position,0,ground);

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
            // Invoke("RockLeft",timer);
        }
    }
    // IEnumerator RockOn()
    // {
    //     Rockright = true;
    //     if(transform.position.x >= rightx) 
    //     {
    //         rb.velocity = new Vector2(0, 0);
    //         if(Rockright)
    //         {
    //             anim.SetBool("right hitting",true);
    //             Rockright = false;
    //         }else{
    //             Invoke("RockRightOff",0.25f);
    //         }
    //         RockWaitTime += Time.deltaTime;
    //         if(RockWaitTime >= 1.0f)
    //         {
    //             RockRight();
    //             RockWaitTime = 0;
    //             Rockleft = true;
    //         }
    //     }
    //     bool Rockleft = true;
    //     if(transform.position.x >= rightx) 
    //     {
    //         rb.velocity = new Vector2(0, 0);
    //         if(Rockright)
    //         {
    //             anim.SetBool("right hitting",true);
    //             Rockright = false;
    //         }else{
    //             Invoke("RockRightOff",0.25f);
    //         }
    //         RockWaitTime += Time.deltaTime;
    //         if(RockWaitTime >= 1.0f)
    //         {
    //             RockRight();
    //             RockWaitTime = 0;
    //             Rockleft = true;
    //         }
    //     }
    // }
    // void AnimOn()
    // {
    //     anim.SetBool("right hitting",true);
    //     Invoke("RockRightOff",0.1f);
    // }
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
    void Death(){
        GameObject ps = GameObject.Find("Player");
        PlayerController pc = ps.GetComponent<PlayerController>();
        if(isTouchPlayerRight && isTouchGroundRight){
            pc.Hit();
            GameController.Instance.ShowGameOver();
        }
        if(isTouchPlayerLeft && isTouchGroundLeft){
            pc.Hit();
            GameController.Instance.ShowGameOver();
        }
    }
}
  