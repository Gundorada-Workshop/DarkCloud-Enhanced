using System;

namespace Dark_Cloud_Improved_Version
{
    public class SideQuestManager
    {
        static string[] dungeonNames = { "Divine Beast Cave", "Wise Owl Forest", "Shipwreck", "Sun & Moon Temple", "Moon Sea", "Gallery of Time", "Demon Shaft" };
        static string[] DBCEnemies = { "Master Jackets", "Dashers", "Mimics", "Dragons" };
        static string[] WOFEnemies = { "Fliflis", "Earth Diggers", "Mimics", "Werewolves" };
        static string[] ShipwreckEnemies = { "Gunnys", "Gyons", "Mimics", "Pirate´s Chariots" };
        static string[] SMEnemies = { "Golems", "Dunes", "Mimics", "Blue Dragons" };
        static string[] MoonSeaEnemies = { "Moon Diggers", "Space Gyons", "Mimics", "Crescent Barons" };
        static string[] GOFEnemies = { "Rash Dashers", "Jokers", "Mimics", "Alexanders" };
        static string[] NorunePondFish = { "Nilers", "Gummies", "Nonkies", "Gobblers" };
        static string[] MatatakiPondFish = { "Baku Bakus", "Gobblers", "Tartons", "Umadakaras" };
        static string[] MatatakiWaterfallFish = { "Baku Bakus", "Nonkies", "Gummies", "Mardan Garayan", "Baron Garayan" };
        static string[] QueensSeaFish = { "Bobos", "Kajis", "Piccolys", "Bons", "Hamahamas" };
        static string[] MuskaOasisFish = { "Negies", "Dens", "Heelas", "Mardan Garayans", "Baron Garayan" };
        //fish ID list:  0 = bobo, 1 = gobbler, 2 = nonky, 3 = kaiji, 4 = baku baku, 5 = mardan, 6 = gummy, 7 = niler , 8 = NULL , 9 = umadakara , 10 = tarton , 11 = piccoly , 12 = bon, 13 = hamahama , 14 = negie, 15 = den , 16 = heela, 17 = baron
        static string[] alliesChar = { "Ť", "Ӿ", "Ʊ", "Ʀ", "Ų", "Ō" };
        static int[] DBCEnemyIDs = { 1, 6, 35, 59 };
        static int[] WOFEnemyIDs = { 8, 12, 79, 7 };
        static int[] ShipwreckEnemyIDs = { 23, 24, 81, 25 };
        static int[] SMEnemyIDs = { 30, 32, 37, 73 };
        static int[] MoonSeaEnemyIDs = { 66, 72, 39, 76 };
        static int[] GOFEnemyIDs = { 63, 48, 83, 43 };
        static int[] NorunePondFishIDs = { 7, 6, 2, 1 };
        static int[] MatatakiPondFishIDs = { 4, 1, 10, 9 };
        static int[] MatatakiWaterfallFishIDs = { 4, 2, 6, 5, 17 };
        static int[] QueensSeaFishIDs = { 0, 3, 11, 12, 13 };
        static int[] MuskaOasisFishIDs = { 14, 15, 16, 5, 17 };
        static int[] DBCBackFloors = { 2, 4, 5, 6, 8, 9, 11, 12, 13 };
        static int rolledDng = 0;
        static int rolledEnemy = 0;
        static int enemyID = 0;
        static int rolledFish = 0;
        static int fishID = 0;
        static int fishingPoints = 0;
        static int randomizedFPoints = 0;
        static int fishMultiplier = 0;
        static int matatakiLocation = 0;
        static int matatakiLocationID = 0;
        public static int generatedNeededFishCount = 0;
        public static int generatedMinFishSize = 0;
        public static int generatedMaxFishSize = 0;
        public static string generatedEnemyName;
        public static string generatedMonsterQuestDungeon;
        public static int generatedEnemyKillsNeeded;

        public static string generatedFishName;

        public static int getDngID;
        public static int getEnemyID;
        public static int getEnemyCounter;
        public static int getFishID;
        public static int getFishCounter;

        static int demonshaftfloor;
        static int demonshaftally;

        static bool checkHPs;
        static bool checkDEFs;
        static bool checkThirsts;
        static bool HPreward;
        static bool DEFreward;
        static bool Thirstreward;

        static bool checkToanDEF;
        static bool checkXiaoDEF;
        static bool checkGoroDEF;
        static bool checkRubyDEF;
        static bool checkUngagaDEF;
        static bool checkOsmondDEF;

        static int rolledbackfloornumber;
        static int backfloornumber;

        static int currentAddress;
        static int currentAddressDungeonID;
        static int currentAddressEnemyName;
        static int currentAddressEnemyID;
        static int currentAddressEnemyCounter;

        static int currentAddressFishingQuestType;
        static int currentAddressFishName;
        static int currentAddressFishID;
        static int currentAddressFishLeftCounter;
        static int currentAddressFishMinSizeReq;
        static int currentAddressFishMaxSizeReq;
        static int currentAddressOriginalFishCounter;
        static int currentAddressMatatakiLocation;
        static int currentAddressQueensQuestsCompleteCount;

        static Random rnd = new Random();
        public static string GetQuestDialogue(string currentDialogue, int characterID)
        {
            if (characterID == 12592) //macho
            {
                TownCharacter.characterIDData = characterID;
                if (Memory.ReadByte(0x21CE4474) == 1)
                {
                    if (Memory.ReadByte(0x21CE4402) == 0)
                    {
                        SetSideQuestAddresses(characterID);
                        GenerateMonsterQuest();
                        currentDialogue = "Your quest is to defeat at least^" + generatedEnemyKillsNeeded + " " + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ".^Good luck!";
                    }
                    else if (Memory.ReadByte(0x21CE4402) == 1)
                    {
                        SetSideQuestAddresses(characterID);
                        GetMonsterQuestValues();
                        currentDialogue = "You´re still on the quest to defeat^" + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ",^just " + generatedEnemyKillsNeeded + " left!";
                    }
                    else if (Memory.ReadByte(0x21CE4402) == 2)
                    {
                        currentDialogue = "Well done, you completed it!^Here´s your reward: a Powerup Powder!";
                    }
                }
                else
                {
                    currentDialogue = "Prove me your true strength!^I can assign you some^Monster Slaying quests.¤The Monster Slayer quests are^tasks to kill a random amount^of random enemies in any dungeon^you have unlocked.¤Talk to me again to get your first quest!";
                }
            }
            else if (characterID == 13618) //gob
            {
                TownCharacter.characterIDData = characterID;
                if (Memory.ReadByte(0x21CE4476) == 1)
                {
                    if (Memory.ReadByte(0x21CE4407) == 0)
                    {
                        SetSideQuestAddresses(characterID);
                        GenerateMonsterQuest();
                        currentDialogue = "Your quest is to defeat at least^" + generatedEnemyKillsNeeded + " " + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ".^Good luck!";
                    }
                    else if (Memory.ReadByte(0x21CE4407) == 1)
                    {
                        SetSideQuestAddresses(characterID);
                        GetMonsterQuestValues();
                        currentDialogue = "You´re still on the quest to defeat^" + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ",^just " + generatedEnemyKillsNeeded + " left!";
                    }
                    else if (Memory.ReadByte(0x21CE4407) == 2)
                    {
                        currentDialogue = "Well done, you completed it!^Here´s your reward: a Powerup Powder!";
                    }
                }
                else
                {
                    currentDialogue = "I might be a cook, but I´m also^a hunter, and I respect those^who can fight.¤That being said, I can assign you^some Monster Slaying quests.";
                }
            }
            else if (characterID == 13108) //jake
            {
                TownCharacter.characterIDData = characterID;
                if (Memory.ReadByte(0x21CE4478) == 1)
                {
                    if (Memory.ReadByte(0x21CE440C) == 0)
                    {
                        SetSideQuestAddresses(characterID);
                        GenerateMonsterQuest();
                        currentDialogue = "Your quest is to defeat at least^" + generatedEnemyKillsNeeded + " " + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ".^Good luck!";
                    }
                    else if (Memory.ReadByte(0x21CE440C) == 1)
                    {
                        SetSideQuestAddresses(characterID);
                        GetMonsterQuestValues();
                        currentDialogue = "You´re still on the quest to defeat^" + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ",^just " + generatedEnemyKillsNeeded + " left!";
                    }
                    else if (Memory.ReadByte(0x21CE440C) == 2)
                    {
                        currentDialogue = "Well done, you completed it!^Here´s your reward: a Powerup Powder!";
                    }
                }
                else
                {
                    currentDialogue = "A message from King:^To gain more reputation for the^elections, we need to show that we^can be strong.¤How about you kill some evil monsters^and let us take the credit?¤I can assign you Monster Slaying quests.";
                }
            }
            else if (characterID == 14388) //chiefbonka
            {
                TownCharacter.characterIDData = characterID;
                if (Memory.ReadByte(0x21CE447A) == 1)
                {                  
                    if (Memory.ReadByte(0x21CE4411) == 0)
                    {
                        SetSideQuestAddresses(characterID);
                        GenerateMonsterQuest();
                        currentDialogue = "Your quest is to defeat at least^" + generatedEnemyKillsNeeded + " " + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ".^Good luck!";
                    }
                    else if (Memory.ReadByte(0x21CE4411) == 1)
                    {
                        SetSideQuestAddresses(characterID);
                        GetMonsterQuestValues();
                        currentDialogue = "You´re still on the quest to defeat^" + generatedEnemyName + " in " + generatedMonsterQuestDungeon + ",^just " + generatedEnemyKillsNeeded + " left!";
                    }
                    else if (Memory.ReadByte(0x21CE4411) == 2)
                    {
                        currentDialogue = "Well done, you completed it!^Here´s your reward: a Powerup Powder!";
                    }
                }
                else
                {
                    currentDialogue = "To survive against the fearful^enemies in your travels, you can^always use some training.¤I can assign you some Monster Slaying^quests.";
                }
            }
            else if (characterID == 13872) //pike
            {
                TownCharacter.characterIDData = characterID;
                if (Memory.ReadByte(0x21CE4475) == 1)
                {
                    SetSideQuestAddresses(characterID);
                    if (Memory.ReadByte(0x21CE4416) == 0)
                    {
                        int whichQuest = rnd.Next(100);

                        if (whichQuest < 50)
                        {
                            Memory.WriteOneByte(0x21CE4417, BitConverter.GetBytes(0));
                            GenerateFishingQuestOne();
                            currentDialogue = "Your quest is to catch^" + generatedNeededFishCount + " " + generatedFishName + " at the Norune Pond.^Good luck!";
                        }
                        else
                        {
                            Memory.WriteOneByte(0x21CE4417, BitConverter.GetBytes(1));
                            GenerateFishingQuestTwo();
                            currentDialogue = "Your quest is to catch any fish^of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Norune Pond.^Good luck!";
                        }
                    }
                    else if (Memory.ReadByte(0x21CE4416) == 1)
                    {
                        if (Memory.ReadByte(0x21CE4417) == 0)
                        {
                            GetFishingQuestOneValues(0);
                            currentDialogue = "You´re still on the quest to catch^" + generatedFishName + " at the Norune Pond,^just " + generatedNeededFishCount + " left!";
                        }
                        else
                        {
                            GetFishingQuestTwoValues();
                            currentDialogue = "You´re still on the quest to catch any^fish of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Norune Pond.^Good luck!";
                        }
                    }
                    else if (Memory.ReadByte(0x21CE4416) == 2)
                    {
                        if (Memory.ReadByte(0x21CE4417) == 0)
                        {
                            RollFishingQuestReward(0);
                        }
                        else
                        {
                            RollFishingQuestTwoReward(0);
                        }
                        currentDialogue = "Nicely done!^Here´s your reward: " + fishingPoints + " Fishing Points!";
                    }
                }
                else
                {
                    currentDialogue = "Oh, I bet you can already guess what^I have in store for you.¤That´s right, Fishing Quests!¤There are 2 types of fishing quests,^and whenever you talk to me,^I can assign you one of them.¤I hope you like fishing!";
                }
            }
            else if (characterID == 13362) //pao
            {
                TownCharacter.characterIDData = characterID;
                if (Memory.ReadByte(0x21CE4477) == 1)
                {
                    SetSideQuestAddresses(characterID);
                    if (Memory.ReadByte(0x21CE441E) == 0)
                    {
                        matatakiLocation = rnd.Next(100);
                        int whichQuest = rnd.Next(100);

                        if (whichQuest < 50)
                        {
                            Memory.WriteOneByte(0x21CE441F, BitConverter.GetBytes(0));
                            GenerateFishingQuestOne();
                            if (matatakiLocationID == 0)
                            {
                                currentDialogue = "Your quest is to catch^" + generatedNeededFishCount + " " + generatedFishName + " at the^Matataki Pond. Good luck!";
                            }
                            else if (matatakiLocationID == 1)
                            {
                                currentDialogue = "Your quest is to catch^" + generatedNeededFishCount + " " + generatedFishName + " at the^Matataki Waterfall. Good luck!";
                            }
                            else
                            {
                                currentDialogue = "Your quest is to catch^" + generatedNeededFishCount + " " + generatedFishName + " anywhere in^Matataki Village. Good luck!";
                            }
                        }
                        else
                        {
                            Memory.WriteOneByte(0x21CE441F, BitConverter.GetBytes(1));
                            GenerateFishingQuestTwo();
                            currentDialogue = "Your quest is to catch any fish^of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^anywhere in Matataki Village.^Good luck!";
                        }

                    }
                    else if (Memory.ReadByte(0x21CE441E) == 1)
                    {
                        if (Memory.ReadByte(0x21CE441F) == 0)
                        {
                            GetFishingQuestOneValues(1);
                            if (matatakiLocationID == 0)
                            {
                                currentDialogue = "You´re still on the quest to catch^" + generatedFishName + " at the Matataki Pond,^just " + generatedNeededFishCount + " left!";
                            }
                            else if (matatakiLocationID == 1)
                            {
                                currentDialogue = "You´re still on the quest to catch^" + generatedFishName + " at the Matataki^Waterfall, just " + generatedNeededFishCount + " left!";
                            }
                            else
                            {
                                currentDialogue = "You´re still on the quest to catch^" + generatedFishName + " anywhere in Matataki^Village, just " + generatedNeededFishCount + " left!";
                            }
                        }
                        else
                        {
                            GetFishingQuestTwoValues();
                            currentDialogue = "You´re still on the quest to catch any^fish of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^anywhere in Matataki Village.^Good luck!";
                        }
                    }
                    else if (Memory.ReadByte(0x21CE441E) == 2)
                    {
                        if (Memory.ReadByte(0x21CE441F) == 0)
                        {
                            RollFishingQuestReward(1);
                        }
                        else
                        {
                            RollFishingQuestTwoReward(1);
                        }

                        currentDialogue = "Nicely done!^Here´s your reward: " + fishingPoints + " Fishing Points!";
                    }
                }
                else
                {
                    currentDialogue = "Show me your hunting skills!¤Wait, you don´t hunt anything?¤Well, I guess fishing could count^as hunting. I can give you some^Fishing Quests.¤Keep in mind that there are two^fishing locations here!";
                }

            }
            else if (characterID == 13363) //sam
            {
                TownCharacter.characterIDData = characterID;

                if (Memory.ReadByte(0x21CE4479) == 1)
                {
                    SetSideQuestAddresses(characterID);
                    if (Memory.ReadByte(0x21CE4427) == 0)
                    {
                        int whichQuest = rnd.Next(100);

                        if (whichQuest < 50)
                        {
                            Memory.WriteOneByte(0x21CE4428, BitConverter.GetBytes(0));
                            GenerateFishingQuestOne();
                            if (Memory.ReadByte(0x21CE442F) < 3)
                            {
                                int questsLeft = 3 - Memory.ReadByte(0x21CE442F);
                                currentDialogue = "Your quest is to catch^" + generatedNeededFishCount + " " + generatedFishName + " at the Queens Sea.¤Additionally, if you can complete^" + questsLeft + " more quests for me, I´ll give^you a special reward!";
                            }
                            else
                            {
                                currentDialogue = "Your quest is to catch^" + generatedNeededFishCount + " " + generatedFishName + " at the Queens Sea.^Good luck!";
                            }
                        }
                        else
                        {
                            Memory.WriteOneByte(0x21CE4428, BitConverter.GetBytes(1));
                            GenerateFishingQuestTwo();
                            if (Memory.ReadByte(0x21CE442F) < 3)
                            {
                                int questsLeft = 3 - Memory.ReadByte(0x21CE442F);
                                currentDialogue = "Your quest is to catch any fish^of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Queens Sea.¤Additionally, if you can complete^" + questsLeft + " more quests for me, I´ll give^you a special reward!";
                            }
                            else
                            {
                                currentDialogue = "Your quest is to catch any fish^of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Queens Sea.^Good luck!";
                            }
                        }
                    }
                    else if (Memory.ReadByte(0x21CE4427) == 1)
                    {
                        if (Memory.ReadByte(0x21CE4428) == 0)
                        {
                            GetFishingQuestOneValues(2);
                            if (Memory.ReadByte(0x21CE442F) < 3)
                            {
                                int questsLeft = 3 - Memory.ReadByte(0x21CE442F);
                                currentDialogue = "You´re still on the quest to catch^" + generatedFishName + " at the Queens Sea,^just " + generatedNeededFishCount + " left!¤Additionally, if you can complete^" + questsLeft + " more quests for me, I´ll give^you a special reward!";
                            }
                            else
                            {
                                currentDialogue = "You´re still on the quest to catch^" + generatedFishName + " at the Queens Sea,^just " + generatedNeededFishCount + " left!";
                            }
                        }
                        else
                        {
                            GetFishingQuestTwoValues();
                            if (Memory.ReadByte(0x21CE442F) < 3)
                            {
                                int questsLeft = 3 - Memory.ReadByte(0x21CE442F);
                                currentDialogue = "You´re still on the quest to catch any^fish of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Queens Sea.¤Additionally, if you can complete^" + questsLeft + " more quests for me, I´ll give^you a special reward!";
                            }
                            else
                            {
                                currentDialogue = "You´re still on the quest to catch any^fish of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Queens Sea.^Good luck!";
                            }
                        }
                    }
                    else if (Memory.ReadByte(0x21CE4427) == 2)
                    {
                        if (Memory.ReadByte(0x21CE4428) == 0)
                        {
                            RollFishingQuestReward(2);
                        }
                        else
                        {
                            RollFishingQuestTwoReward(2);
                        }

                        if (Memory.ReadByte(0x21CE442F) == 3)
                        {
                            currentDialogue = "Awesome,^you completed 3 quests for me!¤As a special reward, you can now^see the fish at the Queens Sea!^Cool, right?¤I´ll also give the regular quest^reward: here´s " + fishingPoints + " fishing points!";
                            TownCharacter.queensQuest = true;
                        }
                        else if (Memory.ReadByte(0x21CE442F) < 3)
                        {
                            int questsLeft = 3 - Memory.ReadByte(0x21CE442F);
                            currentDialogue = "Nicely done!^Here´s your reward: " + fishingPoints + " Fishing Points!¤If you can complete " + questsLeft + " more quests for^me, I´ll give you a special reward!";
                        }
                        else
                        {
                            currentDialogue = "Nicely done!^Here´s your reward: " + fishingPoints + " Fishing Points!";
                        }
                    }
                }
                else
                {
                    currentDialogue = "Fighting monsters in the dungeons^must be exhausting.¤Why don´t you relax with^some Fishing Quests?¤Talk to me for Fishing Quests...^oh by the way, I also have^a special reward!";
                }
            }
            else if (characterID == 13109) //devia
            {
                TownCharacter.characterIDData = characterID;
                if (Memory.ReadByte(0x21CE447B) == 1)
                {
                    SetSideQuestAddresses(characterID);
                    if (Memory.ReadByte(0x21CE4431) == 0)
                    {
                        int whichQuest = rnd.Next(100);

                        if (whichQuest < 50)
                        {
                            Memory.WriteOneByte(0x21CE4432, BitConverter.GetBytes(0));
                            GenerateFishingQuestOne();
                            currentDialogue = "Your quest is to catch^" + generatedNeededFishCount + " " + generatedFishName + " at the Oasis.^Good luck!";
                        }
                        else
                        {
                            Memory.WriteOneByte(0x21CE4432, BitConverter.GetBytes(1));
                            GenerateFishingQuestTwo();
                            currentDialogue = "Your quest is to catch any fish^of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Oasis.^Good luck!";
                        }
                    }
                    else if (Memory.ReadByte(0x21CE4431) == 1)
                    {
                        if (Memory.ReadByte(0x21CE4432) == 0)
                        {
                            GetFishingQuestOneValues(3);
                            currentDialogue = "You´re still on the quest to catch^" + generatedFishName + " at the Oasis,^just " + generatedNeededFishCount + " left!";
                        }
                        else
                        {
                            GetFishingQuestTwoValues();
                            currentDialogue = "You´re still on the quest to catch any^fish of a size from " + generatedMinFishSize + " cm to " + generatedMaxFishSize + " cm^at the Oasis.^Good luck!";
                        }
                    }
                    else if (Memory.ReadByte(0x21CE4431) == 2)
                    {
                        if (Memory.ReadByte(0x21CE4432) == 0)
                        {
                            RollFishingQuestReward(3);
                        }
                        else
                        {
                            RollFishingQuestTwoReward(3);
                        }
                        currentDialogue = "Nicely done!^Here´s your reward: " + fishingPoints + " Fishing Points!";
                    }
                }
                else
                {
                    currentDialogue = "I heard some tourists like to fish at^the Oasis, since you can apparently^find rare fish in there.¤And speaking of fishing... would you^like some Fishing Quests?";
                }
            }
            else if (characterID == 13360) //laura
            {
                TownCharacter.characterIDData = characterID;

                if (Memory.ReadByte(0x21CE4451) == 0)
                {
                    currentDialogue = "I heard some whispers that if^you venture to the backfloors in the^Divine Beast Cave, you might^come across a rare item.¤Apparently it´s a some^kind of powder.";                  
                }
                else
                {
                    bool hasItem = CheckItemQuestReward(171);
                    if (hasItem)
                    {
                        currentDialogue = "Oh, you found it? Great!^It´s a medusa powder?¤You ask me how to use it?^Sorry, I don´t know what it is.";
                    }
                    else
                    {
                        currentDialogue = "Did you find that rare item yet?^Apparently it can be found somewhere in^the backfloors of Divine Beast Cave.";
                    }
                }
            }
            else if (characterID == 12594) //Ro
            {
                TownCharacter.characterIDData = characterID;

                if (Memory.ReadByte(0x21CE4452) == 0)
                {
                    currentDialogue = "One of the Wise Owl Forest´s owls^told me that somewhere deep at the^backsides of the Forest, you can^find some mysterious item.¤It´s said to be an ancient item, and^of which purpose had never been^able to be fulfilled.";
                }
                else
                {
                    bool hasItem = CheckItemQuestReward(173);
                    if (hasItem)
                    {
                        currentDialogue = "You have acquired the ancient item?^You say it´s a warp powder?¤Hmmm, something like that sounds too^powerful, maybe that´s why it hasn´t^been able to show its potential.";
                    }
                    else
                    {
                        currentDialogue = "Have you found the ancient item yet?^It´s said to be somewhere at the^backfloors of Wise Owl Forest.";
                    }
                }
            }
            else if ( characterID == 12852) //phil
            {
                TownCharacter.characterIDData = characterID;

                if (Memory.ReadByte(0x21CE4453) == 0)
                {
                    currentDialogue = "There are some more details I^didn´t tell you about the Queen.¤It´s rumoured that when she sank^to the bottom of the Shipwreck,^her wedding ring got lost.¤The ring might still be somewhere^deep in the Shipwreck. Do you^think you can find it?";
                }
                else
                {
                    bool hasItem = CheckItemQuestReward(243);
                    if (hasItem)
                    {
                        currentDialogue = "You found the Queen´s wedding ring?^I see, so the rumours were true!^Interesting.¤You can keep the ring, who knows^where you might need it^in your adventure.";
                    }
                    else
                    {
                        currentDialogue = "The Queen´s wedding ring could^be hiding somewhere at the backside^of Shipwreck. Good luck searching!";
                    }
                }
            }
            else if (characterID == 12341) //zabo
            {
                TownCharacter.characterIDData = characterID;

                if (Memory.ReadByte(0x21CE4454) == 0)
                {
                    currentDialogue = "A long time ago, there used to be^this rare and mysterious yellow^powder, and no, I´m not talking^about repair powder.¤The true details of this powder are^unknown, but the ancients might have^left one at the dark side of^the Sun & Moon Temple.";
                }
                else
                {
                    bool hasItem = CheckItemQuestReward(172);
                    if (hasItem)
                    {
                        currentDialogue = "I see that you have found the^mysterious powder. I believe the^ancients used to call it^a Hardening Powder.¤I wish we knew more about it.";
                    }
                    else
                    {
                        currentDialogue = "Did you find the powder yet?^There might still be one somewhere at^the dark side of Sun & Moon Temple.";
                    }
                }
            }
            else if (characterID == 13361) //mayor
            {
                TownCharacter.characterIDData = characterID;

                if (Memory.ReadByte(0x21CE4464) == 0)
                {
                    bool hasWeapon = CheckWeapon(298);
                    if (Memory.ReadByte(0x21CE4463) == 1)
                    {
                        currentDialogue = "Woah, you truly are something!¤You know what?^Since you proved your power of will^to collect everything, how about^doing some bonus sidequests?¤You already got so far, so why not^keep going, right?";
                    }
                    else if (hasWeapon == true)
                    {
                        currentDialogue = "You conquered the Demon Shaft?^Well done!¤Unfortunately you´re still not^ready for my quests.¤Come back when you´ve obtained^everything in this world.";
                    }
                    else
                    {
                        currentDialogue = "I might have some quests for you later.¤But for now, come back when^you´re more experienced.";
                    }
                }
                else if (Memory.ReadByte(0x21CE4464) == 1)
                {
                    Memory.WriteByte(0x20293978, 250);
                    Memory.WriteByte(0x2029397A, 250);
                    Memory.WriteByte(0x2029397C, 250);
                    Memory.WriteByte(0x2029397E, 250);
                    Memory.WriteByte(0x20293980, 250);
                    Memory.WriteByte(0x20293982, 250);                    
                    currentDialogue = "After you left Norune, I happened^to collect a bunch of Fruit of Edens,^Gourds and Defence items.¤I´ll assign you some slightly^challenging Dungeon quests, and for^the reward you´ll get one of the^random boost items, as long as^you´re not maxed on them.¤All your party members´s maximum^health has increased to 250,^maximum thirst to 12 and^maximum defence to 99.¤Do you have what it takes^to max your abilities?";
                }
                else if (Memory.ReadByte(0x21CE4464) == 2)
                {
                    if (Memory.ReadByte(0x21CE4468) == 0)
                    {
                        currentDialogue = SetMayorSidequest();
                    }
                    else if (Memory.ReadByte(0x21CE4468) == 1)
                    {
                        currentDialogue = GetMayorSidequest();
                    }
                    else
                    {
                        currentDialogue = GetMayorSidequestReward();
                    }
                }
                else
                {
                    currentDialogue = "I have no more quests to give.^Perhaps you´ve finally^achieved everything?";
                }
            }
            return currentDialogue;
        }

        public static void GenerateMonsterQuest()
        {

            int dngs = 0;
            currentAddress = 0x21CDD80B;
            for (int i = 0; i < 6; i++)
            {
                if (Memory.ReadByte(currentAddress) != 255)
                {
                    dngs++;
                    currentAddress += 0x00000001;
                }
                else
                {
                    break;
                }
            }

            bool checkDuplicate = true;           
            while (checkDuplicate)
            {
                rolledDng = rnd.Next(0, dngs);
                switch (rolledDng)
                {
                    case 0:
                        rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                        if (Memory.ReadByte(0x21CE448C) == 0) //flag for first quest complete
                        {
                            rolledEnemy = 1;
                        }
                        generatedEnemyName = DBCEnemies[rolledEnemy];
                        enemyID = DBCEnemyIDs[rolledEnemy];
                        break;
                    case 1:
                        rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                        generatedEnemyName = WOFEnemies[rolledEnemy];
                        enemyID = WOFEnemyIDs[rolledEnemy];
                        break;
                    case 2:
                        rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                        generatedEnemyName = ShipwreckEnemies[rolledEnemy];
                        enemyID = ShipwreckEnemyIDs[rolledEnemy];
                        break;
                    case 3:
                        rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                        generatedEnemyName = SMEnemies[rolledEnemy];
                        enemyID = SMEnemyIDs[rolledEnemy];
                        break;
                    case 4:
                        rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                        generatedEnemyName = MoonSeaEnemies[rolledEnemy];
                        enemyID = MoonSeaEnemyIDs[rolledEnemy];
                        break;
                    case 5:
                        rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                        generatedEnemyName = GOFEnemies[rolledEnemy];
                        enemyID = GOFEnemyIDs[rolledEnemy];
                        break;
                    case 6: //demon shaft
                        rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                        generatedEnemyName = DBCEnemies[rolledEnemy];
                        enemyID = DBCEnemyIDs[rolledEnemy];
                        break;
                }

                if (Memory.ReadByte(0x21CE4406) == enemyID || Memory.ReadByte(0x21CE440B) == enemyID || Memory.ReadByte(0x21CE4410) == enemyID || Memory.ReadByte(0x21CE4415) == enemyID)
                {
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() +  "Duplicate quest, rerolling...");
                    checkDuplicate = true;
                }
                else
                {
                    checkDuplicate = false;
                }
            }

            generatedMonsterQuestDungeon = dungeonNames[rolledDng];
            generatedEnemyKillsNeeded = rnd.Next(8, 19);

            Memory.WriteOneByte(currentAddressDungeonID, BitConverter.GetBytes(rolledDng));
            Memory.WriteOneByte(currentAddressEnemyName, BitConverter.GetBytes(rolledEnemy));
            Memory.WriteOneByte(currentAddressEnemyCounter, BitConverter.GetBytes(generatedEnemyKillsNeeded));
            Memory.WriteOneByte(currentAddressEnemyID, BitConverter.GetBytes(enemyID));
        }

        public static void SetSideQuestAddresses(int characterID)
        {
            if (characterID == 12592) //macho
            {
                currentAddressDungeonID = 0x21CE4403;
                currentAddressEnemyName = 0x21CE4404;
                currentAddressEnemyCounter = 0x21CE4405;
                currentAddressEnemyID = 0x21CE4406;
            }
            else if (characterID == 13618) //gob
            {
                currentAddressDungeonID = 0x21CE4408;
                currentAddressEnemyName = 0x21CE4409;
                currentAddressEnemyCounter = 0x21CE440A;
                currentAddressEnemyID = 0x21CE440B;
            }
            else if (characterID == 13108) //jake
            {
                currentAddressDungeonID = 0x21CE440D;
                currentAddressEnemyName = 0x21CE440E;
                currentAddressEnemyCounter = 0x21CE440F;
                currentAddressEnemyID = 0x21CE4410;
            }
            else if (characterID == 14388) //chiefbonka
            {
                currentAddressDungeonID = 0x21CE4412;
                currentAddressEnemyName = 0x21CE4413;
                currentAddressEnemyCounter = 0x21CE4414;
                currentAddressEnemyID = 0x21CE4415;
            }
            else if (characterID == 13872) //pike
            {
                currentAddressFishingQuestType = 0x21CE4417;
                currentAddressFishName = 0x21CE4418;
                currentAddressFishID = 0x21CE4419;
                currentAddressFishLeftCounter = 0x21CE441A;
                currentAddressFishMinSizeReq = 0x21CE441B;
                currentAddressFishMaxSizeReq = 0x21CE441C;
                currentAddressOriginalFishCounter = 0x21CE441D;
            }
            else if (characterID == 13362) //pao
            {
                currentAddressFishingQuestType = 0x21CE441F;
                currentAddressFishName = 0x21CE4420;
                currentAddressFishID = 0x21CE4421;
                currentAddressFishLeftCounter = 0x21CE4422;
                currentAddressFishMinSizeReq = 0x21CE4423;
                currentAddressFishMaxSizeReq = 0x21CE4424;
                currentAddressOriginalFishCounter = 0x21CE4425;
                currentAddressMatatakiLocation = 0x21CE4426;
            }
            else if (characterID == 13363) //sam
            {
                currentAddressFishingQuestType = 0x21CE4428;
                currentAddressFishName = 0x21CE4429;
                currentAddressFishID = 0x21CE442A;
                currentAddressFishLeftCounter = 0x21CE442B;
                currentAddressFishMinSizeReq = 0x21CE442C;
                currentAddressFishMaxSizeReq = 0x21CE442D;
                currentAddressOriginalFishCounter = 0x21CE442E;
                currentAddressQueensQuestsCompleteCount = 0x21CE442F;
            }
            else if (characterID == 13109) //devia
            {
                currentAddressFishingQuestType = 0x21CE4432;
                currentAddressFishName = 0x21CE4433;
                currentAddressFishID = 0x21CE4434;
                currentAddressFishLeftCounter = 0x21CE4435;
                currentAddressFishMinSizeReq = 0x21CE4436;
                currentAddressFishMaxSizeReq = 0x21CE4437;
                currentAddressOriginalFishCounter = 0x21CE4438;
            }
        }

        public static void GetMonsterQuestValues()
        {
            getDngID = Memory.ReadByte(currentAddressDungeonID);
            getEnemyID = Memory.ReadByte(currentAddressEnemyName);
            getEnemyCounter = Memory.ReadByte(currentAddressEnemyCounter);

            generatedMonsterQuestDungeon = dungeonNames[getDngID];
            switch (getDngID)
            {
                case 0:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
                case 1:
                    generatedEnemyName = WOFEnemies[getEnemyID];
                    break;
                case 2:
                    generatedEnemyName = ShipwreckEnemies[getEnemyID];
                    break;
                case 3:
                    generatedEnemyName = SMEnemies[getEnemyID];
                    break;
                case 4:
                    generatedEnemyName = MoonSeaEnemies[getEnemyID];
                    break;
                case 5:
                    generatedEnemyName = GOFEnemies[getEnemyID];
                    break;
                case 6:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
            }
            generatedEnemyKillsNeeded = getEnemyCounter;
        }

        public static bool CheckCurrentDungeonQuests(int currentDungeon)
        {
            bool questActive = false;
            if (Memory.ReadByte(0x21CE4402) == 1)
            {
                Dungeon.monsterQuestMachoActive = true;
                questActive = true;
            }
            else
                Dungeon.monsterQuestMachoActive = false;

            if (Memory.ReadByte(0x21CE4407) == 1)
            {
                Dungeon.monsterQuestGobActive = true;
                questActive = true;
            }
            else
                Dungeon.monsterQuestGobActive = false;

            if (Memory.ReadByte(0x21CE440C) == 1)
            {
                Dungeon.monsterQuestJakeActive = true;
                questActive = true;
            }
            else
                Dungeon.monsterQuestJakeActive = false;

            if (Memory.ReadByte(0x21CE4411) == 1)
            {
                Dungeon.monsterQuestChiefActive = true;
                questActive = true;
            }
            else
                Dungeon.monsterQuestChiefActive = false;


            if (questActive)
                return true;
            else
                return false;
        }

        public static void MonsterQuestReward()
        {
            currentAddress = 0x21CDD8BA;
            for (int i = 0; i < 102; i++)
            {
                if (Memory.ReadUShort(currentAddress) > 60000)
                {
                    Memory.WriteUShort(currentAddress, 178);
                    break;
                }
                else
                {
                    currentAddress += 0x00000002;
                }
            }

            if (Memory.ReadByte(0x21CE448C) == 0)
            {
                Memory.WriteByte(0x21CE448C, 1);
            }
        }

        public static void GenerateFishingQuestOne()
        {
            int currentlocation = Memory.ReadByte(0x202A2518);

            switch (currentlocation)
            {
                case 0:
                    rolledFish = rnd.Next(0, NorunePondFish.Length);
                    generatedFishName = NorunePondFish[rolledFish];
                    fishID = NorunePondFishIDs[rolledFish];
                    generatedNeededFishCount = rnd.Next(2, 3);
                    break;
                case 1:
                    if (matatakiLocation < 50)
                    {
                        rolledFish = rnd.Next(0, MatatakiPondFish.Length);
                        generatedFishName = MatatakiPondFish[rolledFish];
                        fishID = MatatakiPondFishIDs[rolledFish];
                        generatedNeededFishCount = rnd.Next(2, 3);
                        if (rolledFish == 0)
                        {
                            matatakiLocationID = 2;
                        }
                        else
                        {
                            matatakiLocationID = 0;
                        }
                    }
                    else
                    {
                        rolledFish = rnd.Next(0, MatatakiWaterfallFish.Length);
                        if (rolledFish == 3 || rolledFish == 4) //mardan/baron
                        {
                            rolledFish = rnd.Next(0, MatatakiWaterfallFish.Length);
                        }
                        generatedFishName = MatatakiWaterfallFish[rolledFish];
                        fishID = MatatakiWaterfallFishIDs[rolledFish];
                        if (rolledFish == 3 || rolledFish == 4) //mardan/baron
                        {
                            generatedNeededFishCount = 1;
                        }
                        else
                        {
                            generatedNeededFishCount = rnd.Next(2, 3);
                        }
                        if (rolledFish == 0)
                        {
                            matatakiLocationID = 2;
                        }
                        else
                        {
                            matatakiLocationID = 1;
                        }
                    }
                    Memory.WriteOneByte(currentAddressMatatakiLocation, BitConverter.GetBytes(matatakiLocationID));
                    break;
                case 2:
                    rolledFish = rnd.Next(0, QueensSeaFish.Length);
                    generatedFishName = QueensSeaFish[rolledFish];
                    fishID = QueensSeaFishIDs[rolledFish];
                    generatedNeededFishCount = rnd.Next(2, 3);
                    break;
                case 3:
                    rolledFish = rnd.Next(0, MuskaOasisFish.Length);
                    if (rolledFish == 3 || rolledFish == 4) //mardan/baron
                    {
                        rolledFish = rnd.Next(0, MuskaOasisFish.Length);
                    }
                    generatedFishName = MuskaOasisFish[rolledFish];
                    fishID = MuskaOasisFishIDs[rolledFish];
                    if (rolledFish == 3) //mardan/baron
                    {
                        generatedNeededFishCount = rnd.Next(1, 3);
                    }
                    else if (rolledFish == 4)
                    {
                        generatedNeededFishCount = 1;
                    }
                    else
                    {
                        generatedNeededFishCount = rnd.Next(2, 3);
                    }
                    break;

                default:
                    rolledFish = rnd.Next(0, NorunePondFish.Length);
                    generatedFishName = NorunePondFish[rolledFish];
                    fishID = NorunePondFishIDs[rolledFish];
                    generatedNeededFishCount = rnd.Next(2, 3);
                    break;


            }

            Memory.WriteOneByte(currentAddressFishName, BitConverter.GetBytes(rolledFish));
            Memory.WriteOneByte(currentAddressFishID, BitConverter.GetBytes(fishID));
            Memory.WriteOneByte(currentAddressFishLeftCounter, BitConverter.GetBytes(generatedNeededFishCount));
            Memory.WriteOneByte(currentAddressOriginalFishCounter, BitConverter.GetBytes(generatedNeededFishCount));
        }

        public static void GenerateFishingQuestTwo()
        {
            int currentlocation = Memory.ReadByte(0x202A2518);
            int fishSize;
            switch (currentlocation)
            {
                case 0:
                    fishSize = rnd.Next(80, 141);
                    generatedMinFishSize = fishSize;
                    generatedMaxFishSize = fishSize + 5;
                    Memory.WriteOneByte(currentAddressFishMinSizeReq, BitConverter.GetBytes(generatedMinFishSize));
                    Memory.WriteOneByte(currentAddressFishMaxSizeReq, BitConverter.GetBytes(generatedMaxFishSize));
                    break;
                case 1:
                    fishSize = rnd.Next(80, 141);
                    generatedMinFishSize = fishSize;
                    generatedMaxFishSize = fishSize + 5;
                    Memory.WriteOneByte(currentAddressFishMinSizeReq, BitConverter.GetBytes(generatedMinFishSize));
                    Memory.WriteOneByte(currentAddressFishMaxSizeReq, BitConverter.GetBytes(generatedMaxFishSize));
                    break;
                case 2:
                    fishSize = rnd.Next(90, 161);
                    generatedMinFishSize = fishSize;
                    generatedMaxFishSize = fishSize + 10;
                    Memory.WriteOneByte(currentAddressFishMinSizeReq, BitConverter.GetBytes(generatedMinFishSize));
                    Memory.WriteOneByte(currentAddressFishMaxSizeReq, BitConverter.GetBytes(generatedMaxFishSize));
                    break;
                case 3:
                    fishSize = rnd.Next(100, 181);
                    generatedMinFishSize = fishSize;
                    generatedMaxFishSize = fishSize + 5;
                    Memory.WriteOneByte(currentAddressFishMinSizeReq, BitConverter.GetBytes(generatedMinFishSize));
                    Memory.WriteOneByte(currentAddressFishMaxSizeReq, BitConverter.GetBytes(generatedMaxFishSize));
                    break;             
            }
        }

        public static void GetFishingQuestOneValues(int area)
        {
            getFishID = Memory.ReadByte(currentAddressFishName);
            getFishCounter = Memory.ReadByte(currentAddressFishLeftCounter);

            switch (area)
            {
                case 0:
                    generatedFishName = NorunePondFish[getFishID];
                    break;
                case 1:
                    matatakiLocationID = Memory.ReadByte(currentAddressMatatakiLocation);
                    if (matatakiLocationID == 0)
                    {
                        generatedFishName = MatatakiPondFish[getFishID];
                    }
                    else if (matatakiLocationID == 1)
                    {
                        generatedFishName = MatatakiWaterfallFish[getFishID];
                    }
                    else
                    {
                        generatedFishName = MatatakiPondFish[getFishID];
                    }              
                    break;
                case 2:
                    generatedFishName = QueensSeaFish[getFishID];
                    break;
                case 3:
                    generatedFishName = MuskaOasisFish[getFishID];
                    break;

                default:
                    generatedFishName = NorunePondFish[getFishID];
                    break;
            }

            generatedNeededFishCount = getFishCounter;           
        }

        public static void GetFishingQuestTwoValues()
        {
            generatedMinFishSize = Memory.ReadByte(currentAddressFishMinSizeReq);
            generatedMaxFishSize = Memory.ReadByte(currentAddressFishMaxSizeReq);
        }

        public static void RollFishingQuestReward(int area)
        {
            if (area == 0)
            {
                randomizedFPoints = rnd.Next(35, 66);
                fishMultiplier = Memory.ReadByte(0x21CE441D);
                fishingPoints = randomizedFPoints * fishMultiplier;
            }
            else if (area == 1)
            {
                randomizedFPoints = rnd.Next(43, 74);
                fishMultiplier = Memory.ReadByte(0x21CE4425);
                fishingPoints = randomizedFPoints * fishMultiplier;
                if (Memory.ReadByte(0x21CE4421) == 5 || Memory.ReadByte(0x21CE4421) == 17)
                {
                    fishingPoints = fishingPoints * 2;
                }
            }
            else if (area == 2)
            {
                randomizedFPoints = rnd.Next(51, 82);
                fishMultiplier = Memory.ReadByte(0x21CE442E);
                fishingPoints = randomizedFPoints * fishMultiplier;
            }
            else if (area == 3)
            {
                randomizedFPoints = rnd.Next(60, 91);
                fishMultiplier = Memory.ReadByte(0x21CE4438);
                fishingPoints = randomizedFPoints * fishMultiplier;
            }
        }

        public static void RollFishingQuestTwoReward(int area)
        {
            fishingPoints = rnd.Next(Memory.ReadByte(currentAddressFishMaxSizeReq) - 30, Memory.ReadByte(currentAddressFishMaxSizeReq));
            if (area == 1)
            {
                fishingPoints += 10;
            }
            else if (area == 2)
            {
                fishingPoints += 20;
            }
            else if (area == 3)
            {
                fishingPoints += 30;
            }
        }

        public static void GetFishingQuestReward()
        {
            currentAddress = 0x21CD431C;
            int currentFP = Memory.ReadUShort(currentAddress);
            currentFP = currentFP + fishingPoints;
            Memory.WriteInt(currentAddress, currentFP);
        }

        public static bool CheckItemQuestReward(byte itemID, bool checkinv = true, bool checkstorage = true)
        {
            int checkitemid;
            if (checkinv)
            {
                currentAddress = 0x21CDD8BA; //first inventory slot
                for (int i = 0; i < 100; i++) //check which items player has in bag
                {
                    checkitemid = Memory.ReadUShort(currentAddress);
                    if (checkitemid == itemID)
                    {
                        return true;
                    }
                    currentAddress += 0x00000002;
                }
            }

            if (checkstorage)
            {
                currentAddress = 0x21CE21E8; //first storage slot
                for (int i = 0; i < 60; i++) //check which items player has in storage
                {
                    checkitemid = Memory.ReadUShort(currentAddress);
                    if (checkitemid == itemID)
                    {
                        return true;
                    }
                    currentAddress += 0x00000002;
                }
            }

            return false;
        }

        public static bool CheckWeapon(int weaponID, bool checkinv = true, bool checkstorage = true)
        {
            int checkitemid;
            if (checkinv)
            {
                currentAddress = 0x21CDDA58; //first weapon slot
                for (int i = 0; i < 10; i++) //check which weapons player has in bag
                {
                    checkitemid = Memory.ReadUShort(currentAddress);
                    if (checkitemid == weaponID)
                    {
                        return true;
                    }
                    currentAddress += 0x000000F8;
                }
            }

            if (checkstorage)
            {
                currentAddress = 0x21CE22D8; //first storage weapon slot
                for (int i = 0; i < 30; i++) //check which weapons player has in storage
                {
                    checkitemid = Memory.ReadUShort(currentAddress);
                    if (checkitemid == weaponID)
                    {
                        return true;
                    }
                    currentAddress += 0x000000F8;
                }
            }

            return false;
        }


        public static bool CheckItemsForMCQuest()
        {
            currentAddress = 0x21CDD8BA;
            if (Memory.ReadShort(currentAddress) == 167)
            {
                currentAddress += 0x00000002;
                if (Memory.ReadShort(currentAddress) == 175)
                {
                    currentAddress += 0x00000002;
                    if (Memory.ReadShort(currentAddress) == 150)
                    {
                        currentAddress += 0x00000002;
                        if (Memory.ReadShort(currentAddress) == 159)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }                  
        }

        public static string SetMayorSidequest()
        {
            string dialogue;

            demonshaftfloor = rnd.Next(1, 100);
            demonshaftally = rnd.Next(0, 6);
            Memory.WriteOneByte(0x21CE4469, BitConverter.GetBytes(demonshaftfloor));
            Memory.WriteOneByte(0x21CE446A, BitConverter.GetBytes(demonshaftally));

            dialogue = "Clear the backside of the floor " + demonshaftfloor + "^in Demon Shaft, using only " + alliesChar[demonshaftally] + ".¤You can buy backfloor keys from Fairy King.";

            return dialogue;
        }

        public static string GetMayorSidequest()
        {
            string dialogue = "";

            demonshaftfloor = Memory.ReadByte(0x21CE4469);
            demonshaftally = Memory.ReadByte(0x21CE446A);

            dialogue = "Clear the backside of the floor " + demonshaftfloor + "^in Demon Shaft, using only " + alliesChar[demonshaftally] + ".¤You can buy backfloor keys from Fairy King.";

            return dialogue;
        }

        public static string GetMayorSidequestReward()
        {
            string dialogue = "";
            string rewardItem = "";

            checkHPs = false;
            checkDEFs = false;
            checkThirsts = false;
            HPreward = false;
            DEFreward = false;
            Thirstreward = false;

            if (Memory.ReadByte(0x21CD9552) < 250 || Memory.ReadByte(0x21CD9554) < 250 || Memory.ReadByte(0x21CD9556) < 250 || Memory.ReadByte(0x21CD9558) < 250 || Memory.ReadByte(0x21CD955A) < 250 || Memory.ReadByte(0x21CD955C) < 250)
            {
                checkHPs = true;
            }

            if (Memory.ReadByte(0x21CDD894) < 99 || Memory.ReadByte(0x21CDD898) < 99 || Memory.ReadByte(0x21CDD89C) < 99 || Memory.ReadByte(0x21CDD8A0) < 99 || Memory.ReadByte(0x21CDD8A4) < 99 || Memory.ReadByte(0x21CDD8A8) < 99)
            {
                checkDEFs = true;
            }

            if (Memory.ReadFloat(0x21CDD838) < 120 || Memory.ReadFloat(0x21CDD83C) < 120 || Memory.ReadFloat(0x21CDD840) < 120 || Memory.ReadFloat(0x21CDD844) < 120 || Memory.ReadFloat(0x21CDD848) < 120 || Memory.ReadFloat(0x21CDD84C) < 120)
            {
                checkThirsts = true;
            }

            if (checkHPs == false && checkDEFs == false && checkThirsts == false)
            {
                dialogue = "I can´t believe it!¤You actually went and^maxed all the stats!¤Thank you for completing all^my quests, and also...¤Thank you for playing the Enchanted Mod!";
                Memory.WriteByte(0x21CE446B, 1);
                return dialogue;
            }

            int rewardType = rnd.Next(300);

            if (rewardType >= 200)
            {
                if (checkHPs)
                {
                    HPreward = true;
                }
                else if (checkDEFs)
                {
                    DEFreward = true;
                }
                else
                {
                    Thirstreward = true;
                }
            }
            else if (rewardType >= 100)
            {
                if (checkDEFs)
                {
                    DEFreward = true;
                }
                else if (checkThirsts)
                {
                    Thirstreward = true;
                }
                else
                {
                    HPreward = true;
                }
            }
            else
            {
                if (checkThirsts)
                {
                    Thirstreward = true;
                }
                else
                {
                    int rollRew = rnd.Next(100);
                    if (rollRew > 50)
                    {
                        if (checkHPs)
                        {
                            HPreward = true;
                        }
                        else
                        {
                            DEFreward = true;
                        }
                    }
                    else
                    {
                        if (checkDEFs)
                        {
                            DEFreward = true;
                        }
                        else
                        {
                            HPreward = true;
                        }
                    }
                }
            }
            if (HPreward)
            {
                TownCharacter.mayorReward = 180;
                rewardItem = "Fruit of Eden";
            }
            else if (Thirstreward)
            {
                TownCharacter.mayorReward = 182;
                rewardItem = "Gourd";
            }
            else
            {
                checkToanDEF = false;
                checkXiaoDEF = false;
                checkGoroDEF = false;
                checkRubyDEF = false;
                checkUngagaDEF = false;
                checkOsmondDEF = false;

                if (Memory.ReadByte(0x21CDD894) < 99)
                    checkToanDEF = true;
                if (Memory.ReadByte(0x21CDD898) < 99)
                    checkXiaoDEF = true;
                if (Memory.ReadByte(0x21CDD89C) < 99)
                    checkGoroDEF = true;
                if (Memory.ReadByte(0x21CDD8A0) < 99)
                    checkRubyDEF = true;
                if (Memory.ReadByte(0x21CDD8A4) < 99)
                    checkUngagaDEF = true;
                if (Memory.ReadByte(0x21CDD8A8) < 99)
                    checkOsmondDEF = true;

                bool rolledAlly = false;
                int count = 0;
                int rollAlly;
                while (rolledAlly == false && count < 1000)
                {
                    rollAlly = rnd.Next(6);

                    if (rollAlly == 0 && checkToanDEF == true)
                    {
                        TownCharacter.mayorReward = 136;
                        rewardItem = "Fluffy Doughnut";
                        rolledAlly = true;
                    }
                    else if (rollAlly == 1 && checkXiaoDEF == true)
                    {
                        TownCharacter.mayorReward = 137;
                        rewardItem = "Fish Candy";
                        rolledAlly = true;
                    }
                    else if (rollAlly == 2 && checkGoroDEF == true)
                    {
                        TownCharacter.mayorReward = 138;
                        rewardItem = "Grass Cake";
                        rolledAlly = true;
                    }
                    else if (rollAlly == 3 && checkRubyDEF == true)
                    {
                        TownCharacter.mayorReward = 139;
                        rewardItem = "Witch Parfait";
                        rolledAlly = true;
                    }
                    else if (rollAlly == 4 && checkUngagaDEF == true)
                    {
                        TownCharacter.mayorReward = 140;
                        rewardItem = "Scorpion Jerky";
                        rolledAlly = true;
                    }
                    else if (rollAlly == 5 && checkOsmondDEF == true)
                    {
                        TownCharacter.mayorReward = 141;
                        rewardItem = "Carrot Cookie";
                        rolledAlly = true;
                    }
                    count++;
                    if (count == 1000)
                    {
                        TownCharacter.mayorReward = 0;
                        rewardItem = "Nothing!";
                    }
                }
            }

            dialogue = "Nicely done!^Here´s your reward: " + rewardItem + ".";

            return dialogue;
        }
    }
}
