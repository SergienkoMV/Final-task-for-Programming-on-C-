using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.FileSystem
{
    interface ISaveLoadService<T>
    {
        void SaveData(T param1, string path);
        Y LoadData<Y>(string path);
    }
}
