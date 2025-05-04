using Leopotam.Ecs;
using _Project.Develop.Runtime.Domain.Shared;
using _Project.Develop.Runtime.Domain.PlayerInitFeature.Components;
using _Project.Develop.Runtime.Domain.PlayerInitFeature.Systems;
using _Project.Develop.Runtime.Domain.TimerFeature.Systems;
using _Project.Develop.Runtime.Domain.InputFeature.Systems;
using _Project.Develop.Runtime.Domain.MovementFeature.Systems;
using _Project.Develop.Runtime.Domain.JumpFeature.Systems;
using _Project.Develop.Runtime.Domain.FinishFeature.Systems;
using _Project.Develop.Runtime.Presentation.UIFeature.Systems;
using _Project.Develop.Runtime.Presentation.PlayerInitFeature.Systems;
using _Project.Develop.Runtime.Presentation.CameraFollowFeature.Systems;
using _Project.Develop.Runtime.Presentation.FinishFeature.Systems;
using _Project.Develop.Runtime.Presentation.JumpFeature.Systems;
using _Project.Develop.Runtime.Presentation.MovementFeature.Systems;
using _Project.Develop.Runtime.Domain.PauseFeature.Systems;
using _Project.Develop.Runtime.Presentation.RestartFeature.Systems;
using _Project.Develop.Runtime.Presentation.TimerFeature.Systems;
using _Project.Develop.Runtime.Startup.Data;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class SystemsInstaller
    {
        public void Init(EcsSystems systems, SceneData sceneData, PlayerInitData playerInitData, ServicesInstaller services)
        {
            systems
                .Add(new UIInitSystem(sceneData.UIView))
                .Add(new PlayerInitSystem(playerInitData))
                .Add(new PlayerSpawnSystem(sceneData.PlayerPrefab, sceneData.SpawnPoint, sceneData.SceneRoot))
                .Add(new CameraInitSystem(sceneData.PlayerCamera, sceneData.CameraBounds))
                .Add(new FinishTriggerInitSystem(sceneData.FinishTrigger))
                .Add(new TimerInitSystem())

                .Add(new InputSystem())
                .Add(new MovementSystem(services.TimeService))
                .Add(new JumpSystem())
                .Add(new GroundCheckApplySystem())
                .Add(new ApplyPhysicsSystem())
                .Add(new ResetInputSystem())

                .Add(new TimerSystem(services.TimeService))
                .Add(new PauseGameSystem(services.TimeService))
                .Add(new ContinueGameSystem(services.TimeService))
                .Add(new LevelRestartSystem())
                .Add(new TimerFinishSystem())
                .Add(new FinishGameSystem())
                .Add(new SelectUIStateSystem(sceneData.UIView))
                .Add(new TimerUISetSystem(sceneData.UIView))

                .Add(new CameraFollowSystem())
                .Add(new DestroyPlayerSystem())

                .OneFrame<PlayerSpawnRequest>()
                .OneFrame<TimerStopRequest>();
        }
    }
}