﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnDucks : MonoBehaviour
{
    public GameObject duckPrefab;
    public float respawnTime = 1.0F;
    private const double perim = 80.0;
    private const double vel = 10.0;
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
    private void startRandom(GameObject o)
    {
        double posAngle = (double)UnityEngine.Random.Range(0, 360);
        o.transform.position = new Vector3((float)(perim * Math.Cos(posAngle)), 20.0F, (float)(perim * Math.Sin(posAngle)));
        double velAngle = (double)UnityEngine.Random.Range((float)posAngle - 90.0F + velAnglePadding, (float)posAngle + 90.0F - velAnglePadding);
        o.GetComponent<Rigidbody>().velocity = new Vector3((float)(vel * Math.Cos(velAngle)) * -1.0F, 0.0F, (float)(vel * Math.Sin(velAngle)) * -1.0F);
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
