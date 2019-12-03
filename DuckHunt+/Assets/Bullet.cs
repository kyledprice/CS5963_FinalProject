using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(camPos.x, transform.position.y, camPos.z)) > Duck.perimRad + 1)
            Destroy(this.gameObject);


    }
}
