using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnAnimals : MonoBehaviour
{
    public GameObject animalPrefab;
    public float respawnTime = 1.0F;

    public float speed = 10.0F;
    public float rotSpeed = 100.0F;
    static Animator anim;
    private Rigidbody rb;
    private ArrayList spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new ArrayList();
        spawnLocations.Add(new Vector3(-128, 12.22304F, 81));
        spawnLocations.Add(new Vector3(-128, 12.22304F, -39));
        spawnLocations.Add(new Vector3(-8, 12.22304F, -149));

        rb = this.GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();

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
        Vector3 randStartingPos = (Vector3)spawnLocations[randIndex];
        o.transform.position = randStartingPos;
        float h = Mathf.Sqrt(randStartingPos.x * randStartingPos.x + randStartingPos.z * randStartingPos.z);
        float theta = Mathf.Atan(randStartingPos.z / randStartingPos.x);
        float theta2 = theta - Mathf.PI;
        o.GetComponent<Rigidbody>().velocity = new Vector3(speed * Mathf.Sin(theta2), 0, speed * Mathf.Cos(theta2));
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
        //float translation = Input.GetAxis("Vertical") * speed;
        //float rotation = Input.GetAxis("Horizontal") * rotSpeed;
        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, 90, 0);


        //if (translation != 0)
        //    anim.SetBool("wolfRun", true);
        //else
        //    anim.SetBool("wolfRun", false);

    }
}
