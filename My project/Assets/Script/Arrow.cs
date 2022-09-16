using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Animator anim;
    private float Time = 1.0f;
    public float Arrowup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitOn () 
    {
        anim.SetBool("hitting",true);
        Invoke("Destroy",Time);
        GameObject pl = GameObject.Find("Player");
        Rigidbody2D prb = pl.GetComponent<Rigidbody2D>();
        prb.velocity = Vector2.up * Arrowup;
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
