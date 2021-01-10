using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    class Dialogues
    {
        static string[] customDialogues = new string[15];
        static string[] customDialogues2 = new string[15];    
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
        static string currentDialogue;
        static string prevDialogue;

        static int currentAddress;
        static int currentArea = 255;
        static int currentChar;
        static int characterIdData;
        static int savedDialogueCheck;
        static int[] noruneCharacters = { 12592, 12848, 13104, 13360, 13616, 13872, 14128, 14384, 14640, 12337, 12849, 13105, 13361 };   //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor

        static int[] customDialoguesCheck = new int[15];
        static int[] noruneXiaoCheck = new int[15];
        static int[] noruneGoroCheck = new int[15];
        static int[] noruneRubyCheck = new int[15];
        static int[] noruneUngagaCheck = new int[15];
        static int[] noruneOsmondCheck = new int[15];

        static byte[] value1 = new byte[1];
        static byte[] value = new byte[2];
        static byte[] value4 = new byte[4];

        static char[] gameCharacters = { '^', '§', '_', '¤', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§', '§',
                              'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                              'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                              '´', '=', '"', '!', '?', '#', '&', '+', '-', '*', '/', '%', '(', ')', '@', '|', '<', '>', '{', '}', '[', ']', ':', ',', '.', '$',
                              '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ť', 'Ӿ', 'Ʊ', 'Ʀ', 'Ų', 'Ō', ' ' };
        

        public static void SetDialogue(int offset)
        {
            if (Memory.ReadByte(0x202A2518) != currentArea)     //DOESNT UPDATE when switching ally, fix later!!
            {
                if (Memory.ReadByte(0x202A2518) == 0) currentArea = 0;
                else if (Memory.ReadByte(0x202A2518) == 1) currentArea = 1;
                else if (Memory.ReadByte(0x202A2518) == 2) currentArea = 2;
                else if (Memory.ReadByte(0x202A2518) == 3) currentArea = 3;
                SetDefaultDialogue(currentArea);

                for (int i = 0; i < customDialoguesCheck.Length; i++)   //reset NPC dialogue progress if changed area
                {
                    customDialoguesCheck[i] = 0;
                }
            }

            currentAddress = Addresses.chrFileLocation + 0x6;

            if (currentChar != Memory.ReadInt(currentAddress))  //if using different ally, switch dialogue data
            {
                if (Memory.ReadInt(currentAddress) == 791752805) //Xiao
                {
                    customDialogues = noruneXiao;
                    customDialogues2 = noruneXiao2;
                    customDialoguesCheck = noruneXiaoCheck;
                }
                else if (Memory.ReadInt(currentAddress) == 791752819)  //Goro
                {
                    customDialogues = noruneGoro;
                    customDialogues2 = noruneGoro2;
                    customDialoguesCheck = noruneGoroCheck;
                }

                else if (Memory.ReadInt(currentAddress) == 791883877)  //Ruby
                {
                    customDialogues = noruneRuby;
                    customDialogues2 = noruneRuby2;
                    customDialoguesCheck = noruneRubyCheck;
                }

                else if (Memory.ReadInt(currentAddress) == 792278899)  //Ungaga
                {
                    customDialogues = noruneUngaga;
                    customDialogues2 = noruneUngaga2;
                    customDialoguesCheck = noruneUngagaCheck;
                }

                else if (Memory.ReadInt(currentAddress) == 792014949)  //Osmond
                {
                    customDialogues = noruneOsmond;
                    customDialogues2 = noruneOsmond2;
                    customDialoguesCheck = noruneOsmondCheck;
                }

                currentChar = Memory.ReadInt(currentAddress);

                for (int i = 0; i < customDialoguesCheck.Length; i++)   //reset NPC dialogue progress if changed ally
                {
                    customDialoguesCheck[i] = 0;
                }
            }


            currentAddress = offset * 0x14A0 + 0x21D26FD9;
            characterIdData = Memory.ReadShort(currentAddress);     //store the ID value of nearby character

            for (int i = 0; i < noruneCharacters.Length; i++)   //search through array to find character match
            {
                if (characterIdData == noruneCharacters[i])
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
                            else if (a == 127)
                            {
                                value1 = BitConverter.GetBytes(2);
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
                else if (value1[0] == 250 || value1[0] == 251 || value1[0] == 252 || value1[0] == 253 || value1[0] == 254 || value1[0] == 255)
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

        //Ť = Toan, Ӿ = Xiao, Ʊ = Goro, Ʀ = Ruby, Ų = Ungaga, Ō = Osmond
        // ^ = Next Line, ¤ = Next Dialogue Bubble. 40 symbols max per line, more than that can clip dialogue

        public static void InitializeDialogues()
        {
            //macho, gaffer, gina, laura, alnet, pike, komacho, carl, paige, renee, claude, hag, mayor
            noruneXiao[0] = "El Gato, how are you doing little buddy?^Need any food or water?";
            noruneXiao[1] = "In all my travels around Terra, I have^never seen a cat like you.¤Anyone with eyes can see that there is^something special about you Ӿ!";
            noruneXiao[2] = "Kitty, were you stuck in a bubble too?";
            noruneXiao[3] = "You´re a cute little cat! Oh no, are you^a stray? You should come live with us!";
            noruneXiao[4] = "Look at you, you are so cute^unlike those muscle freaks!";
            noruneXiao[5] = "I remember when Paige was a little girl,^her mother made her a plush cat^that looked just like you!¤Kids sure do grow up fast, people may^come and go but the memories we make^with out loved ones are eternal.¤Pretty poetic for a fisherman huh, hahaha!";
            noruneXiao[6] = "Sometimes it´s hard to be an older brother,^Macho and I may but heads but^deep down we are about each other.^Do you have any siblings kitty?";
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
            noruneGoro[6] = "So you´re a hunter from Matataki?^Do you think your so tough?^Let me tell you something, I'm strong.¤I bet you that I´m stronger than your^best hunter at Matataki mwahaha!";
            noruneGoro[7] = "Hmm, I wonder what Alnet would say^if I brought home a mallet like that.";
            noruneGoro[8] = "I heard you are from Matataki Village,^I´ve never been there but I know Auntie^Laura´s husband has traveled there¤in the past for work.^I wonder if you know him?";
            noruneGoro[9] = "Hello there, you´re another one of^Toan’s friends! Do you ever get tired^from always carrying that mallet around?";
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
            noruneGoro2[7] = "Matataki Village sounds like a weird^place, you`re telling me everyone wears^animal skins there?";
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
        }

    }
}
