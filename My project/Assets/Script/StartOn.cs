using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOn : MonoBehaviour
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
                AnimStartOn();
                ParticleOn();
                Invoke("ParticleOff", 10.0f);
                AnimOn = false;
            }
        }
        
    }
    void AnimStartOn()
    {
        anim.SetBool("moving",true);
    }
    void AnimStartOff()
    {
        anim.SetBool("moving",false);
    }
    void ParticleOn()
    {
        GameObject st = GameObject.Find("Start");
        GameObject pt= st.transform.Find("Particle1").gameObject;
        pt.SetActive (true);
    }
    void ParticleOff()
    {
        GameObject st = GameObject.Find("Start");
        GameObject pt= st.transform.Find("Particle1").gameObject;
        pt.SetActive (false);
    }
}
