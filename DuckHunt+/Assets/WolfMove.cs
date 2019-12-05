using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Diagnostics;
using System;

public class WolfMove : MonoBehaviour
{
    static Animator anim;
    private Rigidbody rb;
    public Transform goal;
    public AudioClip growl;
    AudioSource audio;
    const float audioThreshold = 30F;
    const int damageRadius = 5;
    const int damageDelta = 2;
    bool howlPlayed = false;
    Stopwatch stopWatch;

    void OnTriggerEnter(Collider other)
    {
        //if (collision.collider.tag == "bullet_tag") 
            UnityEngine.Debug.Log("wolf down");
        //this.GetComponent<Rigidbody>().useGravity = true;
        //this.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
    }
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        goal = GameObject.Find("Player").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        audio = GetComponent<AudioSource>();
        stopWatch = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, goal.transform.position);
        TimeSpan ts = stopWatch.Elapsed;
        
        // if within distance of when growling should be heard 
        if (dist <= audioThreshold)
        {
            // if initial how hasn't occurred, make it happ'n cap'n
            if (!howlPlayed)
            {
                audio.PlayOneShot(growl, .5F);
                howlPlayed = true;
            }
            // if distance of wolf and camera is enough to cause damage
            if (dist <= damageRadius)
            {
                // if wolf stays within proximity of camera long enough, cause 
                // damage and restart timer
                if (!stopWatch.IsRunning)
                {
                    stopWatch.Restart();
                }
                else
                if (ts.Seconds > damageDelta)
                {
                    GameState.health--;
                    stopWatch.Restart();
                }
            }
            else
            {
                stopWatch.Stop();
            }

            // audio is a function of distance from player 
            audio.volume = 1 - (dist / audioThreshold);
        }
        else
        {
            stopWatch.Stop();
            audio.Stop();
            howlPlayed = false;
        }

        //if (dist <= 4)
        //{
        //    Destroy(this.gameObject);
        //}
        anim.SetBool("wolfRun", true);
    }
}
