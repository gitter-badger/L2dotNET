﻿using L2dotNET.Game.model.npcs;

namespace L2dotNET.Game.model.quests.data
{
    class _0005_miners_favor : QuestOrigin
    {
        const int miner_bolter = 30554;
        const int trader_chali = 30517;
        const int trader_garita = 30518;
        const int warehouse_chief_reed = 30520;
        const int blacksmith_bronp = 30526;

        const int bolters_list = 1547;
        const int mining_boots = 1548;
        const int miners_pick = 1549;
        const int boomboom_powder = 1550;
        const int redstone_beer = 1551;
        const int bolters_smelly_socks = 1552;
        const int necklace_of_knowledge = 906;

        public _0005_miners_favor()
        {
            questId = 5;
            questName = "Miner's Favor";
            startNpc = miner_bolter;
            talkNpcs = new int[] { startNpc, trader_chali, trader_garita, warehouse_chief_reed, blacksmith_bronp };
            actItems = new int[] { bolters_list, mining_boots, miners_pick, boomboom_powder, redstone_beer, bolters_smelly_socks };
        }

        public override void tryAccept(L2Player player, L2Citizen npc)
        {
            if (player.Level >= 2)
                player.ShowHtm("miner_bolter_q0005_02.htm", npc, questId);
            else 
                player.ShowHtm("miner_bolter_q0005_01.htm", npc);
        }

        public override void onAccept(L2Player player, L2Citizen npc)
        {
            player.questAccept(new QuestInfo(this));
            player.ShowHtm("miner_bolter_q0005_03.htm", npc);
            player.addItem(bolters_list, 1);
            player.addItem(bolters_smelly_socks, 1);
        }

        public override void onTalkToNpc(L2Player player, L2Citizen npc, int cond)
        {
            int npcId = npc.Template.NpcId;
            string htmltext = no_action_required;
            if (npcId == miner_bolter)
            {
                if (cond == 1)
                    htmltext = "miner_bolter_q0005_04.htm";
                else if (cond == 2 && player.hasAllOfThisItems(mining_boots, miners_pick, boomboom_powder, redstone_beer))
                {
                    htmltext = "miner_bolter_q0005_06.htm";
                    player.takeItem(mining_boots, 1);
                    player.takeItem(miners_pick, 1);
                    player.takeItem(boomboom_powder, 1);
                    player.takeItem(redstone_beer, 1);
                    player.takeItem(bolters_list, 1);
                    player.addItem(necklace_of_knowledge, 1);
                    player.addExpSp(5672, 446, true);
                    player.addItem(57, 2466);
                    player.finishQuest(questId);
                }
            }
            else if (cond == 1 && !player.hasItem(bolters_list))
            {
                if (npcId == trader_chali)
                {
                    if (!player.hasItem(boomboom_powder))
                    {
                        htmltext = "trader_chali_q0005_01.htm";
                        player.addItemQuest(boomboom_powder, 1);
                    }
                    else
                        htmltext = "trader_chali_q0005_02.htm";
                }
                else if (npcId == trader_garita)
                {
                    if (!player.hasItem(mining_boots))
                    {
                        htmltext = "trader_garita_q0005_01.htm";
                        player.addItemQuest(mining_boots, 1);
                    }
                    else
                        htmltext = "trader_garita_q0005_02.htm";
                }
                else if (npcId == warehouse_chief_reed)
                {
                    if (!player.hasItem(redstone_beer))
                    {
                        htmltext = "warehouse_chief_reed_q0005_01.htm";
                        player.addItemQuest(redstone_beer, 1);
                    }
                    else
                        htmltext = "warehouse_chief_reed_q0005_02.htm";
                }
                else if (npcId == blacksmith_bronp && !player.hasItem(bolters_smelly_socks))
                {
                    if (!player.hasItem(miners_pick))
                        htmltext = "blacksmith_bronp_q0005_01.htm";
                    else
                        htmltext = "blacksmith_bronp_q0005_03.htm";
                }
            }

            player.ShowHtm(htmltext, npc);
        }

        public override void onEarnItem(L2Player player, int cond, int id)
        {
            if (cond == 1)
            {
                if (id == mining_boots || id == miners_pick || id == boomboom_powder || id == redstone_beer && player.hasAllOfThisItems(mining_boots, miners_pick, boomboom_powder, redstone_beer))
                {
                    player.changeQuestStage(questId, 2);
                }
            }
        }
    }
}

