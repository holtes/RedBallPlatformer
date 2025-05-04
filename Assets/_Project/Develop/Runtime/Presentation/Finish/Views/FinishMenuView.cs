using _Project.Develop.Runtime.Presentation.RestartFeature.Views;
using _Project.Develop.Runtime.Presentation.TimerFeature.Views;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.FinishFeature.Views
{
    public class FinishMenuView : MonoBehaviour
    {
        [SerializeField] private TimerView _timerView;
        [SerializeField] private RestartGameBtnView _restartGameBtnView;

        public TimerView TimerView => _timerView;

        public void Init(EcsWorld world)
        {
            _restartGameBtnView.Init(world);
        }
    }
}