using _Project.Develop.Runtime.Domain.FinishFeature.Components;
using _Project.Develop.Runtime.Domain.TimerFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.TimerFeature.Systems
{
    public sealed class TimerFinishSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Timer> _timerFilter;
        private readonly EcsFilter<FinishGameRequest> _finishFilter;

        public void Run()
        {
            foreach (var i in _finishFilter)
            {
                foreach (var j in _timerFilter)
                {
                    ref var timer = ref _timerFilter.Get1(j);

                    timer.IsRunning = false;

                    ref var stopRequest = ref _timerFilter.GetEntity(j).Get<TimerStopRequest>();
                    stopRequest.FinalTime = timer.Time;
                }
            }
        }
    }
}