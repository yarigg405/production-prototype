namespace Assets.Code.Infrastructure.States.StatesInfrastructure
{
    public class GamePayloadState<TPayload> : IPayloadState<TPayload>
    {
        public virtual void Enter(TPayload payload) { }

        public virtual void Exit() { }
    }
}

