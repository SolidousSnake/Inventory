using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Gameplay.Stats;
using _Project.Code.Runtime.Gameplay.Unit.Animator;
using _Project.Code.Runtime.Gameplay.Unit.Movement;
using _Project.Code.Runtime.Gameplay.Unit.Rotation;
using _Project.Code.Runtime.Services.Input;
using _Project.Code.Runtime.UI.Bar;
using _Project.Code.Runtime.UI.View;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Gameplay.Unit.Facade
{
    public class PlayerFacade : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _rotationBody;
        [SerializeField] private float _rotationSpeed;

        [Inject] private StatsView _statsView;
        [Inject] private HealthBar _healthBar;
        [Inject] private InputService _inputService;
        [Inject] private ConfigProvider _configProvider;

        [field: SerializeField] public Health.Health Health { get; private set; }
        
        private PlayerAnimator _playerAnimator;
        private PhysicsMovement _physicsMovement;
        private UnitRotation _playerRotation;
        
        public PlayerStatsController StatsController { get; private set; }

        private void Start()
        {
            var playerStats = _configProvider.GetSingle<PlayerStats>();

            _physicsMovement = new PhysicsMovement(_rigidbody, transform);
            _playerRotation = new UnitRotation(_rotationBody);
            _playerAnimator = new PlayerAnimator(_animator);
            StatsController = new PlayerStatsController(playerStats, _statsView);

            StatsController.Initialize();
            Health.Initialize(playerStats.Health.Value);
            _healthBar.Initialize(Health);
            
            _physicsMovement.SetSpeed(playerStats.MovementSpeed.Value);
            _playerRotation.SetRotationSpeed(_rotationSpeed);

            _inputService.MovementButtonPressed += _physicsMovement.Move;
            _inputService.MovementButtonPressed += _playerRotation.RotateTowards;
        }

        private void Update() => _playerAnimator.Move(_rigidbody.velocity.magnitude);

        private void OnDestroy()
        {
            _inputService.MovementButtonPressed -= _physicsMovement.Move;
            _inputService.MovementButtonPressed -= _playerRotation.RotateTowards;
        }
    }
}