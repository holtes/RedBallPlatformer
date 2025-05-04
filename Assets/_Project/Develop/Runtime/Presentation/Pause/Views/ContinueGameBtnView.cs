using _Project.Develop.Runtime.Domain.PauseFeature.Components;
using _Project.Develop.Runtime.Domain.Shared;
using UnityEngine;
using UnityEngine.UI;
using Leopotam.Ecs;
using UniRx;

namespace _Project.Develop.Runtime.Presentation.PauseFeature.Views
{
    [RequireComponent(typeof(Button))]
    public class ContinueGameBtnView : MonoBehaviour
    {
        [SerializeField] private Button _continueGameBtn;

        private EcsWorld _world;

        public void Init(EcsWorld world)
        {
            _world = world;
        }

        private void Awake()
        {
            _continueGameBtn.OnClickAsObservable()
                .Subscribe(_ => OnContinueBtnClicked())
                .AddTo(this);
        }

        private void OnContinueBtnClicked()
        {
            ref var changeUIStateRequest = ref _world.NewEntity().Get<SelectUIStateRequest>();
            changeUIStateRequest.StateName = "Default";

            _world.NewEntity().Get<ContinueGameRequest>();
        }
    }
}