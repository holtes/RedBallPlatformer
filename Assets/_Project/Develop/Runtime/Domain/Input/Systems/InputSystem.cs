using _Project.Develop.Runtime.Domain.InputFeature.Components;
using _Project.Develop.Runtime.Domain.InputFeature.Models;
using Leopotam.Ecs;
using System.Numerics;

namespace _Project.Develop.Runtime.Domain.InputFeature.Systems
{
    public sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputData> _inputFilter;
        private readonly EcsFilter<ButtonInteractEvent> _buttonInteractEventFilter;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var input = ref _inputFilter.Get1(i);

                foreach (var j in _buttonInteractEventFilter)
                {
                    ref var button = ref _buttonInteractEventFilter.Get1(j);

                    switch (button.BtnType)
                    {
                        case BtnTypes.Left:
                            input.Direction += new Vector2(-1, 0);
                            break;
                        case BtnTypes.Right:
                            input.Direction += new Vector2(1, 0);
                            break;
                        case BtnTypes.Jump:
                            input.JumpPressed = true;
                            break;
                    }

                    _buttonInteractEventFilter.GetEntity(j).Destroy();
                }
            }
        }
    }
}