using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Time = 1.0f;
    private float thrust = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Destroy", Time);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
