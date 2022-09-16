using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Animator anim;
    private float Time = 1.0f;
    public GameObject myPrefab;
    public Transform Block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){

    }
    public void HitSide()
    {
        anim.SetBool("hitside",true);
        Invoke("Destroy",Time);
        Invoke("Instantiate",Time);
    }
    public void HitTop()
    {
        anim.SetBool("hittop",true);
        Invoke("Destroy",Time);
        Invoke("Instantiate",Time);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    void Instantiate()
    {
        Instantiate(myPrefab, new Vector3(Block.position.x,Block.position.y,Block.position.z), Quaternion.identity);
    }
}
