using System;


namespace Game.Assets.Code.Gameplay.Production.Buildings
{
    [Serializable]
    internal sealed class ProductionBuildingModel
    {
        public string UniqId { get; private set; }
        public float CurrentProductionTimer { get; private set; }
        public int CurrentResourcesCount { get; private set; }

        public event Action OnResourcesProducted;

        public ProductionBuildingModel(string uniqId)
        {
            UniqId = uniqId;
        }

        public void IncreaseTimer(float timer)
        {
            CurrentProductionTimer += timer;
        }

        public void IncreaseProduction(int productionCount)
        {
            CurrentProductionTimer = 0;
            CurrentResourcesCount += productionCount;

            OnResourcesProducted?.Invoke();
        }

        public void Setup(float timer, int productionCount)
        {
            CurrentProductionTimer = timer;
            CurrentResourcesCount = productionCount;
        }
    }
}
