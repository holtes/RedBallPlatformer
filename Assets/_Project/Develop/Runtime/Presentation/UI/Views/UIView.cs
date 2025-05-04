using _Project.Develop.Runtime.Presentation.FinishFeature.Views;
using _Project.Develop.Runtime.Presentation.InputFeature.Views;
using _Project.Develop.Runtime.Presentation.PauseFeature.Views;
using Leopotam.Ecs;
using UnityEngine;
using TSS;

namespace _Project.Develop.Runtime.Presentation.UIFeature.Views
{
    [RequireComponent(typeof(Canvas))]
    public class UIView : MonoBehaviour
    {
        [SerializeField] private InputBtnView[] _inputBtns;
        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private PauseBtnView _pauseBtn;
        [SerializeField] private FinishMenuView _finishMenuView;
        [SerializeField] private TSSCore _tSSCore;

        public FinishMenuView FinishMenuView => _finishMenuView;

        public void Init(EcsWorld world)
        {
            foreach (var inputBtn in _inputBtns) inputBtn.Init(world);

            _pauseMenuView.Init(world);
            _pauseBtn.Init(world);

            _finishMenuView.Init(world);
        }

        public void SelectUIState(string stateName)
        {
            _tSSCore.SelectState(stateName);
        }
    }
}