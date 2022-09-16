using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player")
        {
            if(AnimOn)
            {
                AnimFlagOutOn();
                ParticleOn();
                Invoke("ParticleOff", 10.0f);
                AnimOn = false;
            }
        }
    }
    void AnimFlagOutOn()
    {
        anim.SetBool("flag out",true);
    }
    void AnimFlagIdelOn()
    {
        anim.SetBool("flag out",false);
        anim.SetBool("flag idel",true);
    }
    void ParticleOn()
    {
        GameObject st = GameObject.Find("Checkpoint");
        GameObject pt= st.transform.Find("Particle2").gameObject;
        pt.SetActive (true);
    }
    void ParticleOff()
    {
        GameObject st = GameObject.Find("Checkpoint");
        GameObject pt= st.transform.Find("Particle2").gameObject;
        pt.SetActive (false);
    }
}
