using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GunController : MonoBehaviour
{
    public SteamVR_Action_Boolean shootAction;

    public Hand hand;

    private void OnEnable()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();

        if (shootAction == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned", this);
            return;
        }

        shootAction.AddOnChangeListener(OnshootActionChange, hand.handType);
    }

    private void OnDisable()
    {
        if (shootAction != null)
            shootAction.RemoveOnChangeListener(OnshootActionChange, hand.handType);
    }
    private void OnshootActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
    {
        if (newValue)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        StartCoroutine(DoShoot());
        //Debug.Log("bang");
        UnityEngine.Debug.Log("Bang");
    }

    private string DoShoot()
    {
        UnityEngine.Debug.Log("Bang");
        Debug.Log("Bang");
        return "bang";
    }

}
