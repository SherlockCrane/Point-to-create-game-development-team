using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearing : MonoBehaviour
{
    private Transform Ap;
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Ap = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void Instantiate()
    {
        Instantiate(myPrefab, new Vector3(Ap.position.x,Ap.position.y,Ap.position.z), Quaternion.identity);
        Destroy();
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
