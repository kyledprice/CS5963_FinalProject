using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LeftLauncher : MonoBehaviour
{

    public Hand hand;
    public SteamVR_Action_Boolean myAction;


    void Start()
    {

    }
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



    private void OnMyActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources input_Sources, bool newValue)
    {
        if (newValue)
        {
            if (actionIn.renderModelComponentName == "button_a")
            {
                UnityEngine.Debug.Log("a");
                GameState.restartGame();
            }
            else
            if (actionIn.renderModelComponentName == "button_b")
            {
                UnityEngine.Debug.Log("b");
                Application.Quit();
            }  
        }
    }
    public void Update()
    {
    }

}
