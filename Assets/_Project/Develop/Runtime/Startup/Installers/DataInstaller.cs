using _Poject.Develop.Runtime.Data;
using _Project.Develop.Runtime.Domain.PlayerInitFeature.Components;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public static class DataInstaller
    {
        public static PlayerInitData PreparePlayerInitData(GameConfig gameConfig)
        {
            var playerInitData = new PlayerInitData
            {
                PlayerSpeed = gameConfig.PlayerSpeed,
                PlayerJumpForce = gameConfig.JumpForce
            };
            return playerInitData;
        }
    }
}