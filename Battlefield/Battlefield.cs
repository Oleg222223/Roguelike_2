﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roguelike_2
{
    class Battlefield  //класс, отвечающий за отображение поля боя
    {
        public static void Pole(Knight knight, Thieve thieve, BlackMage blmage, WhiteMage whmage, Enemy[] enemy)
        {
            byte turn = 1;                              //переменная которая фиксирует чей сейчас ход
            byte coordinates;                           //хранит координаты курсора при выборе действия


            do
            {
                Console.Clear();                        //очищает консоль от лишних символов
                for (int i = 0; i < 4; i++)             //генерирует врагов на арене
                {
                    Person(enemy[i].x, enemy[i].y, enemy[i].ix, enemy[i].iy, enemy[i].battlesym); 
                }
                
                switch (turn)                            //позволяет выдвинуть вперед персонажа, который совершает ход
                {
                    case (1):
                        Person(knight.x -5, knight.y, knight.ix, knight.iy, knight.battlesym);                  //отображение первого персонажа
                        Person(thieve.x, thieve.y, thieve.ix, thieve.iy, thieve.battlesym);
                        Person(blmage.x, blmage.y, blmage.ix, blmage.iy, blmage.battlesym);
                        Person(whmage.x, whmage.y, whmage.ix, whmage.iy, whmage.battlesym);
                        break;
                    case (2):
                        Person(knight.x, knight.y, knight.ix, knight.iy, knight.battlesym);
                        Person(thieve.x -5, thieve.y, thieve.ix, thieve.iy, thieve.battlesym);                  //отображение второго персонажа
                        Person(blmage.x, blmage.y, blmage.ix, blmage.iy, blmage.battlesym);
                        Person(whmage.x, whmage.y, whmage.ix, whmage.iy, whmage.battlesym);
                        break;
                    case (3):
                        Person(knight.x, knight.y, knight.ix, knight.iy, knight.battlesym);
                        Person(thieve.x, thieve.y, thieve.ix, thieve.iy, thieve.battlesym);
                        Person(blmage.x - 5, blmage.y, blmage.ix, blmage.iy, blmage.battlesym);                  //отображение третьего персонажа
                        Person(whmage.x, whmage.y, whmage.ix, whmage.iy, whmage.battlesym);
                        break;
                    case (4):
                        Person(knight.x, knight.y, knight.ix, knight.iy, knight.battlesym);
                        Person(thieve.x, thieve.y, thieve.ix, thieve.iy, thieve.battlesym);
                        Person(blmage.x, blmage.y, blmage.ix, blmage.iy, blmage.battlesym);
                        Person(whmage.x - 5, whmage.y, whmage.ix, whmage.iy, whmage.battlesym);                  //отображение четрвертого персонажа
                        break;
                    default: break;
                }


                Interface(knight, thieve, blmage, whmage);          //отрисовывает показатели персонажей

                Helping(100, 18, "1. Атака");                  //отображает действия, которые может выбрать игрок
                Helping(100, 19, "2. Защита");
                switch (turn)                               //это часть у каждого персонажа разная
                {
                    case (1): Helping(100, 20,"3. " + knight.specaction); break;
                    case (2): Helping(100, 20,"3. " + thieve.specaction); break;
                    case (3): Helping(100, 20,"3. " + blmage.specaction); break;
                    case (4): Helping(100, 20,"3. " + whmage.specaction); break;
                    default: break;
                }
                Helping(100, 21, "4. Предмет");
                Helping(100, 22, "5. Побег");
                Helping(100, 23, "Выберите действие: ");
                coordinates = Convert.ToByte(Console.ReadLine());            
                switch (coordinates)                                    //выполняет действие, которое выбрал игрок
                {
                    case (1):                                          //атака персонажа
                        switch(turn)                                    //какой именно персонаж атакует
                        {
                            case (1):
                                Attak(knight, ref enemy);
                                break;
                            case (2):
                                Attak(thieve, ref enemy);
                                break;
                            case (3):
                                Attak(blmage, ref enemy);
                                break;
                            case (4):
                                Attak(whmage, ref enemy);
                                break;
                        }
                        break;
                    case (2):                               //увеличение защиты у персонажа
                        switch (turn)                       //какой именно персонаж
                        {
                            case (1):
                                knight.defence += 0.25f;
                                break;
                            case (2):
                                thieve.defence += 0.25f;
                                break;
                            case (3):
                                blmage.defence += 0.25f;
                                break;
                            case (4):
                                whmage.defence += 0.25f;
                                break;
                        }
                        break;
                    case (3):                                   //особое действие персонажа
                        switch (turn)                    
                        {
                            case (1):                           //увеличение урона вдвое
                                knight.damage *= 2;
                                break;
                            case (2):                           //воровство предмета

                                break;
                            case (3):                           //черная магия
                                BlackMagic(blmage, ref enemy);
                                break;
                            case (4):                           //белая магия
                                WhiteMagic(knight, thieve, blmage, whmage);
                                break;
                        }
                        break;
                    case (4):                                   //использование предмета
                        switch (turn)                    
                        {
                            case (1):

                                break;
                            case (2):

                                break;
                            case (3):

                                break;
                            case (4):

                                break;
                        }
                        break;
                    case (5):                                   //попытка сбежать с поля боя
                        switch (turn)                    
                        {
                            case (1):

                                break;
                            case (2):

                                break;
                            case (3):

                                break;
                            case (4):

                                break;
                        }
                        break;

                }
                for (int i = 0; i < 4; i++)                 //отображает мертывых противников
                {
                    if (enemy[i].hp <= 0)
                    {
                        enemy[i].battlesym = '+';
                    }
                    else if (turn == 4)                     //обновляет ходы персонажей
                    {
                        turn = 0;
                    }
                }
                turn++;
            } while (turn != 5);

        }



        private static void Helping(int x, int y, string action)        //помогает отображать дейстия, которые может выполнить игрок
        {
            Console.SetCursorPosition(x, y);
            Console.Write(action);
        }
        


        private static void Person(float x, float y, int ix, int iy, char sym)      //Помогает отображать персонажа на экране
        {
            for (int i = 0; i < ix; i++)
            {
                for (int j = 0; j < iy; j++)
                {
                    Console.SetCursorPosition(Convert.ToInt32(x) + i, Convert.ToInt32(y) + j);
                    Console.Write(sym);  
                }
            }
        }



        //private static byte CursorChoise(byte x, byte y, byte a, byte b)          //отображает курсор возле действия игрока
        //{
        //    ConsoleKey cursor;
        //    Console.SetCursorPosition(x, y);
        //    do
        //    {
        //        cursor = Console.ReadKey().Key;
        //        if (cursor == ConsoleKey.UpArrow && y > a)
        //            Console.SetCursorPosition(x, y--);
        //        else
        //            Console.SetCursorPosition(120, y);
        //        if (cursor == ConsoleKey.DownArrow && y < b)
        //            Console.SetCursorPosition(x, y++);
        //        else
        //            Console.SetCursorPosition(x, y);
        //    } while (cursor != ConsoleKey.Enter);
        //    return y;
        //}



        private static void Attak(MainCharacter hero, ref Enemy[] enemy)       //воспроизводит анимацию атаки и саму атаку
        {
            byte which_enemy;
            Console.SetCursorPosition(100, 24);
            Console.Write("Введите номер противника, которого вы хотите ударить: ");
            which_enemy = Convert.ToByte(Console.ReadLine());
            switch (which_enemy)
            {
                case (1):
                    enemy[0].hp -= hero.damage;
                    break;
                case (2):
                    enemy[1].hp -= hero.damage;
                    break;
                case (3):
                    enemy[2].hp -= hero.damage;
                    break;
                case (4):
                    enemy[3].hp -= hero.damage;
                    break;
            }
            Console.SetCursorPosition(Convert.ToInt32(hero.x) - 6, Convert.ToInt32(hero.y + 1));
            Thread.Sleep(250);
            Console.Write("-");
            Console.SetCursorPosition(Convert.ToInt32(hero.x) - 7, Convert.ToInt32(hero.y + 1));
            Thread.Sleep(250);
            Console.Write("-");
            Console.SetCursorPosition(Convert.ToInt32(hero.x) - 8, Convert.ToInt32(hero.y + 1));
            Thread.Sleep(250);
            Console.Write("-");
        }



        private static void BlackMagic(BlackMage hero, ref Enemy[] enemy)       //отвечает за воспроизводство черной магии
        {
            byte cursor;
            byte which_enemy;
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("Выберите заклинание:");
            if (hero.lvl <= 5)                                  //проверяет уровень героя
            {                                                   //с первого по пятый уровень отображаются заклинания первого уровня
                Helping(10, 26, "1. Agi");                         //заклинание огня 
                Helping(10, 27, "2. Bufu");                        //заклинание льда 
                Helping(10, 28, "3. Garu");                        //заклинание ветра 
                Helping(10, 29, "4. Zio");                         //заклинание электричества 
                Console.SetCursorPosition(10, 30);
                Console.Write("Введите номер заклинания, которое вы хотите использовать: ");
                cursor = Convert.ToByte(Console.ReadLine());
                Console.SetCursorPosition(10, 31);
                Console.Write("Введите номер противника, которого вы хотите поразить заклинанием: ");
                which_enemy = Convert.ToByte(Console.ReadLine());
                switch (cursor)
                {
                    case (1):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Agi(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Agi(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Agi(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Agi(enemy[3], hero);
                                break;
                        }
                        break;
                    case (2):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Bufu(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Bufu(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Bufu(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Bufu(enemy[3], hero);
                                break;
                        }
                        break;
                    case (3):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Garu(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Garu(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Garu(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Garu(enemy[3], hero);
                                break;
                        }
                        break;
                    case (4):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Zio(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Zio(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Zio(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Zio(enemy[3], hero);
                                break;
                        }
                        break;
                }
            }
            if (hero.lvl > 5 && hero.lvl <= 10)
            {
                Helping(10, 26, "1. Agilao");                       //заклинание огня второго уровня
                Helping(10, 27, "2. Bufula");                       //заклинание льда второго уровня
                Helping(10, 28, "3. Garula");                       //заклинание ветра второго уровня
                Helping(10, 29, "4. Zionga");                       //заклинание молнии второго уровня
                Console.SetCursorPosition(10, 30);
                Console.Write("Введите номер заклинания, которое вы хотите использовать: ");
                cursor = Convert.ToByte(Console.ReadLine());
                Console.SetCursorPosition(10, 31);
                Console.Write("Введите номер противника, которого вы хотите поразить заклинанием: ");
                which_enemy = Convert.ToByte(Console.ReadLine());
                switch (cursor)
                {
                    case (26):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Agilao(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Agilao(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Agilao(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Agilao(enemy[3], hero);
                                break;
                        }
                        break;
                    case (27):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Bufula(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Bufula(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Bufula(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Bufula(enemy[3], hero);
                                break;
                        }
                        break;
                    case (28):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Garula(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Garula(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Garula(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Garula(enemy[3], hero);
                                break;
                        }
                        break;
                    case (29):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Zionga(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Zionga(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Zionga(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Zionga(enemy[3], hero);
                                break;
                        }
                        break;
                }
            }
            if (hero.lvl > 10)
            {
                Helping(10, 26, "1. Agidyne");                      //заклинание огня третьего уровня
                Helping(10, 27, "2. Bufudyne");                     //заклинание льда третьего уровня
                Helping(10, 28, "3. Garudyne");                     //заклинание ветра третьего уровня
                Helping(10, 29, "4. Ziodyne");                      //заклинание молнии третьего уровня
                Console.SetCursorPosition(10, 30);
                Console.Write("Введите номер заклинания, которое вы хотите использовать: ");
                cursor = Convert.ToByte(Console.ReadLine());
                Console.SetCursorPosition(10, 31);
                Console.Write("Введите номер противника, которого вы хотите поразить заклинанием: ");
                which_enemy = Convert.ToByte(Console.ReadLine());
                switch (cursor)
                {
                    case (26):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Agidyne(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Agidyne(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Agidyne(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Agidyne(enemy[3], hero);
                                break;
                        }
                        break;
                    case (27):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Bufudyne(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Bufudyne(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Bufudyne(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Bufudyne(enemy[3], hero);
                                break;
                        }
                        break;
                    case (28):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Garudyne(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Garudyne(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Garudyne(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Garudyne(enemy[3], hero);
                                break;
                        }
                        break;
                    case (29):
                        switch (which_enemy)
                        {
                            case (1):
                                Magic_Animatoin(enemy[0]);
                                hero.Ziodyne(enemy[0], hero);
                                break;
                            case (2):
                                Magic_Animatoin(enemy[1]);
                                hero.Ziodyne(enemy[1], hero);
                                break;
                            case (3):
                                Magic_Animatoin(enemy[2]);
                                hero.Ziodyne(enemy[2], hero);
                                break;
                            case (4):
                                Magic_Animatoin(enemy[3]);
                                hero.Ziodyne(enemy[3], hero);
                                break;
                        }
                        break;
                }
            }
        }



        private static void Magic_Animatoin(Enemy enemy)                        //отвечает за анимацию заклинаний черной магии
        {
            Console.SetCursorPosition(Convert.ToInt32(enemy.x) + 3, Convert.ToInt32(enemy.y) + 3);
            Console.WriteLine("* *");
            Thread.Sleep(200);
            Console.SetCursorPosition(Convert.ToInt32(enemy.x) + 4, Convert.ToInt32(enemy.y) + 2);
            Console.WriteLine("*");
            Thread.Sleep(200);
            Console.SetCursorPosition(Convert.ToInt32(enemy.x) + 3, Convert.ToInt32(enemy.y) + 1);
            Console.WriteLine("***");
            Thread.Sleep(200);
            Console.SetCursorPosition(Convert.ToInt32(enemy.x) + 4, Convert.ToInt32(enemy.y));
            Console.WriteLine("*");
            Thread.Sleep(200);
            Console.SetCursorPosition(Convert.ToInt32(enemy.x) + 3, Convert.ToInt32(enemy.y) - 1);
            Console.WriteLine("* *");
            Thread.Sleep(200);
        }           



        private static void WhiteMagic(MainCharacter knight, MainCharacter thieve, MainCharacter blmage, WhiteMage whmage)      //отвечает за воспроизводство белой магии
        {
            short a;
            short b;
            Console.SetCursorPosition(10, 25);
            Console.WriteLine("Выберите заклинание:");
            if(whmage.lvl <= 5)
            {
                Helping(10, 26, "1 Dia");
                Console.SetCursorPosition(10, 27);
                Console.Write("Введите номер заклинания. Ваш выбор: ");
                a = Convert.ToInt16(Console.ReadLine());
                switch (a)
                {
                    case (1):
                        Console.SetCursorPosition(20, 27);
                        Console.WriteLine("Выберите союзника, на котором вы хотите применить заклинание:");
                        Console.SetCursorPosition(20, 28);
                        Console.WriteLine("1 " + knight.name);
                        Console.SetCursorPosition(20, 29);
                        Console.WriteLine("2 " + thieve.name);
                        Console.SetCursorPosition(20, 30);
                        Console.WriteLine("3 " + blmage.name);
                        Console.SetCursorPosition(20, 31);
                        Console.WriteLine("4 " + whmage.name);
                        Console.SetCursorPosition(20, 32);
                        Console.Write("Ваш выбор: ");
                        b = Convert.ToInt16(Console.ReadLine());
                        switch (b)
                        {
                            case (1):
                                whmage.Dia(whmage, knight);
                                White_Magic_Animation(knight);
                                break;
                            case (2):
                                whmage.Dia(whmage, thieve);
                                White_Magic_Animation(thieve);
                                break;
                            case (3):
                                whmage.Dia(whmage, blmage);
                                White_Magic_Animation(blmage);
                                break;
                            case (4):
                                whmage.Dia(whmage, whmage);
                                White_Magic_Animation(whmage);
                                break;
                        }
                        break;
                }
            }
            if (whmage.lvl > 5 && whmage.lvl <= 10)
            {
                Helping(10, 26, "1 Diarahan");
                Console.SetCursorPosition(10, 27);
                Console.Write("Введите номер заклинания. Ваш выбор: ");
                a = Convert.ToInt16(Console.ReadLine());
                switch (a)
                {
                    case (1):
                        Console.SetCursorPosition(20, 27);
                        Console.WriteLine("Выберите союзника, на котором вы хотите применить заклинание:");
                        Console.SetCursorPosition(20, 28);
                        Console.WriteLine("1 " + knight.name);
                        Console.SetCursorPosition(20, 29);
                        Console.WriteLine("2 " + thieve.name);
                        Console.SetCursorPosition(20, 30);
                        Console.WriteLine("3 " + blmage.name);
                        Console.SetCursorPosition(20, 31);
                        Console.WriteLine("4 " + whmage.name);
                        Console.SetCursorPosition(20, 32);
                        Console.Write("Ваш выбор: ");
                        b = Convert.ToInt16(Console.ReadLine());
                        switch (b)
                        {
                            case (1):
                                whmage.Diarahan(whmage, knight);
                                White_Magic_Animation(knight);
                                break;
                            case (2):
                                whmage.Diarahan(whmage, thieve);
                                White_Magic_Animation(thieve);
                                break;
                            case (3):
                                whmage.Diarahan(whmage, blmage);
                                White_Magic_Animation(blmage);
                                break;
                            case (4):
                                whmage.Diarahan(whmage, whmage);
                                White_Magic_Animation(whmage);
                                break;
                        }
                        break;
                }
            }
            if (whmage.lvl > 10)
            {
                Helping(10, 26, "1 Diarama");
                Console.SetCursorPosition(10, 27);
                Console.Write("Введите номер заклинания. Ваш выбор: ");
                a = Convert.ToInt16(Console.ReadLine());
                switch (a)
                {
                    case (1):
                        Console.SetCursorPosition(20, 27);
                        Console.WriteLine("Выберите союзника, на котором вы хотите применить заклинание:");
                        Console.SetCursorPosition(20, 28);
                        Console.WriteLine("1 " + knight.name);
                        Console.SetCursorPosition(20, 29);
                        Console.WriteLine("2 " + thieve.name);
                        Console.SetCursorPosition(20, 30);
                        Console.WriteLine("3 " + blmage.name);
                        Console.SetCursorPosition(20, 31);
                        Console.WriteLine("4 " + whmage.name);
                        Console.SetCursorPosition(20, 32);
                        Console.Write("Ваш выбор: ");
                        b = Convert.ToInt16(Console.ReadLine());
                        switch (b)
                        {
                            case (1):
                                whmage.Diarama(whmage, knight);
                                White_Magic_Animation(knight);
                                break;
                            case (2):
                                whmage.Diarama(whmage, thieve);
                                White_Magic_Animation(thieve);
                                break;
                            case (3):
                                whmage.Diarama(whmage, blmage);
                                White_Magic_Animation(blmage);
                                break;
                            case (4):
                                whmage.Diarama(whmage, whmage);
                                White_Magic_Animation(whmage);
                                break;
                        }
                        break;
                }
            }
        }



        private static void White_Magic_Animation(MainCharacter hero)           //отвечает за анимацию заклинаний белой магии
        {
            Console.SetCursorPosition(Convert.ToInt32(hero.x) - 4, Convert.ToInt32(hero.y) + 2);
            Console.WriteLine("*");
            Thread.Sleep(200);
            Console.SetCursorPosition(Convert.ToInt32(hero.x) - 5, Convert.ToInt32(hero.y) + 1);
            Console.WriteLine("***");
            Thread.Sleep(200);
            Console.SetCursorPosition(Convert.ToInt32(hero.x) - 4, Convert.ToInt32(hero.y));
            Console.WriteLine("*");
            Thread.Sleep(200);
        }



        private static void Interface(MainCharacter knight, MainCharacter thieve, MainCharacter blmage, MainCharacter whmage)
        {
            Console.SetCursorPosition(90, 4);
            Console.WriteLine("name: {0}\tHP: {1}\tSP: {2}\tDamage: {3}\tDefence: {4}\tGold: {5}", knight.name, knight.hp, knight.sp, knight.damage, knight.defence, knight.gold);
            Console.SetCursorPosition(90, 5);
            Console.WriteLine("name: {0}\tHP: {1}\tSP: {2}\tDamage: {3}\tDefence: {4}\tGold: {5}", thieve.name, thieve.hp, thieve.sp, thieve.damage, thieve.defence, thieve.gold);
            Console.SetCursorPosition(90, 6);
            Console.WriteLine("name: {0}\tHP: {1}\tSP: {2}\tDamage: {3}\tDefence: {4}\tGold: {5}", blmage.name, blmage.hp, blmage.sp, blmage.damage, blmage.defence, blmage.gold);
            Console.SetCursorPosition(90, 7);
            Console.WriteLine("name: {0}\tHP: {1}\tSP: {2}\tDamage: {3}\tDefence: {4}\tGold: {5}", whmage.name, whmage.hp, whmage.sp, whmage.damage, whmage.defence, whmage.gold);
        }
    }
}