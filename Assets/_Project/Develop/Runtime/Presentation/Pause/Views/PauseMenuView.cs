using UnityEngine;
using Leopotam.Ecs;
using _Project.Develop.Runtime.Presentation.RestartFeature.Views;

namespace _Project.Develop.Runtime.Presentation.PauseFeature.Views
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField] private RestartGameBtnView _restartGameBtnView;
        [SerializeField] private ContinueGameBtnView _continueGameBtnView;

        public void Init(EcsWorld world)
        {
            _restartGameBtnView.Init(world);
            _continueGameBtnView.Init(world);
        }
    }
}