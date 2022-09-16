using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOff : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform uppoint, downpoint;
    private float upx, downx;
    public float Speed;
    private bool UpDown = false;
    private bool FallDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upx = uppoint.position.y;
        downx = downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }
    void Movement()
    {
        if(FallDown)
        {
            if(transform.position.y >= upx)
            {
                Down();

            }
            if(transform.position.y <= downx)
            {
                Stop();
            }
        }
        if (UpDown)
        {
            if(transform.position.y >= upx)
            {
                Stop();
                GameObject pl = GameObject.Find("Player");
                Rigidbody2D prb = pl.GetComponent<Rigidbody2D>();
                prb.velocity = new Vector2(0,0);
            }
        }
    } 
    public void Up()
    {
        Invoke("UpOn",0.5f);
    }
    void UpOn()
    {
        rb.velocity = new Vector2(0,Speed);
        UpDown = true;
        FallDown = false;
    }
    public void Down()
    {
        rb.velocity = new Vector2(0,-Speed);
        FallDown = true;
        UpDown = false;
    }
    void Stop()
    {
        rb.velocity = new Vector2(0,0);
        FallDown = false;
        UpDown = false;
    }
}