using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Events
{
    public class OnTriggerEnterEvent : MonoBehaviour
    {
        public UnityEvent onPressed;
        [SerializeField] private string playerTag = "Player";
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag(playerTag))
            {
                onPressed.Invoke();
            }
        }
   }
}
