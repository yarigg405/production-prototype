namespace Assets.Code.Infrastructure.States.StatesInfrastructure
{
    internal interface IState : IExitableState
    {
        void Enter();
    }
}
