using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private Text score, game_over_text, high_score_text;
    [SerializeField] private Button play_again,shoot_arrow;
    [SerializeField] private AudioSource pts;

    private int scoreIndex = 0,highScore;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
            shoot_arrow.gameObject.SetActive(true);

        highScore = PlayerPrefs.GetInt("high_score", 0);
        high_score_text.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore()
    {
        pts.Play();
        scoreIndex++;
        score.text = scoreIndex.ToString();
        
    }

    public void game_over()
    {
        if(scoreIndex >  highScore)
            PlayerPrefs.SetInt("high_score", scoreIndex);
        game_over_text.gameObject.SetActive(true);
        play_again.gameObject.SetActive(true);
    }

    public void reload_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void start_game()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
