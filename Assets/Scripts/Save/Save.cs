using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(GameDataScript gds)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Save.things";
        FileStream stream = new FileStream(path, FileMode.Create);

        Save save = new Save(gds);

        formatter.Serialize(stream, save);
        stream.Close();
    }

    public static Save LoadData()
    {
        string path = Application.persistentDataPath + "/Save.things";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Save save = formatter.Deserialize(stream) as Save;
            stream.Close();

            return save;
        }
        else
        {
            return new Save("", 100, 100, 0, 68, 70, 74, 75);
        }

    }

}

[System.Serializable]
public class Save
{
    public string name;
    public int bgm, fx;
    public int score;

    public int[] KeyCodes;

    public Save(GameDataScript gds)
    {
        name = gds.name;
        bgm = gds.music;
        fx = gds.volume;
        score = gds.score;
        KeyCodes[0] = (int)gds.arthurKeyCode;
        KeyCodes[1] = (int)gds.percevalKeyCode;
        KeyCodes[2] = (int)gds.lancelotKeyCode;
        KeyCodes[3] = (int)gds.gauvainKeyCode;
    }

    public Save(string n, int b, int f, int s, int a, int p, int l, int g)
    {
        name = n;
        bgm = b;
        fx = f;
        score = s;
        KeyCodes[0] = a;
        KeyCodes[1] = p;
        KeyCodes[2] = l;
        KeyCodes[3] = g;
    }

}
