﻿namespace L2dotNET.GameService.network.serverpackets
{
    class PledgeShowMemberListDeleteAll : GameServerNetworkPacket
    {
        protected internal override void write()
        {
            writeC(0x88);
        }
    }
}