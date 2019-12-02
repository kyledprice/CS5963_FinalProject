using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfMove : MonoBehaviour
{
    static Animator anim;
    private Rigidbody rb;
    public Transform goal;
    public AudioClip growl;
    AudioSource audio;
    const float audioThreshold = 30F;
    bool played = false;
    float hitCount = 0;
    float hitTheshold = 500;
    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        goal = GameObject.Find("Player").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, goal.transform.position);
        if (dist <= audioThreshold)
        {
            if (!played)
            {
                audio.PlayOneShot(growl, .5F);
                played = true;
            }
            if (dist <= 5)
            {
                if (hitCount++ % hitTheshold == 0)
                {
                    GameState.health--;
                }
            }
            audio.volume = 1 - (dist / audioThreshold);
        }
        else
        {
            audio.Stop();
            played = false;
        }

        //if (dist <= 4)
        //{
        //    Destroy(this.gameObject);
        //}
        anim.SetBool("wolfRun", true);
    }
}
