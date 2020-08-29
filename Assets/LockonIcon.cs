using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockonIcon : MonoBehaviour
{
    public GameObject worldTarget;
    Image lockIcon;

    Vector3 clearSize;

    public bool cleared = false;
    //public GameObject parentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.Find("Canvas").transform);

        lockIcon = GetComponent<Image>();

        clearSize = new Vector3(6000, 6000, 0);
    }

    public void ClearSelf()
    {
        cleared = true;
        lockIcon.CrossFadeAlpha(0, 1, true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (cleared)
            transform.localScale = Vector3.Lerp(transform.localScale, clearSize, Time.deltaTime * 0.0025f);

        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 10);

        lockIcon.rectTransform.position = Camera.main.WorldToScreenPoint(worldTarget.transform.position);

    }
}
