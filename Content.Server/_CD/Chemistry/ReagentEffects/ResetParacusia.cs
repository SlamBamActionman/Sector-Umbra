using Content.Server.Traits.Assorted;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Server._CD.Chemistry.ReagentEffects;


[UsedImplicitly]
public sealed partial class ResetParacusia : EntityEffect
{
    [DataField("TimerReset")]
    public int TimerReset = 600;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("reagent-effect-guidebook-reset-paracusia", ("chance", Probability));

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (args is not EntityEffectReagentArgs reagentArgs)
            return;

        if (reagentArgs.Scale != 1f)
            return;

        var sys = reagentArgs.EntityManager.EntitySysManager.GetEntitySystem<ParacusiaSystem>();
        sys.SetIncidentDelay(reagentArgs.TargetEntity, new TimeSpan(0, 0, TimerReset));
    }
}
