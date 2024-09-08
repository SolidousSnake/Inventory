using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Code.Runtime.Services.Input
{
    public class InputService : MonoBehaviour, ITickable
    {
        private Vector2 _movementVector;

        public event Action<Vector3> MovementButtonPressed;
        
        public void OnMove(InputAction.CallbackContext ctx) => _movementVector = ctx.ReadValue<Vector2>();
        
        public void Tick()
        {
            MovementButtonPressed?.Invoke(_movementVector);
        }
    }
}