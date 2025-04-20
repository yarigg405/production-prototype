namespace Assets.Code.Infrastructure.States.StatesInfrastructure
{
    internal interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}
