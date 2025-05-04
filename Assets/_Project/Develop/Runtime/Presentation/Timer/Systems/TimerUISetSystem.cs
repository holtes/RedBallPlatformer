using _Project.Develop.Runtime.Domain.TimerFeature.Components;
using _Project.Develop.Runtime.Domain.TimerFeature.Systems;
using _Project.Develop.Runtime.Presentation.TimerFeature.Views;
using _Project.Develop.Runtime.Presentation.UIFeature.Views;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Presentation.TimerFeature.Systems
{
    public sealed class TimerUISetSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Timer, TimerStopRequest> _requestFilter;

        private readonly TimerView _timerView;

        public TimerUISetSystem(UIView uiView)
        {
            _timerView = uiView.FinishMenuView.TimerView;
        }

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                ref var request = ref _requestFilter.Get2(i);

                _timerView.SetTimer(request.FinalTime);
            }
        }
    }
}