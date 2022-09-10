using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHelper : MonoBehaviour
{
    [SerializeField] private InputField input;
    [SerializeField] private Text nameText;
    [SerializeField] private Text bestScore;

    private void Start()
    {
        DisplayHighScore();
        if (DataSaver.Instance.getIsScoreLoaded() && 
            DataSaver.Instance.highscore > 0)
        {
            input.text = DataSaver.Instance.highscoreName;
        }
    }

    private void DisplayHighScore()
    {
        if (DataSaver.Instance.getIsScoreLoaded())
        {
            bestScore.text = $"Best Score: {DataSaver.Instance.highscoreName}: " +
                $"{DataSaver.Instance.highscore}";
        }
    }

    public void StartButtonClicked()
    {
        if (nameText.text.Length > 0) {
            DataSaver.Instance.username = nameText.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ResetButtonClicked()
    {
        DataSaver.Instance.ResetHighScore();
        DisplayHighScore();
        input.text = "";
    }

    public void QuitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
