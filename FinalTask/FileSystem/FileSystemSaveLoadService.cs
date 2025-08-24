using System;
using System.Collections.Generic;
using System.IO;
using FinalTask.Utils;

namespace FinalTask.FileSystem
{
    class FileSystemSaveLoadService : ISaveLoadService<String>
    {
        private string _path;

        public FileSystemSaveLoadService(string path)
        {
            _path = path;
        }

        public void SaveData(string _money, string _player)
        {
            try
            {
                if (!string.IsNullOrEmpty(_path) && !Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }
                var file = GeneratePath(_player);
                using (StreamWriter writhStream = File.CreateText(file))
                {
                    writhStream.WriteLine(_money);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public string LoadData(string fileName)
        {
            
            var file = GeneratePath(fileName);

            if (File.Exists(file))
            {
                using (var readStream = File.OpenText(file))
                {
                    return readStream.ReadToEnd();
                }
            }
            else
            {
                var bank = GameConstants.StartBank;
                SaveData(bank, fileName);
                return bank;
            }
        }

        private string GeneratePath(string fileName)
        {
            var path = _path + fileName + ".txt";
            return path;
        }
    }
}
