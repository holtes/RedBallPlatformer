using _Project.Develop.Runtime.Domain.JumpFeature.Components;
using _Project.Develop.Runtime.Presentation.MovementFeature.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.JumpFeature.Systems
{
    public sealed class GroundCheckApplySystem : IEcsRunSystem
    {
        private readonly EcsFilter<Jump, RigidbodyRef> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var ground = ref _filter.Get1(i);
                ref var rbRef = ref _filter.Get2(i);

                var rigidbody = rbRef.Rigidbody;

                if (rigidbody == null) continue;

                ground.IsGrounded = Physics2D.Raycast(rigidbody.position, Vector3.down, 0.1f);
            }
        }
    }
}