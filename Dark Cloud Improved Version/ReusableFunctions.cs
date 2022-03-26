using System;
using System.Collections.Generic;
using System.Threading;

namespace Dark_Cloud_Improved_Version
{
    public class ReusableFunctions
    {
        /// <summary>
        /// Puts the current thread to sleep while the game is paused
        /// <br></br>
        /// 0 = Town <br></br>
        /// 1 = Dungeon
        /// </summary>
        /// <param name="mode">0 = Town<br></br>1 = Dungeon</param>
        /// <returns>Returns true when the game is no longer paused</returns>
        public static bool AwaitUnpause(byte mode) {

            bool gameIsPaused;

            while (gameIsPaused = (mode == 0) ? Player.CheckTownIsPaused() : Player.CheckDunIsPaused())
            {
                Thread.Sleep(100);
                continue;
            }

            return true;
        }

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
                                Memory.ReadUShort(Enemies.Enemy15.hp)
            };

            return EnemiesHP;
        }

        public static float[] GetEnemiesDistance()
        {

            //Save every current distance
            float[] distance = { Memory.ReadFloat(Enemies.Enemy0.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy1.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy2.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy3.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy4.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy5.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy6.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy7.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy8.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy9.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy10.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy11.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy12.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy13.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy14.distanceToPlayer),
                                Memory.ReadFloat(Enemies.Enemy15.distanceToPlayer),

            };

            return distance;
        }

        public static List<int> GetEnemiesHitIds(int[] formerEnemiesHp, int[] currentEnemiesHp)
        {
            //Create a list to store the IDs
            List<int> enemyIds = new List<int>();

            //Cycle through enemies HP array
            for (int i = 0; i < formerEnemiesHp.Length; i++)
            {
                //Check for which enemies were damaged
                if (currentEnemiesHp[i] < formerEnemiesHp[i])
                {
                    //Add the iterator to the list we created early as an ID for the damaged enemy
                    enemyIds.Add(i);
                }
            }

            return enemyIds;
        }

        public static List<int> GetEnemiesKilledIds(int[] formerEnemiesHp, int[] currentEnemiesHp)
        {
            //Create a list to store the IDs
            List<int> enemyKilled = new List<int>();

            //Fetch the enemies hit to check if they were killed
            List<int> enemiesHit = GetEnemiesHitIds(formerEnemiesHp, currentEnemiesHp);

            //Go through the enemies hit list and store the ones who died
            foreach (int enemy in enemiesHit)
            {
                switch (enemy)
                {
                    case 0: if (Memory.ReadUShort(Enemies.Enemy0.hp) == 0) enemyKilled.Add(enemy); break;
                    case 1: if (Memory.ReadUShort(Enemies.Enemy1.hp) == 0) enemyKilled.Add(enemy); break;
                    case 2: if (Memory.ReadUShort(Enemies.Enemy2.hp) == 0) enemyKilled.Add(enemy); break;
                    case 3: if (Memory.ReadUShort(Enemies.Enemy3.hp) == 0) enemyKilled.Add(enemy); break;
                    case 4: if (Memory.ReadUShort(Enemies.Enemy4.hp) == 0) enemyKilled.Add(enemy); break;
                    case 5: if (Memory.ReadUShort(Enemies.Enemy5.hp) == 0) enemyKilled.Add(enemy); break;
                    case 6: if (Memory.ReadUShort(Enemies.Enemy6.hp) == 0) enemyKilled.Add(enemy); break;
                    case 7: if (Memory.ReadUShort(Enemies.Enemy7.hp) == 0) enemyKilled.Add(enemy); break;
                    case 8: if (Memory.ReadUShort(Enemies.Enemy8.hp) == 0) enemyKilled.Add(enemy); break;
                    case 9: if (Memory.ReadUShort(Enemies.Enemy9.hp) == 0) enemyKilled.Add(enemy); break;
                    case 10: if (Memory.ReadUShort(Enemies.Enemy10.hp) == 0) enemyKilled.Add(enemy); break;
                    case 11: if (Memory.ReadUShort(Enemies.Enemy11.hp) == 0) enemyKilled.Add(enemy); break;
                    case 12: if (Memory.ReadUShort(Enemies.Enemy12.hp) == 0) enemyKilled.Add(enemy); break;
                    case 13: if (Memory.ReadUShort(Enemies.Enemy13.hp) == 0) enemyKilled.Add(enemy); break;
                    case 14: if (Memory.ReadUShort(Enemies.Enemy14.hp) == 0) enemyKilled.Add(enemy); break;
                    case 15: if (Memory.ReadUShort(Enemies.Enemy15.hp) == 0) enemyKilled.Add(enemy); break;
                    default: break;
                }
            }

            return enemyKilled;
        }

        /// <summary>
        /// Returns the last damage value the player has dealt
        /// </summary>
        /// <returns></returns>
        public static int GetRecentDamageDealtByPlayer()
        {
            int damage = Memory.ReadInt(Player.mostRecentDamage);
            return damage;
        }

        public static int GetDamageSourceCharacterID()
        {
            int character = Memory.ReadInt(Player.damageSource);
            return character;
        }

        public static void ClearRecentDamageAndDamageSource()
        {
            Memory.WriteInt(Player.mostRecentDamage, -1);
            Memory.WriteInt(Player.damageSource, -1);
        }
    }
}