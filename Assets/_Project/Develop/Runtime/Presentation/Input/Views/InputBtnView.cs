using _Project.Develop.Runtime.Domain.InputFeature.Components;
using _Project.Develop.Runtime.Domain.InputFeature.Models;
using Leopotam.Ecs;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.InputFeature.Views
{
    [RequireComponent(typeof(ObservableEventTrigger))]
    public class InputBtnView : MonoBehaviour
    {
        [SerializeField] private ObservableEventTrigger _inputTrigger;
        [SerializeField] private BtnTypes _inputBtnType;

        private EcsWorld _world;
        private CompositeDisposable _disposables = new();

        public void Init(EcsWorld world)
        {
            _world = world;
        }

        private void Awake()
        {
            _inputTrigger.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    if (_inputBtnType == BtnTypes.Jump) SendButtonEvent();
                    else
                    {
                        Observable.EveryUpdate()
                            .TakeUntil(_inputTrigger.OnPointerUpAsObservable())
                            .Subscribe(__ => SendButtonEvent())
                            .AddTo(_disposables);
                    }
                })
                .AddTo(this);
        }

        private void SendButtonEvent()
        {
            var entity = _world.NewEntity();
            ref var pressed = ref entity.Get<ButtonInteractEvent>();
            pressed.BtnType = _inputBtnType;
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}