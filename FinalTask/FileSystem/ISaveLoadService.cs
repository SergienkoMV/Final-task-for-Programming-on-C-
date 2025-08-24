namespace FinalTask.FileSystem
{
    interface ISaveLoadService<T>
    {
        void SaveData(T param1, string path);
        Y LoadData<Y>(string path);
    }
}
