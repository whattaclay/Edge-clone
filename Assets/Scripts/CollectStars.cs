using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStars : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Destroy(gameObject);
            GameStateManager.Instance.StarCounter();
        }
    }
}
