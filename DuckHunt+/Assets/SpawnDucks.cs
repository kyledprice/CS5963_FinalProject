﻿using System.Collections;
using UnityEngine;
using System;

public class SpawnDucks : MonoBehaviour
{
    public GameObject duckPrefab;
    private float respawnTime = 1.0F;
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
    public double toRad(double angle)
    {
        return (Math.PI / 180) * angle;
    }
    private void startRandom(GameObject o)
    {
        // spawns ducks on outer edge of a constant perimenter at random spot 
        // and gives them a random trajectory toward the center of the circle
        double posAngle = toRad((double)UnityEngine.Random.Range(0, 360));
        float randHeight = UnityEngine.Random.Range(20, 60);
        o.transform.position = new Vector3((float)(Duck.perimRad * Math.Cos(posAngle)), randHeight, (float)(Duck.perimRad * Math.Sin(posAngle)));
        double velAngle = toRad((double)UnityEngine.Random.Range((float)posAngle - 90.0F + velAnglePadding, (float)posAngle + 90.0F - velAnglePadding));
        Vector3 velVector = new Vector3((float)(vel * Math.Cos(velAngle)) * -1.0F, 0.0F, (float)(vel * Math.Sin(velAngle)) * -1.0F);
        o.GetComponent<Rigidbody>().velocity = velVector;
        o.transform.rotation = Quaternion.LookRotation(velVector);

    }
    IEnumerator duckWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnDuck();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
