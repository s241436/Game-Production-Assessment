using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class EndScreen : MonoBehaviour
{
    public PlayerController Controller;
    public TextMeshProUGUI Score;
    public float scoreValue;

    // Update is called once per frame
    void Update()
    {
        Controller = GetComponent<PlayerController>();
        float loadedScore = PlayerPrefs.GetFloat("PlayerScoreKey", 0);
        Score.text = loadedScore.ToString();
    }
}
