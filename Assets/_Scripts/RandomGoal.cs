using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGoal : MonoBehaviour
{
    public Vector3 spot;
    public float range;
    public float interval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndMove(interval));
    }

    IEnumerator WaitAndMove(float x)
    {
        while (true)
        {
            yield return new WaitForSeconds(x);
            transform.position = (Random.insideUnitSphere * range) + spot;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
