using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    public GamePlayUIManager UIManager;

    public LineGenerator LineGenerate;

    public PlayerController Player;

    public Transform Camera;

    private float score;

    private float lastUpdate = 0f;

	// Use this for initialization
	void Start () {
        DataManager.isGameStart = false;
    }

    // Update is called once per frame
    void Update () {

        if (DataManager.isGameStart && Player.isDied)
        {
            CancelInvoke("UpdateScore");
            ResetCamera();
            LineGenerate.ResetLines();
            Player.ResetPlayer();
            DataManager.isGameStart = false;
            //Player.gameObject.SetActive(false);
            UIManager.GameOverSetActive(true);

            UIManager.ScoreText.text = "0";

            if (DataManager.GetScore() < DataManager.score)
                DataManager.SaveScore(DataManager.score);

            DataManager.score = 0;
        }

        if(!Player.isDied)
        {
            //score += 0.01f;
            //DataManager.score += (int)Mathf.Round(score);

            //UIManager.ScoreText.text = DataManager.score.ToString();
        }
	}

    public void OnPlayClick()
    {
        DataManager.isGameStart = true;
        LineGenerate.Initialize();
        Player.isDied = false;
        InvokeRepeating("UpdateScore", 0.5f, 1.0f);
        //Player.gameObject.SetActive(true);
        UIManager.MenuSetActive(false);
        UIManager.GamePlaySetActive(true);
    }

    private void UpdateScore()
    {
        DataManager.score += 1;

        UIManager.ScoreText.text = DataManager.score.ToString();
    }

    public void OnHomeClick()
    {
        UIManager.GamePlaySetActive(false);
        UIManager.GameOverSetActive(false);
        UIManager.MenuSetActive(true);
    }

    public void OnPlayAgainClick()
    {
        InvokeRepeating("UpdateScore", 0.5f, 1.0f);
        DataManager.isGameStart = true;
        LineGenerate.Initialize();
        Player.isDied = false;
        //Player.gameObject.SetActive(true);
        UIManager.GameOverSetActive(false);
    }

    private void ResetCamera()
    {
        Camera.position = new Vector3(0f, 0f, -10f);
    }
}
