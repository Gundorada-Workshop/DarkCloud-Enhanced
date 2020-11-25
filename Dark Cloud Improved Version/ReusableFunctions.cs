using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dark_Cloud_Improved_Version
{
    public class ReusableFunctions
    {
        public static float GetCurrentEquippedWhp(int characterId, int weaponslotid)
        {
            float whp = 0;

            switch (characterId)
            {
                case 0:
                    //Check on which slot is the weapon equipped on and save its Whp
                    switch (weaponslotid)
                    {
                        case 0: whp = Memory.ReadFloat(Player.Toan.WeaponSlot0.whp); break;
                        case 1: whp = Memory.ReadFloat(Player.Toan.WeaponSlot1.whp); break;
                        case 2: whp = Memory.ReadFloat(Player.Toan.WeaponSlot2.whp); break;
                        case 3: whp = Memory.ReadFloat(Player.Toan.WeaponSlot3.whp); break;
                        case 4: whp = Memory.ReadFloat(Player.Toan.WeaponSlot4.whp); break;
                        case 5: whp = Memory.ReadFloat(Player.Toan.WeaponSlot5.whp); break;
                        case 6: whp = Memory.ReadFloat(Player.Toan.WeaponSlot6.whp); break;
                        case 7: whp = Memory.ReadFloat(Player.Toan.WeaponSlot7.whp); break;
                        case 8: whp = Memory.ReadFloat(Player.Toan.WeaponSlot8.whp); break;
                        case 9: whp = Memory.ReadFloat(Player.Toan.WeaponSlot9.whp); break;
                    }
                    break;

                case 1:
                    //Check on which slot is the weapon equipped on and save its Whp
                    switch (weaponslotid)
                    {
                        case 0: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot0.whp); break;
                        case 1: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot1.whp); break;
                        case 2: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot2.whp); break;
                        case 3: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot3.whp); break;
                        case 4: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot4.whp); break;
                        case 5: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot5.whp); break;
                        case 6: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot6.whp); break;
                        case 7: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot7.whp); break;
                        case 8: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot8.whp); break;
                        case 9: whp = Memory.ReadFloat(Player.Xiao.WeaponSlot9.whp); break;
                    }
                    break;

                case 2:
                    //Check on which slot is the weapon equipped on and save its Whp
                    switch (weaponslotid)
                    {
                        case 0: whp = Memory.ReadFloat(Player.Goro.WeaponSlot0.whp); break;
                        case 1: whp = Memory.ReadFloat(Player.Goro.WeaponSlot1.whp); break;
                        case 2: whp = Memory.ReadFloat(Player.Goro.WeaponSlot2.whp); break;
                        case 3: whp = Memory.ReadFloat(Player.Goro.WeaponSlot3.whp); break;
                        case 4: whp = Memory.ReadFloat(Player.Goro.WeaponSlot4.whp); break;
                        case 5: whp = Memory.ReadFloat(Player.Goro.WeaponSlot5.whp); break;
                        case 6: whp = Memory.ReadFloat(Player.Goro.WeaponSlot6.whp); break;
                        case 7: whp = Memory.ReadFloat(Player.Goro.WeaponSlot7.whp); break;
                        case 8: whp = Memory.ReadFloat(Player.Goro.WeaponSlot8.whp); break;
                        case 9: whp = Memory.ReadFloat(Player.Goro.WeaponSlot9.whp); break;
                    }
                    break;

                case 3:
                    //Check on which slot is the weapon equipped on and save its Whp
                    switch (weaponslotid)
                    {
                        case 0: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot0.whp); break;
                        case 1: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot1.whp); break;
                        case 2: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot2.whp); break;
                        case 3: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot3.whp); break;
                        case 4: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot4.whp); break;
                        case 5: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot5.whp); break;
                        case 6: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot6.whp); break;
                        case 7: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot7.whp); break;
                        case 8: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot8.whp); break;
                        case 9: whp = Memory.ReadFloat(Player.Ruby.WeaponSlot9.whp); break;
                    }
                    break;

                case 4:
                    //Check on which slot is the weapon equipped on and save its Whp
                    switch (weaponslotid)
                    {
                        case 0: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot0.whp); break;
                        case 1: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot1.whp); break;
                        case 2: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot2.whp); break;
                        case 3: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot3.whp); break;
                        case 4: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot4.whp); break;
                        case 5: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot5.whp); break;
                        case 6: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot6.whp); break;
                        case 7: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot7.whp); break;
                        case 8: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot8.whp); break;
                        case 9: whp = Memory.ReadFloat(Player.Ungaga.WeaponSlot9.whp); break;
                    }
                    break;

                case 5:
                    //Check on which slot is the weapon equipped on and save its Whp
                    switch (weaponslotid)
                    {
                        case 0: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot0.whp); break;
                        case 1: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot1.whp); break;
                        case 2: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot2.whp); break;
                        case 3: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot3.whp); break;
                        case 4: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot4.whp); break;
                        case 5: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot5.whp); break;
                        case 6: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot6.whp); break;
                        case 7: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot7.whp); break;
                        case 8: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot8.whp); break;
                        case 9: whp = Memory.ReadFloat(Player.Osmond.WeaponSlot9.whp); break;
                    }
                    break;
            }
            return whp;
        }

        public static int[] GetEnemiesHp()
        {
            //Save every enemy's HP on the current floor
            int[] EnemiesHP = { Memory.ReadUShort(Enemies.Enemy0.hp),
                                Memory.ReadUShort(Enemies.Enemy1.hp),
                                Memory.ReadUShort(Enemies.Enemy2.hp),
                                Memory.ReadUShort(Enemies.Enemy3.hp),
                                Memory.ReadUShort(Enemies.Enemy4.hp),
                                Memory.ReadUShort(Enemies.Enemy5.hp),
                                Memory.ReadUShort(Enemies.Enemy6.hp),
                                Memory.ReadUShort(Enemies.Enemy7.hp),
                                Memory.ReadUShort(Enemies.Enemy8.hp),
                                Memory.ReadUShort(Enemies.Enemy9.hp),
                                Memory.ReadUShort(Enemies.Enemy10.hp),
                                Memory.ReadUShort(Enemies.Enemy11.hp),
                                Memory.ReadUShort(Enemies.Enemy12.hp),
                                Memory.ReadUShort(Enemies.Enemy13.hp),
                                Memory.ReadUShort(Enemies.Enemy14.hp),
                                Memory.ReadUShort(Enemies.Enemy15.hp)};

            //double average = formerEnemiesHP.Average();

            return EnemiesHP;
        }

        public static int[] GetEnemiesHit(int[] formerEnemiesHp, int[] currentEnemiesHp)
        {
            int[] enemyIds = { };

            for (int i = 0; i < formerEnemiesHp.Length; i++)
            {
                if (currentEnemiesHp[i] < formerEnemiesHp[i])
                    enemyIds.Append(i);
            }

            return enemyIds;
        }
    }
}
