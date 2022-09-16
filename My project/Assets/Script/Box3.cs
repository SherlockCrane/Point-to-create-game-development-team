using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box3 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public Animator anim;
    private float Time = 1.0f;
    public float HitInput = 5;

    public Transform Box;
    public GameObject myPrefab;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void HitOn()
    {
        anim.SetBool("hiting",true);
        Invoke("HitOff", Time);
        if(anim.GetBool("hiting")){
            HitInput -= 1;
        }
        if(HitInput <= 0)
        {
            Invoke("Destroy", Time);
            Invoke("Instantiate", Time);
        }
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
