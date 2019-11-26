using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private Vector3 max;
    public Transform target;
    private GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("[CameraRig]");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, cam.transform.position) > 90)
            Destroy(this.gameObject);

    }
}
