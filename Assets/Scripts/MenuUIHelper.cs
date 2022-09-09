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
    [SerializeField] private Text nameText;

    public void StartButtonClicked()
    {
        if (nameText.text.Length > 0) {
            DataSaver.Instance.username = nameText.text;
            SceneManager.LoadScene(1);
        }
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
