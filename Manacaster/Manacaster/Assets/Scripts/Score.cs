using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreAmount;
    private Text scoreText;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    // Update is called once/frame
    void Update () {
        scoreText.text = "Score: " + scoreAmount;
    }
}
