using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class SpawnAnimals : MonoBehaviour
{
    public GameObject animalPrefab;
    public float respawnTime = 20.0F;

    public float speed = 12.0F;
    public float rotSpeed = 100.0F;
    static Animator anim;
    private Rigidbody rb;
    private ArrayList spawnLocations;
    public Transform goal;
    AudioSource audio;
    public AudioClip howl;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = new ArrayList();
        spawnLocations.Add(new Vector3(-108, 12.22304F, 81));
        spawnLocations.Add(new Vector3(-78, 12.22304F, 1.8F));
        spawnLocations.Add(new Vector3(.22F, 12.22304F, -104));
        //spawnLocations.Add(new Vector3(32, 12.22304F, 27));
        spawnLocations.Add(new Vector3(44, 15.53F, -112));
        spawnLocations.Add(new Vector3(-115, 12.22304F, 116));

        rb = this.GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
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
        //randIndex = 3;
        Vector3 randStartingPos = (Vector3)spawnLocations[randIndex];

        o.transform.position = randStartingPos;
        audio.PlayOneShot(howl, .3F);

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
