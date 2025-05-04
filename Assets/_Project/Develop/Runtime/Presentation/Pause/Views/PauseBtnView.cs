using _Project.Develop.Runtime.Domain.PauseFeature.Components;
using _Project.Develop.Runtime.Domain.Shared;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace _Project.Develop.Runtime.Presentation.PauseFeature.Views
{
    [RequireComponent(typeof(Button))]
    public class PauseBtnView : MonoBehaviour
    {
        [SerializeField] private Button _pauseBtn;

        private EcsWorld _world;
        public void Init(EcsWorld world)
        {
            _world = world;
        }

        private void Awake()
        {
            _pauseBtn.OnClickAsObservable()
                .Subscribe(_ => OnPausedBtnClicked())
                .AddTo(this);
        }

        private void OnPausedBtnClicked()
        {
            ref var changeUIStateRequest = ref _world.NewEntity().Get<SelectUIStateRequest>();
            changeUIStateRequest.StateName = "Pause";

            _world.NewEntity().Get<PauseGameRequest>();
        }
    }
}