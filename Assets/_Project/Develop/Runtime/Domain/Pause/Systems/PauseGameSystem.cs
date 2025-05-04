using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.PauseFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.PauseFeature.Systems
{
    public sealed class PauseGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PauseGameRequest> _pauseFilter;

        private readonly TimeService _timeService;

        public PauseGameSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {
            foreach (var i in _pauseFilter)
            {
                _timeService.PauseTime();
                _pauseFilter.GetEntity(i).Destroy();
            }
        }
    }
}