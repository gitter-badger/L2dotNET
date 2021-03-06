﻿using L2dotNET.Game.model.skills2.speceffects;

namespace L2dotNET.Game.model.skills2.effects
{
    class b_reg_hp_move : TEffect
    {
        TSpecEffect ef;
        public override void build(string str)
        {
            ef = new b_regen_hp_by_move(double.Parse(str.Split(' ')[1]));
        }

        public override TEffectResult onStart(world.L2Character caster, world.L2Character target)
        {
            if (!(target is L2Player))
                return nothing;

            ((L2Player)target).specEffects.Add(ef);

            return nothing;
        }

        public override TEffectResult onEnd(world.L2Character caster, world.L2Character target)
        {
            if (!(target is L2Player))
                return nothing;

            lock(((L2Player)target).specEffects)
                ((L2Player)target).specEffects.Remove(ef);

            return nothing;
        }
    }
}
