using _Project.Develop.Runtime.Domain.TimerFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.TimerFeature.Systems
{
    public sealed class TimerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        public void Init()
        {
            var timerEntity = _world.NewEntity();

            ref var timer = ref timerEntity.Get<Timer>();
            timer.Time = 0;
            timer.IsRunning = true;
        }
    }
}