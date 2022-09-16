using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUp : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Transform uppoint, downpoint;
    private float upy, downy;
    private float Speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        upy = uppoint.position.y;
        downy = downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SawUpOn();
    }
    void SawUpOn()
    {
        if(transform.position.y <= downy) 
        {
        rb.velocity = new Vector2(0, Speed); 
        }
        if(transform.position.y >= upy) 
        {
        rb.velocity = new Vector2(0, -Speed); 
        }  
    }
}
