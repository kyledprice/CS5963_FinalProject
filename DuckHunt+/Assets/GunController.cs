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
        if (trigger.GetStateDown(hand))
        {
            muzzleBlast.Play();
            haptic.Execute(0, 1000, 10, 1, hand);
        }
    }

    //private void OnEnable()
    //{
    //    if (hand == null)
    //        hand = this.GetComponent<Hand>();

    //    if (myAction == null)
    //    {
    //        return;
    //    }
    //    myAction.AddOnChangeListener(OnMyActionChange, hand.handType);
    //}

    //private void OnDisable()
    //{
    //    if (myAction != null)
    //        myAction.RemoveOnChangeListener(OnMyActionChange, hand.handType);
    //}
//    private void OnMyActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources input_Sources, bool newValue)
//    {
//        haptic.Execute(0, 1000, 10, 1, hand);
//    }
}
