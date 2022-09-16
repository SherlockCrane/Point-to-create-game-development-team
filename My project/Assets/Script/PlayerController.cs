using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float JumpForce;
    public Animator anim;
    public LayerMask ground;
    public Collider2D coll;
    public Collider2D DisColl;
    public Transform GroundCheck;

    public int Apple;
    public int Cherry;
    public int Orange;
    public int Pineapple;
    public int Banana;
    public int Strawberry;
    public int Melon;
    public int Kiwi;
    

    private bool isGround;
    private int extraJump;

    private bool isTouchingFront;
    public Transform frontCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;

    private bool wallJumping;
    public float xWallForce;
    public float yWakkForce; 
    public float wallJumpTime;

    private bool isBox;
    public Transform BoxCheck;
    public LayerMask box;

    private float TrampolineJump = 14;
    private float TrampolineJump2 = 12;

    public float BrownOffSpeed;

    private bool AnimOn = true;

    private bool isEnd;
    public LayerMask End;

    private bool upBox;
    public Transform HeadCheck;
    // public static PlayerController Instance;
    // Start is called before the first frame update
    void Start()
    {
        // Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(AnimOn)
        {
            Movement();
        }
        SwitchAnim();
        Jump();
        Climb();
        WallJump();
    }
    private void FixedUpdate(){
       isGround = Physics2D.OverlapCircle(GroundCheck.position,0.2f,ground);
       isTouchingFront = Physics2D.OverlapCircle(frontCheck.position,0,ground);
       isBox = Physics2D.OverlapCircle(GroundCheck.position,0,box);
       upBox = Physics2D.OverlapCircle(HeadCheck.position,0,box);
       isEnd = Physics2D.OverlapCircle(GroundCheck.position,0,End);
    }
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedircetion = Input.GetAxisRaw("Horizontal");

        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove*speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("running",Mathf.Abs(facedircetion));
            anim.SetBool("falling",false);
        }
        if (facedircetion != 0)
        {
            transform.localScale = new Vector3(facedircetion, 1, 1);
        }
//   Crouch();
    }
    void Jump()
    {
        if(isGround | isBox){
            extraJump = 1;
        }
        if(Input.GetButtonDown("Jump") && extraJump > 0){
            rb.velocity = Vector2.up * JumpForce;
            extraJump--;
            anim.SetBool("jumping",false);
            anim.SetBool("double jumping",true);
        }
        if(Input.GetButtonDown("Jump") && extraJump == 0 && isGround){
            rb.velocity = Vector2.up * JumpForce;
            anim.SetBool("jumping",true);
            anim.SetBool("double jumping",false);
        }
        if(Input.GetButtonDown("Jump") && extraJump == 0 && isBox){
            rb.velocity = Vector2.up * JumpForce;
            anim.SetBool("jumping",true);
            anim.SetBool("double jumping",false);
        }              
    }
    void  Climb()
    {
        if(isTouchingFront == true && isGround == false && wallSlidingSpeed != 0)
        {
            wallSliding = true;
        } else {
            wallSliding = false;
        }
        if(wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y,wallSlidingSpeed,float.MaxValue));
            anim.SetBool("falling",false);
            anim.SetBool("climbing",true);
        }
    }
    void WallJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWllJupmingToFalse", wallJumpTime);
        }
        if(wallJumping == true) 
        {
            rb.velocity = new Vector2(xWallForce * -0.2f, yWakkForce);
            anim.SetBool("climbing",false);
            anim.SetBool("jumping",true);
        }
    }
    void SetWllJupmingToFalse()
    {
        wallJumping = false;
    }
    void SwitchAnim()
    {
        if(rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {
            anim.SetBool("climbing",false);
            anim.SetBool("falling",true);
        }
        // if(anim.GetBool("running"))
        // {
        //     if(rb.velocity.y < 0)
        //     {
        //         anim.SetBool("running",false)
        //         anim.SetBool("falling",true);
        //     }
        // }
        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("jumping",false);
            }
        }
        if(anim.GetBool("double jumping"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("double jumping",false);
                anim.SetBool("falling",true);
            }
        }
        else if(coll.IsTouchingLayers(ground) | coll.IsTouchingLayers(box))
        {
            anim.SetBool("falling",false);
        }
    }
    void Desappear()
    {
        anim.SetBool("desappearing",true);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    public void Hit()
    {
        rb.velocity = new Vector2(xWallForce * -0.2f, yWakkForce);
        anim.SetBool("hitting",true);
        CapsuleCollider2D bc = gameObject.GetComponent<CapsuleCollider2D>();
        bc.enabled = false;
        Invoke("Destroy",3.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Apple")
        {
            // Eat.Play();
            Destroy(collision.gameObject);
            Apple += 1;
            // Apple.GetComponent<Animator>().Play("isGot");
        }
        if(collision.tag == "Cherry"){
            Destroy(collision.gameObject);
            Cherry += 1;
        }
        if(collision.tag == "Orange"){
            Destroy(collision.gameObject);
            Orange += 1;
        }
        if(collision.tag == "Pineapple"){
            Destroy(collision.gameObject);
            Pineapple +=1;
        }
        if(collision.tag == "Banana"){
            Destroy(collision.gameObject);
            Banana +=1;
        }
        if(collision.tag == "Strawberry"){
            Destroy(collision.gameObject);
            Strawberry +=1;
        }
        if(collision.tag == "Melon"){
            Destroy(collision.gameObject);
            Melon +=1;
        }
        if(collision.tag == "Kiwi"){
            Destroy(collision.gameObject);
            Kiwi +=1;
        }
        Arrow arrow = collision.gameObject.GetComponent<Arrow>();
        if(collision.gameObject.tag == "Arrow")
        {   
            arrow.HitOn();
            anim.SetBool("jumping",true);        
        }
        FanOff fanoff = collision.gameObject.GetComponent<FanOff>();
        if(collision.gameObject.tag == "FanOff")
        {   
            fanoff.BlowSpeedDown(); 
        }
        Fire fire = collision.gameObject.GetComponent<Fire>();
        if(collision.gameObject.tag == "Fire") 
        {
            // Fire.Instance.On();
            fire.On();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "FanOff")
        {   
            speed = 450; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Box1 box1 = collision.gameObject.GetComponent<Box1>();
        if(collision.gameObject.tag == "Box1")
        {           
            if(anim.GetBool("jumping") |anim.GetBool("double jumping"))
            {
                box1.HitOn();
            }
            if(anim.GetBool("falling"))
            {
                box1.HitOn();
                rb.velocity = Vector2.up * JumpForce;
                anim.SetBool("jumping",true);
            }
        }
        Box2 box2 = collision.gameObject.GetComponent<Box2>();
        if(collision.gameObject.tag == "Box2")
        {           
            if(anim.GetBool("jumping") |anim.GetBool("double jumping"))
            {
                box2.HitOn();
            }
            if(anim.GetBool("falling"))
            {
                box2.HitOn();
                rb.velocity = Vector2.up * JumpForce;
                anim.SetBool("jumping",true);
            }
        }
        Box3 box3 = collision.gameObject.GetComponent<Box3>();
        if(collision.gameObject.tag == "Box3")
        {           
            if(anim.GetBool("falling") | anim.GetBool("jumping") |anim.GetBool("double jumping"))
            {
                box3.HitOn();
            }
        }
        Trampoline trampoline = collision.gameObject.GetComponent<Trampoline>();
        if(collision.gameObject.tag == "Trampoline")
        {
            trampoline.Jump();
            anim.SetBool("jumping",true);
            rb.velocity = Vector2.up * TrampolineJump;
        }
        if(collision.gameObject.tag == "Trampoline2")
        {
            trampoline.Jump();
            anim.SetBool("jumping",true);
            rb.velocity = Vector2.up * TrampolineJump2;
        }
        Blocks block = collision.gameObject.GetComponent<Blocks>();
        if(collision.gameObject.tag == "Block")
        {           
            if(anim.GetBool("falling"))
            {
                block.HitTop();
            }
            if(anim.GetBool("jumping") |anim.GetBool("double jumping"))
            {
                block.HitSide();
            }
        }
        BrownOff brownoff = collision.gameObject.GetComponent<BrownOff>();
        if(collision.gameObject.tag == "BrownOff")
        {
            brownoff.Up();
        }
        Platforms pf = collision.gameObject.GetComponent<Platforms>();
        if(collision.gameObject.tag == "Platform" && isGround) 
        {
            pf.DoFall();
        }
        if(collision.gameObject.tag == "Platform1" && isGround) 
        {
            pf.DoFall1();
        }
        if(collision.gameObject.tag == "Platform2" && isGround) 
        {
            pf.DoFall2();
        }
        if(collision.gameObject.tag == "Platform3" && isGround) 
        {
            pf.DoFall3();
        }
        if(collision.gameObject.tag == "Spike") 
        {
            Hit();
            GameController.Instance.ShowGameOver();
        }
        Fire fire = collision.gameObject.GetComponent<Fire>();
        if(collision.gameObject.tag == "Fire") 
        {
            // Fire.Instance.On();
            fire.On();
        }
        if(collision.gameObject.tag == "venom") 
        {
            speed = 0;
        }
        if(collision.gameObject.tag == "The sand") 
        {
            speed = 50;
        }
        if(collision.gameObject.tag == "The ice") 
        {
            AnimOn = false;
            rb.velocity = new Vector2(transform.localScale.x*speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetBool("falling",true);
        }
        if(collision.gameObject.tag == "End") 
        {
            rb.velocity = Vector2.up * JumpForce;
            anim.SetBool("jumping",true);
            Invoke("Desappear",0.5f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        BrownOff brownoff = collision.gameObject.GetComponent<BrownOff>();
        if(collision.gameObject.tag == "BrownOff")
        {
            brownoff.Down();
        }
        if(collision.gameObject.tag == "venom" | collision.gameObject.tag == "The sand") 
        {
            speed = 450;
        }
        if(collision.gameObject.tag == "The ice") 
        {
            AnimOn = true;
        }
    }
    
}
