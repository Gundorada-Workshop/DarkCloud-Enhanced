using System;
using System.Linq;

namespace Dark_Cloud_Improved_Version
{
    class Dialogues
    {
        static string[] customDialogues = new string[15];
        static string[] customDialogues2 = new string[15];
        static string[] sideQuestDialogueOption = new string[15];
        static string[] itsfinishedDialogue = new string[15];
        static string brownbooPickle;
        static string brownbooPickleData;
        static string brownbooPickleExtraDialogue;
        static string[] noruneXiao = new string[15];
        static string[] noruneXiao2 = new string[15];
        static string[] noruneGoro = new string[15];
        static string[] noruneGoro2 = new string[15];
        static string[] noruneRuby = new string[15];
        static string[] noruneRuby2 = new string[15];
        static string[] noruneUngaga = new string[15];
        static string[] noruneUngaga2 = new string[15];
        static string[] noruneOsmond = new string[15];
        static string[] noruneOsmond2 = new string[15];
        static string[] matatakiXiao = new string[15];
        static string[] matatakiXiao2 = new string[15];
        static string[] matatakiGoro = new string[15];
        static string[] matatakiGoro2 = new string[15];
        static string[] matatakiRuby = new string[15];
        static string[] matatakiRuby2 = new string[15];
        static string[] matatakiUngaga = new string[15];
        static string[] matatakiUngaga2 = new string[15];
        static string[] matatakiOsmond = new string[15];
        static string[] matatakiOsmond2 = new string[15];
        static string[] queensXiao = new string[15];
        static string[] queensXiao2 = new string[15];
        static string[] queensGoro = new string[15];
        static string[] queensGoro2 = new string[15];
        static string[] queensRuby = new string[15];
        static string[] queensRuby2 = new string[15];
        static string[] queensUngaga = new string[15];
        static string[] queensUngaga2 = new string[15];
        static string[] queensOsmond = new string[15];
        static string[] queensOsmond2 = new string[15];
        static string[] muskarackaXiao = new string[15];
        static string[] muskarackaXiao2 = new string[15];
        static string[] muskarackaGoro = new string[15];
        static string[] muskarackaGoro2 = new string[15];
        static string[] muskarackaRuby = new string[15];
        static string[] muskarackaRuby2 = new string[15];
        static string[] muskarackaUngaga = new string[15];
        static string[] muskarackaUngaga2 = new string[15];
        static string[] muskarackaOsmond = new string[15];
        static string[] muskarackaOsmond2 = new string[15];
        static string[] sunmoonXiao = new string[15];
        static string[] sunmoonXiao2 = new string[15];
        static string[] sunmoonGoro = new string[15];
        static string[] sunmoonGoro2 = new string[15];
        static string[] sunmoonRuby = new string[15];
        static string[] sunmoonRuby2 = new string[15];
        static string[] sunmoonUngaga = new string[15];
        static string[] sunmoonUngaga2 = new string[15];
        static string[] sunmoonOsmond = new string[15];
        static string[] sunmoonOsmond2 = new string[15];
        static string[] yellowdropsXiao = new string[15];
        static string[] yellowdropsXiao2 = new string[15];
        static string[] yellowdropsGoro = new string[15];
        static string[] yellowdropsGoro2 = new string[15];
        static string[] yellowdropsRuby = new string[15];
        static string[] yellowdropsRuby2 = new string[15];
        static string[] yellowdropsUngaga = new string[15];
        static string[] yellowdropsUngaga2 = new string[15];
        static string[] yellowdropsOsmond = new string[15];
        static string[] yellowdropsOsmond2 = new string[15];
        static string[] brownbooXiao = new string[15];
        static string[] brownbooXiao2 = new string[15];
        static string[] brownbooGoro = new string[15];
        static string[] brownbooGoro2 = new string[15];
        static string[] brownbooRuby = new string[15];
        static string[] brownbooRuby2 = new string[15];
        static string[] brownbooUngaga = new string[15];
        static string[] brownbooUngaga2 = new string[15];
        static string[] brownbooOsmond = new string[15];
        static string[] brownbooOsmond2 = new string[15];
        static string darkheavenXiao;
        static string darkheavenXiao2;
        static string darkheavenGoro;
        static string darkheavenGoro2;
        static string darkheavenRuby;
        static string darkheavenRuby2;
        static string darkheavenUngaga;
        static string darkheavenUngaga2;
        static string darkheavenOsmond;
        static string darkheavenOsmond2;
        static string currentDialogue;
        static string currentDialogueOptions;
        static string prevDialogue;
        static string dialogueOptions;

        static string[] norunefinishedDialogue = new string[15];
        static string[] matatakifinishedDialogue = new string[15];
        static string[] queensfinishedDialogue = new string[15];
        static string[] muskafinishedDialogue = new string[15];

        static bool isUsingAlly;

        static int currentAddress;
        static int currentsidequestAddress;
        static int currentArea = 255;
        static int currentChar;
        static int characterIdData;
        static int savedDialogueCheck;
        static int[] noruneCharacters = { 12592, 12848, 13104, 13360, 13616, 13872, 14128, 14384, 14640, 12337, 12849, 13105, 13361 };   //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
        static int[] norunesidequestCharacters = { 12592, 13872, 13360, 13361};
        static int[] matatakisidequestCharacters = { 13618, 13362, 12594 };
        static int[] queenssidequestCharacters = { 13108, 13363, 12852 };
        static int[] muskarackasidequestCharacters = { 14388, 13109, 12341 };
        static int[] matatakiCharacters = { 12594, 12850, 13106, 13362, 13618, 13874, 14130, 14386, 14642, 12339, 12595, 12851 }; //ro, annie, momo, pao, gob, kye, baron, cacao, kululu, bunbuku, couscous, mr mustache
        static int[] queensCharacters = { 13107, 13363, 13619, 13875, 14131, 14643, 12340, 12596, 12852, 13108, 13364, 13620, 14644 }; //king, sam, ruty, suzy, lana, basker, stew, joker, phil, jake, wilder, yaya, jack
        static int[] muskarackaCharacters = { 13876, 14388, 12341, 12597, 12853, 13109, 13365, 13621, 13877, 14133, 14389 }; //jibubu, chief bonka, zabo, mikara, nagita, devia, enga, brooke, gron, toto, gosuke
        static int[] sunmoonCharacters = { 12337, 13111 };
        static int[] yellowdropsTalkableCharacterIDs = { 2, 3, 4, 5, 6, 7, 9, 10, 11, 12 };
        static int[] brownbooTalkableCharacterIDs = { 6, 7, 8, 10, 11, 12 };
        static int[] customDialoguesCheck = new int[15];      
        static int[] noruneXiaoCheck = new int[15];
        static int[] noruneGoroCheck = new int[15];
        static int[] noruneRubyCheck = new int[15];
        static int[] noruneUngagaCheck = new int[15];
        static int[] noruneOsmondCheck = new int[15];
        static int[] matatakiXiaoCheck = new int[15];
        static int[] matatakiGoroCheck = new int[15];
        static int[] matatakiRubyCheck = new int[15];
        static int[] matatakiUngagaCheck = new int[15];
        static int[] matatakiOsmondCheck = new int[15];
        static int[] queensXiaoCheck = new int[15];
        static int[] queensGoroCheck = new int[15];
        static int[] queensRubyCheck = new int[15];
        static int[] queensUngagaCheck = new int[15];
        static int[] queensOsmondCheck = new int[15];
        static int[] muskarackaXiaoCheck = new int[15];
        static int[] muskarackaGoroCheck = new int[15];
        static int[] muskarackaRubyCheck = new int[15];
        static int[] muskarackaUngagaCheck = new int[15];
        static int[] muskarackaOsmondCheck = new int[15];
        static int[] sunmoonXiaoCheck = new int[15];
        static int[] sunmoonGoroCheck = new int[15];
        static int[] sunmoonRubyCheck = new int[15];
        static int[] sunmoonUngagaCheck = new int[15];
        static int[] sunmoonOsmondCheck = new int[15];
        static int[] yellowdropsXiaoCheck = new int[15];
        static int[] yellowdropsGoroCheck = new int[15];
        static int[] yellowdropsRubyCheck = new int[15];
        static int[] yellowdropsUngagaCheck = new int[15];
        static int[] yellowdropsOsmondCheck = new int[15];
        static int[] brownbooXiaoCheck = new int[15];
        static int[] brownbooGoroCheck = new int[15];
        static int[] brownbooRubyCheck = new int[15];
        static int[] brownbooUngagaCheck = new int[15];
        static int[] brownbooOsmondCheck = new int[15];
        static int[] darkheavenXiaoCheck = new int[5];
        static int[] darkheavenGoroCheck = new int[5];
        static int[] darkheavenRubyCheck = new int[5];
        static int[] darkheavenUngagaCheck = new int[15];
        static int[] darkheavenOsmondCheck = new int[15];

        static bool[] itemIDCheckList = new bool[380];
        static int[] obtainableAttachmentsList = { 81, 82, 83, 84, 85, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120 };
        static int[] obtainableItemsList = { 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 185, 186, 187, 188, 189, 190, 192, 193, 197, 199, 224, 225, 226, 227, 228, 229, 230, 231, 235, 245, 246, 247, 253 };
        static int[] obtainableUltWeapons = { 280, 295, 296, 297, 298, 312, 313, 324, 329, 341, 345, 356, 357, 372, 373 };
        static int[] obtainableSecretItems = { 171, 172, 173, 191, 233, 234, 241, 243 };
        static int obtainedItems = 0;
        static int obtainedAttachments = 0;
        static int obtainedUltWeapons = 0;
        static int obtainedSecretItems = 0;

        static string[] allfish = { "Bobo", "Gobbler", "Nonky", "Kaiji", "Baku Baku", "Mardan Garayan", "Gummy", "Niler", "null", "Umadakara", "Tarton", "Piccoly", "Bon", "Hamahama", "Negie", "Den", "Heela", "Baron Garayan" };
        static string fishToFind;
        static bool[] fishCheckList = new bool[18];
        static bool masterFishQuestComplete = false;
        public static bool alreadyHasSavingBook = false;

        public static byte[] storageOriginalDialogue;
        public static byte[] storageAllDialogues;

        static int[] noruneSidequestIDs = { 87, 247, 207, 227, 187, 127, 67, 167, 147, 267, 47, 107, 0};
        static int[] noruneSidequestDialogueAddresses = { 0x2064B36C, 0x206507BE, 0x2064F350, 0x2064FC66, 0x2064EAC2, 0x2064CB04, 0x2064A36A, 0x2064DFB0, 0x2064D6C2, 0x206519EE, 0x20649916, 0x2064C088, 0 };

        static byte[] value1 = new byte[1];
        static byte[] value = new byte[2];
        static byte[] value4 = new byte[4];

        static char[] gameCharacters = { '^', '§', '_', '¤', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', //32
                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', //58
                              'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', //84
                              '´', '=', '"', '!', '?', '#', '&', '+', '-', '*', '/', '%', '(', ')', '@', '|', '<', '>', '{', '}', '[', ']', ':', ',', '.', '$',
                              '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ť', 'Ӿ', 'Ʊ', 'Ʀ', 'Ų', 'Ō', ' ' };

        static byte[] gameCharacters2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 88, 87, 90, 110, 96, 91, 85, 97, 98, 94, 92, 108, 93, 109, 95,
                                            111, 112, 113, 114, 115, 117, 118, 119, 120, 121, 107, 0, 101, 86, 102, 89, 99, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58,
                                            105, 0, 106, 0, 2, 0, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 103, 100, 104, 2 };


        public static void SetDialogue(int offset, bool isAlly, bool isSidequest, bool finishedDialogue = false)
        {
            isUsingAlly = isAlly;
            currentAddress = Addresses.chrFileLocation + 0x6;
            if (Memory.ReadByte(0x202A2518) != currentArea)     //DOESNT UPDATE when switching ally, fix later!!
            {
                /*if (Memory.ReadByte(0x202A2518) == 0) currentArea = 0;
                else if (Memory.ReadByte(0x202A2518) == 1) currentArea = 1;
                else if (Memory.ReadByte(0x202A2518) == 2) currentArea = 2;
                else if (Memory.ReadByte(0x202A2518) == 3) currentArea = 3;
                else if (Memory.ReadByte(0x202A2518) == 14) currentArea = 14; */
                currentArea = Memory.ReadByte(0x202A2518);
                SetDefaultDialogue(currentArea);

                for (int i = 0; i < customDialoguesCheck.Length; i++)   //reset NPC dialogue progress if changed area
                {
                    customDialoguesCheck[i] = 0;
                }
                currentChar = 0;
            }

            currentAddress = Addresses.chrFileLocation + 0x6;

            if (finishedDialogue == true)
            {
                GetCurrentAreaFinishedDialogues(currentArea);
            }

            if (currentChar != Memory.ReadInt(currentAddress) && isAlly == true)  //if using different ally, switch dialogue data
            {              

                if (Memory.ReadInt(currentAddress) == 791752805) //Xiao
                {
                    if (currentArea == 0)
                    {
                        customDialogues = noruneXiao;
                        customDialogues2 = noruneXiao2;
                        customDialoguesCheck = noruneXiaoCheck;
                        currentDialogueOptions = sideQuestDialogueOption[0];
                    }
                    else if (currentArea == 1)
                    {
                        customDialogues = matatakiXiao;
                        customDialogues2 = matatakiXiao2;
                        customDialoguesCheck = matatakiXiaoCheck;
                        currentDialogueOptions = sideQuestDialogueOption[1];
                    }
                    else if (currentArea == 2)
                    {
                        customDialogues = queensXiao;
                        customDialogues2 = queensXiao2;
                        customDialoguesCheck = queensXiaoCheck;
                    }
                    else if (currentArea == 3)
                    {
                        customDialogues = muskarackaXiao;
                        customDialogues2 = muskarackaXiao2;
                        customDialoguesCheck = muskarackaXiaoCheck;
                    }
                    else if (currentArea == 14)
                    {
                        customDialogues = brownbooXiao;
                        customDialogues2 = brownbooXiao2;
                        customDialoguesCheck = brownbooXiaoCheck;
                    }
                    else if (currentArea == 23)
                    {
                        customDialogues = yellowdropsXiao;
                        customDialogues2 = yellowdropsXiao2;
                        customDialoguesCheck = yellowdropsXiaoCheck;
                    }
                    else if (currentArea == 38)
                    {
                        customDialogues[0] = darkheavenXiao;
                        customDialogues2[0] = darkheavenXiao2;
                        customDialoguesCheck = darkheavenXiaoCheck;
                    }
                    else if (currentArea == 42)
                    {
                        customDialogues = sunmoonXiao;
                        customDialogues2 = sunmoonXiao2;
                        customDialoguesCheck = sunmoonXiaoCheck;
                    }
                }
                else if (Memory.ReadInt(currentAddress) == 791752819)  //Goro
                {
                    if (currentArea == 0)
                    {
                        customDialogues = noruneGoro;
                        customDialogues2 = noruneGoro2;
                        customDialoguesCheck = noruneGoroCheck;
                        currentDialogueOptions = sideQuestDialogueOption[0];
                    }
                    else if (currentArea == 1)
                    {
                        customDialogues = matatakiGoro;
                        customDialogues2 = matatakiGoro2;
                        customDialoguesCheck = matatakiGoroCheck;
                        currentDialogueOptions = sideQuestDialogueOption[1];
                    }
                    else if (currentArea == 2)
                    {
                        customDialogues = queensGoro;
                        customDialogues2 = queensGoro2;
                        customDialoguesCheck = queensGoroCheck;
                    }
                    else if (currentArea == 3)
                    {
                        customDialogues = muskarackaGoro;
                        customDialogues2 = muskarackaGoro2;
                        customDialoguesCheck = muskarackaGoroCheck;
                    }
                    else if (currentArea == 14)
                    {
                        customDialogues = brownbooGoro;
                        customDialogues2 = brownbooGoro2;
                        customDialoguesCheck = brownbooGoroCheck;
                    }
                    else if (currentArea == 23)
                    {
                        customDialogues = yellowdropsGoro;
                        customDialogues2 = yellowdropsGoro2;
                        customDialoguesCheck = yellowdropsGoroCheck;
                    }
                    else if (currentArea == 38)
                    {
                        customDialogues[0] = darkheavenGoro;
                        customDialogues2[0] = darkheavenGoro2;
                        customDialoguesCheck = darkheavenGoroCheck;
                    }
                    else if (currentArea == 42)
                    {
                        customDialogues = sunmoonGoro;
                        customDialogues2 = sunmoonGoro2;
                        customDialoguesCheck = sunmoonGoroCheck;
                    }
                }

                else if (Memory.ReadInt(currentAddress) == 791883877)  //Ruby
                {
                    if (currentArea == 0)
                    {
                        customDialogues = noruneRuby;
                        customDialogues2 = noruneRuby2;
                        customDialoguesCheck = noruneRubyCheck;
                        currentDialogueOptions = sideQuestDialogueOption[0];
                    }
                    else if (currentArea == 1)
                    {
                        customDialogues = matatakiRuby;
                        customDialogues2 = matatakiRuby2;
                        customDialoguesCheck = matatakiRubyCheck;
                        currentDialogueOptions = sideQuestDialogueOption[1];
                    }
                    else if (currentArea == 2)
                    {
                        customDialogues = queensRuby;
                        customDialogues2 = queensRuby2;
                        customDialoguesCheck = queensRubyCheck;
                    }
                    else if (currentArea == 3)
                    {
                        customDialogues = muskarackaRuby;
                        customDialogues2 = muskarackaRuby2;
                        customDialoguesCheck = muskarackaRubyCheck;
                    }
                    else if (currentArea == 14)
                    {
                        customDialogues = brownbooRuby;
                        customDialogues2 = brownbooRuby2;
                        customDialoguesCheck = brownbooRubyCheck;
                    }
                    else if (currentArea == 23)
                    {
                        customDialogues = yellowdropsRuby;
                        customDialogues2 = yellowdropsRuby2;
                        customDialoguesCheck = yellowdropsRubyCheck;
                    }
                    else if (currentArea == 38)
                    {
                        customDialogues[0] = darkheavenRuby;
                        customDialogues2[0] = darkheavenRuby2;
                        customDialoguesCheck = darkheavenRubyCheck;
                    }
                    else if (currentArea == 42)
                    {
                        customDialogues = sunmoonRuby;
                        customDialogues2 = sunmoonRuby2;
                        customDialoguesCheck = sunmoonRubyCheck;
                    }
                }

                else if (Memory.ReadInt(currentAddress) == 792278899)  //Ungaga
                {
                    if (currentArea == 0)
                    {
                        customDialogues = noruneUngaga;
                        customDialogues2 = noruneUngaga2;
                        customDialoguesCheck = noruneUngagaCheck;
                        currentDialogueOptions = sideQuestDialogueOption[0];
                    }
                    else if (currentArea == 1)
                    {
                        customDialogues = matatakiUngaga;
                        customDialogues2 = matatakiUngaga2;
                        customDialoguesCheck = matatakiUngagaCheck;
                        currentDialogueOptions = sideQuestDialogueOption[1];
                    }
                    else if (currentArea == 2)
                    {
                        customDialogues = queensUngaga;
                        customDialogues2 = queensUngaga2;
                        customDialoguesCheck = queensUngagaCheck;
                    }
                    else if (currentArea == 3)
                    {
                        customDialogues = muskarackaUngaga;
                        customDialogues2 = muskarackaUngaga2;
                        customDialoguesCheck = muskarackaUngagaCheck;
                    }
                    else if (currentArea == 14)
                    {
                        customDialogues = brownbooUngaga;
                        customDialogues2 = brownbooUngaga2;
                        customDialoguesCheck = brownbooUngagaCheck;
                    }
                    else if (currentArea == 23)
                    {
                        customDialogues = yellowdropsUngaga;
                        customDialogues2 = yellowdropsUngaga2;
                        customDialoguesCheck = yellowdropsUngagaCheck;
                    }
                    else if (currentArea == 38)
                    {
                        customDialogues[0] = darkheavenUngaga;
                        customDialogues2[0] = darkheavenUngaga2;
                        customDialoguesCheck = darkheavenUngagaCheck;
                    }
                    else if (currentArea == 42)
                    {
                        customDialogues = sunmoonUngaga;
                        customDialogues2 = sunmoonUngaga2;
                        customDialoguesCheck = sunmoonUngagaCheck;
                    }
                }

                else if (Memory.ReadInt(currentAddress) == 792014949)  //Osmond
                {
                    if (currentArea == 0)
                    {
                        customDialogues = noruneOsmond;
                        customDialogues2 = noruneOsmond2;
                        customDialoguesCheck = noruneOsmondCheck;
                        currentDialogueOptions = sideQuestDialogueOption[0];
                    }
                    else if (currentArea == 1)
                    {
                        customDialogues = matatakiOsmond;
                        customDialogues2 = matatakiOsmond2;
                        customDialoguesCheck = matatakiOsmondCheck;
                        currentDialogueOptions = sideQuestDialogueOption[1];
                    }
                    else if (currentArea == 2)
                    {
                        customDialogues = queensOsmond;
                        customDialogues2 = queensOsmond2;
                        customDialoguesCheck = queensOsmondCheck;
                    }
                    else if (currentArea == 3)
                    {
                        customDialogues = muskarackaOsmond;
                        customDialogues2 = muskarackaOsmond2;
                        customDialoguesCheck = muskarackaOsmondCheck;
                    }
                    else if (currentArea == 14)
                    {
                        customDialogues = brownbooOsmond;
                        customDialogues2 = brownbooOsmond2;
                        customDialoguesCheck = brownbooOsmondCheck;
                    }
                    else if (currentArea == 23)
                    {
                        customDialogues = yellowdropsOsmond;
                        customDialogues2 = yellowdropsOsmond2;
                        customDialoguesCheck = yellowdropsOsmondCheck;
                    }
                    else if (currentArea == 38)
                    {
                        customDialogues[0] = darkheavenOsmond;
                        customDialogues2[0] = darkheavenOsmond2;
                        customDialoguesCheck = darkheavenOsmondCheck;
                    }
                    else if (currentArea == 42)
                    {
                        customDialogues = sunmoonOsmond;
                        customDialogues2 = sunmoonOsmond2;
                        customDialoguesCheck = sunmoonOsmondCheck;
                    }
                }

                currentChar = Memory.ReadInt(currentAddress);

                currentArea = Memory.ReadByte(0x202A2518);
                SetDefaultDialogue(currentArea);

                for (int i = 0; i < customDialoguesCheck.Length; i++)   //reset NPC dialogue progress if changed ally
                {
                    customDialoguesCheck[i] = 0;
                }
            }
            else if (currentChar != Memory.ReadInt(currentAddress) && isAlly == false)
            {
                currentArea = Memory.ReadByte(0x202A2518);
                SetDefaultDialogue(currentArea);
            }
            //SetDialogueOptions(currentDialogueOptions); //TESTING EXTRA DIALOGUE OPTIONS: adds sidequest option after finishing house event

            currentAddress = offset * 0x14A0 + 0x21D26FD9;
            characterIdData = Memory.ReadShort(currentAddress);     //store the ID value of nearby character
            if (currentArea == 0)
            {
                for (int i = 0; i < noruneCharacters.Length; i++)   //search through array to find character match
                {
                    if (characterIdData == noruneCharacters[i])
                    {
                        if (customDialoguesCheck[i] != 1)
                        {
                            if (isSidequest)
                            {
                                if (norunesidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 12849)
                                {
                                    currentDialogue = "I needed your help earlier,^but I´m okay now.¤You see, I slipped on this^pink thing which made me all^slow and slimey.¤Well, I survived from that disaster.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }
                        else
                        {
                            if (isSidequest)
                            {
                                if (norunesidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 12849)
                                {
                                    currentDialogue = "I needed your help earlier,^but I´m okay now.¤You see, I slipped on this^pink thing which made me all^slow and slimey.¤Well, I survived from that disaster.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues2[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }

                        if (i == 1 || i == 11)  //check for shopkeeper
                        {
                            TownCharacter.shopkeeper = true;
                        }
                        else
                        {
                            TownCharacter.shopkeeper = false;
                        }

                        TownCharacter.sidequestDialogueID = 107;
                        currentsidequestAddress = 0x2064C088; //hag's first hello normal dialogue
                    }
                }
            }
            else if (currentArea == 1)
            {
                for (int i = 0; i < matatakiCharacters.Length; i++)   //search through array to find character match
                {
                    if (characterIdData == matatakiCharacters[i])
                    {
                        if (customDialoguesCheck[i] != 1)
                        {
                            if (isSidequest)
                            {
                                if (matatakisidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 14386)
                                {
                                    currentDialogue = "I wish you happened to be there.¤One day I accidentally ventured^too deep into the forest and^was surronded by monsters.¤Luckily, I had this red pouch which^allowed me to get back to safety.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }
                        else
                        {
                            if (isSidequest)
                            {
                                if (matatakisidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 14386)
                                {
                                    currentDialogue = "I wish you happened to be there.¤One day I accidentally ventured^too deep into the forest and^was surronded by monsters.¤Luckily, I had this red pouch which^allowed me to get back to safety.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues2[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }

                        if (i == 10 || i == 11)  //check for shopkeeper
                        {
                            TownCharacter.shopkeeper = true;
                        }
                        else
                        {
                            TownCharacter.shopkeeper = false;
                        }

                        TownCharacter.sidequestDialogueID = 107;
                        currentsidequestAddress = 0x2064C492; //hag's first hello normal dialogue
                    }
                }
            }
            else if (currentArea == 2)
            {
                for (int i = 0; i < queensCharacters.Length; i++)   //search through array to find character match
                {
                    if (characterIdData == queensCharacters[i])
                    {
                        if (customDialoguesCheck[i] != 1)
                        {
                            if (isSidequest)
                            {
                                if (queenssidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 13107)
                                {
                                    bool hasLamp = SideQuestManager.CheckItemQuestReward(241, true, false);
                                    if (hasLamp)
                                    {
                                        currentDialogue = "What do you want?¤Wait... that lamp...¤...that cursed lamp...¤NO! Get it away from me!";
                                    }
                                    else
                                    {
                                        currentDialogue = "I don´t need you to do sidequests,^those are for my henchmen.";
                                    }
                                }
                                else if (characterIdData == 13364)
                                {
                                    currentDialogue = "There was a large fight a while ago.¤I almost wanted to call you for help.^There was this thief who suddenly^took a sip of something and^became more powerful.¤Thanks to the strength of Macho^Brothers´s bloodline, I was able^to deal with him myself.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }
                        else
                        {
                            if (isSidequest)
                            {
                                if (queenssidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 13107)
                                {
                                    bool hasLamp = SideQuestManager.CheckItemQuestReward(241, true, false);
                                    if (hasLamp)
                                    {
                                        currentDialogue = "What do you want?¤Wait... that lamp...¤...that cursed lamp...¤NO! Get it away from me!";
                                    }
                                    else
                                    {
                                        currentDialogue = "I don´t need you to do sidequests,^those are for my henchmen.";
                                    }
                                }
                                else if (characterIdData == 13364)
                                {
                                    currentDialogue = "There was a large fight a while ago.¤I almost wanted to call you for help.^There was this thief who suddenly^took a sip of something and^became more powerful.¤Thanks to the strength of Macho^Brothers´s bloodline, I was able^to deal with him myself.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues2[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }

                        if (i == 2 || i == 3 || i == 4 || i == 5 || i == 7 || i == 12)  //check for shopkeeper
                        {
                            TownCharacter.shopkeeper = true;
                        }
                        else
                        {
                            TownCharacter.shopkeeper = false;
                        }

                        TownCharacter.sidequestDialogueID = 127;
                        currentsidequestAddress = 0x2064DB3A; //basker's first hello normal dialogue
                    }
                }
            }
            else if (currentArea == 3)
            {
                for (int i = 0; i < muskarackaCharacters.Length; i++)   //search through array to find character match
                {
                    if (characterIdData == muskarackaCharacters[i])
                    {
                        if (customDialoguesCheck[i] != 1)
                        {
                            if (isSidequest)
                            {
                                if (muskarackasidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 13877)
                                {
                                    currentDialogue = "How about you get me out of here?¤I wish I had something to^blow up this darn door.¤Oh wait, I probably shouldn´t^be in the cell then.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }
                        else
                        {
                            if (isSidequest)
                            {
                                if (muskarackasidequestCharacters.Contains(characterIdData))
                                {
                                    currentDialogue = SideQuestManager.GetQuestDialogue(currentDialogue, characterIdData);
                                }
                                else if (characterIdData == 13877)
                                {
                                    currentDialogue = "How about you get me out of here?¤I wish I had something to^blow up this darn door.¤Oh wait, I probably shouldn´t^be in the cell then.";
                                }
                                else
                                {
                                    currentDialogue = "Sorry, I don´t have any quests currently.";
                                }
                            }
                            else if (finishedDialogue)
                            {
                                currentDialogue = itsfinishedDialogue[i];
                            }
                            else
                            {
                                currentDialogue = customDialogues2[i];    //gets the correct dialogue and stores it
                                savedDialogueCheck = i;
                            }
                        }

                        if (i == 6 || i == 7)  //check for shopkeeper
                        {
                            TownCharacter.shopkeeper = true;
                        }
                        else
                        {
                            TownCharacter.shopkeeper = false;
                        }
                    }
                    TownCharacter.sidequestDialogueID = 147;
                    currentsidequestAddress = 0x2064DDB8; //basker's first hello normal dialogue
                }
            }
            else if (currentArea == 14)
            {
                currentAddress = currentAddress - 0x00000005;
                byte currentNPCID = Memory.ReadByte(currentAddress);
                if (currentNPCID == 9)
                {
                    if (Memory.ReadByte(0x21CE43FE) == 0)
                    {
                        currentDialogue = brownbooPickle;
                    }
                    else
                    {
                        CheckItems();
                        int allitems = obtainableItemsList.Length + obtainableAttachmentsList.Length;
                        if (obtainedItems == allitems && obtainedUltWeapons == obtainableUltWeapons.Length && obtainedSecretItems == obtainableSecretItems.Length)
                        {
                            string cheatdialogue = "";
                            if (Memory.ReadByte(0x21CE446C) == 1)
                            {
                                cheatdialogue = "¤I hope you didn´t^use any cheats!... right?";
                            }

                            brownbooPickleExtraDialogue = "WOW! Congratulations,^you´ve actually done it!^You collected everything!¤As a present, have this old key.^You should totally try^if you can use it somewhere!" + cheatdialogue;
                            bool hasKey = SideQuestManager.CheckItemQuestReward(248);
                            if (hasKey == false)
                            {
                                Memory.WriteUShort(Addresses.firstBagItem + (0x2 * Player.Inventory.GetBagItemsFirstAvailableSlot()), 248);
                                Memory.WriteByte(0x21CE4463, 1);
                            }
                        }
                        else
                        {
                            brownbooPickleExtraDialogue = "Hmm, seems like you don´t have^100% collection yet. Don´t worry,^it´s a massive achievement to reach!^Good luck!";
                        }
                        
                        currentDialogue = "You have collected:^" + obtainedItems + " / " + allitems + " obtainable items and attachments^" + obtainedUltWeapons + " / " + obtainableUltWeapons.Length +" obtainable ultimate weapons^" + obtainedSecretItems + " / " + obtainableSecretItems.Length +" secret items¤" + brownbooPickleExtraDialogue;
                        obtainedItems = 0;
                        obtainedUltWeapons = 0;
                        obtainedSecretItems = 0;
                        for (int i = 0; i < itemIDCheckList.Length; i++)
                        {
                            itemIDCheckList[i] = false;
                        }
                    }
                }
                else if (currentNPCID == 5)
                {
                    if (Memory.ReadByte(0x21CE444B) == 0)
                    {
                        currentDialogue = "Do you like fishing?^I have a great challenge for you.¤Catch all 17 different types of fish,^and I will reward you with a rare item!¤You can talk to me again^to know your current progress.";
                    }
                    else
                    {
                        CheckFish();
                        if (masterFishQuestComplete)
                        {
                            CheckMasterFishQuestReward();
                            if (alreadyHasSavingBook)
                            {
                                currentDialogue = "I already gave you my reward,^but if you somehow lose it you^can ask for another!";
                            }
                            else
                            {
                                if (Memory.ReadByte(0x21CE4450) == 0)
                                {
                                    currentDialogue = "So you have completed my challenge?¤Cool, you truly are a Master of Fishing!^Here, have this rare book that^I found the other day.¤I don´t know what it does, but^maybe some people collect them.";                                    
                                }
                                else
                                {
                                    currentDialogue = "What? You lost the reward??¤Well, I have another one here,^don´t lose it again!";
                                }
                            }
                        }
                        else
                        {
                            currentDialogue = "You still have to^find the following fish:¤" + fishToFind + "¤Come back when you have caught them!^Good luck!";
                        }
                    }
                }
                else if (currentNPCID == 3)
                {
                    if (Memory.ReadByte(0x21CE4455) == 0)
                    {
                        if (Memory.ReadByte(0x21CDD811) == 255)
                        {
                            currentDialogue = "Have you heard about this?¤There is a legend that somewhere at^north-east of the Matataki Village,^you can find an very long evil tower.¤If you happen to find it, come back^to me. I might have more to tell.";
                        }
                        else
                        {
                            currentDialogue = "According to a legend, there is a^rare artifact hidden somewhere in^the darkness of the Demon Shaft.¤I heard it´s so valuable that^not even money can buy it.";
                        }
                    }
                    else
                    {
                        bool hasItem = SideQuestManager.CheckItemQuestReward(241);
                        if (hasItem)
                        {
                            currentDialogue = "What´s that?^You found the rare artifact?¤Magical lamp... hmmm....¤If you don´t know what to do with it,^you should try speaking to someone^in Queens, there´s plenty of^artifact merchandise.";
                        }
                        else
                        {
                            currentDialogue = "Have you found the Demon Shaft´s^legendary artifact yet? Try searching^behind every stone and WALL.";
                        }
                    }
                }
                else
                {
                    byte NPCID = Memory.ReadByte(currentAddress);
                    if (brownbooTalkableCharacterIDs.Contains(NPCID))
                    {
                        if (customDialoguesCheck[NPCID] != 1)
                        {
                            currentDialogue = customDialogues[NPCID];
                            savedDialogueCheck = NPCID;
                        }
                        else
                        {
                            currentDialogue = customDialogues2[NPCID];
                            savedDialogueCheck = NPCID;
                        }

                        if (isUsingAlly == false)
                        {
                            currentDialogue = "Hello.";
                        }
                    }
                    //currentDialogue = "Sup buddy. I don´t have a dialogue yet.";
                }
            }
            else if (currentArea == 23)
            {
                currentAddress = currentAddress - 0x00000005;
                byte NPCID = Memory.ReadByte(currentAddress);
                if (yellowdropsTalkableCharacterIDs.Contains(NPCID))
                {
                    if (customDialoguesCheck[NPCID] != 1)
                    {
                        currentDialogue = customDialogues[NPCID];
                        savedDialogueCheck = NPCID;
                    }
                    else
                    {
                        currentDialogue = customDialogues2[NPCID];
                        savedDialogueCheck = NPCID;
                    }
                }
                else if (NPCID == 0)
                {
                    if (isSidequest)
                    {
                        if (Memory.ReadByte(0x21CE4459) == 0)
                        {
                            if (Memory.ReadByte(0x21CD9551) != 6)
                            {
                                currentDialogue = "Have you seen our Boss anywhere?¤Go search for him first.^Come back to me if you find him.";
                            }
                            else
                            {
                                currentDialogue = "I have an extremely valuable crystal.¤I know you are strong,^but if you want my crystal, you need^to proof that you are smart as well!¤I have a puzzle for you.^Talk to me again if you^wish to know more.";
                            }
                            
                        }
                        else if (Memory.ReadByte(0x21CE4459) == 1)
                        {
                            bool hasCorrect = SideQuestManager.CheckItemsForMCQuest();
                            if (hasCorrect)
                            {
                                Memory.WriteByte(0x21CE445D, 1);
                                currentDialogue = "That´s correct, well done!^You solved the puzzle!¤As a reward, have this^ultra-rare Magical Crystal.¤While this is in your inventory,^it works similar to the^Magical Crystal you find in the^dungeons, but it is always activated!¤Also, the Magical Crystal you^find in dungeons gets replaced^with extra loot. Worth it, right?";
                            }
                            else
                            {
                                Memory.WriteByte(0x21CE445D, 0);
                                currentDialogue = "I want you to show me certain^four items in a correct order. Place^those items in the first four slots^of your inventory.¤What are the items?^I´m not straight up telling them!^However...¤In the Blue Terra, your homeworld,^you might have met some people^who needed something.¤Perhaps they are the^clue to the right answer?";
                            }
                        }
                        else 
                        {
                            currentDialogue = "I already gave you my reward,^you don´t need a second crystal!";
                        }
                        
                    }
                }
                else if (NPCID == 1)
                {
                    if (isSidequest)
                    {
                        if (Memory.ReadByte(0x21CE445E) == 0)
                        {
                            if (Memory.ReadByte(0x21CD9551) != 6)
                            {
                                currentDialogue = "Have you seen our Boss anywhere?¤Go search for him first.^Come back to me if you find him.";
                            }
                            else
                            {
                                Memory.WriteByte(0x21CDD7C6, 255);
                                currentDialogue = "I have a challenge to test^your true strength.¤If you can conquer Moon Sea Floor 7´s^backside only with Ť and^only using Dagger, you can have^my reward.¤The healing fountains are also^disabled there, so be sure to stock up.";
                            }
                        }
                        else if (Memory.ReadByte(0x21CE445E) == 1)
                        {
                            if (Memory.ReadByte(0x21CE4462) == 0)
                            {
                                currentDialogue = "If you can conquer Moon Sea Floor 7´s^backside only with Ť and^only using Dagger, you can have^my reward.¤The healing fountains are also^disabled there, so be sure to stock up.";
                            }
                            else
                            {
                                currentDialogue = "You completed the challenge? Extraordinary!¤Here, you can have this special Map.¤While this is in your inventory,^it works similar to the Map you find^in the dungeons, but it is^always activated!¤Also, the Map you find in dungeons^gets replaced with extra loot.^Pretty cool, huh?";
                            }
                            
                        }
                        else
                        {
                            currentDialogue = "I already gave you my reward,^you don´t need a second map!";
                        }
                    }
                }

                if (NPCID == 0 || NPCID == 1)
                {
                    TownCharacter.shopkeeper = true;
                }
                else
                {
                    TownCharacter.shopkeeper = false;
                }

                TownCharacter.sidequestDialogueID = 262;

            }
            else if (currentArea == 38)
            {
                if (customDialoguesCheck[0] != 1)
                {
                    currentDialogue = customDialogues[0];
                    savedDialogueCheck = 0;
                }
                else
                {
                    currentDialogue = customDialogues2[0];
                    savedDialogueCheck = 0;
                }
            }
            else if (currentArea == 42)
            {
                for (int i = 0; i < sunmoonCharacters.Length; i++)   //search through array to find character match
                {
                    if (characterIdData == sunmoonCharacters[i])
                    {
                        if (customDialoguesCheck[i] != 1)
                        {
                            currentDialogue = customDialogues[i];    //gets the correct dialogue and stores it
                            savedDialogueCheck = i;
                        }
                        else
                        {
                            currentDialogue = customDialogues2[i];    //gets the correct dialogue and stores it
                            savedDialogueCheck = i;
                        }
                    }
                }
            }

            if (characterIdData == 14132)
            {
                TownCharacter.talkableNPC = false;
            }
            if (currentArea == 0)
            {
                currentAddress = 0x206507BE; //gaffers first normal "hello" dialogue
                if (isSidequest)
                {
                    currentAddress = currentsidequestAddress;
                }
                else if (finishedDialogue)
                {
                    currentAddress = 0x206519EE; //renee first normal hello (267)
                    TownCharacter.itsfinishedDialogueID = 267;
                }
            }
            else if (currentArea == 1)
            {
                currentAddress = 0x2064ECBC; //pao's first normal "hello" dialogue
                if (isSidequest)
                {
                    currentAddress = currentsidequestAddress;
                }
                else if (finishedDialogue)
                {
                    currentAddress = 0x2064F7BC; //kye first normal hello (187)
                    TownCharacter.itsfinishedDialogueID = 187;
                }
            }
            else if (currentArea == 2)
            {
                currentAddress = 0x2064BED8; //suzy's first normal "hello" dialogue
                if (isSidequest)
                {
                    currentAddress = currentsidequestAddress;
                }
                else if (finishedDialogue)
                {
                    currentAddress = 0x2064ED8A; //stu first normal hello (167)
                    TownCharacter.itsfinishedDialogueID = 167;
                }
            }
            else if (currentArea == 3)
            {
                currentAddress = 0x20649A56; //bonka's first normal hello dialogue
                if (isSidequest)
                {
                    currentAddress = currentsidequestAddress;
                }
                else if (finishedDialogue)
                {
                    currentAddress = 0x2064E9B4; //brooke first normal hello (167)
                    TownCharacter.itsfinishedDialogueID = 167;
                }
            }
            else if (currentArea == 14)
            {
                currentAddress = 0x2064ADCA; //pickle's 1st message                   
            }
            else if (currentArea == 23)
            {
                currentAddress = 0x2064AE4A; //Aily's 1st message (id 240)
                if (isSidequest)
                {
                    currentAddress = 0x2064B11C; //yellow drops last message
                }
            }
            else if (currentArea == 38)
            {
                currentAddress = 0x20649784;
            }
            else if (currentArea == 42)
            {
                currentAddress = 0x20648FBA;
            }

            if (currentDialogue != null)
            {
                byte[] dialogueArray = new byte[currentDialogue.Length * 2];
                int currentByte = 0;
                int dialogueAddress = currentAddress;
                for (int i = 0; i < currentDialogue.Length; i++)
                {
                    char character = currentDialogue[i];

                    for (int a = 0; a < gameCharacters.Length; a++)
                    {
                        if (character.Equals(gameCharacters[a]))
                        {
                            if (a > 120)
                            {
                                if (a == 121)
                                {
                                    value1 = BitConverter.GetBytes(250);
                                }
                                else if (a == 122)
                                {
                                    value1 = BitConverter.GetBytes(251);
                                }
                                else if (a == 123)
                                {
                                    value1 = BitConverter.GetBytes(252);
                                }
                                else if (a == 124)
                                {
                                    value1 = BitConverter.GetBytes(253);
                                }
                                else if (a == 125)
                                {
                                    value1 = BitConverter.GetBytes(254);
                                }
                                else if (a == 126)
                                {
                                    value1 = BitConverter.GetBytes(255);
                                }
                                else if (a == 127)
                                {
                                    value1 = BitConverter.GetBytes(2);
                                }
                            }
                            else
                            {
                                value1 = BitConverter.GetBytes(a);
                            }

                            break;
                        }
                    }


                    //Memory.WriteByte(currentAddress, value1[0]);
                    dialogueArray[currentByte] = value1[0];

                    currentAddress += 0x00000001;
                    currentByte++;

                    if (value1[0] == 0 || value1[0] == 2 || value1[0] == 3)
                    {
                        value1 = BitConverter.GetBytes(255);
                        //Memory.WriteByte(currentAddress, value1[0]);
                        dialogueArray[currentByte] = value1[0];
                    }
                    else if (value1[0] == 250 || value1[0] == 251 || value1[0] == 252 || value1[0] == 253 || value1[0] == 254 || value1[0] == 255)
                    {
                        value1 = BitConverter.GetBytes(250);
                        //Memory.WriteByte(currentAddress, value1[0]);
                        dialogueArray[currentByte] = value1[0];
                    }
                    else
                    {
                        value1 = BitConverter.GetBytes(253);
                        //Memory.WriteByte(currentAddress, value1[0]);
                        dialogueArray[currentByte] = value1[0];
                    }

                    currentAddress += 0x00000001;
                    currentByte++;
                }

                Memory.WriteByteArray(dialogueAddress, dialogueArray);

                Memory.WriteByte(currentAddress, 1);
                currentAddress += 0x00000001;
                Memory.WriteByte(currentAddress, 255);
            }
            else
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Currentdialogue is null!");
            }

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "nearNPC");
        }

        public static void SetDefaultDialogue(int area)
        {
            string defDialogue = "Hello.";
            
            if (area == 0)
            {
                currentAddress = 0x206494C4;
            }
            else if (area == 1)
            {
                currentAddress = 0x20649B88;
            }
            else if (area == 2)
            {
                currentAddress = 0x20649B8A;
            }
            else if (area == 3)
            {
                currentAddress = 0x2065207C;
            }
            else if (area == 14)
            {
                if (isUsingAlly == true)
                {
                    currentAddress = 0x20649000; //brownboo first dialogue option
                    defDialogue = "Hey chill, don´t come talking so fast!";
                }

                else
                {
                    currentAddress = 0x20649000; //brownboo first dialogue option
                     if (Memory.ReadByte(0x21CE43FE) == 0  || Memory.ReadByte(0x21CE444B) == 0)
                        defDialogue = "Wait a second please,^I was doing something.";
                     else
                        defDialogue = "Checking your data... Please wait.";
                }
            }
            else if (area == 23)
            {
                currentAddress = 0x20648F50;
            }
            else if (area == 38)
            {
                currentAddress = 0x20649710; //ID 100, 54 characters
                defDialogue = "Wait a second please,^I was doing something.";
            }
            else if (area == 42)
            {
                currentAddress = 0x20648EC8;           
            }

            for (int i = 0; i < defDialogue.Length; i++)
            {
                char character = defDialogue[i];

                for (int a = 0; a < gameCharacters.Length; a++)
                {
                    if (character.Equals(gameCharacters[a]))
                    {
                        if (a == 127)
                        {
                            value1 = BitConverter.GetBytes(2);
                        }
                        else
                        {
                            value1 = BitConverter.GetBytes(a);
                        }

                        break;
                    }
                }


                Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));

                currentAddress += 0x00000001;

                if (value1[0] == 0 || value1[0] == 2 || value1[0] == 3)
                {
                    Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(255));
                }
                else
                {                 
                    Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(253));
                }

                currentAddress += 0x00000001;
            }

            Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(1));
            currentAddress += 0x00000001;
            Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(255));

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "nearNPC+SetDefaultDialogue");

        }

        public static void SetDialogueOptions(int currentArea, bool buildingCheck)
        {
            bool dialogueSet = false;
            if (currentArea == 0)
            {
                if (buildingCheck == false) //if player is not inside (storage) house
                {
                    currentAddress = 0x206492F6; //norune dialogueoptions after event finish
                    dialogueOptions = "Hello.^  How should I rebuild Norune?^  It´s finished!^  Do you have any sidequests?";
                    dialogueSet = true;
                }
                else
                {
                    if (Memory.ReadByte(0x202A2820) == 5) //check for hag
                    {
                        currentAddress = 0x20649364; //can I check for items? dialogue
                        dialogueOptions = "   Can I check in some items?^  Hello.^  How should I rebuild Norune?^  It´s finished!";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered hag's");
                        dialogueSet = true;
                    }
                    else if (Memory.ReadInt(0x202A2820) == -1) 
                    {
                        currentAddress = 0x206492F6; //norune dialogueoptions after event finish
                        dialogueOptions = "Hello.^  Do you have any sidequests?";
                        dialogueSet = true;
                    }
                    else
                    {
                        currentAddress = 0x206492F6; //norune dialogueoptions after event finish
                        dialogueOptions = "Hello.^  How should I rebuild Norune?^  It´s finished!^  Do you have any sidequests?";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered building (not hag's)");
                        dialogueSet = true;
                    }
                }
            }
            else if (currentArea == 1)
            {
                if (buildingCheck == false) //if player is not inside (storage) house
                {
                    currentAddress = 0x20649306; //matataki dialogueoptions after event finish
                    dialogueOptions = "Hello.^  How should I rebuild Matataki Village?^  It´s finished!^  Do you have any sidequests?";
                    dialogueSet = true;
                }
                else
                {
                    if (Memory.ReadByte(0x202A2820) == 5) //check for couscous
                    {
                        currentAddress = 0x2064938A; //can I check for items? dialogue
                        dialogueOptions = "  Can I check in some items?^  Hello.^  How should I rebuild Matataki Village?^  It´s finished!";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered couscous");
                        dialogueSet = true;
                    }
                    else
                    {
                        currentAddress = 0x20649306; //matataki dialogueoptions after event finish
                        dialogueOptions = "Hello.^  How should I rebuild Matataki Village?^  It´s finished!^  Do you have any sidequests?";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered building (not couscous)");
                        dialogueSet = true;
                    }
                }
            }
            else if (currentArea == 2)
            {
                if (buildingCheck == false) //if player is not inside (storage) house
                {
                    currentAddress = 0x206492DA; //queens dialogueoptions after event finish
                    dialogueOptions = "Hi.^  Any requests for rebuilding Queens?^  It´s finished!^  Do you have any sidequests?";
                    dialogueSet = true;
                }
                else
                {
                    if (Memory.ReadByte(0x202A2820) == 7) //check for basker
                    {
                        currentAddress = 0x20649354; //can I check for items? dialogue
                        dialogueOptions = "  Can I check in some items?^  Hello.^  Any requests for rebuilding Queens?^  It´s finished!";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered basker");
                        dialogueSet = true;
                    }
                    else
                    {
                        currentAddress = 0x206492DA; //queens dialogueoptions after event finish
                        dialogueOptions = "Hi.^  Any requests for rebuilding Queens?^  It´s finished!^  Do you have any sidequests?";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered building (not basker)");
                        dialogueSet = true;
                    }
                }
            }
            else if (currentArea == 3)
            {
                if (buildingCheck == false) //if player is not inside (storage) house
                {
                    currentAddress = 0x20649288; //muska dialogueoptions after event finish
                    dialogueOptions = "Hello.^  Any requests for building Muska Racka?^  It´s finished!^  Do you have any sidequests?";
                    dialogueSet = true;
                }
                else
                {
                    if (Memory.ReadByte(0x202A2820) == 5) //check for basker
                    {
                        currentAddress = 0x2064930C; //can I check for items? dialogue
                        dialogueOptions = "  Can I check in some items?^  Hello.^  Any requests for building Muska Racka?^  It´s finished!";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered Enga");
                        dialogueSet = true;
                    }
                    else
                    {
                        currentAddress = 0x20649288; //muska dialogueoptions after event finish
                        dialogueOptions = "Hi.^  Any requests for building Muska Racka?^  It´s finished!^  Do you have any sidequests?";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered building (not enga)");
                        dialogueSet = true;
                    }
                }
            }
            else if (currentArea == 23)
            {
                if (buildingCheck == true)
                {
                    if (Memory.ReadByte(0x21D26FD4) == 0)
                    {
                        currentAddress = 0x20649004;
                        dialogueOptions = "Can I shop here?^  Hello.^  Do you have any sidequests?";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered building (shop)");
                        dialogueSet = true;
                    }
                    else if (Memory.ReadByte(0x21D26FD4) == 1)
                    {
                        currentAddress = 0x20649004;
                        dialogueOptions = "Can I check in some items?^  Hello.^  Do you have any sidequests?";
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Entered building (storage)");
                        dialogueSet = true;
                    }
                }
            }
            if (dialogueSet)
            {
                for (int i = 0; i < dialogueOptions.Length; i++)
                {
                    char character = dialogueOptions[i];

                    for (int a = 0; a < gameCharacters.Length; a++)
                    {
                        if (character.Equals(gameCharacters[a]))
                        {
                            if (a > 120)
                            {
                                if (a == 121)
                                {
                                    value1 = BitConverter.GetBytes(250);
                                }
                                else if (a == 122)
                                {
                                    value1 = BitConverter.GetBytes(251);
                                }
                                else if (a == 123)
                                {
                                    value1 = BitConverter.GetBytes(252);
                                }
                                else if (a == 124)
                                {
                                    value1 = BitConverter.GetBytes(253);
                                }
                                else if (a == 125)
                                {
                                    value1 = BitConverter.GetBytes(254);
                                }
                                else if (a == 126)
                                {
                                    value1 = BitConverter.GetBytes(255);
                                }
                                else if (a == 127)
                                {
                                    value1 = BitConverter.GetBytes(2);
                                }
                            }
                            else
                            {
                                value1 = BitConverter.GetBytes(a);
                            }

                            break;
                        }
                    }


                    Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));

                    currentAddress += 0x00000001;

                    if (value1[0] == 0 || value1[0] == 2 || value1[0] == 3)
                    {
                        value1 = BitConverter.GetBytes(255);
                        Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));
                    }
                    else if (value1[0] == 250 || value1[0] == 251 || value1[0] == 252 || value1[0] == 253 || value1[0] == 254 || value1[0] == 255)
                    {
                        value1 = BitConverter.GetBytes(250);
                        Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));
                    }
                    else
                    {
                        value1 = BitConverter.GetBytes(253);
                        Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));
                    }

                    currentAddress += 0x00000001;
                }

                Memory.WriteByte(currentAddress, 1);
                currentAddress += 0x00000001;
                Memory.WriteByte(currentAddress, 255);

                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Custom dialogue options set!");
            }
            else
            {
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "!!! Custom dialogue options were not set!");
            }
        }

        public static void SetStorageDialogue(int currentArea, bool inStorage)
        {
            if (inStorage)
            {
                if (currentArea == 0)
                {
                    if (storageOriginalDialogue != null)
                    {
                        Memory.WriteByteArray(0x2064C088, storageOriginalDialogue);
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Storage dialogue written");
                    }
                }
                else if (currentArea == 1)
                {
                    if (storageOriginalDialogue != null)
                    {
                        Memory.WriteByteArray(0x2064C492, storageOriginalDialogue);
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Storage dialogue written");
                    }
                }
                else if (currentArea == 2)
                {
                    if (storageOriginalDialogue != null)
                    {
                        Memory.WriteByteArray(0x2064DB3A, storageOriginalDialogue);
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Storage dialogue written");
                    }
                }
                else if (currentArea == 3)
                {
                    if (storageOriginalDialogue != null)
                    {
                        Memory.WriteByteArray(0x2064DDB8, storageOriginalDialogue);
                        Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Storage dialogue written");
                    }
                }
                else if (currentArea == 23)
                {
                    storageOriginalDialogue = Memory.ReadByteArray(0x2064B11C, 200);
                    Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Storage dialogue stored");
                }
            }
            else
            {
                if (currentArea == 0)       storageOriginalDialogue = Memory.ReadByteArray(0x2064C088, 1000);

                else if (currentArea == 1)  storageOriginalDialogue = Memory.ReadByteArray(0x2064C492, 1000);

                else if (currentArea == 2)  storageOriginalDialogue = Memory.ReadByteArray(0x2064DB3A, 1000);

                else if (currentArea == 3)  storageOriginalDialogue = Memory.ReadByteArray(0x2064DDB8, 1000);

                else if (currentArea == 23)
                {
                    if (storageOriginalDialogue != null)
                    {
                        if (storageOriginalDialogue[0] != 0)
                        {
                            Memory.WriteByteArray(0x2064B11C, storageOriginalDialogue);
                            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Storage dialogue written");
                        }
                    }
                }

                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Storage dialogue stored");
            }
        }

        public static void SetFishingDisabledDialogue(int area)
        {
            currentDialogue = "Only Ť is able to fish here.";

            if (area == 0)
            {
                currentAddress = 0x204334F6;
            }
            else if (area == 1)
            {
                currentAddress = 0x2042F628;
            }
            else if (area == 19)
            {
                currentAddress = 0x20429AD6;
            }
            else if (area == 3)
            {
                currentAddress = 0x204305B8;
            }

            for (int i = 0; i < currentDialogue.Length; i++)
            {
                char character = currentDialogue[i];

                for (int a = 0; a < gameCharacters.Length; a++)
                {
                    if (character.Equals(gameCharacters[a]))
                    {
                        if (a > 120)
                        {
                            if (a == 121)
                            {
                                value1 = BitConverter.GetBytes(250);
                            }
                            else if (a == 127)
                            {
                                value1 = BitConverter.GetBytes(2);
                            }
                        }
                        else
                        {
                            value1 = BitConverter.GetBytes(a);
                        }

                        break;
                    }
                }


                Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));

                currentAddress += 0x00000001;

                if (value1[0] == 0 || value1[0] == 2 || value1[0] == 3)
                {
                    value1 = BitConverter.GetBytes(255);
                    Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));
                }
                else if (value1[0] == 250)
                {
                    value1 = BitConverter.GetBytes(250);
                    Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));
                }
                else
                {
                    value1 = BitConverter.GetBytes(253);
                    Memory.WriteOneByte(currentAddress, BitConverter.GetBytes(value1[0]));
                }

                currentAddress += 0x00000001;
            }

            Memory.WriteByte(currentAddress, 1);
            currentAddress += 0x00000001;
            Memory.WriteByte(currentAddress, 255);

            Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Fishing disabled");
        }

        public static void ChangeDialogue()
        {
            if (customDialoguesCheck[savedDialogueCheck] != 1)  //change dialogue flag between 1st and 2nd dialogue
            {
                customDialoguesCheck[savedDialogueCheck] = 1;
            }
            else
            {
                customDialoguesCheck[savedDialogueCheck] = 0;
            }
        }

        public static void GetCurrentAreaFinishedDialogues(int area)
        {
            switch (area)
            {
                case 0:
                    itsfinishedDialogue = norunefinishedDialogue;
                    break;
                case 1:
                    itsfinishedDialogue = matatakifinishedDialogue;
                    break;
                case 2:
                    itsfinishedDialogue = queensfinishedDialogue;
                    break;
                case 3:
                    itsfinishedDialogue = muskafinishedDialogue;
                    break;

            }
        }

        public static void CheckItems()
        {
            int itemid;

            currentAddress = 0x21CDD8AE; //first active item slot
            for (int i = 0; i < 3; i++) //check which items player has active slots
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid < 380)
                {
                    itemIDCheckList[Memory.ReadUShort(currentAddress)] = true;
                }
                currentAddress += 0x00000002;
            }

            currentAddress = 0x21CDD8BA; //first inventory slot
            for (int i = 0; i < 100; i++) //check which items player has in bag
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid < 380)
                {
                    itemIDCheckList[Memory.ReadUShort(currentAddress)] = true;
                }
                currentAddress += 0x00000002;
            }
            currentAddress = 0x21CE21E8; //first storage slot
            for (int i = 0; i < 60; i++) //check which items player has in storage
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid < 380)
                {
                    itemIDCheckList[Memory.ReadUShort(currentAddress)] = true;
                }
                currentAddress += 0x00000002;
            }

            for (int i = 0; i < obtainableItemsList.Length; i++) //increase counter for each unique item
            {
                if (itemIDCheckList[obtainableItemsList[i]] == true)
                {
                    obtainedItems++;
                }
            }

            currentAddress = 0x21CE1A48; //first attachment slot
            for (int i = 0; i < 40; i++) //check which attachments player has in bag
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid < 380)
                {
                    itemIDCheckList[Memory.ReadUShort(currentAddress)] = true;
                }
                currentAddress += 0x00000020;
            }

            currentAddress = 0x21CE3FE8; //first storage attachment slot
            for (int i = 0; i < 30; i++) //check which attachments player has in storage
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid < 380)
                {
                    itemIDCheckList[Memory.ReadUShort(currentAddress)] = true;
                }
                currentAddress += 0x00000020;
            }

            for (int i = 0; i < obtainableAttachmentsList.Length; i++) //increase counter for each unique item
            {
                if (itemIDCheckList[obtainableAttachmentsList[i]] == true)
                {
                    obtainedItems++;
                }
            }

            currentAddress = 0x21CDDA58; //first weapon ID in bag
            for (int i = 0; i < 65; i++) //check which weapons player is carrying
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid < 380)
                {
                    itemIDCheckList[Memory.ReadUShort(currentAddress)] = true;
                }
                currentAddress += 0x000000F8;
            }

            currentAddress = 0x21CE22D8; //first weapon slot in storage
            for (int i = 0; i < 30; i++) //check which weapons player has in storage
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid < 380)
                {
                    itemIDCheckList[Memory.ReadUShort(currentAddress)] = true;
                }
                currentAddress += 0x000000F8;
            }

            for (int i = 0; i < obtainableUltWeapons.Length; i++) //increase counter for each unique item
            {
                if (itemIDCheckList[obtainableUltWeapons[i]] == true)
                {
                    obtainedUltWeapons++;
                }
            }

            for (int i = 0; i < obtainableSecretItems.Length; i++) //increase counter for each unique item
            {
                if (itemIDCheckList[obtainableSecretItems[i]] == true)
                {
                    obtainedSecretItems++;
                }
            }
        }

        public static void CheckMasterFishQuestReward()
        {
            int itemid;
            alreadyHasSavingBook = false;

            currentAddress = 0x21CDD8BA; //first inventory slot
            for (int i = 0; i < 100; i++) //check which items player has in bag
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid == 191)
                {
                    alreadyHasSavingBook = true;
                }
                currentAddress += 0x00000002;
            }

            currentAddress = 0x21CE21E8; //first storage slot
            for (int i = 0; i < 60; i++) //check which items player has in storage
            {
                itemid = Memory.ReadUShort(currentAddress);
                if (itemid == 191)
                {
                    alreadyHasSavingBook = true;
                }
                currentAddress += 0x00000002;
            }
        }

        public static void GiveMasterFishQuestReward()
        {
            Memory.WriteUShort(Addresses.firstBagItem + (0x2 * Player.Inventory.GetBagItemsFirstAvailableSlot()), 191);
            Memory.WriteByte(0x21CE4450, 1);
        }

        public static void CheckFish()
        {
            currentAddress = 0x21CE4439;
            byte fishCount = 0;
            for (int i = 0; i < allfish.Length; i++)
            {
                if (i != 8)
                {
                    if (Memory.ReadByte(currentAddress) == 1)
                    {
                        fishCheckList[i] = true;
                        fishCount++;
                    }
                }
                currentAddress += 0x00000001;
            }
            if (fishCount == 17)
            {
                masterFishQuestComplete = true;
                Memory.WriteByte(0x21CE444F, 1);
            }
            else
            {
                masterFishQuestComplete = false;
                byte fishAmountToFind = 0;
                fishToFind = "";
                for (int i = 0; i < allfish.Length; i++)
                {
                    if (i != 8)
                    {
                        if (fishCheckList[i] != true)
                        {
                            fishToFind += allfish[i];
                            fishAmountToFind++;
                            if (fishAmountToFind == 4 || fishAmountToFind == 8 || fishAmountToFind == 12)
                            {
                                fishToFind += "¤";
                            }
                            else
                            {
                                fishToFind += "^";
                            }
                        }
                    }
                }
                if (fishAmountToFind == 4 || fishAmountToFind == 8 || fishAmountToFind == 12)
                {
                    fishToFind = fishToFind.Remove(fishToFind.Length - 1, 1);
                }
            }
        }

        public static void FixCharacterNamesInDialogues()
        {
            byte charByte = 0;
            if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 791752805) //Xiao
            {
                charByte = 251;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 791752819) //Goro
            {
                charByte = 252;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 791883877) //Ruby
            {
                charByte = 253;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 792278899)  //Ungaga
            {
                charByte = 254;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 792014949)  //Osmond
            {
                charByte = 255;
            }

            if (charByte > 250)
            {            
                 storageAllDialogues = Memory.ReadByteArray(0x20645000, 200000);
                 Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "started char fixing, alldialogue length: " + storageAllDialogues.Length);
                 for (int i = 0; i < storageAllDialogues.Length; i++)
                 {
                     if (storageAllDialogues[i] == 250)
                     {
                         i++;
                         if (storageAllDialogues[i] == 250)
                         {
                             i--;
                             storageAllDialogues[i] = charByte;
                             i++;
                         }
                     }
                     else
                     {
                         i++;
                     }
                 }
                 Memory.WriteByteArray(0x20645000, storageAllDialogues);
                 Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Finished char fixing");
                 
            }
        }

        public static void FixCharacterNamesInShopDialogues()
        {
            
            byte charByte = 0;

            if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 791752805) //Xiao
            {
                charByte = 251;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 791752819) //Goro
            {
                charByte = 252;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 791883877) //Ruby
            {
                charByte = 253;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 792278899)  //Ungaga
            {
                charByte = 254;
            }
            else if (Memory.ReadInt(Addresses.chrFileLocation + 0x6) == 792014949)  //Osmond
            {
                charByte = 255;
            }

            if (charByte > 250)
            {
                storageAllDialogues = Memory.ReadByteArray(0x218229E0, 37000);
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "started shop char fixing, alldialogue length: " + storageAllDialogues.Length);
                for (int i = 0; i < storageAllDialogues.Length; i++)
                {
                    if (storageAllDialogues[i] == 250)
                    {
                        i++;
                        if (storageAllDialogues[i] == 250)
                        {
                            i--;
                            storageAllDialogues[i] = charByte;
                            i++;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
                Memory.WriteByteArray(0x218229E0, storageAllDialogues);
                Console.WriteLine(ReusableFunctions.GetDateTimeForLog() + "Finished shop char fixing");
            }

        }



        //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
        // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue

        public static void InitializeDialogues()
        {
            sideQuestDialogueOption[0] = "Hello.^  How should I rebuild Norune?^  It´s finished!^  Do you have any sidequests?";
            sideQuestDialogueOption[1] = "Hello.^  How should I rebuild Matataki Village?^  It´s finished!^  Do you have any sidequests?";

            brownbooPickle = "Hey there, wanderer! Would you like^to know your collection progress?^Whenever you talk to me, I´ll check^your obtained items and weapons.¤You need to be either carrying them^or have them in your storage.¤Can you make it to the 100% collection?^It won´t be easy, but if you commit^to it, you can achieve anything!^Good luck!";
            brownbooPickleData = "You have collected:^X / Y obtainable items^X / Y obtainable weapons";

            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
            noruneXiao[0] = "El Gato, how are you doing little buddy?^Need any food or water?";
            noruneXiao[1] = "In all my travels around Terra, I have^never seen a cat like you.¤Anyone with eyes can see that there is^something special about you Ӿ!";
            noruneXiao[2] = "Kitty, were you stuck in a bubble too?";
            noruneXiao[3] = "You´re a cute little cat! Oh no, are you^a stray? You should come live with us!";
            noruneXiao[4] = "Look at you, you are so cute^unlike those muscle freaks!";
            noruneXiao[5] = "I remember when Paige was a little girl,^her mother made her a plush cat^that looked just like you!¤Kids sure do grow up fast, people may^come and go but the memories we make^with out loved ones are eternal.¤Pretty poetic for a fisherman huh, hahaha!";
            noruneXiao[6] = "Sometimes it´s hard to be an older brother.^Macho and I may butt heads but^deep down we care about each other.^Do you have any siblings kitty?";
            noruneXiao[7] = "No way, I can´t believe Ť let´s you go^on adventures with him. You are so lucky!";
            noruneXiao[8] = "Hey there, I´ve been seeing you^hang out with Ť! Are you^his little sidekick now? <3";
            noruneXiao[9] = "I appreciate how you are helping Ť^on his journey, I still wonder where^he got that change potion.¤It´s hard for one person to try change^the world but if we all work together^as allies, anything is possible. Don´t^worry, I won´t tell anyone your secret <3";
            noruneXiao[10] = "Are you helping Ť with^fixing other people´s houses?¤Since you´re helping people can^you help me, I have a bit of a mouse^problem. I could pay you in food!";
            noruneXiao[11] = "They say animals have sharper senses^then that of humans, can you feel^the magic within this village?¤I sense something different about you^Ӿ, perhaps you´re no ordinary cat!";
            noruneXiao[12] = "Hmm I wonder where you came from,^I haven´t seen any other cats in this village.";

            noruneXiao2[0] = "I see you following Ť everywhere,^I bet you taught him everything he knows!¤Next time I go training in the Cave, I^gotta bring you with me to watch my back!";
            noruneXiao2[1] = "If anyone understands the troubles^that come with being a wanderer it´s me.¤If you ever need a place^to stay, there is always a^spot for you in my buggy Ӿ.";
            noruneXiao2[2] = "Let´s have a race kitty, I bet^I can run faster than you!";
            noruneXiao2[3] = "Gina would love to have you as a playmate,^the poor girl gets lonely now that^Ť is too busy to play with her.";
            noruneXiao2[4] = "If you are ever hungry you should go^to Uncle Pike, he always has spare fish!";
            noruneXiao2[5] = "Have you ever heard of the legendary^fish Mardan Garayan, knowing my^luck you probably ate one before!";
            noruneXiao2[6] = "I remember there was once luchador who^wore a red lion mask who stood for justice^and good, he was as quick as thunder.¤He fought for many decades before^he was finally defeated by evil.^They say he fought valiantly to^the bitter end that even those evil¤doers respected his resolve. I´m sure^there are many who are following^the footsteps of that hero.";
            noruneXiao2[7] = "It´s no fair, I always wanted a pet cat^but my sister doesn´t let me have one^after I had that accident with my^pet fish Uncle Pike gave me...";
            noruneXiao2[8] = "Ť may act like a tough guy but^he doesn´t always use his head.^Sometimes I really worry about him.¤It´s not like I can go with him^you know. You can though, I see^you following him around everywhere.¤Can you do me a favour and make^sure he stays out of trouble?^Thanks Ӿ, I appreciate it.";
            noruneXiao2[9] = "Is Ť taking proper care of you?^That boy has a good heart but sometimes^he works way too hard, he gets^that habit from his father.";
            noruneXiao2[10] = "What´s your favourite food kitty, I bet^having cat food everyday gets old.";
            noruneXiao2[11] = "Oh-hohoho have you come to live^with me, I guess this old Hag^could use a cat by her side!";
            noruneXiao2[12] = "If the village ever has a rat problem^would you be willing to take a break^from following Ť around to^help the rest of the village?";

            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            noruneGoro[0] = "Hey bro, carrying that heavy mallet^around seems like one heck of^a workout, I should try it sometime.";
            noruneGoro[1] = "Ah yes, Matataki Village,^that´s not too far from here.¤I avoid doing business in that area^since there are huge hornets not too far^from Matataki.";
            noruneGoro[2] = "Wow, you´re from Matataki Village,^my Daddy works there!";
            noruneGoro[3] = "Oh so you are from Matataki Village?^My husband works as a travelling^merchant there!";
            noruneGoro[4] = "My goodness you look just like Claude,^were you two separated at birth?";
            noruneGoro[5] = "Look at you, a hunter!^You´re talking to a true blue fisherman^so I guess I´m a bit of a hunter myself.";
            noruneGoro[6] = "So you´re a hunter from Matataki?^Do you think your so tough?^Let me tell you something, I´m strong.¤I bet you that I´m stronger than your^best hunter at Matataki mwahaha!";
            noruneGoro[7] = "Hmm, I wonder what Alnet would say^if I brought home a mallet like that.";
            noruneGoro[8] = "I heard you are from Matataki Village,^I´ve never been there but I know Auntie^Laura´s husband has traveled there¤in the past for work.^I wonder if you know him?";
            noruneGoro[9] = "Hello there, you´re another one of^Toan´s friends! Do you ever get tired^from always carrying that mallet around?";
            noruneGoro[10] = "Everyone in the village says I look^just like you, you should give me^your bearskin hood¤and we can play a prank on all of Norune!";
            noruneGoro[11] = "I´ve heard that Matataki Village has^magical fairies called Laughapockle,^these seven fairies can be quite^mischievous!";
            noruneGoro[12] = "I´ve heard you can find a monster named^King Prickly around Matataki Village,¤I´ve been having an issue with Pricklies^coming in my home so I can´t imagine^a King Prickley!";

            noruneGoro2[0] = "You´re all pudgy just like Claude^but they say you´re a powerful hunter,^we should go down to the^cave and train together.";
            noruneGoro2[1] = "I´ve heard of a very frugal shopkeeper^by the name of Mr.Mustache in Matataki,^I hope you find my prices more fair.";
            noruneGoro2[2] = "I think carrying that big heavy hammer^around made you short haha!";
            noruneGoro2[3] = "Haha, finally there´s someone in the^village who is the same height as my^little Gina!";
            noruneGoro2[4] = "You look a little taller than Carl,^is everyone from Matataki Village^so short?";
            noruneGoro2[5] = "Oh, you´ve come from Matataki Village?^I wonder what kind of fish you can^find it there.";
            noruneGoro2[6] = "Norune Village is too quiet sometimes.^Our villagers don´t put much value in^exercise or body strength, they just^live care free.¤I think the other villagers could learn^something from you hunters of Matataki.";
            noruneGoro2[7] = "Matataki Village sounds like a weird^place, you´re telling me everyone wears^animal skins there?";
            noruneGoro2[8] = "When I first saw you I thought^you were Claude, another villager who^lives not too far from here.¤It´s almost like you could be twins,^perhaps distant relatives!";
            noruneGoro2[9] = "I know you like wearing animal skins^but please don´t do anything to our^Llama, we need it for milk and cheese.";
            noruneGoro2[10] = "I wonder what kind of food can be found^in Matataki Village, can you bring some^back for me?";
            noruneGoro2[11] = "Animals are essential to our^world´s spirits. I cannot condone your^village´s hunting practices¤but I guess to each is they´re own.";
            noruneGoro2[12] = "Dran is a magical beast that defends^our village of Norune, tell the beast^hunters of Matataki that he is a gentle,¤well - mannered monster and not to^be hunted.";


            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            noruneRuby[0] = "Who would have guessed that a genie^would be helping Ť on his^adventure!";
            noruneRuby[1] = "Ah yes, Queens, that´s a name I have^not heard in a while. I have not visited^that port town in years!";
            noruneRuby[2] = "Your purple hair is pretty!";
            noruneRuby[3] = "All of the kids in the village are^talking about you, it wouldn´t hurt to^show them a magic trick or two!";
            noruneRuby[4] = "I know you are traveling with Ť^but you better not get any ideas sister,^Paige has a crush on him so you better^back off!";
            noruneRuby[5] = "I´ve heard about you Ʀ,^they say that you are trying to be^the best genie in the world!¤Do you know of any spells to make the^legendary Mardan Garayan appear?";
            noruneRuby[6] = "The other villagers say that you are a^genie. I hope you haven´t come back to^put us into those weird bubbles again.";
            noruneRuby[7] = "I heard Uncle Pike saying that he wants^to go on a fishing trip to Queens.^I hope he takes me!";
            noruneRuby[8] = "Wow I love your clothes!^Before the Dark Genie attacked our^village I was celebrating the¤Star festival, it was really scary!";
            noruneRuby[9] = "Hello, you met Ť in Queens?^It´s nice that you are lending your^magical abilities to Ť and^the rest of his allies!";
            noruneRuby[10] = "It´s cool that you are a genie, can you^do spells? Can you make 100 plates of^premium chicken appear out of thin^air through magic?";
            noruneRuby[11] = "Oh-ho-ho-ho I may look like an old^fossil but there was once a time where^I was just as beautiful as^you Ʀ.";
            noruneRuby[12] = "The other villagers told me you are^from Queens, I remember hearing a story^about how your Queen ran away to be^with her love.¤Who is leading your city now?";

            noruneRuby2[0] = "I heard that you prefer to use magic^instead of your fists.¤Now I don´t know about that but we^should train together sometime!";
            noruneRuby2[1] = "I remember Queens was a bustling port^town, has it expanded since?";
            noruneRuby2[2] = "Woah! You can you use magic!?^You have to teach Gina!";
            noruneRuby2[3] = "Gina says that when she grows up she^wants purple hair just like you!^It looks like you are her role model^now.";
            noruneRuby2[4] = "Paige and I practice dancing every week,^you should join us one day!";
            noruneRuby2[5] = "No way, so your from Queens!?^That port town is every fisherman´s^dream!";
            noruneRuby2[6] = "I could tell that you are from Queens^just by looking at you.¤I have family living there that^specialize in law enforcement.";
            noruneRuby2[7] = "I heard Queens is surrounded by water,^I almost drowned once when Uncle Pike^let me borrow his fishing rod.";
            noruneRuby2[8] = "I remember hearing an old story from^Queens about its ruler La Saia falling^in love with a commoner.¤They say they ran away to be together^forever, how romantic!"; /*<-- Insert <3 to replace the '!' */
            noruneRuby2[9] = "You said you want to be the best genie,^I wonder if there are more genies^out there.";
            noruneRuby2[10] = "Is it true that the food in Queens is^the best in the world?";
            noruneRuby2[11] = "I heard that you are on a quest to be^the best genie in the world, I know it^may be a daunting task but come to me^if you need any advice.";
            noruneRuby2[12] = "Dran is an all-powerful beast that^helps protect Norune. I hope he^will help Ť and you all^on your adventure.";


            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            noruneUngaga[0] = "Woah bro, you look strong! I´d love to^spar with you and see what you can do!";
            noruneUngaga[1] = "The villagers of Muska Racka must be^resourceful people if they are^living in a barren desert.";
            noruneUngaga[2] = "Yay it´s Mr. Ų, I wish I^can be as tall as you one day!";
            noruneUngaga[3] = "Watch where you point that staff,^you might poke your eye out!";
            noruneUngaga[4] = "Your clothes look really interesting,^is that how all warriors^from Muska Racka dress like?";
            noruneUngaga[5] = "It must be difficult to live in^such a harsh terrain, is it possible^to fish in Muska Racka?";
            noruneUngaga[6] = "It´s nice to see that someone from^so far away is helping Ť^on his quest. You are a good man.";
            noruneUngaga[7] = "Look at you, you´re almost as^tall as those muscle brothers!¤Wow, what is your secret?";
            noruneUngaga[8] = "I bet with that staff you could^be an excellent Shepard, we have^plenty of Llama´s here in Norune!";
            noruneUngaga[9] = "Thank you for helping my son on his^journey, there is a saying that it^takes a village to raise a child.¤He will learn a lot from^all of his new allies!";
            noruneUngaga[10] = "What, your favourite food is^scorpion jerky?! Say it isn´t so!";
            noruneUngaga[11] = "Oh, a scorpion warrior from the far^off village of Muska Racka has come^to visit?¤The Sun and Moon Temple is a source^of magic power for your village much^like Dran´s Windmill is for Norune.";
            noruneUngaga[12] = "I am glad strong warriors like you^are helping Ť on his quest,^we will defeat the genie!";

            noruneUngaga2[0] = "I´m glad someone strong like you^is helping Ť on his journey,^he needs all the muscle he can get!";
            noruneUngaga2[1] = "I heard in Muska Racka that the^sand warriors are at war with the^scorpion warriors, is that true?";
            noruneUngaga2[2] = "I have been picking up all^of the sticks I find to^make a staff like you!";
            noruneUngaga2[3] = "Gina has been picking up twigs^and sticks and saying that she^is the great warrior Ų¤Children are so impressionable!";
            noruneUngaga2[4] = "You are much more polite then^those muscle brothers!";
            noruneUngaga2[5] = "Every fisherman´s dream is the Mardan^Garayan, if you see one let me know.";
            noruneUngaga2[6] = "While you are on your quest, make^sure to try and take a break too, life^is all about the work rest balance.";
            noruneUngaga2[7] = "I hope Alnet would let me use a staff^one day, maybe I can defend^Norune just like Ť!";
            noruneUngaga2[8] = "All of the villagers complain about^the heat in our village, I can´t^imagine living in a desert!";
            noruneUngaga2[9] = "Has Ť been taking care of^his health, the last thing^I need is him getting sick!";
            noruneUngaga2[10] = "Is it true that Muska Racka is a big^desert? How do you grow food?";
            noruneUngaga2[11] = "Looking at your eyes I can tell^that you are a strong person who^has conquered many challenges.¤May the Dark Genie be one more^challenge for you to overcome.";
            noruneUngaga2[12] = "We all believe in you, the village of^Norune thanks you all for your help.";


            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            noruneOsmond[0] = "Woah I hear that you are powerful^even though you are small!";
            noruneOsmond[1] = "The dream of every merchant is to^sell their products across the world,^imagine selling items on the moon!";
            noruneOsmond[2] = "Yay Bunny Boy is back! Can you tell^me more stories about the Moon?";
            noruneOsmond[3] = "I´ve never seen someone who looks^like you before, you kind of^look like a bunny.";
            noruneOsmond[4] = "Aren´t you a small little guy,^I wonder how you can float like that!";
            noruneOsmond[5] = "I heard from other villagers that^you are from the moon, is it true^that there is a moon sea?";
            noruneOsmond[6] = "I´m happy that even the moon knows^about Norune village, let them know^that we are the strongest on Terra.";
            noruneOsmond[7] = "Is it true that you are from the Moon?^I heard from the other villagers^but I didn´t believe it!";
            noruneOsmond[8] = "Wow I heard you are from the moon,^is that true?";
            noruneOsmond[9] = "Thank you for helping Ť on^his journey, you have come from so^far away! It just goes to show that^if we are near or far, hard times¤bring people together. If we all^work together as allies,^anything is possible.";
            noruneOsmond[10] = "You are telling me that you are^from the Moon? Is it true the Moon^is made from cheese?";
            noruneOsmond[11] = "I know that the Moon People are well^versed in magic, yet you use a fire arm?^You confuse me young one.";
            noruneOsmond[12] = "Hmm I wonder where you came from,^I haven´t seen any other bunnies^in this village.";

            noruneOsmond2[0] = "If you take Ť to the moon^make sure he doesn´t get lost, he^has a bright future ahead of him!";
            noruneOsmond2[1] = "If you are trying to get some items,^Gaffer´s Buggy is the best shop^in all of Terra!";
            noruneOsmond2[2] = "How can you fly, is it magic?^Teach Gina how to fly too!";
            noruneOsmond2[3] = "You are the same height as my Gina^but you are much older, I guess^you didn´t eat your vegetables!";
            noruneOsmond2[4] = "If Ť goes to the Moon with^you remind him to get a souvenir for^Paige, that would be so romantic!";
            noruneOsmond2[5] = "Imagine fishing on the moon hahaha!";
            noruneOsmond2[6] = "If you ever need any carrots^you should talk to Gaffer.";
            noruneOsmond2[7] = "It´s no fair, Ť gets to go^to the Moon while I´m stuck here^in boring Norune! ";
            noruneOsmond2[8] = "I´m a little confused on where there^would be bunnies on the moon,^strange isn´t it!";
            noruneOsmond2[9] = "Please make sure Ť behaves^himself when he is on the Moon,^he is a nice boy but he could^also be mischievous!¤He is growing up fast but he^will always be my boy.";
            noruneOsmond2[10] = "Ť should take me to the Moon^one day, I bet I could live^like a king on the Moon!";
            noruneOsmond2[11] = "There was something I always wanted^to ask a Moon Person, perhaps^you may have the answer.¤I heard whispers of a legendary tower^that floats in the sky by the name of^the Demon Shaft, who created that^and for what purpose?";
            noruneOsmond2[12] = "What, you are from the Moon?! I see,^perhaps Dran knows something about the^people of the Moon. Norune Village^hopes that you feel welcome and at home!";



            //ro, annie, momo, pao, gob, kye, baron, cacao, kululu, bunbuku, couscous, mr mustache
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            matatakiXiao[0] = "Hello there, you must be a^traveler since we don´t see many^cats around here.";
            matatakiXiao[1] = "Ohohoh aren´t you a cute one!";
            matatakiXiao[2] = "Oh my, what is a small cat like you^doing here?¤You better be careful in this village,^we hunt ferocious beasts but you seem^like a gentle kitty.";
            matatakiXiao[3] = "Hey there don´t mind my scarf I´m a^friendly guy, I swear!";
            matatakiXiao[4] = "Here kitty, I have a proposition for^you! If you could keep an eye on Momo^for me I´ll cook for you my specialty^manly cooking kitty cat miracle dish!";
            matatakiXiao[5] = "If it isn´t a little itty bitty kitty^cat... Your cute appearance can´t^fool me, for I know your secret!¤You are actually the legendary white^tiger coming back to hunt us one by^one!";
            matatakiXiao[6] = "Haha, seeing you brings back many^memories of my youth! After a long^fought battle, I conquered this lion^that I´m wearing but I´m sure you´re¤more tough than any king of the jungle^little one!";
            matatakiXiao[7] = "Interesting, it´s rare seeing a cat^like you here. The last time we had a^feline come into the village was when¤the legendary white tiger came to^challenge Fudo.¤I don´t believe in wearing any beast^skins, you can feel at ease when you´re^with me.";
            matatakiXiao[8] = ".......Cute.......";
            matatakiXiao[9] = "Oh wow, I can´t believe that there´s a^cat in the village, wait until Kululu^hears about this!";
            matatakiXiao[10] = "Oh hello there kitty, I´m very happy to^see you I don´t always have visitors.^It´s very nice to meet you Ӿ!";
            matatakiXiao[11] = "Hooo! You better not get any ideas cat,^I´m not going to be an easy meal!";

            matatakiXiao2[0] = "Be careful around this village, the^hunters here are vigilant. I´ll be sure^to dismantle any traps around our house^for now, you are welcome here.";
            matatakiXiao2[1] = "Poor little kitty do you have a home?^You shouldn´t be living in the forest.¤It could be dangerous here, if you need^anything feel free to come back, our^house is hard to miss!";
            matatakiXiao2[2] = "Wow that´s such a pretty little bell,^I´d love to have that as a necklace!";
            matatakiXiao2[3] = "It must be a bizarre feeling being in a^village like this... The villagers of^Matataki take pride in wearing the^skins and fur of the beasts they¤defeated in battle, each one was a^challenge we overcame. For us, these^skins and what they represent are a way^of life.";
            matatakiXiao2[4] = "I wonder if cats like you can even^digest my manly cooking,¤hmm maybe you shouldn´t have it after^all!";
            matatakiXiao2[5] = "Wait, perhaps I can use your power!¤Join me white tiger and together^we can rule the world.";
            matatakiXiao2[6] = "Say I remember hearing that small cats^like you are common in our neighbouring^village of Norune just north of our^Matataki.¤I wonder what brings you to these parts?";
            matatakiXiao2[7] = "The story of Fudo and his heroism is so^inspiring. Sometimes I get upset that^he is not here with us.¤I know that although he may not be here,^he will always be in our hearts.¤I´ve never been much of a hunter but^Fudo continues to inspire me to be a^stronger person and to overcome my^challenges and make Fudo proud.¤Perhaps one day, we will both be strong^little kitty.";
            matatakiXiao2[8] = "......Here Kitty Kitty......";
            matatakiXiao2[9] = "Beasts rarely come to the village^because they know that strong hunters^live here, like me!";
            matatakiXiao2[10] = "Sometimes I wish I could leave this^house and see the outside world, only^sometimes though.¤Ӿ it would be nice if you could^visit from time to time and tell me^all about your adventures with your^friends, I would appreciate that.¤We could enjoy some fish candy^and share stories!!";
            matatakiXiao2[11] = "If your hungry for some fish, I´m sure^I can give you a great deal!";


            //ro, annie, momo, pao, gob, kye, baron, cacao, kululu, bunbuku, couscous, mr mustache
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            matatakiGoro[0] = "Why if it isn´t young Ʊ I´m^happy to see that you´ve come to join^the other villagers.";
            matatakiGoro[1] = "My oh my, if it isn´t little Ʊ!^You´ve grown up but you still have those^chubby cheeks, come here and let your¤granny Annie give you a pinch for old^times´ sake!";
            matatakiGoro[2] = "Hey there, who would have thought the^son of the legendary hunter would be so^handsome!"; //Suppose to end with heart <3
            matatakiGoro[3] = "It´s a surprise seeing you come outside^Ʊ we were worried about you.¤We wanted to reach out but at the same^time we knew that you needed your space.¤Know that you will always have a place^in this village, we are all family.";
            matatakiGoro[4] = "Grrrr, I have reason to believe that^Momo has her eyes on you! What does she^see in you that I don´t have.¤I bet you don´t even know how to cook!";
            matatakiGoro[5] = "You, you´re the boy who lives in the^tree house! Oh I heard a lot about you^yes!¤The Spirits said you would come, they^said you would save us all they did!";
            matatakiGoro[6] = "Do my eyes deceive me?! What a surprise^but a welcome one to be sure! You´ve^become a man since I last saw you^Ʊ.";
            matatakiGoro[7] = "Hello there Ʊ, you´ve grown^since I last saw you. I understand^how difficult things may be for you.¤Remember to hold your head up high and^always take pride in the life that was^given you.¤What happened to Fudo was a tragedy but^that suffering shouldn´t define you,^you´ll always be your father´s son and^you already made him proud.¤I can´t wait to start writing songs^about the Legendary Hunter Ʊ,^Son of Fudo.";
            matatakiGoro[8] = "......You grew......";
            matatakiGoro[9] = "Woaah, you´re that weird kid who never^comes out of his house!¤I remember when we were younger we would^play in the forest all the time!¤Haha do you remember when we would chase^after those Laughapockle? Good Times!";
            matatakiGoro[10] = "The Spirits told me all about you^Ʊ¤I know the loneliness that comes with^being all alone.¤I´m happy that you found your purpose^and overcame that challenge.";
            matatakiGoro[11] = "Look whooo decided to come out of^hiding! It´s about time, buy something^will ya!";

            matatakiGoro2[0] = "I remember seeing your father Fudoh^teaching you how to hunt when you were^young, you were a natural.¤You definitely take after your old man^but you are a little chubby haha!";
            matatakiGoro2[1] = "No matter how much you´ve grown you´ll^always be little Ʊ to me!";
            matatakiGoro2[2] = "Once you and your friends are done^saving the world, we should go shopping^sometime!";
            matatakiGoro2[3] = "I could tell that you´ve been training,^you´ve grown!¤Be careful when you are in the forest,^I heard there is a monster named King^Prickly that jumps out at you when you^least expect it!";
            matatakiGoro2[4] = "Regardless of how I feel, men must put^their feelings aside. Best of luck on^your journey my friend.¤When you defeat that Dark Genie, I´ll^make a manly cooking feast in your^honor!";
            matatakiGoro2[5] = "Ʊ I had a great respect for^your father Fudoh but he did leave one^thing undone...¤That man still owes me five Gilda, how^uncivilized leaving this world without^paying me!¤Feel free to pay your fathers debt at^your convenience son.";
            matatakiGoro2[6] = "Grow strong Ʊ and rid this^world of the evil that plagues it.¤My time in this world is limited, this^village will require a new chief...¤Grow strong and make Fudoh proud, he will^always watch over you. May you watch^over us Legendary Hunter Ʊ.";
            matatakiGoro2[7] = "Stay strong Ʊ all of^Matataki is cheering you on! One day you^will surpass even your father Fudoh,^always believe in yourself and never¤give up.^Let your might trample the eternal^forest beasts in your way brave hunter.";
            matatakiGoro2[8] = "......I miss Fudoh, thank you for saving^us Ʊ......";
            matatakiGoro2[9] = "Say, can I borrow that mallet you got^there?¤It would be handy for squashing those^pesky Earth Diggers!";
            matatakiGoro2[10] = "Remember, if you ever need somewhere to^store your mallet collection come to me.";
            matatakiGoro2[11] = "I wonder how much you would sell that^bear fur, it would make a nice rug.";


            //ro, annie, momo, pao, gob, kye, baron, cacao, kululu, bunbuku, couscous, mr mustache
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            matatakiRuby[0] = "Greetings young lady and welcome to the^village of Matataki!";
            matatakiRuby[1] = "Oh hello there young lady, I´ve seen you^helping Ʊ and Ť on^their quest!";
            matatakiRuby[2] = "I love your outfit, it´s so glamorous!^I get tired of wearing the same beast^skins.¤Maybe we should go shopping together and^you could help me put together a cute^outfit!";
            matatakiRuby[3] = "I don´t think I´ve ever seen you here,^it seems like Ť is gathering^allies from all over Terra!¤We are a proud village of hunters,^if you need any assistance with anything^let us know.";
            matatakiRuby[4] = "I heard from some of the other villagers^that you´re from the port town of Queens,^how did you travel all the way over^here!?";
            matatakiRuby[5] = "Ah if it isn´t my lovely granddaughter^Momo. My goodness, what did you do to^your hair!";
            matatakiRuby[6] = "Hello there young lady, on behalf of all^of the Matataki villagers I wanted to^thank you for your assistance on^Ť and Ʊ´s quest.¤I guess not all magic is bad after all.";
            matatakiRuby[7] = "You must be the friendly genie everyone^is talking about.¤This village is home to some of the best^hunters on Terra. To be honest, I have^never been one for fighting but magic^sounds interesting.";
            matatakiRuby[8] = "...I can feel your magical energy...";
            matatakiRuby[9] = "I never saw someone with purple hair^before!¤You say you´re from Queens, does^everyone from Queens have purple hair^and dress weird?";
            matatakiRuby[10] = "I can feel the magical power emanating^from you, you must be one powerful^genie! I´m happy you´re on our side.";
            matatakiRuby[11] = "Remember to buy more items to help you^on your quest. Genie or not you´ll need^all the help you can get!";

            matatakiRuby2[0] = "Seeing you reminds me of Annie when she^was your age, oh she was the most^beautiful lady in the  village.¤I remember getting into arguments with^Kye and Baron over her.¤In the end it was me who won her over^with my dashing good looks and smart wit^haha!";
            matatakiRuby2[1] = "The other villagers say that your trying^to prove that your Terra´s greatest^genie.¤I think that is very admirable that^you´re also helping us along your way,^it´s like hitting two Fli Fli´s with one^stone!";
            matatakiRuby2[2] = "Matataki´s way of life focuses on^hunting and comradery, although Queens^does sounds exciting!¤I´d love to visit a port town with lots^of shops!";
            matatakiRuby2[3] = "The word in the village is that you´re a^powerful genie, I guess that explains^your odd clothes!";
            matatakiRuby2[4] = "If you ever feel even the slightest bit^hungry feel free to enjoy my manly^cooking.¤Wait do genies get hungry like humans?";
            matatakiRuby2[5] = "Momo, I know I may be a handful, I know^I may be silly but I wanted thank you^for taking care of me.";
            matatakiRuby2[6] = "The magic and wonder of going on an^adventure, oh to be young again!";
            matatakiRuby2[7] = "If you don´t mind me asking, do you know^of any spells to enhance one´s musical^ability?";
            matatakiRuby2[8] = "......I like your hair......";
            matatakiRuby2[9] = "Using magic sounds like it would make^hunting a breeze!¤Do you think you could teach me one day?";
            matatakiRuby2[10] = "I´ve been trying to practice magic at^home to the best of my ability.¤I was able to turn my candy into Gilda!¤I made sure to transform it back because^Gilda doesn´t taste as good as delicious^candy.";
            matatakiRuby2[11] = "I know you may be the best genie in the^world but that doesn´t change anything,^you have to pay like everyone else!";


            //ro, annie, momo, pao, gob, kye, baron, cacao, kululu, bunbuku, couscous, mr mustache
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            matatakiUngaga[0] = "As the years go by, I find myself^thinking about my youth. The problems^we faced and the challenges we overcame^together.¤Annie was always with me through thick^and thin, I´m very thankful for that.¤Family and loved ones are important,^never forget that young man.";
            matatakiUngaga[1] = "These days Ro has been very^introspective, this situation with the^Dark Genie must have really got to him. I^wish life can return to how it once was.¤At my age I´ve seen a lot of life, but^I´ve seen a lot of death as well,^Fudo is proof of that.¤These are feelings that I wish no one^else has to go through. I know that^things will get better in time,^thank you for the help.";
            matatakiUngaga[2] = "I never seen you in this village,^what brings you here?¤Oh you´re assisting Ť and^Ʊ on their quest,^that´s amazing!";
            matatakiUngaga[3] = "Welcome to Matataki Village, I heard^the other villagers talking about a tall^warrior who is aiding Ť^on his quest.¤I can tell you are strong,^they need all the help they can get.";
            matatakiUngaga[4] = "Woah brother, you look tough!";
            matatakiUngaga[5] = "When I was walking by the Waterfall^my friend Mardan Garayan told me that^he was going to move to Muska Racka,^I wonder where that is?";
            matatakiUngaga[6] = "If it isn´t another one of Ť^and Ʊ´s traveling companions!^Make yourself at home fellow hunter.¤Perhaps you could teach me how^to use that fighting stick!";
            matatakiUngaga[7] = "I heard from some of the other villagers^that you are from the far off desert^village of Muska Racka, a village^renowned for their powerful warriors.¤I remember reading that the desert is a^harsh climate full of competing tribes.^If only we can all live in harmony...";
            matatakiUngaga[8] = "...You´re so tall...";
            matatakiUngaga[9] = "You´re huge giant man,^how did you get so tall!";
            matatakiUngaga[10] = "Hello tall man, you are almost as tall as me!^Keep on growing tall man and maybe one^day we could both be giants!";
            matatakiUngaga[11] = "Such exotic clothes, how much gilda^would you like for your hat sir?";

            matatakiUngaga2[0] = "Defeat the evil Ų, there will^always be brighter days ahead,^that alone is worth fighting for.";
            matatakiUngaga2[1] = "Times are uncertain but that won´t^stop me from being positive,¤maybe when this is all over we´ll^travel north to visit our^neighbors in Norune Village!";
            matatakiUngaga2[2] = "I don´t think I´ve ever seen anyone^fight with a large staff like that,^let alone be able to control^the wind either!";
            matatakiUngaga2[3] = "I wonder what kind of beasts the^warriors of Muska Racka hunt?";
            matatakiUngaga2[4] = "I wonder what kind of culinary^delights can be found in your village^of Muska Racka?¤I´m proud of my manly cooking but there^is always room to improve and^implement new styles!";
            matatakiUngaga2[5] = "I always wondered, is it Muska Lacka^or Muska Racka? It´s hard to believe^a village like that would have^such a confusing name!";
            matatakiUngaga2[6] = "I wanted to extended my^gratitude Ų. Although Matataki^and Muska Racka are two villages very^far away from one another, we´re still¤helping each other. Both villages^take pride in their strength and the^warriors that call these two areas home.¤Know that if we all come together,^we can defeat this great evil.";
            matatakiUngaga2[7] = "Brave warrior of the scorpion tribe,^seeing you has reminded me of a fairy^tale I heard when I was younger.¤It told the tale of someone who lived^in a harsh environment much like^us hunters. They overcame the many^challenges life threw their way and¤even went on to help the^underprivileged as well as the weak.¤This was a story of an ordinary man^growing old, he was just a common^man with a big heart. That in itself^is a rarity in our harsh reality.";
            matatakiUngaga2[8] = "...Nice hat...";
            matatakiUngaga2[9] = "Seriously that fighting stick is^almost as tall as I am!";
            matatakiUngaga2[10] = "Do you like eating candy, wait what^is scorpion jerky? I don´t want to be a^meanie but that sounds gross, have a^lollypop instead!¤Didn´t you almost die from a^scorpion sting anyways?";
            matatakiUngaga2[11] = "Hooo, that fighting stick would make for an^excellent stick for me to perch on,^care to part with it?";


            //ro, annie, momo, pao, gob, kye, baron, cacao, kululu, bunbuku, couscous, mr mustache
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            matatakiOsmond[0] = "Woah watch out my friend, this^house is rigged with traps!";
            matatakiOsmond[1] = "Ohhh seeing you brings back a flood of^memories, my parents would tell me^bedtime stories about bunnies^who lived on the moon.";
            matatakiOsmond[2] = "Oh you´re so cute!";
            matatakiOsmond[3] = "Oh giant bunny, welcome to our humble^village of Matataki. We hereby swear^to not harm a hair on your fuzzy head!";
            matatakiOsmond[4] = "You look strong for such a little guy!";
            matatakiOsmond[5] = "I know it may be hard to believe but^every night my moon bunny friends^come by and take me to the moon!!¤Come take me away bunnie boys old Kye^is ready: lucky, cookie, zucchini!";
            matatakiOsmond[6] = "It brings me great pride to know that^the noble moon people are assisting us.¤The Dark Genie will regret the day^he awoke from his dark urn!";
            matatakiOsmond[7] = "I heard that there was a bunny helping^Ť and his friends. As a village^that hunts beasts this may sound^preposterous but thank you my friend.";
            matatakiOsmond[8] = "...Interesting...";
            matatakiOsmond[9] = "What´s up with your weird clothes,^how come you don´t^wear any animal skins?";
            matatakiOsmond[10] = "Wowie, I heard you came from the moon,^do you think one day you^could take me with you?¤Imagine the space adventures of^Couscous and Ō, that would^make for a great story!";
            matatakiOsmond[11] = "Hmm, what kind of currency^do you use on the Moon?";

            matatakiOsmond2[0] = "I wonder why the Dark Genie wants to^destroy Terra? Little is known about^Flagg Gilgister. Either it really makes^you think about their motivations...";
            matatakiOsmond2[1] = "It brings me pride knowing that^Ʊ and his companions reached^the moon, that boy is a lot^like his father.";
            matatakiOsmond2[2] = "Hey big bunny, do you want a carrot?";
            matatakiOsmond2[3] = "You must be some sort of^divine beast, I´ve never seen^a bunny as large as you!";
            matatakiOsmond2[4] = "When we were children we would always^hear stories about the moon being made^of cheese or bunnies living on the moon.¤I´m happy that one of those things^turned out to be real!";
            matatakiOsmond2[5] = "Ahhhh stay away from me, I caught^the rare moon disease^known as space prebbles!";
            matatakiOsmond2[6] = "Throughout all my years, I never^thought I would encounter a moon^person, I am honoured my friend.";
            matatakiOsmond2[7] = "To a beast, this village may seem^menacing, but to me, it´s home.¤I never was one for hunting since my^body cannot handle it but I have^a great respect for you fighters.";
            matatakiOsmond2[8] = "...Big bunny!...";
            matatakiOsmond2[9] = "Wait, your ears... They´re^kind of like rabbit ears!^You aren´t a rabbit are you?!";
            matatakiOsmond2[10] = "Is the Moon really made^of delicious cheese?";
            matatakiOsmond2[11] = "I hear the Moon Sea is home to many^dangerous monsters, it seems like a bad^investment to set up a business there!";



            //king, sam, ruty, suzy, lana, basker, stew, joker, phil, jake, wilder, yaya, jack
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            queensXiao[0] = "Ahh! I´m glad that you´re here.^My name is King and I´m the mayor^of this humble seaside town.¤We could use some pest control,^these rats are becoming more common.";
            queensXiao[1] = "Hey there, stay out of trouble now!";
            queensXiao[2] = "I noticed that you have your eye on our^world famous flapping fish, would you^like to try some?";
            queensXiao[3] = "The importance of having a^Watery goes a long way back.¤The water from Queens is considered^to be some of the best, most premium^water in all of the Earth.¤Many merchant families made their name^by selling our desirable water to^other villages and towns.¤I hope my humble store^can continue that legacy.";
            queensXiao[4] = "Aren´t you the cutest little cat I´ve^ever seen!¤Have you come to Queens in search of^fish?";
            queensXiao[5] = "Stray cats like you used to be found all^over Queens as the ocean smell would^brings cats from around the world.¤Not many animals can be seen after the^Genie attacked..."; //CANNOT REACH THE NPC
            queensXiao[6] = "Sheriff Wilder is always giving us^trouble but we´re just trying to make^Queens a better place for everyone.¤I mean maybe we´re also looking out for^ourselves but a man´s gotta stay ahead^right!";
            queensXiao[7] = "The King Mimic carries many treasures,^defeating one is a challenge worthy only^for the strongest warrior.";
            queensXiao[8] = "This is a holy place and a refuge for^all.¤These recent events only underscore that^we are stronger together.^The Dark Genie will not defeat our^indelible spirit!";
            queensXiao[9] = "I love cats but you better stay out of^King´s property!";
            queensXiao[10] = "Hey there little buddy, let me know if^you see any trouble okay?";
            queensXiao[11] = "Oh have you come to get your fortune^told?¤Sorry, I don´t do pets, ohohohoho!¤I hear the villagers in Matataki share a^bond with animals, perhaps they can^help.";
            queensXiao[12] = "Beat it cat, I have allergies!¤Wait, having you around might be good^for business!";

            queensXiao2[0] = "This town is so ungrateful, you work^tirelessly and do your best for the^people and what do you get for it?¤Here´s some advice, it´s best if^you look out for yourself.";
            queensXiao2[1] = "*Whew* Taking care of Queens is a big^job, I don´t know how the Sheriff does^it!";
            queensXiao2[2] = "I heard from some of the other merchants^that there are many large warrior fish^by the name of Gyon who inhabit the^Shipwreck.¤They carry large spears, take caution if^you try to gobble up that fish!";
            queensXiao2[3] = "To think that the queen and a commoner^once fell in love right here in Queens!¤How romantic!";
            queensXiao2[4] = "When Stu was young he used to take care^of all the stray cats.¤There was King Speed and Plugal but Hot^Sauce was his favourite.¤Oh, children grow up so fast...";
            queensXiao2[5] = "Dark Genie or not, It´s important that^we take care of our physical health."; //CANNOT REACH THE NPC
            queensXiao2[6] = "I heard that the Sheriff has been^suspicious of Joker for a while now.¤We´re all relieved as it gives us a^break from dealing with him and his^dim-witted partner.";
            queensXiao2[7] = "I hear everyone was brought back by the^power of Ť´s Atlamillia, a^powerful gem indeed...¤It makes one think about what would^happen if a gem like that would fall^into the wrong hands...";
            queensXiao2[8] = "As long as this cathedral stands, the^story of La Saia will never leave our^hearts.";
            queensXiao2[9] = "I´m not a fan of people but animals are^a different story.";
            queensXiao2[10] = "Would you like to join Sam and I with^fighting crime and keeping Queens safe?";
            queensXiao2[11] = "Hmm, there´s something special about^you, are you sure your just a cat?";
            queensXiao2[12] = "You better be careful, there´re weapons^and bombs all over the place.¤Last thing we need is an accident, let^alone one involving a cat!";


            //king, sam, ruty, suzy, lana, basker, stew, joker, phil, jake, wilder, yaya, jack
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            queensGoro[0] = "Here he comes, the hammer boy that is^the talk of the town.¤Hey can you do me a favour?¤If you do defeat the Dark Genie can you^tell everyone it´s because I told you^to, it would help with my re-election^campaign.";
            queensGoro[1] = "Woah you look strong Ʊ¤Do you think if I wore an animal skin^the other villagers would take me more^seriously when it comes to stopping^crime?";
            queensGoro[2] = "Hey I know you!¤You´re the hunter that carries around^that huge Frozen Tuna!¤That must be exhausting for such a small^guy.¤You Matataki Hunters are something else!";
            queensGoro[3] = "Oh you look pretty heavy, are you sure^it´s not all water weight?";
            queensGoro[4] = "Oh look at those chubby cheeks, you look^just like Stew when he was a baby!";
            queensGoro[5] = "Oh you say you are from the distant^village of Matataki?¤I hear the forests around the village^are home to many lethal monsters which^are poisonous such as the hornets or^Cannibal plants."; //CANNOT TALK TO THE NPC
            queensGoro[6] = "Hey there bear skin, King is the person^who runs this town and don´t you forget^it!";
            queensGoro[7] = "Everyone is talking about that chubby^kid from Matataki and how he uses a^Frozen Tuna to pummel his enemies.¤Here´s a tip, if you can find a sundew^that will lead to finding many precious^gems.";
            queensGoro[8] = "A band of warriors consisting of people^from all over the Earth, what an^inspiring sight.¤Strong people are those who are pure of^heart and put the needs of others before^themselves.¤Thank you for everything Ʊ.";
            queensGoro[9] = "You must be strong if you defeated a^bear, why don´t you join us?";
            queensGoro[10] = "I see you´re wearing a bear skin on your^head, did you defeat that bear in^combat?¤You must be a very strong warrior indeed!¤Seeing you reminds me of family that I^have in far off village who also value^physical strength hahaha!";
            queensGoro[11] = "What brings you here, oh you wish to^have your fortune told? Which one first,^the bear or the boy?";
            queensGoro[12] = "You look like the kind of guy who would^really benefit from purchasing my^Big Bucks Hammer.¤You´d get so much money that you could^even ditch those old animal skins and^finally make yourself look presentable.¤Everyone in Queens will call you^Big Money Ʊ, all you have to do^is grab that hammer.";

            queensGoro2[0] = "Woah someone as plump as you must be^living the good life!";
            queensGoro2[1] = "It must be nice to be able to pick up^that huge hammer, Sheriff Wilder says^that he´s going to help me train.¤Maybe one day I´ll be as big as he is!";
            queensGoro2[2] = "Hunters and fisherman really are not too^different from each other.¤It´s no Frozen Tuna but you´re always^welcome to my flapping fish!";
            queensGoro2[3] = "I heard that the village of Matataki has^a pond in the shape of a peanut.¤That´s pretty interesting!";
            queensGoro2[4] = "It´s good to see you again young man.^Thank you for helping fix our seaside^town, we´re very thankful.¤Maybe as a reward I can sew you some^clothes that don´t look so raggedy.";
            queensGoro2[5] = "I know you are a hunter but don´t get^ahead of yourself.¤Always remember to pack antidotes and^mighty healing when going on your^adventures."; //CANNOT TALK TO THE NPC
            queensGoro2[6] = "Hahaha I know this may sound weird but^you look like Auntie Medu!";
            queensGoro2[7] = "The Shipwreck is not only home to the^treasures and but also many lethal^monsters, each one more challenging then^the next.¤Now it´s as if all of the treasure^hunters of Queens are profiting of their^Queen´s misfortunate demise.¤A tragedy to be sure but it´s not like^she needs those treasures anymore.";
            queensGoro2[8] = "When meeting travellers who come to^Queens I always love telling them about^the story of La Saia.¤I feel like it´s one that many could^relate to as we all have someone that^left us whom we miss...";
            queensGoro2[9] = "Everyone says that your from Matataki^village but I never heard of that place.¤For all I know maybe you made that name^up.";
            queensGoro2[10] = "Anyone who could defeat a bear is worthy^enough to call themselves a warrior!";
            queensGoro2[11] = "I sense a lot of regret in your heart^young man.¤As if you lost something or someone^without properly saying goodbye.^However, it´s as if there is a spiritual^presence that´s watching you.¤I feel peace and a sense of pride^emanating from this presence.";
            queensGoro2[12] = "I wonder, out of all the weapons, why^did you choose to use a mallet?¤Oh, you use axes too?¤I hear only the most accomplished^Matataki hunters can use an axe^effectively.¤Whoever taught the ways of a hunter must^be proud.";


            //king, sam, ruty, suzy, lana, basker, stew, joker, phil, jake, wilder, yaya, jack
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            queensRuby[0] = "Does this Dark Genie guy think he´s^tougher than me?¤He´s got another thing coming.¤Now I don´t want anything to do with you^Ʀ but having one of my old^associates defeat the Dark Genie would^help my chances at re-election.";
            queensRuby[1] = "I´m glad that you´ve turned a new leaf^Ʀ.";
            queensRuby[2] = "I´m glad you are using your magical^powers for good!¤There´s nothing better than finding^your purpose.";
            queensRuby[3] = "I always appreciated you Ʀ,^well at least when you weren´t getting^into mischief.¤Thank you for helping Ť and^his group with fighting off the^Dark Genie.";
            queensRuby[4] = "Back in my day proper ladies wouldn´t^dress like that.";
            queensRuby[5] = "I´m curious about your hair color^Ʀ, was it always like this?¤It´s a rare color indeed, perhaps it´s^connected to your magic!"; //CANNOT TALK TO THE NPC
            queensRuby[6] = "Hey there Ruby, how´s it going?¤The last time you got Jake and I in^trouble we couldn´t come into work with^King for a while!¤I´m going to be honest, it was nice^having that vacation!";
            queensRuby[7] = "The Mask of Prajna is one of the undead^doomed to haunt the once hallowed halls^La Saia´s Shipwreck.";
            queensRuby[8] = "It would only make sense that a native^of Queens would try to free La Saia from^her curse.¤What happened between her and her lover^was tragic."; //THIS IS SPOILERS BEFORE THE BOSS FIGHT
            queensRuby[9] = "Don´t think that just because you´re^helping everyone that King owes you any^favours.";
            queensRuby[10] = "I´m very proud of how far you´ve come^Ʀ.¤I remember when you would cause all^sorts of issues for the people of Queens^with King and his hoodlums.¤Continue to make us proud Ʀ.";
            queensRuby[11] = "*Humph* Everyone in Queens is talking^about the magical powers of the great^genie Ʀ as well as her good^looks.¤How come no one compliments me,^the great fortune teller Yaya, for my^beauty?";
            queensRuby[12] = "Hey you´re not here to take more^merchandise are you?¤Come on Ʀ I can´t keep giving^you discounts like this.¤One of these days you´ll send me to the^poor house!";

            queensRuby2[0] = "Remember that one time when Stew tried^teasing me by calling me King Ploogal?¤I made sure to punch him right in the^face.";
            queensRuby2[1] = "That King is always up to no good!";
            queensRuby2[2] = "The fish were barely biting, it doesn´t^help that the sea is so blue that you^can´t see them either!¤Say, you´re trying to prove that you´re^the most powerful genie, do you know of^any spells that can help?"; //POTENTIAL EASTER EGG
            queensRuby2[3] = "Even a genie like you needs to stay^hydrated, feel free to come by if you^ever need something healthy to drink!";
            queensRuby2[4] = "I wish my son would get married and give^me a grandchild.¤Would you like to meet my son, he´s such^a nice boy!";
            queensRuby2[5] = "As a doctor I often have to administer^mighty healing to people who fall ill.¤King´s tough bodyguards Stew and Jake^cried when I had to do them haha!"; //CANNOT TALK TO THE NPC
            queensRuby2[6] = "Do you want to help us procure some rare^gems from Joker again?";
            queensRuby2[7] = "I´ve been collecting gems for quite some^time but I´ve never seen a Sun Stone.¤If only I had one in my collection.¤The legend goes that the Sun Stone only^shows itself to those who are pure of^heart.¤Heh like that´s going to happen.";
            queensRuby2[8] = "Seeing merchants from all over come by^and pillage La Saia´s resting place,^the Shipwreck is a disgrace.¤I never thought people could be so^heartless.";
            queensRuby2[9] = "Don´t talk with me, I don´t want^anything to do with you after the^mischief you made last time.¤King wouldn´t speak to us for weeks^even!";
            queensRuby2[10] = "Sam and I are going to keep a close eye^on King and Joker.¤It seems like more and more people want^to work for that bad King.";
            queensRuby2[11] = "One must wonder, once the people of^Earth defeat the Dark Genie, will they^turn their attention to you next?¤Humans fear what they don´t^understand...¤Perhaps that´s why the Moon People chose^to seclude themselves in Brownboo^Village.";
            queensRuby2[12] = "You should encourage Ʊ to use^that Big Bucks Hammer to make some^extra Gilda!";


            //king, sam, ruty, suzy, lana, basker, stew, joker, phil, jake, wilder, yaya, jack
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            queensUngaga[0] = "It´s comforting to know that Gilda can^solve problems in society.¤How much do you think it would cost to^get the Dark Genie to leave and never^show his ugly face here again?¤Hey, everyone has a price.";
            queensUngaga[1] = "I hope that one day I´ll be as tall as^you Ų.";
            queensUngaga[2] = "Interesting, I heard your from the^desert village of Muska Racka.¤I know that there´s some rare fish that^can be found in the desert by using^potato cakes as bait.";
            queensUngaga[3] = "It hasn´t been easy running a business^since King was elected as mayor.¤I feel like he slowly wants to buy every^business in Queens.¤I´d love to give him a piece of my mind!";
            queensUngaga[4] = "The good thing about living in Queens is^we get people from all around the world^coming to visit!";
            queensUngaga[5] = "I had the luxury of travelling all^around the Earth but not once have I^been to Muska Racka."; //CANNOT TALK TO THE NPC
            queensUngaga[6] = "You´re dressed funny, you must be from^out of town.";
            queensUngaga[7] = "I don´t think you or any of your friends^are going to be able to defeat the^Dark Genie.¤The power of hate is too strong, it lies^in the heart of everyone.¤Something tells me that Genie draws from^that hate to fuel itself.";
            queensUngaga[8] = "The story of La Saia underscores the^importance of upholding the promises you^make with loved ones.";
            queensUngaga[9] = "You think you´re so tough?¤We should see which one of us is^stronger.";
            queensUngaga[10] = "Ahh, a brave warrior from the Muska Racka^Desert.¤Thank you for all the help young man,^the people of Queens appreciate your^service.¤We´ll make that Dark Genie pay for what^he did!";
            queensUngaga[11] = "You, I sense a that you hold a great^responsibility, is there someone who you^wish to protect?";
            queensUngaga[12] = "I don´t believe in using a staff, a good^weapon should be sharp and to the^point.¤I hear the shipwreck is home to many^ferocious monster and precious gems.¤I wouldn´t want to go down there even^if there´re rare gems!";

            queensUngaga2[0] = "I should take you out on a spin in my^new car as a way of saying thanks for^freeing me.";
            queensUngaga2[1] = "My primary goal in life is to keep^people safe, who knows maybe one day^I´ll be the Sheriff!";
            queensUngaga2[2] = "That´s a cool looking turban you´ve got^there, Rando has one just like it!¤I guess it goes to show that even^Muska Racka and Queens share some^similarities!";
            queensUngaga2[3] = "Being trapped in Atla wasn´t so bad,^at the very least I was able to have^some alone time!";
            queensUngaga2[4] = "Say, now that I think about it Rando^hasn´t aged a day!¤I wonder what kind of moisturizer he is^using and if he´d be willing to share^some with me ohhohoho!";
            queensUngaga2[5] = "Be safe when you enter the Shipwreck,^there are many strange monsters which^call La Saia´s underwater grave home."; //CANNOT TALK TO THE NPC
            queensUngaga2[6] = "I heard that there was some merchants^who went down to the Shipwreck and^didn´t return.¤I know King is the Mayor but why is this^his problem?";
            queensUngaga2[7] = "The Moon Orb is said to give eternal^life to the one who owns it.¤Wouldn´t you want to live forever?";
            queensUngaga2[8] = "This church was built hundreds of years^ago, since it has become a landmark^bringing many lovers together in unity.";
            queensUngaga2[9] = "Sheriff Wilder is always running around^and ruining our plans.¤One of these days his assistant Sam is^going to disappear.¤Hehehehe.";
            queensUngaga2[10] = "Haha you have admirers, Sam was talking^about how he wants to be as tall as you^one day!";
            queensUngaga2[11] = "I also can see that you have a fear of^scorpions, perhaps you were hurt by one?¤That makes no sense as I saw you eating^scorpion jerky the other day!";
            queensUngaga2[12] = "Come to think of it, I used to know a^guy from Muska Racka, we used to trade^merchandise every so often.¤His name was Brooke, he was one tough^guy!";


            //king, sam, ruty, suzy, lana, basker, stew, joker, phil, jake, wilder, yaya, jack
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            queensOsmond[0] = "Everyone says that you´re from the Moon,^I find it hard to believe.¤I bet your just a short person in a^bunny suit trying to find their claim to^fame by defeating the Genie.";
            queensOsmond[1] = "Your heli-pack is so cool can I try it^one day?";
            queensOsmond[2] = "Wow, it´s the first time I´ve seen^someone from the Moon!¤Did you fly down to the Earth with your^heli-pack?";
            queensOsmond[3] = "What a surprise, is outer space filled^with cute little bunnies just like you?";
            queensOsmond[4] = "I´m surprised that I had the Moon Orb^all along!¤If Joker had known he would have^certainly given me trouble.";
            queensOsmond[5] = "Well I can´t guarantee that I can help^you medically if you get hurt, I could^still sell you many useful items."; //CANNOT TALK TO THE NPC
            queensOsmond[6] = "Hey you better be careful where you fly^bunny boy, this is our town.";
            queensOsmond[7] = "People give me a lot of trouble, maybe^I should move away to the Moon with you.";
            queensOsmond[8] = "It makes me happy to know^that Ť has your experience and^leadership, together we´ll defeat that^genie.";
            queensOsmond[9] = "Haha you´re a bunny, why are you flying?¤You should be hopping around everywhere^not flying!";
            queensOsmond[10] = "I still have a hard time believing that^the Dark Genie´s evil has even^influenced the Moon and its inhabitants.¤His power really is astounding...";
            queensOsmond[11] = "You, I don´t know what it is but you´re^different from your allies.¤I sense that fate has a much greater^role for you.¤I see many Chronicles unfolding with a^blinding White light.¤What could this all mean?";
            queensOsmond[12] = "I can´t believe it, you use guns on^the Moon?!¤I have so many questions!¤Can I get one please?";

            queensOsmond2[0] = "That Suzy is going around and telling^people that I want to buy up all the^shops in town.¤Now why would I want to buy a puny shop^like hers?¤I aughta buy it just to shut it down.";
            queensOsmond2[1] = "Everyone in town is very grateful for^all the work that you and your allies^have been doing!";
            queensOsmond2[2] = "Space Gyon is a fish monster that can^be found in the Moon Sea.¤I wonder how Gyon managed to get to^outer space...¤Perhaps it was through the help of the^Dark Genie.";
            queensOsmond2[3] = "I´m proud to say that I have the best^watery in Queens but now you tell me^that there´s a Moon Sea?¤I wonder what Moon water tastes like?";
            queensOsmond2[4] = "Stew is still embarrassed about this^when he was young he would play pretend^hero!¤He would call himself King Speed but^then one day he found a strange feather^that made him faster then everyone.";
            queensOsmond2[5] = "The Genie caught us all by surprise but^now we´re ready."; //CANNOT TALK TO THE NPC
            queensOsmond2[6] = "What brings you down here anyways?^The Dark Genie isn´t the business of the^Moon People, we can solve our own^problems.";
            queensOsmond2[7] = "Is there any rare gems to be found on^the Moon?";
            queensOsmond2[8] = "Through the flurry of changes one must^ensure that they stay true to^themselves.¤I can tell that you´re a good^person Ō and that goes for the^rest of your allies.";
            queensOsmond2[9] = "I´ve never seen a bunny in Queens^before, what are you doing here?";
            queensOsmond2[10] = "I do what I can to keep our sea side^town safe but if you ever need anything^Ō let me know.";
            queensOsmond2[11] = "You´re a strong leader, I can tell you^have many who look up to you even if^you´re a cute little bunny.";
            queensOsmond2[12] = "How did you get that heli-pack?¤I have to admit the first time that I^saw you flying with that thing it blew^my mind!";



            //jibubu, chief bonka, zabo, mikara, nagita, devia, enga, brooke, gron, toto, gosuke
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            muskarackaXiao[0] = "Filthy beasts like you can learn^a thing or two from my beauty!¤You probably think you´re so cute but^you´ll never be anything when^compared to the great Jibubu!";
            muskarackaXiao[1] = "What´s a small cat like you doing in^this desert?¤You must be fierce and vigilant to^survive in this harsh climate.¤You may look cute but looking at your^eyes I can see the warrior within...";
            muskarackaXiao[2] = "I heard Enga used to be an accomplished^swordsman when he was a young man.¤I never was able to master the sword^like Enga but I´m the only warrior in^the village who can use a Slingshot!";
            muskarackaXiao[3] = "You´re a small cat aren´t you, I know a^thing or two about being the smallest...¤Living out in the desert can be^dangerous, the other day my friend was^stung by a scorpion and almost died!¤If you need anything at all or even a^house to take shelter, feel free to find^me.";
            muskarackaXiao[4] = "A stray cat like you has no business^being in or around my home!¤There´s plenty of room in the wide open^desert for you to roam around in.";
            muskarackaXiao[5] = "Gosuke and Toto would always pretend to^be warriors and have adventures^together!¤Maybe you could join them and be an^adventurer too!¤You´re a small cat now I´m sure you´ll^change the world one day! Tehehe"; // <3 AT THE END
            muskarackaXiao[6] = "The Sun and Moon Temple is a sacred^place as it´s not only the home of the^Moon Ship but also the final resting¤place of our noble king who passed away^generations ago.¤Since his passing his kingdom broke up^into many warring tribes.¤Since then blood has been split and^people have been killed, perhaps it is¤too late to unify...¤It´s up to our generation to unify after^years of conflict.";
            muskarackaXiao[7] = "No one should ever under estimate the^killer instinct of an animal.¤You may be small but you´re a worthy^hunter in your own right.";
            muskarackaXiao[8] = "Hey cat, how about you bust me out of^here!";
            muskarackaXiao[9] = "Wow, a cat in our village!^Would you like to play with me?";
            muskarackaXiao[10] = "You, your no ordinary cat...¤What are you?";

            muskarackaXiao2[0] = "Everyone thinks that Ų is^the most handsome looking man^in the village!¤Keep this between you and me but^everyone here has low standards!¤Here I am talking to^a wild animal, shoo!";
            muskarackaXiao2[1] = "I always see you following the boy in^the green hat. I once knew a man with^sparkling eyes just like him, full of^hope and strength.¤He was a travelling adventurer, when he^made his way here he defeated everyone^in the village!¤They say he was looking for something or^perhaps someplace...¤He was determined so I´m sure he found^what he was looking for.";
            muskarackaXiao2[2] = "It´s been my responsibility to take care^of the Moon Signet for quite some time^now.¤I feel a sense of pride whenever I think^about the village trusting me with this^heirloom.¤The Moon Signet used to be inseparable^from the Moon people here on Terra but^in recent years they´ve become lazy.";
            muskarackaXiao2[3] = "Mikara doesn´t like animals, she says^she´s allergic but I think she´s just^scared.";
            muskarackaXiao2[4] = "Devia was talking about you the other^day, she said she wanted to take you in.¤Don´t get any ideas little cat, there´s^no room in the 3 Sisters´ House.";
            muskarackaXiao2[5] = "Were you also stuck inside of a weird^bubble?¤I wonder how that all happened anyways,^one minute we´re minding our own^business and the next we´re gone...¤I guess everything can change in the^blink of an eye huh Ӿ.";
            muskarackaXiao2[6] = "Cats like you shouldn´t step foot into^the Temple, it´s a tomb festering with^some of the most ferocious monsters only^seen in your nightmares.¤No place for a little critter like you^haha!";
            muskarackaXiao2[7] = "I wish it were possible for all the^desert tribes to live in peace.¤If the return of the Dark Genie has^taught us anything it´s that we should^stand together.";
            muskarackaXiao2[8] = "These people, they put me in this prison^like an animal.¤If I was given another chance I would^be a changed man, honest!";
            muskarackaXiao2[9] = "Gosuke will always be my best friend,^I see you running after Ť all^the time, I guess he would be your best^friend haha!";
            muskarackaXiao2[10] = "I feel magic...¤Are you like Gosuke?¤No, you are different...";


            //jibubu, chief bonka, zabo, mikara, nagita, devia, enga, brooke, gron, toto, gosuke
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            muskarackaGoro[0] = "You are so out of shape, have you ever^thought of laying off the grass cakes?";
            muskarackaGoro[1] = "Ah so your from the village of Matataki,^I can tell by your distinct warrior^garb.¤The Moon People used to maintain the^shrine but they've gotten lazy over^time, now they relax in the woods not to^far from Matataki.¤Make sure your people don´t hunt them^by accident!";
            muskarackaGoro[2] = "The Sun and Moon Temple is a sacred^place, no one outside of the village has^ever stepped foot inside of it.¤It´s a shame that it has been riddled^with monsters, please help Ť^and Ų rid us of this^infestation.";
            muskarackaGoro[3] = "It´s hard to believe that we were almost^destroyed had not been for Ť^and his friends rescuing us.¤We are all in your debt.";
            muskarackaGoro[4] = "Why are you wearing that, you must^be hot!";
            muskarackaGoro[5] = "You´re so heroic, seeing you fight side^side with Ų makes me inspired^to become a warrior myself!";
            muskarackaGoro[6] = "Bonka used to be the strongest person in^the villages´ history, that all changed^when that traveler came.¤I still remember that fated encounter^to this day, he wielded a beautiful sky^blue blade engraved in gold!¤Much to everyone´s surprise, in just one^swing he defeated Bonka.¤He said he came from a faraway village^in search of a powerful weapon.¤I can´t remember what he was in search^in particular but he seemed desperate^to find it.¤Come to think of it, he looked a lot^like that boy leading you all...";
            muskarackaGoro[7] = "Ah, a hunter from Matataki!¤Matataki Village is renowned for their^hunting prowess and bravery in battle.";
            muskarackaGoro[8] = "Chubby hunters like you better watch out^when walking near me, they didn´t put me^in this cage for show you know!¤You better watch your back forest^hunter!";
            muskarackaGoro[9] = "You´re a small guy huh, yet your still a^capable warrior!¤That´s so inspiring, I want to be just^like the great warrior Ʊ when^I´m older!";
            muskarackaGoro[10] = "You are small like Toto yet you fight...¤What are you fighting for little one?";

            muskarackaGoro2[0] = "I heard Devia say that you looked cute,^how and why!¤The women of the village should be^coming to me and not some out of shape^Opar like you!";
            muskarackaGoro2[1] = "You seem like quite the accomplished^warrior, you remind me of myself when^I was young.¤I used to be the best warrior in all the^village, I still am to some degree.¤This all changed when I was bested in a^duel with a travelling adventurer by the^name of Aga.¤He was determined to find a weapon that^was capable of defeating the darkness^which had begun to linger in our world.¤We were both young and I must admit I^was impressed.¤I have not seen him since and I fear he^may have succumbed to the darkness^himself...";
            muskarackaGoro2[2] = "To access the Moon Ship you need both^the Sun and the Moon Signet.¤The Sun Signet has always been in the^care of our village chief but the Moon^Signet was recently given to us by the^Moon People.¤Sure it makes it more convenient but I^can´t imagine someone walking away from^their duty!";
            muskarackaGoro2[3] = "I can´t fathom leaving your home behind^and going on an adventure across the^world.¤For a small guy you are quite brave...";
            muskarackaGoro2[4] = "They say that you are a warrior, as if!¤I bet even that wimp Jibubu could defeat^you with one hand tied behind his back!";
            muskarackaGoro2[5] = "I bet your mallet is so strong that you^can even crack the shell of a crabby^hermit!";
            muskarackaGoro2[6] = "If that mallet of yours ever becomes^worn out be sure to visit Brooke to get^some repair powder.¤He is one of the bravest warriors in our^village, his eye is proof of that.";
            muskarackaGoro2[7] = "Always take care brave hunter.^To defeat the evil plaguing our land one^must first overcome the evil within and^extinguish any self-doubts.";
            muskarackaGoro2[8] = "One thing you and the hunters from^Muska Racka have in common is that you´re^both prideful, that pride will be your^downfall.¤It´s that same pride that helped fuel^the conflict between our desert tribes.¤Even if you found some way to defeat the^Dark Genie you´ll never defeat the evil^within the human heart!";
            muskarackaGoro2[9] = "They say Gosuke appeared in our village^soon after a powerful warrior departed.¤Whenever I ask the adults about who this^traveller was they´re always very^secretive about his identity.¤I´d love to meet him and ask how he made^Gosuke, maybe he could make more!";
            muskarackaGoro2[10] = "The animal you´re wearing, it is dead...¤Why did you harm it?";


            //jibubu, chief bonka, zabo, mikara, nagita, devia, enga, brooke, gron, toto, gosuke
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            muskarackaRuby[0] = "Oh my, finally someone with beautiful^sensibilities such as myself!¤What kind of foundation do you use for^your skin?";
            muskarackaRuby[1] = "Now aren´t you the pretty one, it´s not^every day that you meet another woman^warrior.¤I´ve been the chief of this village for^quite some time, initially my ability to^lead was called into question due to my^gender.¤However these disagreements were always^settled in a duel and I always was the^victor.¤Let no one dictate what you can do,^always take pride in who you are.";
            muskarackaRuby[2] = "Oh you came from a port town called^Queens? That´s funny the most water we^have is our oasis.";
            muskarackaRuby[3] = "You can use magic right?¤I wonder if you can make Toto another^playmate like Gosuke, he often gets^lonely...";
            muskarackaRuby[4] = "I never met someone who could use magic^but old Enga says that long ago the Moon^people once sealed the Dark Genie by^using magic.";
            muskarackaRuby[5] = "Wow I love your outfit, it´s so cute!"; // <3 AT THE END
            muskarackaRuby[6] = "You and the Dark Genie share many^similarities but I sense no hostility^from you.";
            muskarackaRuby[7] = "I´ve never had the experience of facing^a magic user in battle and I hope I^never have the chance. You are a^formidable fighter indeed.";
            muskarackaRuby[8] = "Purple hair?¤Jeez they must really be desperate for^help if they let a purple hair clown^like you join!¤Oops did I say clown, I meant to say ´Genie´";
            muskarackaRuby[9] = "No way you can do magic, they say Gosuke^came from magic!";
            muskarackaRuby[10] = "Maaaaaaaaagic...";

            muskarackaRuby2[0] = "I heard that if you use the saliva of a^blue dragon it can promote hair growth!¤I mean there´s only one way to test that^theory, time to find some blue dragons!";
            muskarackaRuby2[1] = "They say that you see the same eyes in^different people and that time passes^faster as you age.¤That boy who arrived in the village,^the one with the green hat, I´m sure he^is the son of Aga.¤He was in search for a weapon in^preparation which can defeat a coming^great evil.¤Perhaps he himself became lost to evil^and the Fairies saw fit to send his own^son to finish the journey his father^began...¤Aga...";
            muskarackaRuby2[2] = "The Moon Signet represents our^connection to the moons, I´m not sure^why the Moon people gave it up but I´m^very proud to defend this signet.";
            muskarackaRuby2[3] = "The other day I saw Ӿ sitting^by the river waiting for Ť to^catch a fish, it was such a precious^moment!";
            muskarackaRuby2[4] = "Now I heard all about your skills in^magic but if only you could use find^someway to use your magic to change the^weather!";
            muskarackaRuby2[5] = "I heard that you want to be the most^power genie in the world, I bet you can^do it!";
            muskarackaRuby2[6] = "Watching that young Toto run and play^reminds me of the good old days of my^youth!";
            muskarackaRuby2[7] = "I once heard a story of an old merchant^who wore a sombrero and owned a number^of buggies.¤They say that man has no eyes to speak^of, what manor or horror is he?¤Perhaps it is just make believe...";
            muskarackaRuby2[8] = "Being in this prison is making me bored,^hey genie can you do any magic tricks!¤Maybe you could make a moon bunny come^out of your green friends hat haha!";
            muskarackaRuby2[9] = "I hope I can go on an adventure like^Ų and Ť when^I´m older!";
            muskarackaRuby2[10] = "Thank you for helping, magic girl...";


            //jibubu, chief bonka, zabo, mikara, nagita, devia, enga, brooke, gron, toto, gosuke
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            muskarackaUngaga[0] = "Everyone seems to prefer you over me and^now your going on an adventure to save^the world? The Spirits always seems to^deal you a better hand.¤I know we haven´t always got along but^I´ll be sure to defend the village in^your absence...¤But, if I get so much as one scratch on^my perfect face that´s it for me!";
            muskarackaUngaga[1] = "That friend of yours, the one with the^green hat... Be sure to keep him close^and learn from him.¤Ų I´m an old warrior but not^one without regrets.¤Long ago, there was a day when that^boy´s father and I met each other in^battle.¤His strength was unmatched and I was^quickly bested. He treated everyone,^with love and kindness, even on the^battlefield. He was a good man.¤Part of me wishes I could have joined^him on his journey but I had to fulfil^my responsibilities here to guide our^village as chief.¤(Sigh) As people grow older, they tend^to wonder about what could have been.¤Life is a journey Ų, be sure to^live without regrets.";
            muskarackaUngaga[2] = "Hey Ų, make sure to take some^precaution when going into the Sun and^Moon Temple.¤I hear there´s plenty of poisonous^scorpions there, last thing we need is^you being stung again haha!¤Sorry, I´m just teasing!";
            muskarackaUngaga[3] = "I always worry about you Ų, it´s^like you are always putting yourself in^harm´s way for the sake of the village^but now with the threat of the¤Dark Genie, you´re doing it for all of^the world.¤Only you and your allies can save us.";
            muskarackaUngaga[4] = "Ų you´re a strong warrior, that^little kid with the green hat will need^all the help he can get to defeat the^Dark Genie.¤Take care and make sure you come back in^one piece, I don´t want you breaking my^sisters heart!";
            muskarackaUngaga[5] = "Thank you so much for helping everyone^in the village, make sure you give that^Dark Genie a good whack in the head^for me!¤I may be an optimist but perhaps all of^the desert tribes can come together and^start a new way of life!";
            muskarackaUngaga[6] = "All of these events has reminded me of^an old fable that has been passed down^throughout our Muska Racka.¤One which tells the story of a young boy^who´s village was torn from the earth by^a great evil and suspended from the sky!¤This boy had to travel throughout the^lands to find a way to not only defeat^the evil but also return his home.¤Make believe often mimics reality it^seems haha!";
            muskarackaUngaga[7] = "You are the pride of our village, now^you´ll step foot into the outside world^and everyone why the warriors of Muska^Racka are the strongest to walk on Terra.";
            muskarackaUngaga[8] = "Heh, if it isn´t the brave Ų^have you come to taunt me once again!";
            muskarackaUngaga[9] = "Woah, big bro!¤I had so much fun during our training,^I want to be just like you when I´m^older!";
            muskarackaUngaga[10] = "Ų... friend...";

            muskarackaUngaga2[0] = "I heard Enga used to be the most^handsome man in the village.I have a^hard time believing that!";
            muskarackaUngaga2[1] = "You are strong Ų be sure to^stay true to your ideals.¤You are now traveling the world for a^great purpose, to protect those who are^weak and to defeat the great evil that^is afflicting the land.¤That same evil destroyed this village^and will not stop until the it leaves^only dark clouds of destruction in its^wake.";
            muskarackaUngaga2[2] = "I heard you spent time with a Moon Bunny^by the name of Theo, that is so cool!^I wish they would come visit more often!";
            muskarackaUngaga2[3] = "Ų as you explore the world make^it would make me happy if you could come^back to visit and tell me all about your^journey.";
            muskarackaUngaga2[4] = "The other day, Devia was drawing water^from the Oasis at dusk when she saw the^most bizarre fish!¤She described it as being the oddest^shade of purple with long yellow fins^that resembled a regal hair style!¤We´re not sure why it appeared, we made^Potato Cakes perhaps it was fond of the^smell?";
            muskarackaUngaga2[5] = "After what happened to our village I^think I have a new found motivation to^become a strong warrior like Chief^Bonka.";
            muskarackaUngaga2[6] = "They say a Moon person helped snap you^out of that depression you fell into.¤They are quite the wise ones those Moon^people!";
            muskarackaUngaga2[7] = "I´ve watched over you since you were^young, it takes a village to raise a^child!¤I´m very proud of all of the progress^you have made, not only as a warrior but^also as a person.¤Ų our warring tribes is no^stranger to conflict and there will be^times where you will have to put your¤values to the test on the battlefield.^That is how I lost my eye.¤That´s the price we have to pay for^holding true to our ideals.¤It´s important that when faced with^difficulty, you don´t lose sight of who^you are.";
            muskarackaUngaga2[8] = "I wonder, once you fail and meet your^end what will become of your legacy?¤Will your pitiful tribe still hold you^to high regard or will be known as the^failure that doomed them?";
            muskarackaUngaga2[9] = "Don´t tell Chief Bonka or Enga but I was^once exploring the Sun and Moon Temple^the other day and I saw some gold and^silver golems.¤Do you think they´re related to Gosuke?";
            muskarackaUngaga2[10] = "Don´t be sad Ų...^Gosuke proud of you...";


            //jibubu, chief bonka, zabo, mikara, nagita, devia, enga, brooke, gron, toto, gosuke
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            muskarackaOsmond[0] = "You cover your face with goggles and a^scarf, why not show your beauty for all^to see?";
            muskarackaOsmond[1] = "Ah hah, finally a Moon person comes to^our village!¤I´ll have you know that the people of^Muska Racka have been staying on top of^the defending the Sun and Moon Temple as^well as the Signets.¤We´re not lazy like those bunnies who^chose to live the easy life in the^forest...";
            muskarackaOsmond[2] = "Ah a Moon person, have you come to visit^the Sun and Moon Temple?¤Take caution as it is invested with^monsters!";
            muskarackaOsmond[3] = "So if you´re here that must^mean that Ų and his friends^made his way to the moons!";
            muskarackaOsmond[4] = "Old Enga would tell us that the moons^are home to the Moon tribe but I never^thought they would be bunnies!";
            muskarackaOsmond[5] = "You may be small and cuddly but I bet^your quite the warrior!"; // <3 AT THE END
            muskarackaOsmond[6] = "Ahhh how are doing young one!¤It has been a lifetime since I´ve been^in the presence of your kind.¤I have passed down the stories and myths^that your tribe has given us to the next^generation of Muska Racka¤but they often have a hard time^believing that the Moon people once^lived among us!";
            muskarackaOsmond[7] = "It has been sometime since a moon person^has journeyed to our village.^If you are in need of any supplies let^me know my friend.¤The Moon people and the tribe of^Muska Racka have always had a close^partnership and we wish to maintain that^connection.";
            muskarackaOsmond[8] = "What even are you?";
            muskarackaOsmond[9] = "Wooah, nice you can fly!";
            muskarackaOsmond[10] = "Moons... Pretty...";

            muskarackaOsmond2[0] = "Are you a short hair or a long hair^bunny, what is your hair care regimen?";
            muskarackaOsmond2[1] = "I can tell by your demeanour that you’re^the leader of your moon tribe, care to^have a duel?¤The winner will be both the chief of the^desert tribe as well as the moon^bunnies!";
            muskarackaOsmond2[2] = "What is that weapon you use, it´s like^a slingshot but mechanical! I know Moon^people are adept in magic but what magic^is this?!";
            muskarackaOsmond2[3] = "When this is all over I hope that we can^continue to live in unison.¤It seems like people have been fighting^each other for some time now and that^has to change.";
            muskarackaOsmond2[4] = "Ų is the best warrior the^village has to offer, I hope he will aid^you all on your quest.";
            muskarackaOsmond2[5] = "Have you been teaching Ų a^thing or two when it comes to fighting?";
            muskarackaOsmond2[6] = "I often wonder about Gosuke and his^creation.¤How was that traveller Aga able to^create him, did he learn a method from^you Moon people or did he use some other^form of magic to conjure Gosuke?";
            muskarackaOsmond2[7] = "They say the Moon people here on Terra^have been spending their time relaxing^in the woods, have you visited them yet?";
            muskarackaOsmond2[8] = "Hahaha you are going to fight the^Dark Genie?!¤Good luck short stuff!";
            muskarackaOsmond2[9] = "I can´t believe I´m actually talking to^a Moon person! Enga tells me all about^your tribe, I always believed him but^it´s so cool to see one for real!¤Can you take me with you to the Moon^one day?";
            muskarackaOsmond2[10] = "Gosuke likes you little bunny...";



            //ungaga, theo
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            sunmoonXiao[0] = "It´s nice to see such^a friendly creature.";
            sunmoonXiao[1] = "Oh my, you smell like magic!¤Did you use a Change Potion recently?";

            sunmoonXiao2[0] = "It´s useless, I´m not a strong warrior^like Ť, I let everyone down.¤Mikara...";
            sunmoonXiao2[1] = "I envy you, I can only imagine^what going on a journey^with Ť is like!";


            sunmoonGoro[0] = "A brave warrior like you would^have prevented this tragedy.¤I bet you have always been strong,^your determination is unwavering.";
            sunmoonGoro[1] = "I´m glad I could see a familiar face,^we may be far away from Brownboo or^Matataki but we´re still neighbours,^and neighbours help each other out!";

            sunmoonGoro2[0] = "Life is precious, I failed to^protect the living...¤I am a failure...";
            sunmoonGoro2[1] = "We really need to cheer Ų up,^if he stays like this he´ll never^be the warrior we need!¤It might be difficult^but I´m sure you´re a^barrel full of laughs Ʊ!";


            sunmoonRuby[0] = "You´re a genie, perhaps you´ve come^to finish the work left behind^by the Dark Genie...";
            sunmoonRuby[1] = "I can´t believe Ť and his^allies actually recruited a genie,^wait until I tell everyone!";

            sunmoonRuby2[0] = "I let everyone down...";
            sunmoonRuby2[1] = "We should try to find the time^to do a magic show, after we defeat^the Dark Genie of course!";


            sunmoonUngaga[0] = "Hmm, it seems you used a cheat device^to unlock all characters before^getting Ų, this dialogue^shouldn´t be possible¤but that didn´t stop you haha!^I may as well use this dialogue space^to shout out my talented friends^Word of Wind, MikeZord, Plguee,^Dayuppy and Glitchedd for all of the¤generous contributions they´ve made to^the Dark Cloud Community and for^their diligent work on this fan mod.¤It was a challenge and we worked day^and night to make this mod something^truly special for you all to enjoy.¤One thing I love about this community^is that it´s home to so many^passionate and talented people.¤Even after 20 years you all continue^to be creative, we hope this mod^can help make new memories.^Thank you for all the support.¤Sincerely, Hiddencastle and^the Dark Cloud Compendium.";
            sunmoonUngaga[1] = "Hey you are not supposed to be here!¤Dark Cloud is home to some of the most^interesting cut content, one of my^favourite moments in my time in^the Dark Cloud Community was when¤Word of Wind and MikeZord actually^found the cut playable character Seda!¤Ahhhh we were so happy,^it was 20 years in the making!¤Could you imagine if we got Seda^instead of Osmond, crazy to think!";

            sunmoonUngaga2[0] = "We lost so much during the pandemic^years, countless good people^gone too soon.¤On August 17th 2020, I lost my father^due to cancer and a lot of this^dialogue was inspired by the stories^we would tell each other.¤We´re all missing someone but^it can´t rain all the time.¤This is dedicated to everyone we^lost in the pandemic years,^the young and the old.¤We miss you more than words^can describe, you will all^forever be in our hearts.";
            sunmoonUngaga2[1] = "Oh so you want to know about the^legendary Dark Cloud 3 eh?¤Well if I told you I´d^have to eat you!¤I may look like a cute Moon Bunny^but I´m secretly a Xenomorph!";


            sunmoonOsmond[0] = "Hmm, it seems you used a cheat device^to unlock all characters before^getting Ų, this dialogue^shouldn´t be possible¤but that didn´t stop you haha!^I may as well use this dialogue space^to shout out my talented friends^Word of Wind, MikeZord, Plguee,^Dayuppy and Glitchedd for all of the¤generous contributions they´ve made to^the Dark Cloud Community and for^their diligent work on this fan mod.¤It was a challenge and we worked day^and night to make this mod something^truly special for you all to enjoy.¤One thing I love about this community^is that it´s home to so many^passionate and talented people.¤Even after 20 years you all continue^to be creative, we hope this mod^can help make new memories.^Thank you for all the support.¤Sincerely, Hiddencastle and^the Dark Cloud Compendium.";
            sunmoonOsmond[1] = "Hey you are not supposed to be here!¤Dark Cloud is home to some of the most^interesting cut content, one of my^favourite moments in my time in^the Dark Cloud Community was when¤Word of Wind and MikeZord actually^found the cut playable character Seda!¤Ahhhh we were so happy,^it was 20 years in the making!¤Could you imagine if we got Seda^instead of Osmond, crazy to think!";

            sunmoonOsmond2[0] = "We lost so much during the pandemic^years, countless good people^gone too soon.¤On August 17th 2020, I lost my father^due to cancer and a lot of this^dialogue was inspired by the stories^we would tell each other.¤We´re all missing someone but^it can´t rain all the time.¤This is dedicated to everyone we^lost in the pandemic years,^the young and the old.¤We miss you more than words^can describe, you will all^forever be in our hearts.";
            sunmoonOsmond2[1] = "Oh so you want to know about the^legendary Dark Cloud 3 eh?¤Well if I told you I´d^have to eat you!¤I may look like a cute Moon Bunny^but I´m secretly a Xenomorph!";




            //linda, lumba, salsa, flammi, flada, limbo, jive, tap, aily, cheek
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            yellowdropsXiao[2] = "I heard that some individuals^on the Blue Terra think that the^Moon People resemble bunnies,^how preposterous!";
            yellowdropsXiao[3] = "It seems like the people on Terra have^spent countless years in conflict, if^only we could all get along!";
            yellowdropsXiao[4] = "I could have sworn I saw you transform^into a person, maybe I´m seeing things!";
            yellowdropsXiao[5] = "I´m proud to see you here with the other^humans and the genie, I guess if one^good thing has come from the¤Dark Genie´s arrival it´s that he´s^uniting everyone together. Cats^included!";
            yellowdropsXiao[6] = "Are you impressed with the technology we^have here on Yellow Drops?";
            yellowdropsXiao[7] = "It´s hard to think about how the other^Moon People are living on Terra, have^they lost touch with their culture, can^they still use magic?";
            yellowdropsXiao[9] = "Oh wow, you are very far away from home^little kitty!";
            yellowdropsXiao[10] = "Not to sound rude or anything but cats^don´t belong here, if you wonder into^the Moon Factory and cause mischief¤again who knows what Ō^will do!";
            yellowdropsXiao[11] = "I wonder how Ʊ still manages^to carry that large mallet out here,^imagine how heavy it is!";
            yellowdropsXiao[12] = "The Sun Giant will always be the pride^of Yellow Drops!";

            yellowdropsXiao2[2] = "I wonder how it would be to live^just one day on Terra...";
            yellowdropsXiao2[3] = "Salsa said that he saw you transform^into a person haha!¤Oh Salsa, what a comedian!";
            yellowdropsXiao2[4] = "Seeing Osmand fly with his heli-pac is^so inspiring, is there anything he^can´t do?";
            yellowdropsXiao2[5] = "We saw the Dark Genie´s attack from up^here, it looked so scary! I´m sorry you^all had to go through that...";
            yellowdropsXiao2[6] = "Perhaps one day Blue Terra could be just^as advanced as we are in technology!";
            yellowdropsXiao2[7] = "I hear that the Moon people on Terra^have become lazy, I guess that comes^when living the good life!";
            yellowdropsXiao2[9] = "I always see you chasing around^Ť and his companions, I wish I^could go on an adventure like you!";
            yellowdropsXiao2[10] = "Promise to always stay by Ť^side, he has a good heart and will make^sure you won´t cause any trouble!¤The last time you wondered into the^Moon Factory you left destruction in^your wake.¤Who would have thought such a small^creature could cause large damage!";
            yellowdropsXiao2[11] = "I admire Ų´s height.^I wish that I can be that tall one day^that way Ō won´t boss^me around!"; // REVIEW THIS
            yellowdropsXiao2[12] = "I wish it were possible for me to take^that Sun Giant out for a spin!";



            //linda, lumba, salsa, flammi, flada, limbo, jive, tap, aily, cheek
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            yellowdropsGoro[2] = "I always enjoyed reading about the^Hunting Tribe of Matataki, your village^is close to Brownboo is it not?";
            yellowdropsGoro[3] = "Minotaur Joe is the #1 combatant to^watch in the coliseum!";
            yellowdropsGoro[4] = "The other day Ō was kicking^around the idea of competing in the^coliseum, that wouldn´t be fair to the^other fighters!";
            yellowdropsGoro[5] = "I saw you and your friends come down on^the Moon Ship, that was really cool!";
            yellowdropsGoro[6] = "I always admired how the people of^Matataki maintained their connection^to nature.";
            yellowdropsGoro[7] = "I always admired how Ō is able^to bring everyone together, he´s a^great leader!";
            yellowdropsGoro[9] = "I hope you enjoy your time in^Yellow Drops, we have everything here!";
            yellowdropsGoro[10] = "The other day Jive had the brilliant^idea of going to the Moon Sea, he ended^up being chased out by Cresent Baron!";
            yellowdropsGoro[11] = "I would often look at Blue Terra and^wonder what it would be like if I went^down for a visit.";
            yellowdropsGoro[12] = "The Dark Genie may be powerful but you^got that mallet, never underestimate the^power of a good mallet.";

            yellowdropsGoro2[2] = "I heard legends of a white tiger which^used to stalk the surrounding forests^of Matataki.¤It would wipe out settlement after^settlement!¤If only there was someone brave enough^to stand up to that beast.";
            yellowdropsGoro2[3] = "When I grow up I want to be just like^Minotaur Joe, he will always be my hero!";
            yellowdropsGoro2[4] = "I know Matataki is a tribe of hunters,^maybe you could train me one day so I^can be the next Minotaur Joe!";
            yellowdropsGoro2[5] = "The Moon Sea wasn´t always so dangerous,^I used to spend my childhood days^exploring every inch of that place!";
            yellowdropsGoro2[6] = "Careful with that mallet, is it really^necessary to carry that with you^everywhere?";
            yellowdropsGoro2[7] = "I heard the others needed a hammer for^the Sun Giant repairs, perhaps they^could borrow yours?";
            yellowdropsGoro2[9] = "Say, those are some weird clothes!^Does everyone from Blue Terra dress^like that?";
            yellowdropsGoro2[10] = "I wonder why the Dark Genie decimated^all of Blue Terra but didn´t do the same^to Yellow Drops?¤He must have been pretty angry at you^folks!";
            yellowdropsGoro2[11] = "I can´t believe that the Moon People on^Terra have forgotten how to use magic,^the easy life made them forget the^fundamentals!";
            yellowdropsGoro2[12] = "Once this Dark Genie business is over I^want to get a heli-pack like Ō!¤Hey don´t look at me like that, you have^to treat yourself!";



            //linda, lumba, salsa, flammi, flada, limbo, jive, tap, aily, cheek
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            yellowdropsRuby[2] = "I heard that you´re a being comprised of^magic, a genie! I never met an actual^genie before!";
            yellowdropsRuby[3] = "Have you heard about Minotaur Joe?^He´ll always be my favourite combatant^to watch in the coliseum!";
            yellowdropsRuby[4] = "One day we´ll remember this ordeal and^laugh! We gotta stay positive!";
            yellowdropsRuby[5] = "Ō is so brilliant, they say he^invented that heli-pack by combining a^milk can, pipes and a belt!¤How did he even do that?";
            yellowdropsRuby[6] = "If I can go anywhere on Terra I´d love^to visit Queens!";
            yellowdropsRuby[7] = "Being in Yellow Drops must be different^from being in Queens, let me know if you^need anything!";
            yellowdropsRuby[9] = "Yellow Drops is always in a state of^nightfall, sometimes it gets scary and^I´d get the others to check under^my bed!";
            yellowdropsRuby[10] = "The others were uncomfortable with the^idea of having a genie in Yellow Drops^but you´re nothing like the Dark Genie.¤Thanks helping Ť and his^allies!";
            yellowdropsRuby[11] = "I can´t imagine living on Blue Terra!";
            yellowdropsRuby[12] = "When I was young my friends and I would^go to the Moon Sea and try to test our^bravery! We would all chicken out except^for Ō of course!";

            yellowdropsRuby2[2] = "I was wondering, how do you channel^magic through your armbands?";
            yellowdropsRuby2[3] = "When I grow up, I want to be Tag Team^Champions with Minotaur Joe! Our team^could be called the Bunny and Bull^Connection or the Joe and Lum Express!";
            yellowdropsRuby2[4] = "I remember reading in an old textbook^that long ago there once used to be^floating continent. I wonder if that was^the work of the Dark Genie was well!";
            yellowdropsRuby2[5] = "I heard that in some parts of Terra they^don´t use technology at all?¤That can´t be true can it?";
            yellowdropsRuby2[6] = "I heard from the other allies that some^of Terra´s animals have become^dangerous. They must be under the^influence of the Dark Genie!";
            yellowdropsRuby2[7] = "I wonder, you´re a strong magic user you^should compete in the coliseum!¤If that blockhead Minotaur Joe could be^a champion so could you!";
            yellowdropsRuby2[9] = "Last time I found a baby Moon Beetle^under my pillow, crazy right!";
            yellowdropsRuby2[10] = "Yellow Drops has always took pride in^how we use magic and technology, maybe^we could learn from each other!";
            yellowdropsRuby2[11] = "Everyone in Yellow Drops was so excited^when you all came, we rarely get^visitors!";
            yellowdropsRuby2[12] = "There was never monsters in the Moon^Sea, the other day I was going out for^exercise and a Crescent Baron tried^whipping me!";


            //linda, lumba, salsa, flammi, flada, limbo, jive, tap, aily, cheek
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            yellowdropsUngaga[2] = "Woah you´re so much taller than me!^Your almost as big as the sun giant!";
            yellowdropsUngaga[3] = "You´re almost as tall as Minotaur Joe^but he still bigger haha!";
            yellowdropsUngaga[4] = "I heard the fighting stick is only used^by the most honorable sand warriors!";
            yellowdropsUngaga[5] = "Thank you for all of your help^Ų I know the Moon People could^count on the Desert Tribe to help defeat^Dark Genie!";
            yellowdropsUngaga[6] = "Ʊ seems pretty scary, he´s^wearing an animal pelt! What if he^attacks me, that mallet is huge!";
            yellowdropsUngaga[7] = "I always wanted to go on an adventure,^maybe once this is all done Ō^can plan an expedition across the^Moon Sea!";
            yellowdropsUngaga[9] = "Both you and Ʊ carry your^weapons out, if any monsters appear I^know that you two will defend us!";
            yellowdropsUngaga[10] = "The Moon People and the Desert Tribe of^Blue Terra always had a good^relationship with each other.^Make yourself at home Ų.";
            yellowdropsUngaga[11] = "Make sure not to drink the yellow moon^water, it can give humans a tummy ache!";
            yellowdropsUngaga[12] = "When it´s time for bed I hear odd^notices coming from the direction of the^Moon Sea...¤I have no idea what´s out there but^watch yourself.";

            yellowdropsUngaga2[2] = "I saw Ӿ the cat walking around^with a slingshot in her mouth, what was^she up to?";
            yellowdropsUngaga2[3] = "Minotaur Joe always acts like a crazy^beast in the ring but I heard he´s a^quiet Minotaur when outside of the^coliseum.¤Looks can be deceiving!";
            yellowdropsUngaga2[4] = "Often I wonder about the power of the^Dark Genie, would it be possible for^someone to harness that power and use it^for good?¤I guess it´s not possible, after all the^Genie was locked away to prevent anyone^from misusing that power.";
            yellowdropsUngaga2[5] = "I hope that once this situation is over^that the Moon People of Yellow Drops can^find some way to keep in contact with^the people of Blue Terra!";
            yellowdropsUngaga2[6] = "Maybe I was over exaggerating, I would^totally beat Ʊ in a duel.¤Just don´t tell him I said that!";
            yellowdropsUngaga2[7] = "I had a question Mr.Ų when you^look down at that little blue marble.^Do you ever get homesick?";
            yellowdropsUngaga2[9] = "I love your head wrap! Can you teach me^how to make one?! I´ll make it Yellow^Drop´s new fashion trend!";
            yellowdropsUngaga2[10] = "I was surprised when Jive told me that^Muska Laka is home to a legendary family^of fish!";
            yellowdropsUngaga2[11] = "Ӿ once tried to jump into that^yellow water, she looked disappointed^when Ť stopped her!¤It seems like that little cat thinks^that she´s the boss of everyone haha!";
            yellowdropsUngaga2[12] = "Once this is all done I´m sure you´re^excited to be back home! Make sure you^tell everyone about the mighty warrior^Cheek okay?";


            //linda, lumba, salsa, flammi, flada, limbo, jive, tap, aily, cheek
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            yellowdropsOsmond[2] = "You should get Ʀ to teach you^some Genie magic, imagine how strong^you would be!";
            yellowdropsOsmond[3] = "You´re such a strong leader, once you^retire from the Moon Factory you could^start a new career as a coliseum fighter^like Minotaur Joe!";
            yellowdropsOsmond[4] = "Thank you for all the hard work you^do Boss!";
            yellowdropsOsmond[5] = "I saw that Ť has a fishing rod,^it´s a shame we have no fishing spots^here!";
            yellowdropsOsmond[6] = "Ų´s wisdom never ceases to amaze^me!¤We were talking about the Sun and Moon^Temple as well as the Signits.¤The Moon People and the Desert Tribe^share many similarities.";
            yellowdropsOsmond[7] = "You´re so lucky, now you can travel to^Blue Terra! I heard that they think the^Moon is made of cheese!";
            yellowdropsOsmond[9] = "The Sun Giant has such a magnificent^design, truly the pride of Yellow Drops!";
            yellowdropsOsmond[10] = "Don´t tell the other allies I said this^but you´re definitely the star of the^show Boss!";
            yellowdropsOsmond[11] = "Boss I heard that Ӿ was causing^some mischief in the Moon Factory...¤Do you think it´s wise to let an^adventurous cat like her to wander^around unsurprised?";
            yellowdropsOsmond[12] = "I can´t imagine what the Dark Genie is^thinking trying to destroy Terra but we^cannot let this evil go unanswered.";

            yellowdropsOsmond2[2] = "Finding the courage to be a leader is^challenge for most people. Thanks for^everything Boss!";
            yellowdropsOsmond2[3] = "Minotaur Joe is an inspiration to^us all!";
            yellowdropsOsmond2[4] = "I was looking down at Blue Terra with a^telescope and I noticed a large spire,^a shaft like structure?¤Was that always there?";
            yellowdropsOsmond2[5] = "I wish Ť would teach me how^to fish, we could go on a big fishing^trip on Terra one day!";
            yellowdropsOsmond2[6] = "It´s been so long but I wonder how the^Moon People and the Desert Tribe´s^relationship began?";
            yellowdropsOsmond2[7] = "Make sure to get me a souvenir from^Blue Terra, something cool!";
            yellowdropsOsmond2[9] = "I try to avoid going into the Moon Sea^unless we´re going to the coliseum, you^should come with us!";
            yellowdropsOsmond2[10] = "It was not too long ago when we were^children, you were always the trouble^maker haha!";
            yellowdropsOsmond2[11] = "The Moon People and Blue Terra have a^lot of shared history so it´s nice that^we can reconnect!";
            yellowdropsOsmond2[12] = "Who exactly is Ӿ?^Why did Ť go through the^effort of bringing his pet cat all the^here!¤Perhaps there´s more to that cat then^meets the eye...¤Aha, Ӿ is the team´s mascot!";


             //Storage guard, kiwi, mango, suger, natade, mousse
             //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
             // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            brownbooXiao[6] = "Make sure to watch your step when^walking around Brownboo, I´ve seen many^slip into the water below but^a cat!¤They say there´s a first time for^everything but for your sake I hope^that´s not true!";
            brownbooXiao[7] = "What are you doing here kitty,^are you lost? I think I saw^Ť walking over there, you^should catch up with him while you can!";
            brownbooXiao[8] = "I think you would love to live here,^there are all sorts of fun activities^for a cat to partake in here at Brownboo^Village!¤You could look for fish in the streams^or even search for some delicious moon^fruit!";
            brownbooXiao[10] = "Agh it's the legendary white tiger, you^destroyed Matataki and now you´ve come^for us!¤Please, spare this village, why not go^to Queens I hear they have all sorts of^tasty fish!¤Just don´t eat me *sobs*";
            brownbooXiao[11] = "Did you come from the hunter´s village^of Matataki?¤You better be careful, I saw a villager^wearing a cat as a scarf.¤Knowing your luck you´d probably end up^on a dinner plate or in someone´s closet^as a fashion accessory!";
            brownbooXiao[12] = "Are you Ť´s pet cat? You are so^lucky he seems like such a nice guy!¤I hope he´s feeding you well during this^adventure!";

            brownbooXiao2[6] = "Sorry to disappoint you but no fish can^be found in our waters, sorry!";
            brownbooXiao2[7] = "Ohhhhh, I can feel that^magic emanating from you.¤What´s going on, is there something^Ť is not telling us about you?";
            brownbooXiao2[8] = "Maybe when your done adventuring with^Ť you can come back and play^with me!";
            brownbooXiao2[10] = "Oh wait, you are definitely not the^white tiger!¤Please don´t tell anyone about this,^I´ll never stop hearing about it from^the others!";
            brownbooXiao2[11] = "I´m sure that people often discredit you^because you are a small cat but I bet you^are quite the fighter.¤If Ť and the allies ever need^back up I´m sure you´ll be the first one^to answer that call to arms!";
            brownbooXiao2[12] = "I know it´s hard to believe but you are^helping Ť and the rest of the^allies in your own way, by providing the^best kind of support!¤I bet if you actually saw the Dark Genie^you would claw his eyes out!";


            brownbooGoro[6] = "You look like a strong hunter, if you^ever need to store anything come to me!";
            brownbooGoro[7] = "We almost never get any visitors from^Matataki, I´m pleased to meet you!¤Welcome to Brownboo Village, make^yourself at home neighbor!¤Just make sure not to hunt any of our^villagers. Just because we look like^beasts doesn´t mean we should be hunted^like them.";
            brownbooGoro[8] = "Over the years the Moon People of^Brownboo have forgotten how to use^magic.¤Since ancient times we were the^guardians of Terra but things have been^pretty easygoing!¤The carefree life was a good fit for us.^That is until the Dark Genie returned.^Now we´re rethinking our way of life...";
            brownbooGoro[10] = "We would often visit Matataki Village at^night when all the hunters were asleep!¤We´d tip toe all throughout the night!¤There was one villager who was pretty^friendly, a rather large fellow named^Cous Cous! We´d often visit their house^to get treats!";
            brownbooGoro[11] = "There was once a time where Sugar and^Mango went exploring into the Wise Owl^Forest but they were scared off by a^giant silver serpent.¤This beast´s scales were as pale as the^two moons and it´s fangs looked like^something from our worst nightmares.¤Poor Mango couldn´t go to bed for weeks!";
            brownbooGoro[12] = "Once upon a time, long long ago the^Dark Genie ravaged all of Terra. That is^all except for Brownboo Village.¤This tiny village was the only surviving^bastion from the influence of the Dark^Genie.¤The remaining survivors from all over^Terra journeyed to this village as a^safe haven.¤Many years have since passed and the^Dark Clouds have once again begun to^stir.¤It´s time to make a stand brave Hunter,^like all of those who came before you,^and for the sake of those who will come^after you.¤For the sake of all the life on Terra.";

            brownbooGoro2[6] = "Keep an eye on that Ӿ she´s^quite the mischievous little cat but I^get an odd vibe from her.¤I can´t quite put my paw on it but^something tells me she is not like other^cats...";
            brownbooGoro2[7] = "Keep this between us but some of the^other villagers of Brownboo were afraid^of the hunters of Matataki.¤We believed that if you found our quiet^village you would hunt us all down^mercilessly.¤I´m glad that we we´re wrong about that.";
            brownbooGoro2[8] = "Unlike most of the other villagers of^Brownboo, I still remember how to use^some magic!¤Yes my friend, you are in the presence^of  the amazingly legendary Mango the^Magician!¤For the first trick I will make your^nose disappear!¤Wait, was your nose always that tiny or^did my magic actually work?";
            brownbooGoro2[10] = "Mr.Mustache´s shop was our go to spot^for late night snacks!¤I think we ever ran into a laughapockle^there once!";
            brownbooGoro2[11] = "If you ever outgrow that boring old^wooden mallet can I have it?¤Picture this, the great hunter Natade of^Brownboo Village!¤That mean old genie better look out^because I´d give him a good bonk on the^head!";
            brownbooGoro2[12] = "The culture of Matataki is fascinating,^it seems like you´re people have always^valued hunting and community.¤It seems like the hunt is what brings^you together as a community, both are^intertwined! That´s so interesting to^think about, the most we do here in¤Brownboo is pick Moon Fruit and share^jokes!";


            //Storage guard, kiwi, mango, suger, natade, mousse
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            brownbooRuby[6] = "I´m glad that you are indeed a friendly^Genie!¤Unless you are waiting for the right^moment to trick us!¤I really hope that´s not the case...";
            brownbooRuby[7] = "Genie´s can't be all bad, I mean here^you are helping out Ť and his^friends.¤You don´t have to do that, but here you^are!¤I guess it´s proof that you can´t always^judge a book by it´s cover, only in this^case don´t judge a Genie haha!";
            brownbooRuby[8] = "We´ve been living in the village of^Brownboo for generations!¤Initially, the Moon People used to^maintain a good relationship with the^humans of Terra who live out in the far¤away village of Muska Laka but we wanted^an easier life!";
            brownbooRuby[10] = "Brownboo has always been a village of^solitude, the Dark Genie didn´t think of^attacking us!¤We´ve been living in secret for many^lifetimes so they probably didn´t know^where we were.¤It was so sad, we all heard the voices^of Terra cry out for help, only to be^silenced in unison...¤I´m glad that Ť answered that^call for help.¤Life on Terra can still be saved.";
            brownbooRuby[11] = "The village of Matataki hunts down^beasts, a stark contrast to it´s^neighboring village of Norune where^people live in harmony with the beasts¤such as Dran. Meanwhile Queens is a^bustling port town that doesn´t have any^relationship with beasts at all!¤Terra is such an interesting place when^you think about it!";
            brownbooRuby[12] = "I found a witch parfait the other day^and it was delicious, I can see why they^are your favorite food!";

            brownbooRuby2[6] = "I hope I didn´t hurt your feelings.¤If Ť and his friends trusts^you, then I trust you. You are always^welcome in Brownboo.";
            brownbooRuby2[7] = "I wonder how your magical armband works^in combat?¤Perhaps it´s magic older than anyone of^us, magic from a by gone era...¤Just how old are you Ʀ?";
            brownbooRuby2[8] = "The Moon People of Brownboo haven´t^visited Yellow Drops for countless^years.¤Sometimes I would gaze up at the two^moons and wonder what´s out there.¤Can you be homesick for a place that you^have never been to? A culture you've^never really known?¤Who knows, one things for sure when all^this is over we need to pay them a^visit.¤You can join us Ʀ as long as^you take responsibility of that^mischievous Ӿ!";
            brownbooRuby2[10] = "Thank you Ʀ for fighting^against the Dark Genie.";
            brownbooRuby2[11] = "Mango was talking about you the other^day, they said that you were trying to^be the best genie in history!¤I think they´d love to be your student^one day, of course once this whole Dark^Genie fiasco is over!";
            brownbooRuby2[12] = "I´d really appreciate it if you could^bring us some Witch Parfaits from Queens^if you ever get the chance!";


            //Storage guard, kiwi, mango, suger, natade, mousse
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            brownbooUngaga[6] = "I think if you gave up scorpion jerky,^you would probably be stronger.¤Why not eat Moon Fruit instead?";
            brownbooUngaga[7] = "I wonder how you got so tall, maybe it´s^all of the scorpion jerky you´ve been^eating!";
            brownbooUngaga[8] = "We´ve been living in Brownboo for^generations!¤Initially the Moon People used to^maintain a good working relationship^with the humans of Terra in Muska Laka^but it started being too much of a¤commitment and we wanted an easier life!^It´s not like we made the promise,^rather it was our ancestors.¤Should we be held responsible for the^decisions of our forebears, that doesn´t^seem very fair does it.";
            brownbooUngaga[10] = "I always have been curious, why did you^choose to use a fighting stick as your^weapon of choice?¤I think the weapon that someone chooses^says a lot about their personality.¤Perhaps you like to keep the enemy at a^distance because you don´t want to get^hurt, but you don´t seem like the overly^defensive type...¤Is there someone you care for, aha that^is probably it!¤Make sure you finish this journey in one^piece, make that special person proud!";
            brownbooUngaga[11] = "Sometimes I like to sit along the pier^and just listen to the waves.¤I think about a lot of things like all^of my friends here in Brownboo and even^life on Terra.¤Do you think that we´ll get rid of the^Dark Genie for good?¤I just want us all to live in peace^without the fear of being trapped in^Atla!";
            brownbooUngaga[12] = "Some of you lost loved ones from the^Dark Genie´s attack, we can live here in^protection and comfort but we are not^numb to the suffering of the outside¤world. We, the people of Brownboo, are^here for you.";

            brownbooUngaga2[6] = "I don´t do well in fighting but one^thing I always excelled at was hording^items!¤If you ever need to store items bring^them to me!";
            brownbooUngaga2[7] = "If the Dark Genie could grant me one^wish I would ask to be taller...";
            brownbooUngaga2[8] = "I had a dream the other day that humans,^moon people and monsters all lived in^harmony.¤Everything was peaceful until the Opars^attacked.¤Never turn your back on the Opars...";
            brownbooUngaga2[10] = "Mousse and I were enjoying a relaxing^walking through the Wise Owl Forest when^a giant orange King Prickly landed on^Mousse´s head!¤It was the funniest thing ever!";
            brownbooUngaga2[11] = "I don´t get how the Dark Genie was freed^from his prison...";
            brownbooUngaga2[12] = "The important thing is that you are all^healthy and safe, to be able to fight^means you must first have your health.¤Don´t forget that Ų, health^always comes first.";


            brownbooOsmond[6] = "I don´t think Brownboo will ever adopt^the technology that is used in Yellow^Drops, although having a machine to pick¤all of the Moon Fruit for us would be^really handy!";
            brownbooOsmond[7] = "Wow, are you serious?¤I´ve never seen an outsider who is a^Moon Person before! This is actually^surreal...¤I hope you enjoy your time at Brownboo,^tell everyone back home we say hello!";
            brownbooOsmond[8] = "The Moon People are well known for their^skills in magic here on Terra, but^Yellow Drops has been leading the way in^technology.¤It makes me wonder, will technology^replace magic one day?";
            brownbooOsmond[10] = "For an outsider, you are very polite!^It´s hard to believe that you are the^boss of the Moon Factory, we can use a^good leader here in Brownboo!¤Our leader is a bit of an odd duck to^say the least but we value his guidance^all the same haha!";
            brownbooOsmond[11] = "Against all odds, Ť and his^allies have been fighting against the^Genie´s nefarious work.¤What´s even better is that they are^actually making a difference!";
            brownbooOsmond[12] = "Usually whenever we get an outsider in^the village, we tie them up and put them^through a trial of questions.¤It´s pretty fun!";

            brownbooOsmond2[6] = "Thanks for visiting Brownboo Ō^we don´t get very many outsiders here!";
            brownbooOsmond2[7] = "If only we knew that the Genie would^come back, we would have maintained^better contact with our people back^home...¤I guess there’s nothing that could be^done about that now.¤Moving forward, we can make a change for^the better and stay in contact.¤Life is too short to stay distant from^one another.";
            brownbooOsmond2[8] = "You may think we live a primitive life^here in Brownboo compared to the^technologically rich society of Yellow^Drops.¤In reality, we value the simple things^in life...¤Although, having a heli-pack like that^would be pretty cool!";
            brownbooOsmond2[10] = "Yikes, is that a gun?! Watch where you^point that thing, you´ll poke someone´s^eye out!";
            brownbooOsmond2[11] = "I don´t think we did a good job staying^in touch with everyone in Yellow Drops,^make sure you tell them that we´re all^doing well and that we can handle any¤challenge that comes our way. Dark Genie^or otherwise!";
            brownbooOsmond2[12] = "I saw you walking side by side with^Ų and boy did he make you look^tiny!¤Don´t get me wrong, Moon People are not^known for their towering heights but^standing next to someone taller than you^didn´t do any favours!";


            //Storage guard, kiwi, mango, suger, natade, mousse
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue

            darkheavenXiao = "I must admit that prior to this^cataclysm, I had a hard time^trusting humans.¤However, I watched from afar how each^of the villagers of Norune did their^part to look after a stray like you,^as if you were one of their own.¤Their actions and kindness opened^my eyes to the great potential that^humanity holds. Perhaps that is what^led me to trust your friend Ť.¤Thank you for teaching this old^fairy a valuable lesson Ӿ.";
            darkheavenXiao2 = "This is the final act Ӿ.^Although you grew up as a stray, know^that Ť and his allies cared^for you as if you were family.¤In order for peace to return to Terra,^the threat of the Dark Genie^must be vanquished.¤Take caution as there is no guarantee^that you will all survive this battle...¤Be Strong Ӿ, fight hard and^defend your allies: your family.";
            darkheavenGoro = "Once upon a time, long long ago the^Dark Genie ravaged all of Terra: that^is all except your neighbouring^village of Brownboo.¤This tiny village hidden away deep^in the Forest was once the only^surviving bastion from the influence^of the Dark Genie.¤The remaining survivors from all over^Terra journeyed to that village^as a safe haven.¤Many years have since passed and the^Dark Clouds have once again begun to^stir, the black winds have begun to howl^to the two moons on this night^of our final act.¤We must make haste Ʊ.";
            darkheavenGoro2 = "It´s time to make a stand brave Hunter,^like all of those hunters who came^before you: in the name of the young^who will come after you.¤For the sake of all the life on^Terra... For the sake of your Father.¤Make him proud Ʊ,^he´ll always be watching you.¤May the Spirits guide your way.";
            darkheavenRuby = "Whether it truly be for the personal^glory of proving that you are the best^Genie or a genuine concern for the^fate of Terra, it was very admirable^of you to aid Ť on his quest.¤To involve yourself in the affairs of^others, let alone aiding human, you^now have your chance to prove you are^indeed the most powerful genie in^all of the land.¤But know this, the Dark Genie will^not go out without a fight...";
            darkheavenRuby2 = "This is the final battle Ʀ,^Genie against Genie, magic against magic,^the Spirits cry out as you clash.¤The fate of Terra depends on which^side will prevail!¤This perilous journey has taken you^and your allies all around Terra and^now it´s finally met it´s end.";
            darkheavenUngaga = "On that tragic night when the Genie^ravaged Terra, you fought to protect^your village.¤You fought to protect the^village you called home.¤As fate would have it you lost^everything, even the will to live...¤Despite the Genie´s best efforts to^destroy life on Terra, here you stand.¤That´s a testimate to the strength^you and your allies wield and the will^to succeed.¤Know that you are not fighting to^defend just your kinsfolk but also^those who you matter to you:^for Mikara.";
            darkheavenUngaga2 = "The warriors of Muska Racka have^always been renowned for their bravery.¤The Spirits and I have watched from^afar for generations as the desert^tribes clashed on the battlefield.¤Ų, you possess a skill which^many warriors do not: compassion.¤Perhaps after the threat of the Genie^has been vanquished you can use that^compassion to unify the tribes and^bring peace to the desert.";
            darkheavenOsmond = "I must say, when Ť and I^travelled to Yellow Drops I took the^opportunity to look down upon Terra^from the Moons.¤Looking at our world, our home, the^joy and suffering, it was a sobering^experience.¤Mankind has often dealt with an issue^of self-importance, Flagg Gilgister^is proof of that, but when I look¤at Ť and his allies I see a^band of brave adventurers taking^a stand to defend all life.¤I humbly thank you for involving^yourself in the affairs of Terra.¤Like it or not but for the moment,^this is where we make our stand.¤To preserve and cherish all life^in our world.";
            darkheavenOsmond2 = "I wonder how the magical power of the^Dark Genie will compare with the cutting^edge technology of Yellow Drops´^greatest inventor.¤I must say that strange weapon you^wield scares me ohohohohoho!";



            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            norunefinishedDialogue[0] = "Fighting is what a person lives for,^sometimes we forget this and lose^our way. The most important thing is^that we pick ourselves up^and continue the fight.¤Never lose your smile my friend.";
            norunefinishedDialogue[1] = "Being a merchant as long as I have,^you see some pretty amazing things.^Never would have thought I would^see a gem like Ť´s.";
            norunefinishedDialogue[2] = "Gina had a dream that the Dark Genie^came to the village to say sorry,^we all had food and played.^It was so much fun.";
            norunefinishedDialogue[3] = "Maybe with the Dark Genie out, it^will give the Mayor second thoughts^about being noisy!¤For all we know the Genie could^have targeted us because of that^awful commotion caused by the mayor!";
            norunefinishedDialogue[4] = "Thank you for helping the village^everyone, make sure Ť doesn´t^fall for anyone else on his travels or^else it would break poor Paige´s heart.";
            norunefinishedDialogue[5] = "You know, once this is all said and^done, I´ll have to reward you all with^a fishing trip as long as you make^sure everyone behaves.";
            norunefinishedDialogue[6] = "It´s hard to believe that in an instant^the Genie was able to destroy our^village, everything we hold dear.¤You all brought it back,^we´re in your debt.";
            norunefinishedDialogue[7] = "Don´t tell my older sister but I´m^secretly planning on joining your^adventure, I don´t tell Alnet or^she will get angry!";
            norunefinishedDialogue[8] = "It´s hard to believe that Norune Village´s^Ť is leading a band of warriors^that are going to stop the Dark Genie.¤You´re all special in your own way^but Ť is special to me...^Take care of him.";
            norunefinishedDialogue[9] = "Even after the Genie destroyed our^village, the morning sun continued^to rise each day: that never changed.¤I can´t imagine losing my son or our^loved ones like that again. Thank you^for helping restore the world.";
            norunefinishedDialogue[10] = "Do you think if we gave the Dark Genie^a box full of candies he would leave^us all alone? I mean, that works^for me all the time.";
            norunefinishedDialogue[11] = "I´ve been gifted by the Spirits with^the ability to foresee the future,^however for the first time I´m^afraid to use this gift.¤I´m afraid of what I will see.^This Genie is a fearsome opponent^indeed, be sure to take caution.";
            norunefinishedDialogue[12] = "Nothing here.";


            //ro, annie, momo, pao, gob, kye, baron, cacao, kululu, bunbuku, couscous, mr mustache
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            matatakifinishedDialogue[0] = "I lived long enough to know that^it´s not easy for people to put aside^their differences to solve a problem,^but here we are.¤The people of Matataki are^forever in your debt.";
            matatakifinishedDialogue[1] = "It brings a tear to my eye seeing^young people band together for a single^cause, to help save the world^from this cataclysm.¤Thank you for fixing our^home and our lives.";
            matatakifinishedDialogue[2] = "Thanks for finishing our home,^do you think you can build^a few more stores?¤Mr.Mustache´s shop can be a little^expensive and I only have so much^Gilda in my wallet!";
            matatakifinishedDialogue[3] = "This village is full of the strongest^hunters, but you are by far the^best builders here.";
            matatakifinishedDialogue[4] = "I bet you would have finished^rebuilding my home if you had^a better diet.¤Haha, I´m only kidding.^Any time you feel hungry,^my cooking services are yours!";
            matatakifinishedDialogue[5] = "Just you wait, in the future we´ll^be building houses with giant flying^robots with huge eyes and hands, it´ll^even be piloted by dwarves!¤You´ll see, you´ll all see!";
            matatakifinishedDialogue[6] = "Congratulations young warriors,^you´ve made the hunters of Matataki^very proud.";
            matatakifinishedDialogue[7] = "My home is whole once again and^I´m able to write music again.¤Perhaps I´ll write a song about the^young hunter Ʊ, son of Fudoh.";
            matatakifinishedDialogue[8] = "You helped me when I was scared...^thank you very much.";
            matatakifinishedDialogue[9] = "Wow, my house is better then it´s^ever been. Maybe being attacked by^the Genie was a blessing!¤Don´t tell the others I said that!";
            matatakifinishedDialogue[10] = "Thank you so much friend, I wish^I could give you a hug but I don´t^want to hurt you!";
            matatakifinishedDialogue[11] = "Don´t think that I owe you anything^for rebuilding my shop, you were^doing your civic duty for the^people of Matataki.";

            //king, sam, ruty, suzy, lana, basker, stew, joker, phil, jake, wilder, yaya, jack
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            queensfinishedDialogue[0] = "The people of Queens owe your group^a great debt of gratitude, but^remember I owe you nothing now.¤I could have stopped the Genie myself^but the people of Queens needed me.";
            queensfinishedDialogue[1] = "We may not be defeating the Dark^Genie, but we´ll keep Queens and her^people safe from criminals like King.";
            queensfinishedDialogue[2] = "I spent so much time fishing to earn^a living that I forgot to take it^easy and live life slow.¤This is the lesson I want to take^from this. Gilda isn´t everything, it^doesn´t hurt to enjoy life every^now and then.";
            queensfinishedDialogue[3] = "You know, I´m not as strong as you all^but I do want to be stronger.¤I guess what I´m trying to say is^that where we are today isn´t where^we will be tomorrow.";
            queensfinishedDialogue[4] = "Thank you for all your help, it´s^scary to think that the Dark Genie^made everything on Terra disappear^in the blink of an eye.¤Where would we be without your help?";
            queensfinishedDialogue[5] = "Thanks to you I can get back to^business, I hope King doesn´t decide^to raise taxes again.";
            queensfinishedDialogue[6] = "King is getting ready to run for mayor.^Defeating the Dark Genie is^our #1 campaign goal.";
            queensfinishedDialogue[7] = "Who knows, maybe when the Dark Genie^obliterates the world, more rare^gems will resurface.¤However, destroying the world would^be bad for business...^You all need to stop him.";
            queensfinishedDialogue[8] = "What happened in Queens with La Saia^is nothing short of tragic, but^today we stand before many brave^warriors who are taking a stand^to save all of Terra.¤May you find peace in your journey.";
            queensfinishedDialogue[9] = "Being King´s assistant is a big job,^much more challenging than fighting^that Dark Genie wimp.";
            queensfinishedDialogue[10] = "I´m not surprised that you all^fixed up the police station.¤You´re led by Ť from Norune^and he learned everything he knows^from my family in Norune haha!";
            queensfinishedDialogue[11] = "I heard from the other villagers^that you were all complaining about^my Pumpkin Panty Fortune Telling.¤You know as much as me that if it^wasn´t for my services, your quest^would not have moved forward!";
            queensfinishedDialogue[12] = "Jack´s shop is back in business,^if you ever need weapons or powders^I´m your guy! Just don´t let^Sheriff Wilder know.";

            //jibubu, chief bonka, zabo, mikara, nagita, devia, enga, brooke, gron, toto, gosuke
            //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
            // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue
            muskafinishedDialogue[0] = "To think that someone of your beauty^standards actually rebuilt my house^down to the last elegant detail.";
            muskafinishedDialogue[1] = "In the blink of an eye everything^disappeared: villagers, animals,^all life in the desert.¤The Genie is always going to be a^threat to the world. The last thing^we should do is continue these^age old tribal conflicts.¤Thank you for your help.";
            muskafinishedDialogue[2] = "Hey thanks for fixing up the place!^I was really worried, I thought that^I may have to find somewhere^else to live!¤Home is where the heart is and^I´m forever greatful.";
            muskafinishedDialogue[3] = "Words cannot express the gratitude that^all the villagers have for you.¤Thank you for all the hard work.";
            muskafinishedDialogue[4] = "Hmph... I guess you did a good job^putting our house back together.";
            muskafinishedDialogue[5] = "Thank you so much for fixing our home,^I can´t believe that the Dark Genie^actually had us trapped in those^weird bubbles.";
            muskafinishedDialogue[6] = "Never in all my years would I have^thought that everything in Muska Racka^would disappear the way that it did.¤I´m very pleased with my house,^thank you.";
            muskafinishedDialogue[7] = "Many warriors have come and gone,^your group is special.¤Keep fighting the darkness and^never give up. Things won´t be easy^moving forward. I am in your debt.";
            muskafinishedDialogue[8] = "You must be real proud of yourself^rebuilding this jail cell, would it^have killed you to not include^the locked gate?";
            muskafinishedDialogue[9] = "When I get older I want to join you^on your adventures. Old Enga has^even been teaching me how to fight!";
            muskafinishedDialogue[10] = "Wait, how are you reading this?";
        }
    }
}
