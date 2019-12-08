using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public TextMeshPro scoreText;
    public TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "Score " + GameState.score.ToString();
    }
}
