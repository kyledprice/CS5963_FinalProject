using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfMove : MonoBehaviour
{
    static Animator anim;
    private Rigidbody rb;
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        goal = GameObject.Find("[CameraRig]").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, goal.transform.position) <= 4)
        {
            Destroy(this.gameObject);
        }
        anim.SetBool("wolfRun", true);
    }
}
