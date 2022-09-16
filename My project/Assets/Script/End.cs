using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Animator anim;
    private bool AnimOn = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player")
        {
            if(AnimOn)
            {
                AnimPressOn();
                ParticleOn();
                Invoke("ParticleOff", 10.0f);
                AnimOn = false;
            }
        }
        
    }
    void AnimPressOn()
    {
        anim.SetBool("pressing",true);
    }
    void AnimPressOff()
    {
        anim.SetBool("pressing",false);
    }
    void ParticleOn()
    {
        GameObject st = GameObject.Find("End");
        GameObject pt= st.transform.Find("Particle3").gameObject;
        pt.SetActive (true);
    }
    void ParticleOff()
    {
        GameObject st = GameObject.Find("End");
        GameObject pt= st.transform.Find("Particle3").gameObject;
        pt.SetActive (false);
    }
}
