using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameState : MonoBehaviour
{
    public const float fullHealth = 10;
    public static float health = fullHealth;
    public static int score = 0;
    public static AudioSource deathAudioSource;
    private TextMeshProUGUI textMesh;
    public TextMeshPro healthText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            restartGame();
        }   
    }

    public static void restartGame()
    {
        health = fullHealth;
        score = 0;
        AudioSource dieSound = GameObject.Find("Player").GetComponent<AudioSource>();
        dieSound.PlayOneShot(dieSound.clip);

        // wolves and ducks included with animal_tag
        GameObject[] animals = GameObject.FindGameObjectsWithTag("animal_tag");
        foreach (GameObject animal in animals)
        {  
            Destroy(animal);
        }
    }
}
