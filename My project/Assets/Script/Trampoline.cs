using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jump()
    {
        anim.SetBool("jumping",true);
    }
    void JumpOff()
    {
        anim.SetBool("jumping",false);
    }
}
