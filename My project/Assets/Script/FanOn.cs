using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanOn : MonoBehaviour
{
    private float Time = 5.0f;
    private float Time2 = 6.0f;
    public Animator anim;
    public GameObject fanon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FanR");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){
      
    }
    IEnumerator FanR()
    {
        anim.SetBool("blowing",true);
        while(true) 
        {

            yield return new WaitForSeconds(15.0f);
            anim.SetBool("blowing",true);
            Pson();
            Invoke("Blowoff", Time2);
            Invoke("Psoff", Time2);
            // Invoke("Ps2off", Time2);
        }
    }
    void Blowoff()
    {
        anim.SetBool("blowing",false);
    }
    void Blowon()
    {
        anim.SetBool("blowing",true);
    }
    void Pson()
    {
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = true;
        GameObject ps = GameObject.Find("FanOn");
        GameObject map= ps.transform.Find("map").gameObject;
        map.SetActive (true);
        GameObject ps2 = GameObject.Find("FanOn2");
        GameObject map2= ps2.transform.Find("map2").gameObject;
        map2.SetActive (true);
        GameObject ps3 = GameObject.Find("FanOn3");
        GameObject map3= ps3.transform.Find("map3").gameObject;
        map3.SetActive (true);
    }
    // void Pso2ff()
    // {
    //     BoxCollider2D bc2 = gameObject.GetComponent<BoxCollider2D>();
    //     bc2.enabled = false;
    //     GameObject ps2 = GameObject.Find("FanOn(2)");
    //     GameObject map2= ps2.transform.Find("map2").gameObject;
    //     map2.SetActive (false);
    // }
    void Psoff()
    {
        BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
        bc.enabled = false;
        GameObject ps = GameObject.Find("FanOn");
        GameObject map= ps.transform.Find("map").gameObject;
        map.SetActive (false);
        GameObject ps2 = GameObject.Find("FanOn2");
        GameObject map2= ps2.transform.Find("map2").gameObject;
        map2.SetActive (false);
        GameObject ps3 = GameObject.Find("FanOn3");
        GameObject map3= ps3.transform.Find("map3").gameObject;
        map3.SetActive (false);
    }
}
