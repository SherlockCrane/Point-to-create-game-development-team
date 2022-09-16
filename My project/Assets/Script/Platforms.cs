using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Transform Fan;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      FallOff();   
    }
    public void DoFall()
    {
        Invoke("Fall",2.0f);
    }
    public void DoFall1()
    {
        Invoke("Fall1",2.0f);
    }
    public void DoFall2()
    {
        Invoke("Fall2",2.0f);
    }
    public void DoFall3()
    {
        Invoke("Fall3",2.0f);
    }
    void Fall()
    {
        anim.SetBool("falling",false);
        GameObject fp = GameObject.Find("Falling Platforms");
        GameObject pt= fp.transform.Find("Particle").gameObject;
        pt.SetActive (false);
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = false;
        TargetJoint2D tj = gameObject.GetComponent<TargetJoint2D>();
        tj.enabled = false;
    }
    void Fall1()
    {
        GameObject fp1 = GameObject.Find("Falling Platforms1");
        GameObject pt1= fp1.transform.Find("Particle1").gameObject;
        pt1.SetActive (false);
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = false;
        TargetJoint2D tj = gameObject.GetComponent<TargetJoint2D>();
        tj.enabled = false;
    }
    void Fall2()
    {
        GameObject fp2 = GameObject.Find("Falling Platforms2");
        GameObject pt2= fp2.transform.Find("Particle2").gameObject;
        pt2.SetActive (false);
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = false;
        TargetJoint2D tj = gameObject.GetComponent<TargetJoint2D>();
        tj.enabled = false;
    }
    void Fall3()
    {
        GameObject fp3 = GameObject.Find("Falling Platforms3");
        GameObject pt3= fp3.transform.Find("Particle3").gameObject;
        pt3.SetActive (false);
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = false;
        TargetJoint2D tj = gameObject.GetComponent<TargetJoint2D>();
        tj.enabled = false;
    }
    void FallOff()
    {
        anim.SetBool("falling",true);
    }
}
