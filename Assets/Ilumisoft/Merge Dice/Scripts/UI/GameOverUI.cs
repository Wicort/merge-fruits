using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Ilumisoft.MergeDice
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField]
        Text scoreText = null;

        [SerializeField]
        Text highscoreText = null;

        [SerializeField]
        Text messageText = null;

        void Start()
        {
            if (HasNewHighscore())
            {
                UpdateHighscore();
                DisplayHighscore(false);
                DisplayNewHighscoreMessage();
            }
            else
            {
                DisplayHighscore(true);
                DisplayNormalMessage();
            }

            DisplayScore();
        }

        bool HasNewHighscore()
        {
            if (Score.Value > Highscore.Value)
            {
                YandexGame.NewLeaderboardScores("TopScores", Score.Value);
                return true;
            }
            else return false;
        }

        void UpdateHighscore()
        {
            Highscore.Value = Score.Value;
        }

        void DisplayNewHighscoreMessage()
        {
            messageText.text = "NEW HIGHSCORE";
            if (YandexGame.SDKEnabled)
            {
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    messageText.text = "НОВЫЙ РЕКОРД";
                }
            }
        }

        void DisplayNormalMessage()
        {
            messageText.text = "ANOTHER TRY?";
            if (YandexGame.SDKEnabled)
            {
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    messageText.text = "ЕЩЕ РАЗ?";
                }
            }
        }

        void DisplayHighscore(bool show)
        {
            if (show)
            {
                highscoreText.text = $"BEST\n{Highscore.Value}";
                if (YandexGame.SDKEnabled)
                {
                    if (YandexGame.EnvironmentData.language == "ru")
                    {
                        highscoreText.text = $"ЛУЧШИЙ\n{Highscore.Value}";
                    }
                }
            }
            else
            {
                highscoreText.text = string.Empty;
            }
        }

        void DisplayScore()
        {
            scoreText.text = Score.Value.ToString();
        }
    }
}
