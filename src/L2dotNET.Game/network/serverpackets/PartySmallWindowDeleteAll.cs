﻿
namespace L2dotNET.Game.network.l2send
{
    class PartySmallWindowDeleteAll : GameServerNetworkPacket
    {
        protected internal override void write()
        {
            writeC(0x50);
        }
    }
}
