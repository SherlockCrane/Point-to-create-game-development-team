using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Time = 1.0f;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Left();
        Invoke("Destroy", Time);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    // void Low()
    // {
    //     
    // }
    void Left()
    {
        rb.AddForce(-transform.up * thrust);
        rb.AddForce(-transform.right * thrust);
    }
}
