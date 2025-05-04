using _Project.Develop.Runtime.Presentation.FinishFeature.Triggers;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Presentation.FinishFeature.Systems
{
    public sealed class FinishTriggerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        private readonly FinishTrigger _finishTrigger;

        public FinishTriggerInitSystem(FinishTrigger finishTrigger)
        {
            _finishTrigger = finishTrigger;
        }

        public void Init()
        {
            _finishTrigger.Init(_world);
        }
    }
}