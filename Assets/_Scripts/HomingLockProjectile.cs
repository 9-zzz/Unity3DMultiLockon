using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLockProjectile : MonoBehaviour
{
    public GameObject target;

    public bool launched =false;

    float power = 0.09f;

    Rigidbody rb;

    public Vector3 targetScale;
    public GameObject hitParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime);

        if (launched)
        {
            transform.LookAt(target.transform.position);
            rb.AddForce(transform.forward* power, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "lockedon")
        {
            Instantiate(hitParticles, transform.position, transform.rotation);
            rb.isKinematic = true;
            Destroy(gameObject, 3);
        }
    }
}
