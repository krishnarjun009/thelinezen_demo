using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIManager : MonoBehaviour {

    public Text ScoreText;

    public GameObject MenuPnl;
    public GameObject GameOverPnl;
    public GameObject GamePlayPnl;

    public void MenuSetActive(bool visible)
    {
        MenuPnl.SetActive(visible);
    }

    public void GameOverSetActive(bool visible)
    {
        GameOverPnl.SetActive(visible);
    }

    public void GamePlaySetActive(bool visible)
    {
        GamePlayPnl.SetActive(visible);
    }
}
