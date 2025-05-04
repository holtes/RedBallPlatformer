using _Project.Develop.Runtime.Presentation.UIFeature.Views;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Presentation.UIFeature.Systems
{
    public sealed class UIInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        private readonly UIView _uiView;

        public UIInitSystem(UIView uiView)
        {
            _uiView = uiView;
        }

        public void Init()
        {
            _uiView.Init(_world);
        }
    }
}