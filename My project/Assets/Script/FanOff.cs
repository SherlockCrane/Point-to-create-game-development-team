using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanOff : MonoBehaviour
{
    private float Time = 5.0f;
    private float Time2 = 6.0f;
    public Transform Fan;
    public Animator anim;
    private bool UnBlow = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FanO");
    }

    // Update is called once per frame
    void Update()
    {
        BlowSpeedUp();
    }
    private void FixedUpdate(){
      
    }
    IEnumerator FanO()
    {
        anim.SetBool("blowing",false);
        while(true) 
        {

            yield return new WaitForSeconds(15.0f);
            Blowoff2();
            Psoff();
            Invoke("Blowon", Time2);
            Invoke("Pson", Time2);
        }
    }
    void Blowoff2()
    {
        anim.SetBool("blowing",false);
        UnBlow = true;
    }
    void Blowon()
    {
        anim.SetBool("blowing",true);
        UnBlow = false;
    }
    void Pson()
    {
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = true;
        GameObject ps = GameObject.Find("FanOff");
        GameObject map= ps.transform.Find("map").gameObject;
        map.SetActive (true);
    }
    void Psoff()
    {
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = false;
        GameObject ps = GameObject.Find("FanOff");
        GameObject map= ps.transform.Find("map").gameObject;
        map.SetActive (false);
    }
    public void BlowSpeedDown()
    {
        GameObject pl = GameObject.Find("Player");
        PlayerController pcl = pl.GetComponent<PlayerController>();
        if(anim.GetBool("blowing"))
        {
            pcl.speed = 100;
        }   
    }
    void BlowSpeedUp()
    {
        GameObject pl = GameObject.Find("Player");
        PlayerController pcl = pl.GetComponent<PlayerController>();
        if(UnBlow)
        {
            pcl.speed = 450;
        }     
    }
}
