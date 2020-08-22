using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    class Dayuppy
    {
        private static Thread elementSwapThread = new Thread(new ThreadStart(ElementSwapping)); //Create a new thread to run monitorElementSwapping()
        private static byte[] originalDunMessage = Memory.ReadByteArray(Addresses.dunMessage10, 158); //Read 158 bytes of byte array that stores dungeon message 10

        private static void ElementSwapping()
        {
            string[] elementName = new string[6];

            elementName[0] = "Fire";
            elementName[1] = "Ice";
            elementName[2] = "Thunder";
            elementName[3] = "Wind";
            elementName[4] = "Holy";
            elementName[5] = "None";

            byte elementSelected;

            while (1 == 1)
            {
                int currentCharacter = Player.CurrentCharacterNum();
                byte currentWeaponSlot;

                if (Memory.ReadUShort(Addresses.buttonInputs) == 4096 && Player.InDungeonFloor() == true && Memory.ReadUInt(Addresses.dungeonDebugMenu) == 0)  //If DPadUp and in dungeon, go to previous element
                {
                    switch (currentCharacter)
                    {
                        case 0:
                            currentWeaponSlot = Memory.ReadByte(Player.Toan.currentWeaponSlot);

                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Toan.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 1:
                            currentWeaponSlot = Memory.ReadByte(Player.Xiao.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 2:
                            currentWeaponSlot = Memory.ReadByte(Player.Goro.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Goro.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 3:
                            currentWeaponSlot = Memory.ReadByte(Player.Ruby.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 4:
                            currentWeaponSlot = Memory.ReadByte(Player.Ungaga.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 5:
                            currentWeaponSlot = Memory.ReadByte(Player.Osmond.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot0.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot1.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot2.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot3.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot4.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot5.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot6.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot7.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot8.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot9.elementHUD);

                                    if (elementSelected > 0)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;
                    }
                }

                if ((Memory.ReadUShort(Addresses.buttonInputs) == 16384 && Player.InDungeonFloor() == true && Memory.ReadUInt(Addresses.dungeonDebugMenu) == 0))  //If DPadDOWN, go to next element
                {
                    switch (currentCharacter)
                    {
                        case 0:
                            currentWeaponSlot = Memory.ReadByte(Player.Toan.currentWeaponSlot);

                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Toan.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Toan.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 1:
                            currentWeaponSlot = Memory.ReadByte(Player.Xiao.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Xiao.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Xiao.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 2:
                            currentWeaponSlot = Memory.ReadByte(Player.Goro.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Goro.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Goro.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 3:
                            currentWeaponSlot = Memory.ReadByte(Player.Ruby.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ruby.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ruby.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 4:
                            currentWeaponSlot = Memory.ReadByte(Player.Ungaga.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Ungaga.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Ungaga.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;

                        case 5:
                            currentWeaponSlot = Memory.ReadByte(Player.Osmond.currentWeaponSlot);
                            switch (currentWeaponSlot)
                            {
                                case 0:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot0.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot0.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 1:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot1.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot1.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 2:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot2.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot2.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 3:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot3.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot3.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 4:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot4.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot4.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 5:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot5.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot5.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 6:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot6.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot6.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 7:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot7.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot7.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 8:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot8.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected++;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot8.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;

                                case 9:
                                    elementSelected = Memory.ReadByte(Player.Osmond.WeaponSlot9.elementHUD);

                                    if (elementSelected < 5)
                                    {
                                        elementSelected--;
                                        Memory.WriteByte(Player.Osmond.WeaponSlot9.elementHUD, elementSelected); //Set element in HUD for weapon
                                        Memory.WriteUShort(Player.elementActual, elementSelected); //Set element 
                                        displayMessage("Changed current active weapon attribute to   \n" + elementName[elementSelected] + "                         \n                          ");
                                    }

                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private static byte[] displayMessage(string message)
        {
            byte[] customMessage = Encoding.GetEncoding(10000).GetBytes(message);
            byte[] outputMessage = new byte[customMessage.Length * 2];

            decimal maxNumLines = customMessage.Length / 28;

            System.Math.Ceiling(maxNumLines);

            Console.WriteLine();
            Console.WriteLine("maxNumLines: " + maxNumLines);
            Console.WriteLine();
            Console.WriteLine("Custom  Message: " + BitConverter.ToString(customMessage));
            Console.WriteLine();
            Console.WriteLine("Dungeon Message: " + BitConverter.ToString(originalDunMessage));

            byte[] normalCharTable =
            {0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, //A-Z

            0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
            0x70, 0x71, 0x72, 0x73, 0x74 ,0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, //a-z

            //SPC
            0x20,
            
            //.    $      ?    !      %     &   \n
            0x2E, 0x24, 0x3F, 0x21, 0x25, 0x26, 0x0A

            };

            byte[] dcCharTable =
            {0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, //A-Z
            
            0x3B, 0x3C, 0x3D, 0x3E, 0x3F, 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49,
            0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, //a-z

            //SPC
            0x02,

            //.    $    ?     !    %     &        \n
            0x6D, 0x6E, 0x59, 0x58, 0x60,  0x5B, 0x00
            
            };

            for (int i = 0; i < outputMessage.Length; i++)
            {
                outputMessage[i] = 0xFD;  //Initialize outputMessage to 0xFD
            }

            for (int i = 0; i < customMessage.Length; i++)
            {
                for (int t = 0; t < dcCharTable.Length; t++)
                {
                    if (customMessage[i] == normalCharTable[t])
                    {
                        if (normalCharTable[t] == 0x0A) //newLine
                        {
                            outputMessage[i * 2] = 0x00;
                            outputMessage[i * 2 + 1] = 0xFF;
                            Console.WriteLine("New line detected.");
                        }

                        else if (normalCharTable[t] == 0x20) //SPC
                        {
                            outputMessage[i * 2] = 0x02;
                            outputMessage[i * 2 + 1] = 0xFF;
                        }

                        else
                            outputMessage[i * 2] = dcCharTable[t];
                    }
                }
            }
            Console.WriteLine(BitConverter.ToString(outputMessage));

            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            Memory.WriteByteArray(Addresses.dunMessage10, outputMessage);
            Thread.Sleep(50);
            Memory.WriteInt(Addresses.dunMessage, 10); //Display the 10th dungeon message
            Thread.Sleep(2000); //Wait two seconds
            Memory.WriteUInt(Addresses.dunMessage, 4294967295); //Display nothing
            Memory.WriteByteArray(Addresses.dunMessage10, originalDunMessage); //Revert message back to default

            return outputMessage;
        }

        public static void CallGameFunction(byte[] function) // functionBGMStop
        {
            Console.WriteLine("Function address to write: {0:X}", Addresses.functionEntryPoint);
            Console.WriteLine("Current Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));
            Console.WriteLine("Function to write: " + BitConverter.ToString(Addresses.functionOverride));
            Console.WriteLine("Attempting to write function value. ");

            byte[] function2OriginalOpcode = Memory.ReadByteArray(Addresses.functionEntryPoint2, 4);

            Memory.WriteByteArray(Addresses.functionEntryPoint, Addresses.functionOverride);
            Memory.WriteByteArray(Addresses.functionEntryPoint2, function); 
        }

        public static void Testing()
        {
            if (!elementSwapThread.IsAlive) //If we are not already running
                elementSwapThread.Start(); //Start thread

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            bool godMode = false;

            int textureAddress1 = 0x20429F10;
            int textureAddress2 = 0x2043A350;
            //int textureAddress3 = 0x2044A790;

            byte[] testImage = new byte[] { 0x00 };
            byte[] modifiedTexture1 = new byte[] { 0x00 };
            byte[] modifiedTexture2 = new byte[] { 0x00 };

            if (FileSystem.FileExists("20429f10.tm2"))
            {
                testImage = FileSystem.ReadAllBytes("test.tm2");
            }

            if (FileSystem.FileExists("20429f10.tm2"))
            {
                modifiedTexture1 = FileSystem.ReadAllBytes("20429f10.tm2");
                modifiedTexture2 = FileSystem.ReadAllBytes("20429f10.tm2");
                //modifiedTexture3 = FileSystem.ReadAllBytes("20429f10.tm2");
            }


            CallGameFunction(Addresses.functionBGMStop);
            Console.WriteLine("New Function value: " + BitConverter.ToString(Memory.ReadByteArray(Addresses.functionEntryPoint, 4)));


            while (1 == 1)
            {
                int currentCharacter = Memory.ReadInt(Player.currentCharacter); //Read 4 bytes of currentCharacter value and check if Toan, Xiao, etc. Toan = 1680945251, Xiao = 1647587427

                if (Memory.ReadUInt(Addresses.dungeonClear) == 4294967281)
                {
                    Memory.WriteUInt(Addresses.dunMessage, 10); //Display dungeon leave message
                    Memory.WriteUInt(Addresses.dungeonClear, 0); //Change this value so that the message doesn't get written forever
                }

                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10); //Format the TimeSpan value.
                //Console.WriteLine("RunTime " + elapsedTime);

                if (Memory.ReadUShort(Addresses.buttonInputs) == 2319)  //If L1+L2+R1+R2+Select+Start is pressed, return to main menu
                {
                    Thread.Sleep(2000); //Wait two seconds
                    if ((Memory.ReadUShort(Addresses.buttonInputs) == 2319))  //Check again
                    {
                        if (Player.InDungeonFloor() == true)
                            Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                        else
                            Memory.WriteInt(Addresses.townSoftReset, 1); //If we are in town, this will take us to the main menu
                    }
                }

                if (Memory.ReadUShort(Addresses.buttonInputs) == 4111)  //If L1+L2+R1+R2+DpadUp is pressed, activate godmode
                {
                    Thread.Sleep(2000); //Wait two seconds
                    if (Memory.ReadUShort(Addresses.buttonInputs) == 4111)  //Check again
                    {
                        if (Player.InDungeonFloor() == true)
                        {
                            if (godMode == true)
                            {
                                godMode = false;
                                Memory.WriteByteArray(Addresses.dunMessage10, displayMessage("God Mode deactivated.             \n                    \nYou are no longer invincible to enemy damage."));
                            }

                            else if (godMode == false)
                            {
                                godMode = true;
                                displayMessage("God Mode activated.             \n                          \nYou are now invincible to enemy damage.      ");
                            }           
                        }
                    }
                }

                if (godMode == true)
                {
                    Thread.Sleep(50);
                    if (Player.InDungeonFloor() == false) //We left the dungeon
                        godMode = false; //Disable god mode.

                    if (currentCharacter == 1680945251) //Toan
                    {
                        Memory.WriteUShort(Player.Toan.hp, Memory.ReadUShort(Player.Toan.maxHP)); //Set Toan's HP to match max HP
                    }
                    else if (currentCharacter == 1647587427) //Xiao
                    {
                        Memory.WriteUShort(Player.Xiao.hp, Memory.ReadUShort(Player.Xiao.maxHP)); //Set Xiaos's HP to match max HP
                    }
                }

                if (Player.CurrentCharacterNum() == 2) //If Xiao
                {
                    Memory.WriteByteArray(textureAddress1, modifiedTexture1);
                    Memory.WriteByteArray(textureAddress2, modifiedTexture2);
                    ///Memory.WriteByteArray(textureAddress3, modifiedTexture3);
                }

                //Console.WriteLine("Input: " + Memory.ReadUShort(Addresses.buttonInputs));
                //Thread.Sleep(10); //10ms
                //Console.Clear();
            }
            //Form1.dayThread.Abort();
            //elementSwapThread.Abort();
            //stopWatch.Stop();
        }
    }
}
