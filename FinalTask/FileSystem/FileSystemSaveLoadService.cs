using System;
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

        private string GeneratePath(string fileName)
        {
            var path = _path + fileName + ".txt";
            return path;
        }

        public Y LoadData<Y>(string fileName)
        {
            var file = GeneratePath(fileName);

            if (!File.Exists(file))
            {
                var bank = GameConstants.StartBank;
                SaveData(bank, fileName);
            }

            using (var readStream = File.OpenText(file))
            {
                string content = readStream.ReadToEnd();
                return (Y)Convert.ChangeType(content, typeof(Y));
            }

        }
    }
}
