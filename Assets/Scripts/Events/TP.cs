using UnityEngine;

namespace Events
{
    public class TP : MonoBehaviour
    {
        [SerializeField] private Vector3 tpPoint = new Vector3(1f, 1f, 1f);

        public void TPPosition()
        {
            var _player = GameStateManager._player;
            _player.transform.position = tpPoint;
        }
        
    }
}
