using System;
using System.Collections.Generic;
using System.IO;
using FinalTask.Game;
using FinalTask.FileSystem;
using FinalTask.Game.Games;
using FinalTask.Utils;

namespace FinalTask
{
    class Casino : IGame
    {
        //public const string StartBank = "1000";
        public int MaxBank = 10000;
        private string _player;
        private int _playerMoney = 0;
        //private Dictionary<string, int> _profile;
        private int _gameNumber = 1;
        private bool correctInput;
        private string _path = "G:\\Учеба\\GameDev\\Курс Разработчик Unity3d Netologia\\Итоговая работа по C#\\Итоговая работа по программированию\\FinalTask\\Profiles\\";
        private BlackJeck blackJeck;
        private Dice dice;
        private CasinoGameBase currentGame;

        public int Money => _playerMoney;

        public Casino()
        {
            blackJeck = new BlackJeck(54);
            //dice = new Dice();
        }

        public void StartGame()
        {
            //1. Приветствие игрока
            MeetWithPlayer();

            //Создаем экземпляр для работы с файлами
            var fileManager = new FileSystemSaveLoadService(_path);

            //2. Загрузка профиля игрока. Если профиля нет - создать. Предложить игроку ввести имя.
            if (int.TryParse(fileManager.LoadData(_player), out int money))
            {
                Console.WriteLine("Your bank is: " + money);
                _playerMoney = money;
            } 
            else
            {
                throw new Exception("We have a tecknical problem and we haven't accecc to your bank");
            }

            //3. Выбор игры
            while (_gameNumber != 0/* && _playerMoney > 0*/)
            {
                ChooseTheGame();
                if (CheckMoney()) 
                {
                    if (MakeBet() > 0)
                    {
                        currentGame.PlayGame();
                        currentGame.ResultOutpu();
                    }
                    
                    //5.Далее выводится результат игры: значение карт либо костей(в зависимости от выбранной игры), победа / поражение или ничья.
                }
            } 

            //6.Прощаемся с игроком.
            Console.WriteLine("Goodbye, {0}", _player);
            //7.Сохраняем профиль.
            fileManager.SaveData(_playerMoney.ToString(), _player);
            //8.Выход из игры.
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

        //private void /*Dictionary<string, int>*/ LoadProfile(string nmae)
        //{
        //    //return _profile;
        //    _profile.TryGetValue(_player, out int value);
        //    Console.WriteLine("Your bank is: " + _profile[_player] /*value*/);
        //}

        private void ChooseTheGame()
        {
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
                    correctInput = true;
                    switch (_gameNumber)
                    {
                        case 1:
                            //if (!CheckMoney())
                            //{
                            //    break;
                            //}
                            currentGame = blackJeck;
                            break;
                        case 2:
                            //if (!CheckMoney())
                            //{
                            //    break;
                            //}
                            currentGame = dice;
                            break;
                        case 0:

                            break;
                        default:
                            Console.WriteLine("There are not this game in our casino.");
                            correctInput = false;
                            break;
                    } 
                }
            } while (!correctInput);
        }

        public int MakeBet()
        {
            int bank = 0;
            do
            {
                Console.WriteLine("Please, make your bet:");
                
                if (int.TryParse(Console.ReadLine(), out int playerBet))
                {
                    if (playerBet > _playerMoney)
                    {
                        Console.WriteLine("You haven't so money. Please use that you have");
                        return 0;
                    }
                    else
                    {
                        //4.После выбора игры предлагается сделать ставку.
                        //Ставка не должна превышать значение банка игрока.
                        //Значение ставки компьютера равняется ставке игрока. 
                        bank = playerBet * 2;
                        //Объявляем сумму банка
                        Console.WriteLine("Player's bet is {0}. Casino's bet is {0}. Bank is {1}", playerBet, bank);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input, please make bet by money");
                }
            } while (false);
            return bank;
        }

        private bool CheckMoney()
        {
            if (_playerMoney <= 0)
            {
                Console.WriteLine("No money? Kicked");
                return false;
            } 
            else if (_playerMoney > GameConstants.MaxBank)
            {
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
                _playerMoney = _playerMoney / 2;
            }
            return true;
        }
    }
}
