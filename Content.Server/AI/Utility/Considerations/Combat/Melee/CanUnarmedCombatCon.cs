using Content.Server.AI.Utility.Curves;
using Content.Server.AI.WorldState;
using Content.Server.AI.WorldState.States;
using Content.Server.GameObjects.Components.Weapon.Melee;

namespace Content.Server.AI.Utility.Considerations.Combat.Melee
{
    public sealed class CanUnarmedCombatCon : Consideration
    {
        public CanUnarmedCombatCon(IResponseCurve curve) : base(curve) {}

        public override float GetScore(Blackboard context)
        {
            return context.GetState<SelfState>().GetValue().HasComponent<UnarmedCombatComponent>() ? 1.0f : 0.0f;
        }
    }
}