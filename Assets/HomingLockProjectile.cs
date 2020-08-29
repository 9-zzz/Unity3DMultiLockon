using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLockProjectile : MonoBehaviour
{
    public GameObject target;

    public bool launched =false;

    float power = 0.09f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (launched)
        {
            transform.LookAt(target.transform.position);
            rb.AddForce(transform.forward* power, ForceMode.VelocityChange);
        }
    }
}
