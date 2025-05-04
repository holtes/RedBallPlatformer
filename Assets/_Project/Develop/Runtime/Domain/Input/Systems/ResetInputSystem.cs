using _Project.Develop.Runtime.Domain.InputFeature.Components;
using Leopotam.Ecs;
using System.Numerics;

namespace _Project.Develop.Runtime.Domain.InputFeature.Systems
{
    public sealed class ResetInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputData> _inputFilter;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var input = ref _inputFilter.Get1(i);
                input.Direction = Vector2.Zero;
                input.JumpPressed = false;
            }
        }
    }
}