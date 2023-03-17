using DG.Tweening;
using UnityEngine;

namespace Platforms
{
    public class SecMovingPlatformPositioned : MovingPlatform
    {
        [SerializeField] private Transform _pos1;
        [SerializeField] private Transform _pos2;
        [SerializeField] private Transform _pos3;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private Ease _ease = Ease.Linear;
        private Transform _currentPos;
        private bool _isMoving = false;
        private Transform _switcherPos;

        private void Start()
        {
            _currentPos= _pos3;
            transform.position = _pos3.position;
        }
        public override void Move()
        {   
            if (_isMoving) return;
            _switcherPos = _currentPos != _pos3 ? _pos3 : _pos1;
            _isMoving = true;
            MoveToPos(_pos2);
        }
        private void MoveToPos(Transform targetPos)
        {
            var distance = Vector3.Distance(transform.position, targetPos.position);
            var duration = distance / _speed;
            _currentPos = targetPos;
            transform.DOMove(targetPos.position, duration).SetEase(_ease).OnComplete(OnComplete);
        }
        private void OnComplete()
        {
            if (_currentPos == _switcherPos)
            {
                _isMoving = false;
                return;
            }
            MoveToPos(_switcherPos);
        }
    }
}