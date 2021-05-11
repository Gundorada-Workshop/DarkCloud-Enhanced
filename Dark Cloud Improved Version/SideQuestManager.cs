using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static int[] DBCEnemyIDs = { 1, 6, 35, 59 };
        static int[] WOFEnemyIDs = { 8, 12, 79, 7 };
        static int[] ShipwreckEnemyIDs = { 23, 24, 81, 25 };
        static int[] SMEnemyIDs = { 30, 32, 37, 73 };
        static int[] MoonSeaEnemyIDs = { 66, 72, 39, 76 };
        static int[] GOFEnemyIDs = { 63, 48, 83, 43 };
        public static string generatedEnemyName;
        public static string generatedMonsterQuestDungeon;
        public static int generatedEnemyKillsNeeded;

        public static int getDngID;
        public static int getEnemyID;
        public static int getEnemyCounter;

        static int currentAddress;
        static int currentAddressDungeonID;
        static int currentAddressEnemyName;
        static int currentAddressEnemyID;
        static int currentAddressEnemyCounter;

        static Random rnd = new Random();
        public static string GetQuestDialogue(string currentDialogue, int characterID)
        {
            if (characterID == 12592)
            {
                TownCharacter.characterIDData = characterID;
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

            int rolledDng = rnd.Next(0, dngs);
            int rolledEnemy = 0;
            int enemyID = 0;
            switch (rolledDng)
            {
                case 0:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
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

            generatedMonsterQuestDungeon = dungeonNames[rolledDng];
            //generatedEnemyKillsNeeded = rnd.Next(8, 21);
            generatedEnemyKillsNeeded = rnd.Next(2, 4);

            Memory.Write(currentAddressDungeonID, BitConverter.GetBytes(rolledDng));
            Memory.Write(currentAddressEnemyName, BitConverter.GetBytes(rolledEnemy));
            Memory.Write(currentAddressEnemyCounter, BitConverter.GetBytes(generatedEnemyKillsNeeded));
            Memory.Write(currentAddressEnemyID, BitConverter.GetBytes(enemyID));
        }

        public static void SetSideQuestAddresses(int characterID)
        {
            if (characterID == 12592)
            {
                currentAddressDungeonID = 0x21CE4403;
                currentAddressEnemyName = 0x21CE4404;
                currentAddressEnemyCounter = 0x21CE4405;
                currentAddressEnemyID = 0x21CE4406;
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
            if (Memory.ReadByte(0x21CE4402) == 1)
            {
                DungeonThread.monsterQuestMachoActive = true;
                return true;
            }
            else
                DungeonThread.monsterQuestMachoActive = false;

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
        }
    }
}
