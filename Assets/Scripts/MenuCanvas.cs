using UnityEngine;
using UnityEngine.Serialization;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    private bool _pauseGame = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pauseGame)
        {
            MenuCanvasOpen();
                
        }
        else if (Input.GetKeyDown(KeyCode.Escape)&& _pauseGame)
        {
            MenuCanvasExit();
        }
    }

    private void MenuCanvasOpen()
    {
        Time.timeScale = 0;
        menuCanvas.SetActive(true);
        _pauseGame = true;
    }
    public void MenuCanvasExit()
    {
        Time.timeScale = 1;
        menuCanvas.SetActive(false);
        _pauseGame = false;
    }
}