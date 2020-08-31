using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Dark_Cloud_Improved_Version
{
    internal class CheatCodes
    {
        internal class InputBuffer
        {
            [Flags]
            public enum Button
            {
                None        = 0b_0000000000000000,
                L2          = 0b_0000000000000001,
                R2          = 0b_0000000000000010,
                L1          = 0b_0000000000000100,
                R1          = 0b_0000000000001000,
                Triangle    = 0b_0000000000010000,
                Circle      = 0b_0000000000100000,
                Cross       = 0b_0000000001000000,
                Square      = 0b_0000000010000000,
                Select      = 0b_0000000100000000,
                L3          = 0b_0000001000000000,
                R3          = 0b_0000010000000000,
                Start       = 0b_0000100000000000,
                DPad_Up     = 0b_0001000000000000,
                DPad_Right  = 0b_0010000000000000,
                DPad_Down   = 0b_0100000000000000,
                DPad_Left   = 0b_1000000000000000,
                All         = 0b_1111111111111111
            }

            public static int index = 0;
            public static Button[] inputBuffer = new Button[10];
            public readonly Button[] empty = new Button[] {Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None, Button.None};
            public static Button[] cheatGodmode = new Button[] { Button.DPad_Up, Button.DPad_Up, Button.DPad_Down, Button.DPad_Down, Button.DPad_Left, Button.DPad_Right, Button.DPad_Left, Button.DPad_Right, Button.Square, Button.Cross };

            internal static void Monitor()
            {
               while (1 == 1)
                {
                    Thread.Sleep(250);

                    if (Memory.ReadUShort(Addresses.buttonInputs) != 0) //If button input detected
                        Add((Button)Memory.ReadUShort(Addresses.buttonInputs)); //Add our button to the buffer

                    if(CheckSequence(cheatGodmode))
                    {
                        toggleGodMode(true);
                    }

                    Button softResetList = Button.L1 | Button.L2 | Button.R1 | Button.R2 | Button.Select | Button.Start; //All at once

                    if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)softResetList)  //If L1+L2+R1+R2+Select+Start is pressed, return to main menu
                    {
                        Thread.Sleep(2000); //Wait two seconds
                        if (Memory.ReadUShort(Addresses.buttonInputs) == (ushort)softResetList)  //Check again
                        {
                            if (Player.InDungeonFloor() == true)
                                Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                            else
                                Memory.WriteByte(Addresses.mode, 1);
                        }
                    }
                }
            }

            public static void Add(Button button)
            {
                inputBuffer[index] = button;

                Console.WriteLine("Button: " + button + " added to inputBuffer at index: " + index);

                if (index < inputBuffer.Length - 1)
                {
                    index++;
                }

                else
                {
                    index = 0;
                }
            }

            public static bool CheckSequence(Button[] cheatCodeArray)
            {
                Button[] tmp = { };

                for (int i = 0; i < cheatCodeArray.Length - 1; i++)
                {
                    if (inputBuffer.SequenceEqual(tmp)) //Matched sequence
                    {
                        for (int bufferIndex = 0; bufferIndex < inputBuffer.Length; bufferIndex++) //Loop through our buffer
                        {
                            inputBuffer[i] = Button.None; //Clear it
                        }
                        return true;
                    }
                    tmp = ShiftElements(cheatCodeArray, i);
                }

                return false;
            }

            private static void toggleGodMode(bool toggle)
            {
                if (toggle == true)
                {
                    Console.WriteLine("God mode activated");
                    Dayuppy.DisplayMessage("^BCheat Activated: God Mode");
                    Memory.WriteByte(Player.Ultraman, 2);
                }

                else
                {
                    Console.WriteLine("God mode de-activated");
                    Dayuppy.DisplayMessage("^RCheat De-Activated: God Mode");
                    Memory.WriteByte(Player.Ultraman, 0);
                }
            }

            private static Button[] ShiftElements(Button[] cheatCodeArray, int amount)
            {
                Button[] tmp = new Button [cheatCodeArray.Length];

                for (int i = 0; i < cheatCodeArray.Length; i++)
                {
                    tmp[(i + amount) % tmp.Length] = cheatCodeArray[i]; //I don't understand how this line works, but it does.
                }

                return tmp;
            }
        }
    }
}
