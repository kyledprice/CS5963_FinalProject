using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class SpawnAnimals : MonoBehaviour
{
    public GameObject animalPrefab;
    public float respawnTime = 1.0F;

    public float speed = 10.0F;
    public float rotSpeed = 100.0F;
    static Animator anim;
    private Rigidbody rb;
    private ArrayList spawnLocations;
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new ArrayList();
        spawnLocations.Add(new Vector3(-128, 12.22304F, 81));
        spawnLocations.Add(new Vector3(-128, 12.22304F, -39));
        spawnLocations.Add(new Vector3(10, 12.22304F, -107));
        //spawnLocations.Add(new Vector3(97, 12.22304F, -61.5F));
        spawnLocations.Add(new Vector3(41, 12.22304F, -98));
        spawnLocations.Add(new Vector3(10, 12.22304F, -37));

        rb = this.GetComponent<Rigidbody>();
        StartCoroutine(animalWave());
    }
    public void spawnAnimal()
    {
        GameObject o = Instantiate(animalPrefab) as GameObject;
        startRandom(o);
    }
    private void startRandom(GameObject o)
    {
        int randIndex = UnityEngine.Random.Range(0, spawnLocations.Count);
        //randIndex = 5;
        Vector3 randStartingPos = (Vector3)spawnLocations[randIndex];
        UnityEngine.Debug.Log(randIndex);

        //goal = GameObject.Find("[CameraRig]").transform;
        //NavMeshAgent agent = o.GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;

        o.transform.position = randStartingPos;

        //goal = GameObject.Find("[CameraRig]").transform;
        //NavMeshAgent agent = o.GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }
    IEnumerator animalWave()
    {
        while (true)
        {
            //UnityEngine.Debug.Log("what the fuck");
            yield return new WaitForSeconds(respawnTime);
            spawnAnimal();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
