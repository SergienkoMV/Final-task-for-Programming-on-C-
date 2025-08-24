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
        private string _player;
        private int _playerMoney = 0;
        private int _gameNumber = 1;
        private int _bank;
        private bool correctInput;
        private string _path = "G:\\Учеба\\GameDev\\Курс Разработчик Unity3d Netologia\\Итоговая работа по C#\\Итоговая работа по программированию\\FinalTask\\Profiles\\";
        private BlackJeck _blackJeck;
        private DiceGame _dice;
        private CasinoGameBase currentGame;

        public int Money => _playerMoney;

        public Casino()
        {
            _blackJeck = new BlackJeck(new int[] { 54 });
            _dice = new DiceGame(new int[] { 5, 1, 6 });
        }

        public void StartGame()
        {
            MeetWithPlayer();

            var fileManager = new FileSystemSaveLoadService(_path);

            if (int.TryParse(fileManager.LoadData<string>(_player), out int money))
            {
                Console.WriteLine("Your bank is: " + money + "$");
                _playerMoney = money;
            } 
            else
            {
                throw new Exception("We have a tecknical problem and we haven't accecc to your bank");
            }

            do
            {
                _gameNumber = ChooseTheGame();
                if (CheckMoney())
                {
                    if (_gameNumber != 0)
                    {
                        _bank = MakeBet();
                        currentGame.PlayGame();
                        currentGame.OnWin += OnWinOutput;
                        currentGame.OnLoose += OnLooseOutput;
                        currentGame.OnDraw += OnDrawOutput;
                        currentGame.ResultOutpu();
                        currentGame.OnWin -= OnWinOutput;
                        currentGame.OnLoose -= OnLooseOutput;
                        currentGame.OnDraw -= OnDrawOutput;
                    }
                }
                else
                {
                    break;
                }
            } while (_gameNumber != 0);

            Console.WriteLine("Goodbye, {0}", _player);
            fileManager.SaveData(_playerMoney.ToString(), _player);
            Console.ReadLine();
        }

        private void MeetWithPlayer()
        {
            Console.WriteLine("Welcome to the our Casino!");
            Console.WriteLine("What is your name?");
            _player = Console.ReadLine();
            Console.WriteLine("Nice to meet you: " + _player);
        }

        private int ChooseTheGame()
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
                            currentGame = _blackJeck;
                            break;
                        case 2:
                            currentGame = _dice;
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("There is not this game in our casino.");
                            correctInput = false;
                            break;
                    } 
                }
            } while (!correctInput);
            return _gameNumber;
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
                        correctInput = false;
                    }
                    else if(playerBet == 0)
                    {
                        Console.WriteLine("You should make bet. You can not play without bet.");
                        correctInput = false;
                    }
                    else
                    {
                        bank = playerBet * 2;
                        Console.WriteLine("Player's bet is {0}$. Casino's bet is {0}$. There is {1}$ in the bank", playerBet, bank);
                        correctInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input, please make bet by money");
                    correctInput = false;
                }
            } while (!correctInput);
            return bank;
        }

        private bool CheckMoney()
        {
            if (_playerMoney <= 0)
            {
                Console.WriteLine("You have {0}$", _playerMoney);
                Console.WriteLine("No money? Kicked");
                return false;
            } 
            else if (_playerMoney > GameConstants.MaxBank)
            {
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
                _playerMoney = _playerMoney / 2;
                Console.WriteLine("You have {0}$", _playerMoney);
            }
            else
            {
                Console.WriteLine("You have {0}$", _playerMoney);
            }

            return true;
        }

        public void OnWinOutput()
        {
            Console.WriteLine(" *** Player win ***");
            Console.WriteLine(" *** Player get bank: {0}$ ***", _bank);
            _playerMoney += _bank / 2; 
        }

        public void OnLooseOutput()
        {
            Console.WriteLine(" *** Casino win ***");
            Console.WriteLine(" *** Player loose bet: {0}$ ***", _bank / 2);
            _playerMoney -= _bank / 2;
        }

        public void OnDrawOutput()
        {
            Console.WriteLine(" *** No winner ***");
            Console.WriteLine(" *** Player return bet: {0}$ ***", _bank / 2);
        }
    }
}
