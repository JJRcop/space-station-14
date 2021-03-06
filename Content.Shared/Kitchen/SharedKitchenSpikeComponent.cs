#nullable enable
using Content.Shared.GameObjects.Components.Mobs;
using Content.Shared.GameObjects.Components.Mobs.State;
using Content.Shared.GameObjects.EntitySystems.ActionBlocker;
using Content.Shared.Interfaces.GameObjects.Components;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.ViewVariables;

namespace Content.Shared.Kitchen
{
    public abstract class SharedKitchenSpikeComponent : Component, IDragDropOn
    {
        public override string Name => "KitchenSpike";

        [ViewVariables]
        [DataField("delay")]
        protected float SpikeDelay = 12.0f;

        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("sound")]
        protected string? SpikeSound = "/Audio/Effects/Fluids/splat.ogg";

        bool IDragDropOn.CanDragDropOn(DragDropEventArgs eventArgs)
        {
            if (eventArgs.User == eventArgs.Dragged ||
                !eventArgs.Dragged.TryGetComponent<IMobStateComponent>(out var state) ||
                (eventArgs.User.TryGetComponent(out SharedCombatModeComponent? combatMode) && !combatMode.IsInCombatMode))
            {
                return false;
            }

            // TODO: Once we get silicons need to check organic
            return !state.IsDead();
        }

        public abstract bool DragDropOn(DragDropEventArgs eventArgs);
    }
}
