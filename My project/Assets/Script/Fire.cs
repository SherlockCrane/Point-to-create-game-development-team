using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator anim;
    public GameObject Gfire;
    // Start is called before the first frame update
    // public static Fire Instance;
    void Start()
    {
        anim = GetComponent<Animator>();
        // Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void On()
    {
        Hiton();
        Invoke("FireOn",1.0f);
    }
    void Hiton()
    {
        anim.SetBool("hitting",true);
    }
    void FireOn()
    {
        anim.SetBool("hitting",false);
        anim.SetBool("fireon",true);
        CapsuleCollider2D cc = gameObject.GetComponent<CapsuleCollider2D>();
        cc.enabled = true;
        Gfire.tag = "Spike";
        Invoke("FireOff",1.0f);  
    }
    void FireOff()
    {
        anim.SetBool("fireon",false);
        CapsuleCollider2D cc = gameObject.GetComponent<CapsuleCollider2D>();
        cc.enabled = false;
        Gfire.tag = "Fire";
    }
}
