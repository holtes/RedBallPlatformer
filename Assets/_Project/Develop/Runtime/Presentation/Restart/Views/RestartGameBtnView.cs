using _Project.Develop.Runtime.Presentation.RestartFeature.Components;
using UnityEngine;
using UnityEngine.UI;
using Leopotam.Ecs;
using UniRx;

namespace _Project.Develop.Runtime.Presentation.RestartFeature.Views
{
    [RequireComponent(typeof(Button))]
    public class RestartGameBtnView : MonoBehaviour
    {
        [SerializeField] private Button _restartGameBtn;

        private EcsWorld _world;

        public void Init(EcsWorld world)
        {
            _world = world;
        }

        private void Awake()
        {
            _restartGameBtn.OnClickAsObservable()
                .Subscribe(_ => OnRestartBtnClicked())
                .AddTo(this);
        }

        private void OnRestartBtnClicked()
        {
            _world.NewEntity().Get<LevelRestartRequest>();
        }
    }
}