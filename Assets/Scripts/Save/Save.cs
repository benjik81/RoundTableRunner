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
            Debug.Log(save.name);
            return save;
        }
        else
        {
            return new Save("", 100, 100, 0, 68, 70, 74, 75, 0);
        }

    }

}

[System.Serializable]
public class Save
{
    public string name;
    public int bgm, fx;
    public int score, highScore;

    //public int[] KeyCodes;
    public int arthurCode, percevalCode, gauvainCode, lancelotCode;

    public Save(GameDataScript gds)
    {
        name = gds.playerName;
        bgm = gds.music;
        fx = gds.volume;
        score = gds.score;
        arthurCode = (int)gds.arthurKeyCode;
        percevalCode = (int)gds.percevalKeyCode;
        gauvainCode = (int)gds.lancelotKeyCode;
        lancelotCode = (int)gds.gauvainKeyCode;
        highScore = gds.highscore;
    }

    public Save(string n, int b, int f, int s, int a, int p, int l, int g, int h)
    {
        name = n;
        bgm = b;
        fx = f;
        score = s;
        arthurCode = a;
        percevalCode = p;
        lancelotCode = l;
        gauvainCode = g;
        highScore = h;
    }

}
