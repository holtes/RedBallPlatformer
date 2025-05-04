using _Project.Develop.Runtime.Domain.FinishFeature.Components;
using _Project.Develop.Runtime.Domain.PauseFeature.Components;
using Leopotam.Ecs;

namespace _Project.Develop.Runtime.Domain.FinishFeature.Systems
{
    public sealed class FinishGameSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<FinishGameRequest> _requestFilter;

        public void Run()
        {
            foreach (var i in _requestFilter)
            {
                _world.NewEntity().Get<PauseGameRequest>();

                _world.NewEntity().Get<DestroyPlayerRequest>();

                _requestFilter.GetEntity(i).Destroy();
            }
        }
    }
}