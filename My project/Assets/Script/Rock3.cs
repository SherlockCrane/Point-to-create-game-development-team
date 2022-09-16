using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float Speed = 13;

    public Transform rockleftpoint, rockrightpoint, rockuppoint, rockdownpoint, leftpoint, rightpoint, uppoint, downpoint;
    private float leftx, lefty, rightx, righty, upx, upy, downx, downy;

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

    private float timer = 1.0f;    
    private float RockWaitTime;
    private bool Rockleft = true;
    private bool Rockright = true;
    private bool Rockup = true;
    private bool Rockdown = true;
    private bool AnimOn = false;
    private bool AnimOn2 = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftx = leftpoint.position.x;
        lefty = leftpoint.position.y;

        rightx = rightpoint.position.x;
        righty = rightpoint.position.y;

        upx = uppoint.position.x;
        upy = uppoint.position.y;

        downx = downpoint.position.x;
        downy = downpoint.position.y;

        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
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
        if(transform.position.y <= downy && transform.position.x <= downx) 
        {
            if(AnimOn)
            {
                if(Rockdown)
                {
                    anim.SetBool("bottom hitting",true);
                    rb.velocity = new Vector2(0, 0);
                    Rockdown = false;
                }else{
                    Invoke("RockDownOff",0.25f);
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
        if(transform.position.x >= rightx && transform.position.y <= righty) 
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
                RockUp();
                RockWaitTime = 0;
                Rockup = true;
                AnimOn2 = true;
            }
        }
        if(transform.position.y >= upy && transform.position.x >= upx) 
        {
            if(AnimOn2) 
            {
                if(Rockup)
                {
                    anim.SetBool("top hitting",true);
                    rb.velocity = new Vector2(0, 0);
                    Rockup = false;
                }else{
                    Invoke("RockUpOff",0.25f);
                }
            }
            RockWaitTime += Time.deltaTime;
            if(RockWaitTime >= 1.5f)
            {
                RockLeft();
                RockWaitTime = 0;
                Rockleft = true;
            }
        }
        if(transform.position.x <= leftx && transform.position.y >= lefty) 
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
                RockDown();
                RockWaitTime = 0;
                Rockdown = true;
                AnimOn = true;
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
    void RockUp()
    {
        rb.velocity = new Vector2(0, Speed);
    }
    void RockDown()
    {
        rb.velocity = new Vector2(0, -Speed);
    }
    void RockLeftOff(){
        anim.SetBool("left hitting", false);
    }
    void RockRightOff(){
        anim.SetBool("right hitting", false);
    }
    void RockUpOff(){
        anim.SetBool("top hitting", false);
    }
    void RockDownOff(){
        anim.SetBool("bottom hitting", false);
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
        if(isTouchPlayerUp && isTouchGroundUp){
            pc.Hit();
            GameController.Instance.ShowGameOver();
        }
        if(isTouchPlayerDown && isTouchGroundDown){
            pc.Hit();
            GameController.Instance.ShowGameOver();
        }
    }
}
