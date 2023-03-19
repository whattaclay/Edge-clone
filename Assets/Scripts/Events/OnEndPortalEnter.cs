using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Events
{
    public class OnEndPortalEnter : MonoBehaviour
    {
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject winGameObjects;
        [SerializeField] private GameObject playAgainObjects;
        public void EndScreen()
        {
            menuCanvas.SetActive(true);
            winGameObjects.SetActive(true);
            playAgainObjects.SetActive(false);
            Time.timeScale = 0;
        }
    }
}