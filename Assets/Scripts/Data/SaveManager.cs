using System.IO;
using UnityEngine;

public class SaveManager : ISaveManager
{
    private string Path => Application.persistentDataPath + "/Matching_Save.json";

    public void SaveMatchingSaveData(MatchSaveStateDataList data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Path, json);
    }

    public MatchSaveStateDataList LoadMatchingSaveData()
    {
        if (!File.Exists(Path))
            return null;

        string json = File.ReadAllText(Path);
        return JsonUtility.FromJson<MatchSaveStateDataList>(json);
    }

    public void DeleteMatchingSaveData()
    {
        if (File.Exists(Path))
            File.Delete(Path);
    }
}


