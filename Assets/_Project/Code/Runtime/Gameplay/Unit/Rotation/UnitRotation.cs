using System;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.Unit.Rotation
{
    public class UnitRotation
    {
        private readonly Transform _body;

        private float _rotationSpeed;

        public UnitRotation(Transform body)
        {
            _body = body;
        }

        public void SetRotationSpeed(float speed)
        {
            if (speed <= 0)
                throw new Exception($"Rotation speed must be positive. Received: {speed}");

            _rotationSpeed = speed;
        }
        
        public void RotateTowards(Vector3 direction)
        {
            if(direction == Vector3.zero)
                return;

            var rotationVector = new Vector3(direction.x, 0f, direction.y);
            
            var targetRotation = Quaternion.LookRotation(rotationVector);
            var newRotation = Quaternion.Slerp(_body.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _body.rotation = newRotation;
        }
    }
}