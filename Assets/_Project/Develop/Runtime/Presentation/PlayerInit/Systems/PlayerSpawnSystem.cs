using _Project.Develop.Runtime.Domain.PlayerInitFeature.Components;
using _Project.Develop.Runtime.Presentation.MovementFeature.Components;
using _Project.Develop.Runtime.Presentation.PlayerInitFeature.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.PlayerInitFeature.Systems
{
    public sealed class PlayerSpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<PlayerSpawnRequest> _playerFilter;

        private readonly GameObject _playerPrefab;
        private readonly Transform _spawnPoint;
        private readonly Transform _sceneRoot;

        public PlayerSpawnSystem(GameObject playerPrefab, Transform spawnPoint, Transform sceneRoot)
        {
            _playerPrefab = playerPrefab;
            _spawnPoint = spawnPoint;
            _sceneRoot = sceneRoot;
        }

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                var playerEntity = _playerFilter.GetEntity(i);

                var playerGO = Object.Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity, _sceneRoot);

                var playerRigidbody = playerGO.GetComponent<Rigidbody2D>();

                ref var rigidbodyRef = ref playerEntity.Get<RigidbodyRef>();
                rigidbodyRef.Rigidbody = playerRigidbody;

                ref var cameraInitRequest = ref _world.NewEntity().Get<CameraInitRequest>();
                cameraInitRequest.PlayerTransform = playerGO.transform;
            }
        }
    }
}