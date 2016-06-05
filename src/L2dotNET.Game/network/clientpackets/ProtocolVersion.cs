﻿using log4net;
using L2dotNET.GameService.network.serverpackets;

namespace L2dotNET.GameService.network.clientpackets
{
    class ProtocolVersion : GameServerNetworkRequest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProtocolVersion));

        public ProtocolVersion(GameClient client, byte[] data)
        {
            base.makeme(client, data);
        }

        private int _protocol;

        public override void read()
        {
            _protocol = readD();
        }

        public override void run()
        {
            if (_protocol != 746 && _protocol != 251)
            {
                log.Error($"Protocol fail {_protocol}");
                getClient().sendPacket(new KeyPacket(getClient(), 0));
                getClient().termination();
                return;
            }
            else if (_protocol == -1)
            {
                log.Info($"Ping received {_protocol}");
                getClient().sendPacket(new KeyPacket(getClient(), 0));
                getClient().termination();
                return;
            }

            log.Info($"Accepted {_protocol} client");

            getClient().sendPacket(new KeyPacket(getClient(), 1));
            getClient().Protocol = _protocol;
        }
    }
}