using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class Dialogues
    {
        static string[] noruneXiao = new string[15];
        static string[] noruneXiao2 = new string[15];
        static string currentDialogue;
        static string prevDialogue;

        static int currentAddress;
        static int currentArea = 255;
        static int characterIdData;
        static int[] noruneCharacters = { 12592, 12848, 13104, 13360, 13616, 13872, 14128, 14384, 14640, 12337, 12849, 13105, 13361 };   //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor

        static int[] noruneXiaoCheck = new int[15];

        static byte[] value1 = new byte[1];
        static byte[] value = new byte[2];
        static byte[] value4 = new byte[4];

        static char[] gameCharacters = { '^', '§', '_', '¤', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§',
                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                              'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                              '´', '=', '"', '!', '?', '#', '&', '+', '-', '*', '/', '%', '(', ')', '@', '|', '<', '>', '{', '}', '[', ']', ':', ',', '.', '$',
                              '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '¥', 'Ť', 'Ʊ', 'Ʀ', 'Ų', 'Ō' };

        public static void InitializeDialogues()
        {
            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
            noruneXiao[0] = "El Gato, how are you doing little buddy?^Need any food or water?";
            noruneXiao[1] = "In all my travels around Terra, I have^never seen a cat like you.¤Anyone with eyes can see that there is^something special about you [Xiao]!";
            noruneXiao[2] = "Kitty, were you stuck in a bubble too?";
            noruneXiao[3] = "You´re a cute little cat! Oh no, are you^a stray? You should come live with us!";
            noruneXiao[4] = "Look at you, you are so cute^unlike those muscle freaks!";
            noruneXiao[5] = "I remember when Paige was a little girl,^her mother made her a plush cat^that looked just like you!¤Kids sure do grow up fast, people may^come and go but the memories we make^with out loved ones are eternal.¤Pretty poetic for a fisherman huh, hahaha!";
            noruneXiao[6] = "Sometimes it´s hard to be an older brother,^Macho and I may but heads but^deep down we are about each other.^Do you have any siblings kitty?";
            noruneXiao[7] = "No way, I can´t believe ¥ let´s you go^on adventures with him. You are so lucky!";
            noruneXiao[8] = "Hey there, I´ve been seeing you^hang out with [Toan]! Are you^his little sidekick now? <3";
            noruneXiao[9] = "I appreciate how you are helping [Toan]^on his journey, I still wonder where^he got that change potion.¤It´s hard for one person to try change^the world but if we all work together^as allies, anything is possible. Don´t^worry, I won´t tell anyone your secret <3";
            noruneXiao[10] = "Are you helping [Toan] with^fixing other people´s houses?¤Since you´re helping people can^you help me, I have a bit of a mouse^problem. I could pay you in food!";
            noruneXiao[11] = "They say animals have sharper senses^then that of humans, can you feel^the magic within this village?¤I sense something different about you^[Xiao], perhaps you´re no ordinary cat!";
            noruneXiao[12] = "Hmm I wonder where you came from,^I haven´t seen any other cats in this village.";

            noruneXiao2[0] = "I see you following [Toan] everywhere,^I bet you taught him everything he knows!¤Next time I go training in the Cave, I^gotta bring you with me to watch my back!";
            noruneXiao2[1] = "If anyone understands the troubles^that come with being a wanderer it´s me.¤If you ever need a place^to stay, there is always a^spot for you in my buggy [Xiao].";
            noruneXiao2[2] = "Let´s have a race kitty, I bet^I can run faster than you!";
            noruneXiao2[3] = "Gina would love to have you as a playmate,^the poor girl gets lonely now that^[Toan] is too busy to play with her.";
            noruneXiao2[4] = "If you are ever hungry you should go^to Uncle Pike, he always has spare fish!";
            noruneXiao2[5] = "Have you ever heard of the legendary^fish Mardan Garayan, knowing my^luck you probably ate one before!";
            noruneXiao2[6] = "I remember there was once luchador who^wore a red lion mask who stood for justice^and good, he was as quick as thunder.¤He fought for many decades before^he was finally defeated by evil.^They say he fought valiantly to^the bitter end that even those evil¤doers respected his resolve. I´m sure^there are many who are following^the footsteps of that hero.";
            noruneXiao2[7] = "It´s no fair, I always wanted a pet cat^but my sister doesn´t let me have one^after I had that accident with my^pet fish Uncle Pike gave me...";
            noruneXiao2[8] = "[Toan] may act like a tough guy but^he doesn´t always use his head.^Sometimes I really worry about him.¤It´s not like I can go with him^you know. You can though, I see^you following him around everywhere.¤Can you do me a favour and make^sure he stays out of trouble?^Thanks [Xiao], I appreciate it.";
            noruneXiao2[9] = "Is [Toan] taking proper care of you?^That boy has a good heart but sometimes^he works way too hard, he gets^that habit from his father.";
            noruneXiao2[10] = "What´s your favourite food kitty, I bet^having cat food everyday gets old.";
            noruneXiao2[11] = "Oh-hohoho have you come to live^with me, I guess this old Hag^could use a cat by her side!";
            noruneXiao2[12] = "If the village ever has a rat problem^would you be willing to take a break^from following [Toan] around to^help the rest of the village?";
        }

        public static void SetDialogue(int offset)
        {
            if (Memory.ReadByte(0x202A2518) != currentArea)
            {
                if (Memory.ReadByte(0x202A2518) == 0) currentArea = 0;
                else if (Memory.ReadByte(0x202A2518) == 1) currentArea = 1;
                else if (Memory.ReadByte(0x202A2518) == 2) currentArea = 2;
                else if (Memory.ReadByte(0x202A2518) == 3) currentArea = 3;
                SetDefaultDialogue(currentArea);
            }

            currentAddress = offset * 0x14A0 + 0x21D26FD9;
            characterIdData = Memory.ReadShort(currentAddress);     //store the ID value of nearby character

            for (int i = 0; i < noruneCharacters.Length; i++)   //search through array to find character match
            {
                if (characterIdData == noruneCharacters[i])
                {
                    if (noruneXiaoCheck[i] != 1)
                    {
                        currentDialogue = noruneXiao[i];    //gets the correct dialogue and stores it
                        noruneXiaoCheck[i] = 1;                      
                    }
                    else
                    {
                        currentDialogue = noruneXiao2[i];    //gets the correct dialogue and stores it
                        noruneXiaoCheck[i] = 0;
                    }

                    if (i == 1 || i == 11)  //check for shopkeeper
                    {
                        TownCharacter.shopkeeper = true;
                    }
                    else
                    {
                        TownCharacter.shopkeeper = false;
                    }
                }
            }

            if (characterIdData == 13361)
            {
                TownCharacter.talkableNPC = false;
            }

            currentAddress = 0x2064BA60; //hag's longest line

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
                        }
                        else
                        {
                            value1 = BitConverter.GetBytes(a);
                        }
                    }
                }


                Memory.WriteByte(currentAddress, value1[0]);

                currentAddress += 0x00000001;

                if (value1[0] == 0 || value1[0] == 2 || value1[0] == 3)
                {
                    value1 = BitConverter.GetBytes(255);
                    Memory.WriteByte(currentAddress, value1[0]);
                }
                else if (value1[0] == 250 || value1[0] == 251 )
                {
                    value1 = BitConverter.GetBytes(250);
                    Memory.WriteByte(currentAddress, value1[0]);
                }
                else
                {
                    value1 = BitConverter.GetBytes(253);
                    Memory.WriteByte(currentAddress, value1[0]);
                }

                currentAddress += 0x00000001;
            }

            Memory.WriteByte(currentAddress, 1);
            currentAddress += 0x00000001;
            Memory.WriteByte(currentAddress, 255);
            

            Console.WriteLine("nearNPC");
        }

        public static void SetDefaultDialogue(int area)
        {
            string defDialogue = "Hello";
            
            if (area == 0)
            {
                currentAddress = 0x206494C4;
            }

            for (int i = 0; i < defDialogue.Length; i++)
            {
                char character = defDialogue[i];

                for (int a = 0; a < gameCharacters.Length; a++)
                {
                    if (character.Equals(gameCharacters[a]))
                    {
                        value1 = BitConverter.GetBytes(a);
                    }
                }


                Memory.WriteByte(currentAddress, value1[0]);

                currentAddress += 0x00000001;

                if (value1[0] == 0 || value1[0] == 2 || value1[0] == 3)
                {
                    value1 = BitConverter.GetBytes(255);
                    Memory.WriteByte(currentAddress, value1[0]);
                }
                else
                {
                    value1 = BitConverter.GetBytes(253);
                    Memory.WriteByte(currentAddress, value1[0]);
                }

                currentAddress += 0x00000001;
            }

            Memory.WriteByte(currentAddress, 1);
            currentAddress += 0x00000001;
            Memory.WriteByte(currentAddress, 255);

            Console.WriteLine("nearNPC+SetDefaultDialogue");

        }
        
    }
}
