﻿using L2dotNET.Game.network.l2send;
using System.Collections.Generic;

namespace L2dotNET.Game.network.l2recv
{
    class RequestManorList : GameServerNetworkRequest
    {
        public RequestManorList(GameClient client, byte[] data)
        {
            base.makeme(client, data, 2);
        }

        public override void read()
        {
            // do nothing
        }

        public override void run()
        {
            List<string> manorsName = new List<string>();
            manorsName.Add("gludio");
            manorsName.Add("dion");
            manorsName.Add("giran");
            manorsName.Add("oren");
            manorsName.Add("aden");
            manorsName.Add("innadril");
            manorsName.Add("goddard");
            manorsName.Add("rune");
            manorsName.Add("schuttgart");
            getClient().sendPacket(new ExSendManorList(manorsName));
        }
    }
}
