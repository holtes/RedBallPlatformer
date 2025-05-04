using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Presentation.UIFeature.Views;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Presentation.UIFeature.Systems
{
    public sealed class SelectUIStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SelectUIStateRequest> _requestFilter;

        private readonly UIView _uiView;

        public SelectUIStateSystem(UIView uiView)
        {
            _uiView = uiView;
        }

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                ref var request = ref _requestFilter.Get1(i);

                _uiView.SelectUIState(request.StateName);
                _requestFilter.GetEntity(i).Destroy();
            }
        }
    }
}