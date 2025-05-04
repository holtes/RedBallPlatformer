using _Project.Develop.Runtime.Presentation.CameraFollowFeature.Components;
using _Project.Develop.Runtime.Presentation.PlayerInitFeature.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.CameraFollowFeature.Systems
{
    public sealed class CameraInitSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<CameraInitRequest> _requestFilter;

        private readonly Camera _camera;
        private readonly BoxCollider2D _bounds;

        public CameraInitSystem(Camera camera, BoxCollider2D bounds)
        {
            _camera = camera;
            _bounds = bounds;
        }

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                ref var request = ref _requestFilter.Get1(i);
                var playerTransform = request.PlayerTransform;

                var cameraEntity = _world.NewEntity();
                ref var comp = ref cameraEntity.Get<CameraFollow>();

                comp.Camera = _camera;
                comp.TargetTransform = playerTransform;
                comp.Bounds = _bounds;

                _requestFilter.GetEntity(i).Destroy();
            }
        }
    }
}