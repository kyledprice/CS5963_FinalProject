using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnDucks : MonoBehaviour
{
    public GameObject duckPrefab;
    private float respawnTime = 1.0F;
    private const double perim = 80.0;
    private const double vel = 20.0;
    private const float velAnglePadding = 30.0F;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(duckWave());
    }
    public void spawnDuck()
    {
        GameObject o = Instantiate(duckPrefab) as GameObject;
        startRandom(o);
    }
    public double toRad(double angle)
    {
        return (Math.PI / 180) * angle;
    }
    private void startRandom(GameObject o)
    {
        double posAngle = toRad((double)UnityEngine.Random.Range(0, 360));
        o.transform.position = new Vector3((float)(perim * Math.Cos(posAngle)), 20.0F, (float)(perim * Math.Sin(posAngle)));
        double velAngle = toRad((double)UnityEngine.Random.Range((float)posAngle - 90.0F + velAnglePadding, (float)posAngle + 90.0F - velAnglePadding));
        o.GetComponent<Rigidbody>().velocity = new Vector3((float)(vel * Math.Cos(velAngle)) * -1.0F, 0.0F, (float)(vel * Math.Sin(velAngle)) * -1.0F);
        //o.GetComponent<Rigidbody>().transform.Rotate(0, (float)velAngle, 0);
        //o.GetComponent<Rigidbody>().transform.localEulerAngles = new Vector3(o.GetComponent<Rigidbody>().transform.localEulerAngles.x, 
        //                                                                  (float)velAngle,
        //                                                                  o.GetComponent<Rigidbody>().transform.localEulerAngles.z);
        //o.transform.localEulerAngles = new Vector3(o.transform.localEulerAngles.x,
        //                                           o.transform.localEulerAngles.y - (float)velAngle,
        //                                           o.transform.localEulerAngles.z);
        //transform.localRotation = Quaternion.LookRotation(o.GetComponent<Rigidbody>().velocity); ;
        //Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //Vector3 lookDirection = moveDirection + o.transform.position;
        //o.transform.LookAt(lookDirection);
        o.transform.localEulerAngles = new Vector3(0,
                                                   (float)velAngle,
                                                   0);
    }
    IEnumerator duckWave()
    {
        while (true)
        {
            //UnityEngine.Debug.Log("what the fuck");
            yield return new WaitForSeconds(respawnTime);
            spawnDuck();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
