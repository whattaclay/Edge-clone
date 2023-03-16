using UnityEngine;

namespace Ai
{
    public interface IAiState
    {
        public Vector3 GetDirection(Vector3 transformPosition);
        public void OnUpdate(float deltaTime);
        public IAiState GetNextState();
    }
}