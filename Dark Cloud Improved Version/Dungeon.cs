using System;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    internal class Dungeon
    {
        public const uint MagicCircleOne_PosX = 0x21DE61C0;
        public const uint MagicCircleOne_PosY = 0x21DE61C8;
        public const uint MagicCircleTwo_PosX = 0x21DE61E0;
        public const uint MagicCircleTwo_PosY = 0x21DE61E8;
        public const uint MagicCircleThree_PosX = 0x21DE61E0;
        public const uint MagicCircleThree_PosY = 0x21DE61E8;
        
    }

    public class DungeonThread
    {
        public static void WeaponsCustomEffects()
        {

            while (true)
            {
                if (Player.InDungeonFloor())
                {
                    switch (Player.CurrentCharacterNum())
                    {
                        //Toan
                        case 0:
                            break;

                        //Xiao
                        case 1:
                            if (Player.GetCurrentWeaponId() == 307) // Dragon's Y ID
                            {
                                CustomEffects.DragonsY();
                            }
                            break;

                        //Goro
                        case 2:
                            break;

                        //Ruby
                        case 3:
                            if (Player.GetCurrentWeaponId() == 341) //Mobius Ring ID
                            {
                                CustomEffects.MobiusRing();
                            }
                            break;

                        //Ungaga
                        case 4:
                            if (Player.GetCurrentWeaponId() == 356) //Hercules Wrath ID
                            {
                                CustomEffects.HerculesWrath();
                            }

                            if (Player.GetCurrentWeaponId() == 357) //Babel Spear ID
                            {
                                CustomEffects.BabelSpear();
                            }
                            break;

                        //Osmond
                        case 5:
                            if (Player.GetCurrentWeaponId() == 373) //Supernova ID
                            {
                                CustomEffects.Supernova();
                            }
                            break;
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}