﻿
namespace L2dotNET.Game.network.l2send
{
    class PartySmallWindowDelete : GameServerNetworkPacket
    {
        private int id;
        private string name;
        public PartySmallWindowDelete(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        protected internal override void write()
        {
            writeC(0x51);
            writeD(id);
            writeS(name);
        }
    }
}
