using UnityEngine;

namespace Events
{
    public class TP : MonoBehaviour
    {
        [SerializeField] private Vector3 tpPoint = new Vector3(1f, 1f, 1f);
        [SerializeField] private GameObject _player;

        public void TPPosition()
        {
            _player.transform.position = tpPoint;
            Debug.Log("tp");
        }
        
    }
}
