using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game.Data
{
    public static class DataManager
    {
        public static bool isGameStart;

        public static int score;

        public static void SaveScore(int score)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
        }

        public static int GetScore()
        {
            return PlayerPrefs.GetInt("hightscore");
        }
    }
}
