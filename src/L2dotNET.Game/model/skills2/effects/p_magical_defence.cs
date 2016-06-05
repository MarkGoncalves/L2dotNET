﻿using L2dotNET.GameService.network.serverpackets;

namespace L2dotNET.GameService.Model.skills2.effects
{
    class p_magical_defence : TEffect
    {
        public p_magical_defence()
        {
            SU_ID = StatusUpdate.M_DEF;
            type = TEffectType.p_magical_defense;
        }

        public override void build(string str)
        {
            string[] v = str.Split(' ');
            SetCondition(v[1]);
            SetSup(v[2]);
        }
    }
}