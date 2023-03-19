using UnityEngine;
using UnityEngine.SceneManagement;

namespace Events
{
    public class PlayAgainButton : MonoBehaviour
    {
        public void PlayAgain()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
    }
}