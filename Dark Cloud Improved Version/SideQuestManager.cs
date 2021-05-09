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
        public static string generatedEnemyName;
        public static string generatedMonsterQuestDungeon;
        public static int generatedEnemyKillsNeeded;

        public static int getDngID;
        public static int getEnemyID;
        public static int getEnemyCounter;

        static int currentAddress;
        static int currentAddressDungeonID;
        static int currentAddressEnemyID;
        static int currentAddressEnemyCounter;

        static Random rnd = new Random();
        public static string GetQuestDialogue(string currentDialogue, int characterID)
        {
            if (characterID == 12337)
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
                    currentDialogue = "Well done, you completed it!^Here´s your reward!";
                }
            }
            return currentDialogue;
        }

        public static void GenerateMonsterQuest()
        {

            int dngs = 0;
            currentAddress = 0x21CDD80B;
            for (int i = 0; i < 7; i++)
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
            switch (rolledDng)
            {
                case 0:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                    generatedEnemyName = DBCEnemies[rolledEnemy];    
                    break;
                case 1:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                    generatedEnemyName = DBCEnemies[rolledEnemy];
                    break;
                case 2:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                    generatedEnemyName = DBCEnemies[rolledEnemy];
                    break;
                case 3:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                    generatedEnemyName = DBCEnemies[rolledEnemy];
                    break;
                case 4:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                    generatedEnemyName = DBCEnemies[rolledEnemy];
                    break;
                case 5:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                    generatedEnemyName = DBCEnemies[rolledEnemy];
                    break;
                case 6:
                    rolledEnemy = rnd.Next(0, DBCEnemies.Length);
                    generatedEnemyName = DBCEnemies[rolledEnemy];
                    break;
            }

            generatedMonsterQuestDungeon = dungeonNames[rolledDng];
            generatedEnemyKillsNeeded = rnd.Next(8, 21);

            Memory.Write(currentAddressDungeonID, BitConverter.GetBytes(rolledDng));
            Memory.Write(currentAddressEnemyID, BitConverter.GetBytes(rolledEnemy));
            Memory.Write(currentAddressEnemyCounter, BitConverter.GetBytes(generatedEnemyKillsNeeded));
        }

        public static void SetSideQuestAddresses(int characterID)
        {
            if (characterID == 12337)
            {
                currentAddressDungeonID = 0x21CE4403;
                currentAddressEnemyID = 0x21CE4404;
                currentAddressEnemyCounter = 0x21CE4405;
            }
        }

        public static void GetMonsterQuestValues()
        {
            getDngID = Memory.ReadByte(currentAddressDungeonID);
            getEnemyID = Memory.ReadByte(currentAddressEnemyID);
            getEnemyCounter = Memory.ReadByte(currentAddressEnemyCounter);

            generatedMonsterQuestDungeon = dungeonNames[getDngID];
            switch (getDngID)
            {
                case 0:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
                case 1:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
                case 2:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
                case 3:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
                case 4:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
                case 5:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
                case 6:
                    generatedEnemyName = DBCEnemies[getEnemyID];
                    break;
            }
            generatedEnemyKillsNeeded = getEnemyCounter;
        }
    }
}
