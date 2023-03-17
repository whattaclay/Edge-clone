using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Ai
{
    [RequireComponent(typeof(CubeController))]
    public class AiStateMachine : MonoBehaviour
    {
        [SerializeField] private Vector3 _startDirection = Vector3.forward;
        private IAiState _currentState;
        private CubeController _cubeController;
        private Rigidbody _rigidbody;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _currentState = new WanderState(_startDirection);
            _cubeController = GetComponent<CubeController>();
        }
        
        private void Update()
        {
            _rigidbody.isKinematic = false;
            var direction = _currentState.GetDirection(transform.position);
            _cubeController.Move(direction);
            _currentState.OnUpdate(Time.deltaTime);
            var newState = _currentState.GetNextState();
            if (newState != null)
            {
                _currentState = newState;
            }
        }
    }
}