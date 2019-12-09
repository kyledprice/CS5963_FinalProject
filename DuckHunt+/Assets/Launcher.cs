using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private float launchForce = 70000000000000f;

    public Hand hand;
    public SteamVR_Action_Boolean myAction;

    // Test members
    public Vector3 velocity;
    public float gravityMultiplier = 1f;
    public LayerMask hitMask = -1; // all layers by default
    public AudioSource shoot;

    void Start()
    {
        shoot = GetComponent<AudioSource>();
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
            LaunchProjectile();
            shoot.Play();
        }
    }
    public void Update()
    {
    }

    private void LaunchProjectile()
    {       
            var projectileInstance = Instantiate(
                projectilePrefab,
                firePoint.position,
                firePoint.rotation);

        projectileInstance.AddForce(firePoint.forward * launchForce * 1f);

    }
}
