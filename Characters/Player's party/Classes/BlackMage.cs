﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike_2
{
    class BlackMage : MainCharacter, IBlackMagic
    {
        public BlackMage(string name, int damage, float defence, int hp, int sp, float x, float y, int ix, int iy, int lvl, int gold, string specaction, char sym) : base (name, damage, defence, hp, sp, x, y, ix, iy, lvl, gold, specaction, sym) { }


        public void Agi(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 3 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(30f * (1f - enemy.defence));
                mage.sp -= 3; 
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }


        public void Agilao(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 10 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(40f * (1f - enemy.defence));
                mage.sp -= 10;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }
        

        public void Agidyne(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 15 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(50f * (1f - enemy.defence));
                mage.sp -= 15;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }




        public void Bufu(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 3 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(30f * (1f - enemy.defence));
                mage.sp -= 3;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }


        public void Bufula(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 10 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(40f * (1f - enemy.defence));
                mage.sp -= 10;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }


        public void Bufudyne(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 15 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(50f * (1f - enemy.defence));
                mage.sp -= 15;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }




        public void Garu(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 3 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(30f * (1f - enemy.defence));
                mage.sp -= 3;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }


        public void Garula(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 10 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(40f * (1f - enemy.defence));
                mage.sp -= 10;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }


        public void Garudyne(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 15 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(50f * (1f - enemy.defence));
                mage.sp -= 15;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }




        public void Zio(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 3 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(30f * (1f - enemy.defence));
                mage.sp -= 3;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }


        public void Zionga(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 10 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(40f * (1f - enemy.defence));
                mage.sp -= 10;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }


        public void Ziodyne(Enemy enemy, BlackMage mage, byte hit)
        {
            if (mage.sp >= 15 && hit > 3)
            {
                enemy.hp -= Convert.ToInt32(50f * (1f - enemy.defence));
                mage.sp -= 15;
            }
            else
            {
                Console.SetCursorPosition(10, 32);
                Console.WriteLine("У вас ничего не получилось");
                Thread.Sleep(400);
            }
        }

    }
}
