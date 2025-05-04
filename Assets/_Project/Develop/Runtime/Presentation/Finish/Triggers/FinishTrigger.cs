using _Project.Develop.Runtime.Domain.FinishFeature.Components;
using _Project.Develop.Runtime.Domain.Shared;
using Leopotam.Ecs;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.FinishFeature.Triggers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FinishTrigger : MonoBehaviour
    {
        private EcsWorld _world;

        public void Init(EcsWorld world)
        {
            _world = world;
        }

        private void Awake()
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(collider => OnFinishTriggered(collider))
                .AddTo(this);
        }

        private void OnFinishTriggered(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                ref var changeUIStateRequest = ref _world.NewEntity().Get<SelectUIStateRequest>();
                changeUIStateRequest.StateName = "Finish";

                _world.NewEntity().Get<FinishGameRequest>();
            }
        }
    }
}