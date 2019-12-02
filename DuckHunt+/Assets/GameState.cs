using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public const float fullHealth = 10;
    public static float health = fullHealth;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(health);
        if (health <= 0)
        {
            restartGame();
        }   
    }
    void restartGame()
    {
        health = fullHealth;
        score = 0;

        // wolves and ducks included with animal_tag
        GameObject[] animals = GameObject.FindGameObjectsWithTag("animal_tag");
        foreach (GameObject animal in animals)
        {  
            Destroy(animal);
        }
    }
}
