using UnityEngine;

public class Ui : MonoBehaviour
{
    public void RestartGame()
    { 
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
