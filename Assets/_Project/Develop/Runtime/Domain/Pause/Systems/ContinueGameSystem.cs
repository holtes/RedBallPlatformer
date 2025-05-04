using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.PauseFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.PauseFeature.Systems
{
    public sealed class ContinueGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ContinueGameRequest> _continueFilter;

        private readonly TimeService _timeService;

        public ContinueGameSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run()
        {
            foreach (var i in _continueFilter)
            {
                _timeService.ContinueTime();
                _continueFilter.GetEntity(i).Destroy();
            }
        }
    }
}