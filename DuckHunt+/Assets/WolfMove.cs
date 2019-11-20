using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMove : MonoBehaviour
{
    //public float speed = 10.0F;
    //public float rotSpeed = 100.0F;
    static Animator anim;
    private Rigidbody rb;
    //private ArrayList spawnLocations;  

    // Start is called before the first frame update
    void Start()
    {
        //spawnLocations = new ArrayList();
        //spawnLocations.Add(new Vector3(-128, 12.22304F, 81));
        //spawnLocations.Add(new Vector3(-128, 12.22304F, -39));
        //spawnLocations.Add(new Vector3(-8, 12.22304F, -149));

        rb = this.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) > 200)
        {
            Destroy(this.gameObject);
        }
        anim.SetBool("wolfRun", true);
        Vector3 vel = rb.velocity;
        float angle = Mathf.Atan(vel.x / vel.z);
        //transform.eulerAngles = new Vector3(0, angle * Mathf.Rad2Deg, 0);


        //float translation = Input.GetAxis("Vertical") * speed;
        //float rotation = Input.GetAxis("Horizontal") * rotSpeed;
        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);


        //if (translation != 0)
        //    anim.SetBool("wolfRun", true);
        //else
        //    anim.SetBool("wolfRun", false);


    }
}
