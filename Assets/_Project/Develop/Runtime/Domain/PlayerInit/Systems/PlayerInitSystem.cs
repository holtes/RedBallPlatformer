using _Project.Develop.Runtime.Domain.InputFeature.Components;
using _Project.Develop.Runtime.Domain.JumpFeature.Components;
using _Project.Develop.Runtime.Domain.MovementFeature.Components;
using _Project.Develop.Runtime.Domain.PlayerInitFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.PlayerInitFeature.Systems
{
    public sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        private readonly PlayerInitData _playerInitData;

        public PlayerInitSystem(PlayerInitData playerInitData)
        {
            _playerInitData = playerInitData;
        }

        public void Init()
        {
            var playerEntity = _world.NewEntity();

            ref var input = ref playerEntity.Get<InputData>();

            ref var velocity = ref playerEntity.Get<Velocity>();

            ref var movement = ref playerEntity.Get<Movement>();
            movement.Speed = _playerInitData.PlayerSpeed;

            ref var jump = ref playerEntity.Get<Jump>();
            jump.JumpForce = _playerInitData.PlayerJumpForce;

            playerEntity.Get<PlayerSpawnRequest>();
        }
    }
}