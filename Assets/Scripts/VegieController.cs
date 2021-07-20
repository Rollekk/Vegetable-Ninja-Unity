using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegieController : MonoBehaviour
{
    public int Points = 5;
    public Transform canonPoint;
    public float forceValue = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(canonPoint.up * forceValue, ForceMode.Impulse);

        Destroy(this.gameObject, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
