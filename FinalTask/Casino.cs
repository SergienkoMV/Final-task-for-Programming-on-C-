using System;
using System.Collections.Generic;
using System.IO;
using FinalTask.Game;
using FinalTask.FileSystem;

namespace FinalTask
{
    class Casino : IGame
    {
        public const string StartBank = "1000";
        private string _player;
        private int _money = 1000;
        private Dictionary<string, int> _profile;
        private int _gameNumber;
        private bool correctInput;
        private string _path = "G:\\Учеба\\GameDev\\Курс Разработчик Unity3d Netologia\\Итоговая работа по C#\\Итоговая работа по программированию\\FinalTask\\Profiles\\";

        public void EnterToTheCasino()
        {
            //Узнаем имя для профиля.
            MeetWithPlayer();

            //Создаем экземпляр для работы с файлами
            var fileManager = new FileSystemSaveLoadService(_path);

            //Считываем данные профиля из файла
            if(int.TryParse(fileManager.LoadData(_player), out int money))
            {
                Console.WriteLine("Your bank is: " + money);
                _money = money;
            }
            //LoadProfile(_player);

            _profile = new Dictionary<string, int>();
            //считать профиль из сохраненных

            if (!_profile.ContainsKey(_player)) //_profile.TryGetValue(_player, out int value))
            {
                _profile = new Dictionary<string, int>();
                _profile.Add(_player, _money);
            }

            ChooseTheGame();

            Console.ReadLine(); //Остановка, чтобы сразу не вылететь из программы. 
        }

        private void MeetWithPlayer()
        {
            Console.WriteLine("Welcome to the our Casino!");
            Console.WriteLine("What is your name?");
            _player = Console.ReadLine();

            //CheckProfile(_player);
            //_profile.TryGetValue(_player, out int value);
            Console.WriteLine("Nice to meet you: " + _player);
        }

        //если методы создаются только для того, чтобы структурировать программу и сделать более читаемой, нет же смысла передавать в методы и возвращать переменные, которые используются внутри данного класса?

        private void /*Dictionary<string, int>*/ LoadProfile(string nmae)
        {
            //return _profile;
            _profile.TryGetValue(_player, out int value);
            Console.WriteLine("Your bank is: " + _profile[_player] /*value*/);
        }

        private void ChooseTheGame()
        {
            do
            {
                if (!CheckMoney())
                {
                    break;
                }

                do
                {
                    Console.WriteLine("Please, choose the game:");
                    Console.WriteLine("1 - BlackJeck");
                    Console.WriteLine("2 - Dice");
                    Console.WriteLine("0 - For leave casino");
                    if (!Int32.TryParse(Console.ReadLine(), out _gameNumber)) //добавить проверку, что выбранное значение есть в enum
                    {
                        Console.WriteLine("Incorrect input");
                        correctInput = false;
                    } 
                    else
                    {
                        if (_gameNumber == 1 || _gameNumber == 2 || _gameNumber == 0)
                        {
                            Console.WriteLine("1, 2 or 0"); //удалить. Проверка что вызывается код
                            correctInput = true;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("There are not this game in our casino.");
                            correctInput = false;
                        }
                    }

                } while (!correctInput);


                //switch 

                //case
                //{

                //}
            }
            while (_gameNumber != 0);
        }

        private bool CheckMoney()
        {
            if (_profile[_player] <= 0)
            {
                Console.WriteLine("No money? Kicked");
                return false;
            }
            return true;
        }
    }
}
