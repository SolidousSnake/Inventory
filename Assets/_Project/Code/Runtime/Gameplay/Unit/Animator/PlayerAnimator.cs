using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.Unit.Animator
{
    public class PlayerAnimator
    {
        private static readonly int Speed = UnityEngine.Animator.StringToHash("Speed");
        private static readonly int IsMoving = UnityEngine.Animator.StringToHash("IsMoving");
        
        private readonly UnityEngine.Animator _animator;

        public PlayerAnimator(UnityEngine.Animator animator)
        {
            _animator = animator;
        }

        public void Move(float speed)
        {
            if(speed == 0)
                StopMoving();
            else
                Move();
            
            _animator.SetFloat(Speed, speed, .1f, Time.deltaTime);
        }

        private void Move() => _animator.SetBool(IsMoving, true);
        private void StopMoving() => _animator.SetBool(IsMoving, false);
    }
}