using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string LoadData(string _player)
        {
            
            var file = GeneratePath(_player);

            if (File.Exists(file))
            {
                using (var readStream = File.OpenText(file))
                {
                    return readStream.ReadToEnd();
                }
            }
            else
            {
                var bank = FinalTask.Casino.StartBank;
                SaveData(bank, _player);
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
