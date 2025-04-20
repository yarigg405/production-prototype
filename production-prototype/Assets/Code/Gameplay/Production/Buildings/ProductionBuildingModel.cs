using System;
using Yrr.Utils;


namespace Game.Assets.Code.Gameplay.Production.Buildings
{
    [Serializable]
    internal sealed class ProductionBuildingModel
    {
        public string UniqId;
        public float CurrentProductionTimer;
        public ReactiveValue<int> CurrentResourcesCount = new();

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
            CurrentResourcesCount.Value += productionCount;

            OnResourcesProducted?.Invoke();
        }

        public void ConsumeProduction(int count)
        {
            CurrentResourcesCount.Value -= count;
        }

        public void Setup(float timer, int productionCount)
        {
            CurrentProductionTimer = timer;
            CurrentResourcesCount.Value = productionCount;
        }
    }
}
