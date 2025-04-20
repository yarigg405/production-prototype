using UnityEngine;
using UnityEngine.AI;
using VContainer;


namespace Game.Assets.Code.Gameplay.Player
{
    internal sealed class PlayerEntity : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent { get; private set; }

        [Inject]
        private void Construct(NavMeshAgent navMeshAgent)
        {
            NavMeshAgent = navMeshAgent;
        }
    }
}
