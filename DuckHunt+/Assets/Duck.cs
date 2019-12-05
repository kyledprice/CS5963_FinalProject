using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public const double perimRad = 120.0;
    private Vector3 max;
    public Transform target;
    private Vector3 camPos;
    public Animator anim;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        //if (collision.collider.tag == "bullet_tag")
        UnityEngine.Debug.Log("duck down");
        this.GetComponent<Rigidbody>().useGravity = true;
        anim.SetBool("duck_die", true);
        //this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    void Start()
    {
        camPos = GameObject.Find("Player").transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if duck's x/z component distance is out of perimeter
        if (Vector3.Distance(transform.position, new Vector3 (camPos.x, transform.position.y, camPos.z)) > perimRad + 1)
            Destroy(this.gameObject);

    }

}
