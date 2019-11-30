using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ViveGameController : MonoBehaviour
{
    public SteamVR_Action_Boolean myAction;

    public Hand hand;

    public GameObject projectile;

    private void OnEnable()
    {
        if (hand == null)
            hand = this.GetComponent<Hand>();

        if (myAction == null)
        {
            return;
        }
        myAction.AddOnChangeListener(OnMyActionChange, hand.handType);
    }

    private void OnDisable()
    {
        if (myAction != null)
            myAction.RemoveOnChangeListener(OnMyActionChange, hand.handType);
    }
    // Start is called before the first frame update

    private void OnMyActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources input_Sources,bool newValue)
    {
        if (newValue)
        {
            Instantiate(projectile, hand.transform.position, hand.transform.rotation);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
