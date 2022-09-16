using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Speed = 0f;

    private bool AnimOn = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Boll");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){
       
    }
    IEnumerator Boll() 
    {
        while(true)
        {
            if(AnimOn)
            {
                Left();
                AnimOn = false;
            }
            yield return new WaitForSeconds(1.5f); 
            Right();
            Invoke("Left",Speed);
            Speed = 0.1f;
        }
    }
    void Left()
    {
        HingeJoint2D hj = gameObject.GetComponent<HingeJoint2D>();
        hj.useMotor = false;
    }
    void Right()
    {
        HingeJoint2D hj = gameObject.GetComponent<HingeJoint2D>();
        hj.useMotor = true;
    }
}
