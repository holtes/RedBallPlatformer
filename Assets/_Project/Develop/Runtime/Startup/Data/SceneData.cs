using _Project.Develop.Runtime.Presentation.FinishFeature.Triggers;
using _Project.Develop.Runtime.Presentation.UIFeature.Views;
using UnityEngine;

namespace _Project.Develop.Runtime.Startup.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform _sceneRoot;
        [SerializeField] private UIView _uiView;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private BoxCollider2D _cameraBounds;
        [SerializeField] private FinishTrigger _finishTrigger;

        public Transform SceneRoot => _sceneRoot;
        public UIView UIView => _uiView;
        public Transform SpawnPoint => _spawnPoint;
        public GameObject PlayerPrefab => _playerPrefab;
        public Camera PlayerCamera => _playerCamera;
        public BoxCollider2D CameraBounds => _cameraBounds;
        public FinishTrigger FinishTrigger => _finishTrigger;
    }
}