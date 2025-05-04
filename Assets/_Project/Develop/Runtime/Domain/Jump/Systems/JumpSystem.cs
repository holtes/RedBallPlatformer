using _Project.Develop.Runtime.Domain.InputFeature.Components;
using _Project.Develop.Runtime.Domain.JumpFeature.Components;
using _Project.Develop.Runtime.Domain.MovementFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.JumpFeature.Systems
{
    public sealed class JumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputData, Jump, Velocity> _jumpFilter;

        public void Run()
        {
            foreach (var i in _jumpFilter)
            {
                ref var input = ref _jumpFilter.Get1(i);
                ref var jump = ref _jumpFilter.Get2(i);
                ref var velocity = ref _jumpFilter.Get3(i);

                if (input.JumpPressed && jump.IsGrounded)
                {
                    velocity.Value.Y += jump.JumpForce;
                }
            }
        }
    }
}