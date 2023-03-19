using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuExit : MonoBehaviour
{
    public void MainMenuMove()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}