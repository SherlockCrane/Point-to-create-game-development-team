using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    private float BreakTime = 1.0f;
    private float DestroyTime = 2.0f;
    private float thrust = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Break();
        rb.AddForce(transform.up * thrust);
    }
    void Break()
    {
        anim.SetBool("lighting",true);
        Invoke("BreakOff",BreakTime);
        Invoke("Destroy",DestroyTime);
    }
    void BreakOff()
    {
        anim.SetBool("lighting",false);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
