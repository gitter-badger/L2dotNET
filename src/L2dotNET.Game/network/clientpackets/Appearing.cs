﻿using L2dotNET.Game.network.l2send;
using System;

namespace L2dotNET.Game.network.l2recv
{
    class Appearing : GameServerNetworkRequest
    {
        public Appearing(GameClient client, byte[] data)
        {
            base.makeme(client, data);
        }

        public override void read()
        {
            // nothing
        }

        public override void run()
        {
            L2Player player = Client.CurrentPlayer;

            int x = player.X;
            int y = player.Y;

            if (player._obsx != -1)
            {
                x = player._obsx;
                y = player._obsy;
            }

            player.sendPacket(new UserInfo(player));
            player.validateVisibleObjects(x, y, false);
            player.updateVisibleStatus();

            if (player.Summon != null)
            {
                player.Summon.validateVisibleObjects(x, y, false);
                player.Summon.isTeleporting = false;
            }

            player.sendActionFailed();
        }
    }
}
