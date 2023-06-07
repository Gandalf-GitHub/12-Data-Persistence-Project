using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameField;
    [SerializeField] GameObject missingNameText;
    [SerializeField] TMP_Text currentHighscore;

    private void Awake()
    {
        if (GameManager.Instance.highscore == 0)
        {
            currentHighscore.text = $"Best Score: N/A : 0";
        }
        else
        {
            currentHighscore.text = $"Best Score: {GameManager.Instance.highscoreName} : {GameManager.Instance.highscore}";
        }
    }

    public void StartNew()
    {
        string playerName = playerNameField.text;

        if (string.IsNullOrEmpty(playerName) || string.IsNullOrWhiteSpace(playerName))
        {
            missingNameText.SetActive(true);
            return;
        }

        GameManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
