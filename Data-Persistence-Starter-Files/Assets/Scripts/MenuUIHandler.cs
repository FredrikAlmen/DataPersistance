#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public static string playerName;

    private void Start()
    {

    }

    public void SaveName()
    {
        playerName = nameInput.GetComponent<TMP_InputField>().text;
        MainManagerMenu.Instance.playerName = playerName;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetHighScore()
    {
        MainManagerMenu.Instance.ResetHighScore();
    }

    public void Exit()
    {
        
       // MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    //public void SaveColorClicked()
    //{
    //    MainManager.Instance.SaveColor();
    //}

    //public void LoadColorClicked()
    //{
    //    MainManager.Instance.LoadColor();
    //    ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    //}
}


