using System;
using Yrr.Utils;


namespace Game.Assets.Code.Gameplay.Player.Components
{
    [Serializable]
    internal sealed class PlayerViewModel
    {
        public ReactiveValue<bool> IsMoving = new();
        public ReactiveValue<bool> IsInInteraction = new();
    }
}
