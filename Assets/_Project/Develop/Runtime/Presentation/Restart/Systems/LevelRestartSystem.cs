using _Project.Develop.Runtime.Presentation.RestartFeature.Components;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace _Project.Develop.Runtime.Presentation.RestartFeature.Systems
{
    public sealed class LevelRestartSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LevelRestartRequest> _restartFilter;

        public void Run()
        {
            foreach (var i in _restartFilter)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                _restartFilter.GetEntity(i).Destroy();
                break;
            }
        }
    }
}