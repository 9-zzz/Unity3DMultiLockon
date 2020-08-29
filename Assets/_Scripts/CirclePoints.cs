using UnityEngine;
using System.Collections.Generic;

public class CirclePoints : MonoBehaviour
{
    public Transform markerPrefab;
    [Range(1, 100)]
    public int pointCount;
    public float radius;

    public float spin;
    public Vector3 axis = Vector3.up;

    public List<Transform> markers;


    public void Start()
    {
        markers = new List<Transform>();
        InitMarkers();
    }

    public void Update()
    {

        if (pointCount != markers.Count)
        {
            InitMarkers();
        }

        ////// the core bit ///////
        Quaternion quaternion = Quaternion.AngleAxis(360f / (float)(pointCount - 1), transform.up);
        Vector3 vec3 = transform.forward * radius;
        for (int index = 0; index < pointCount-1; ++index)
        {
            markers[index].position = transform.position + vec3;
            // update for the next one
            vec3 = quaternion * vec3;
        }
        ////// end of the core bit ///////

            transform.Rotate(axis, Time.deltaTime * spin);
    }

    private void InitMarkers()
    {
        if (pointCount > markers.Count)
        {
            for (int i = markers.Count; i < pointCount-1; i++)
            {
                // doesn't matter, we're updating the positions later
                markers.Add(Instantiate(markerPrefab, Vector3.zero, Quaternion.identity) as Transform);
            }
        }
        if (pointCount < markers.Count)
        {
            while (pointCount < markers.Count)
            {
                Destroy(markers[0].gameObject);
                markers.RemoveAt(0); // dont miss this line out!!
            }
        }
    }
}
