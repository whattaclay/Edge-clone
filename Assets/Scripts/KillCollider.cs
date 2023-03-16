
using UnityEngine;

public class KillCollider : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            GameStateManager.Instance.Die();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            GameStateManager.Instance.Die();
        }
    }
    
    
}
