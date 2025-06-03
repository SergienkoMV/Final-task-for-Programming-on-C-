using System;
using System.Collections.Generic;
using System.IO;
using FinalTask.Utils;

namespace FinalTask.FileSystem
{
    class FileSystemSaveLoadService : ISaveLoadService<String>
    {
        //private int _money;
        private string _path;

        public FileSystemSaveLoadService(string path)
        {
            _path = path;
        }

        public void SaveData(string _money, string _player)
        {
            var file = GeneratePath(_player);
            using (StreamWriter writhStream = File.CreateText(file)) //как я понял, можно сделать без "(", ")" в таком случае память освободится, когда выйдем из метода
            {
                writhStream.WriteLine(_money);
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

            //return default(string);
        }

        private string GeneratePath(string fileName)
        {
            var path = _path + fileName + ".txt";
            return path;
        }
    }
}
