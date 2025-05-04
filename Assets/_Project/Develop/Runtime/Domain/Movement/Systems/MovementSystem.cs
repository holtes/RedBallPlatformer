using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.InputFeature.Components;
using _Project.Develop.Runtime.Domain.MovementFeature.Components;
using Leopotam.Ecs;
using System.Numerics;

namespace _Project.Develop.Runtime.Domain.MovementFeature.Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputData, Movement, Velocity> _movementfilter;

        private readonly TimeService _timeService;

        public MovementSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {
            foreach (var i in _movementfilter)
            {
                ref var input = ref _movementfilter.Get1(i);
                ref var move = ref _movementfilter.Get2(i);
                ref var velocity = ref _movementfilter.Get3(i);

                if (input.Direction != Vector2.Zero)
                {
                    velocity.Value.X = input.Direction.X * move.Speed * _timeService.DeltaTime;
                }
            }
        }
    }
}