using _Poject.Develop.Runtime.Data;
using _Project.Develop.Runtime.Startup.Data;
using _Project.Develop.Runtime.Startup.Installers;
using Leopotam.Ecs;
using UnityEngine;

namespace _Poject.Develop.Runtime.Startup
{
    public sealed class Startup : MonoBehaviour 
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private SceneData _sceneData;

        private EcsWorld _world;
        private EcsSystems _systems;
        private SystemsInstaller _systemsInstaller;
        private ServicesInstaller _servicesInstaller;

        void Start () 
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systemsInstaller = new SystemsInstaller();

            _servicesInstaller = new ServicesInstaller();

            var playerInitData = DataInstaller.PreparePlayerInitData(_gameConfig);

            _systemsInstaller.Init(_systems, _sceneData, playerInitData, _servicesInstaller);

            _systems.Init ();
        }

        void Update () 
        {
            _systems?.Run ();
        }

        void OnDestroy () 
        {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}