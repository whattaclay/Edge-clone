using UnityEngine;

namespace Events
{
    public class SetFXWhiteButton : MonoBehaviour
    {
        [SerializeField] private GameObject whiteButtonFX;

        public void SetFXOn()
        {
            whiteButtonFX.SetActive(true);
        }
    }
}