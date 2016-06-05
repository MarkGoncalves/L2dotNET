﻿using L2dotNET.GameService.Model.player;
using L2dotNET.GameService.network.loginauth;
using L2dotNET.GameService.network.serverpackets;

namespace L2dotNET.GameService.network.clientpackets
{
    class Logout : GameServerNetworkRequest
    {
        public Logout(GameClient client, byte[] data)
        {
            base.makeme(client, data);
        }

        public override void read()
        {
            // nothing
        }

        public override void run()
        {
            AuthThread.Instance.setInGameAccount(Client.AccountName, false);

            L2Player player = Client.CurrentPlayer;

            if (player == null) //re-login на выборе чаров
                return;

            if (player._p_block_act == 1)
            {
                player.sendActionFailed();
                return;
            }

            if (player.isInCombat())
            {
                player.sendSystemMessage(SystemMessage.SystemMessageId.CANT_LOGOUT_WHILE_FIGHTING);
                player.sendActionFailed();
                return;
            }

            player.Termination();
            player.sendPacket(new LeaveWorld());
        }
    }
}