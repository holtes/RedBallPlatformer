using _Project.Develop.Runtime.Domain.MovementFeature.Components;
using _Project.Develop.Runtime.Presentation.MovementFeature.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.MovementFeature.Systems
{
    public sealed class ApplyPhysicsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Velocity, RigidbodyRef> _physicsFilter = null;

        public void Run()
        {
            foreach (var i in _physicsFilter)
            {
                ref var velocity = ref _physicsFilter.Get1(i);
                var rb = _physicsFilter.Get2(i).Rigidbody;

                var veclocityUnity = new Vector2(velocity.Value.X, velocity.Value.Y);

                rb.AddForce(veclocityUnity, ForceMode2D.Impulse);
                velocity.Value = System.Numerics.Vector2.Zero;
            }
        }
    }
}