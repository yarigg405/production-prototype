using Game.Assets.Code.Gameplay.Gathering;

namespace Cheats
{
    public class CheatConsoleController
    {
        private static PlayerResourcesStorage _resourcesStorage;

        public static void Init(PlayerResourcesStorage resourcesStorage)
        {
            _resourcesStorage = resourcesStorage;
        }

        //TO DO: Console Method
    }
}