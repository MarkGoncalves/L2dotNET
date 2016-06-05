﻿using L2dotNET.GameService.Model.player;
using L2dotNET.GameService.Model.skills2;
using L2dotNET.GameService.tables;

namespace L2dotNET.GameService.network.serverpackets
{
    class RecipeItemMakeInfo : GameServerNetworkPacket
    {
        private readonly int RecipeID;
        private readonly int Type;
        private readonly int CurrentMP;
        private readonly int MaxMP;
        private readonly int MakingResult;

        public RecipeItemMakeInfo(L2Player player, L2Recipe rec, int result)
        {
            RecipeID = rec.RecipeID;
            Type = rec._iscommonrecipe;
            CurrentMP = (int)player.CurMP;
            MaxMP = (int)player.CharacterStat.getStat(TEffectType.b_max_mp);
            MakingResult = result;
        }

        protected internal override void write()
        {
            writeC(0xdd);
            writeD(RecipeID);
            writeD(Type);
            writeD(CurrentMP);
            writeD(MaxMP);
            writeD(MakingResult);
        }
    }
}