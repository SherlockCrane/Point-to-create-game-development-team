using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public Transform rockleftpoint, rockrightpoint, rockuppoint, rockdownpoint, leftpoint, rightpoint;
    private float lefty, righty;
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
    private bool Rocktop = true;
    private bool Rockbottom = true;
    private bool AnimOn = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lefty = leftpoint.position.y;
        righty = rightpoint.position.y;
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
        if(transform.position.y <= righty) 
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
            if(RockWaitTime >= 1.0f)
            {
                RockBottom();
                RockWaitTime = 0;
                Rocktop = true;
            }
        }
        if(transform.position.y >= lefty) 
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
            if(RockWaitTime >= 1.0f)
            {
                RockTop();
                RockWaitTime = 0;
                Rockbottom = true;
                AnimOn = true;
            }
            // Invoke("RockLeft",timer);
        }
    }
    void RockTop()
    {
        rb.velocity = new Vector2(0, -Speed);
    }
    void RockBottom()
    {
        rb.velocity = new Vector2(0, Speed);
    }
    void RockTopOff(){
        anim.SetBool("top hitting", false);
    }
     void RockBottomOff(){
        anim.SetBool("bottom hitting", false);
    }
    void Death(){
        GameObject ps = GameObject.Find("Player");
        PlayerController pc = ps.GetComponent<PlayerController>();
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
