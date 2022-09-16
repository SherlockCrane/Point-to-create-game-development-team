using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCome : MonoBehaviour
{
    private Transform PC;
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate();
    }
    void Instantiate()
    {
        Instantiate(myPrefab, new Vector3(PC.position.x,PC.position.y,PC.position.z), Quaternion.identity);
        Destroy();
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
