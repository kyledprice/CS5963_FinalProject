using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Vibration haptic;
    public SteamVR_Input_Sources hand;
    public ParticleSystem muzzleBlast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // vibrate when right trigger pulled
        if (trigger.GetStateDown(hand))
        {
            muzzleBlast.Play();
            haptic.Execute(0, 1000, 10, 1, hand);
        }
    }
}
