using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    public Text scoreField;
    public Text waveField;

    public static int score;
    public static int wave;

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void AddWave()
    {

    }

    // Use this for initialization
    void Start()
    {
        score = 0;
        wave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreField.text = "Score: " + score;
        waveField.text = "Wave: " + wave;


    }
}
