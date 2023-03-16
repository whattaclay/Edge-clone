using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platforms
{
    public class FallingPlatform : MovingPlatform
    {
        [SerializeField] private float distance = 5f;
        [SerializeField] private float duration = 1f;
        [SerializeField] private float delay = 0.5f;
        public override void Move()
        {
            transform.DOMove(transform.position + Vector3.down * distance, duration).SetDelay(delay).OnComplete(OnComplete);
        }

        private void OnComplete()
        { 
            Destroy(gameObject);
        }
    }
}