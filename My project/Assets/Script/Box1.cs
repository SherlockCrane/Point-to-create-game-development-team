using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public Animator anim;
    private float Time = 1.0f;

    public Transform Box;
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitOn()
    {
        anim.SetBool("hiting",true);
        Invoke("Destroy", Time);
        Instantiate();
    }
    void HitOff()
    {
        anim.SetBool("hiting",false);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    void Instantiate()
    {
        Instantiate(myPrefab, new Vector3(Box.position.x,Box.position.y,Box.position.z), Quaternion.identity);
    }
}
