using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.TimerFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.TimerFeature.Systems
{
    public sealed class TimerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Timer> _filter;
        private readonly TimeService _timeService;

        public TimerSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var timer = ref _filter.Get1(i);
                if (timer.IsRunning) timer.Time += _timeService.DeltaTime;
            }
        }
    }
}