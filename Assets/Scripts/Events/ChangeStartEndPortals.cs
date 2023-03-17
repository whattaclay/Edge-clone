using UnityEngine;

namespace Events
{
    public class ChangeStartEndPortals : MonoBehaviour
    {
        [SerializeField] private GameObject startPortal;
        [SerializeField] private GameObject endPortal;

        public void ChangePortals()
        {
            startPortal.SetActive(false);
            endPortal.SetActive(true);
        }
    }
}