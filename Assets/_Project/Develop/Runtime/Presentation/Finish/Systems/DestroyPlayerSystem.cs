using _Project.Develop.Runtime.Domain.FinishFeature.Components;
using _Project.Develop.Runtime.Presentation.CameraFollowFeature.Components;
using _Project.Develop.Runtime.Presentation.MovementFeature.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.FinishFeature.Systems
{
    public sealed class DestroyPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyPlayerRequest> _requestFilter;
        private readonly EcsFilter<RigidbodyRef> _playerFilter;
        private readonly EcsFilter<CameraFollow> _cameraFilter;

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                foreach (var j in _playerFilter)
                {
                    ref var rbRef = ref _playerFilter.Get1(i);
                    var rigidbody = rbRef.Rigidbody;
                    Object.Destroy(rigidbody.gameObject);

                    _playerFilter.GetEntity(j).Destroy();
                }

                foreach (var j in _cameraFilter)
                {
                    _cameraFilter.GetEntity(j).Destroy();
                }

                _requestFilter.GetEntity(i).Destroy();
            }
        }
    }
}