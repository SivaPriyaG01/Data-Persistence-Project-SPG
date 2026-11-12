using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(LoadMainScene);
        quitButton.onClick.AddListener(QuitGame);
        inputName.onEndEdit.AddListener(SetPlayerName);
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("main");
    }

    void QuitGame()
    {
        EditorApplication.ExitPlaymode();
    }

    void SetPlayerName(string name)
    {
        if(SessionManager.Instance!=null)
        {
            SessionManager.Instance.playerName=name;
        }
    }

}
