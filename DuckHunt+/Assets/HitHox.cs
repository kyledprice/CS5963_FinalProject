using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("I am duck and just got shot!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
