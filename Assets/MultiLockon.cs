using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiLockon : MonoBehaviour
{

    public GameObject lockonIcon;

    public float range = 100;

     public List<GameObject> targets = new List<GameObject>();

    Camera mainCam;
    public CirclePoints circlePoints;

    public Canvas mainCan;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        
    }

    IEnumerator Launch()
    {
        Component[] LockonIcons = mainCan.GetComponentsInChildren(typeof(LockonIcon), true);

        //foreach(Transform proj in circlePoints.markers)
        for (int j = 0; j < circlePoints.markers.Count; j++)
        {
                yield return new WaitForSeconds(0.1f);
                circlePoints.markers[j].GetComponent<HomingLockProjectile>().target = targets[j];
                circlePoints.markers[j].GetComponent<HomingLockProjectile>().launched = true;
                LockonIcons[j].GetComponent<LockonIcon>().ClearSelf();
        }

        circlePoints.pointCount = 1;
        circlePoints.markers.Clear();
        targets.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(Launch());
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 rayOrigin = mainCam.ViewportToWorldPoint( new Vector3(0.5f,0.5f, 0));

            RaycastHit hit;

            if(Physics.Raycast(rayOrigin, mainCam.transform.forward, out hit, range))
            {
                if(hit.transform.gameObject.tag == "lockon")
                {
                    var icon = Instantiate(lockonIcon);
                    icon.GetComponent<LockonIcon>().worldTarget = hit.transform.gameObject;

                    hit.transform.gameObject.tag = "lockedon";

                    circlePoints.pointCount += 1;
                    circlePoints.spin += 10;

                    targets.Add(hit.transform.gameObject);
                }

            }

        }
        
    }
}
