using System;
using System.Collections;
using System.Collections.Generic;
using Tony;
using UnityEngine;

[Serializable]
public class Data {
    public int Level;
    public int EXPNeed;
    public int ATK;
    public int HP ;
    public float DEG;
    public int CP;
}

public class ReadCharacterCSV<T> :IReadCSV<Data>
{

    [SerializeField] private CharacterData characterData;
    [SerializeField] private List<Data> datas=new List<Data>();
    private TextAsset textAsset;

     public ReadCharacterCSV(CharacterData characterData)
     {
        this.characterData = characterData;
        textAsset = characterData.csvFile;
     }

    public List<Data> GetData()
    {
        return datas;
    }
    public void ReadData(Action onComplete)
    {
        if (textAsset != null)
        {
            var csvText = textAsset.text.Trim().Replace("\r\n", "\n");
            var lines = csvText.Split("\n");
            for (int i = 1; i < lines.Length; i++)
            {
                var segments = lines[i].Split(',');

                if (segments.Length > 0)
                {
                    Data data=new Data();
                    data.Level = int.Parse(segments[2]);
                    data.EXPNeed = int.Parse(segments[3]);
                    data.ATK = int.Parse(segments[4]);
                    data.HP = int.Parse(segments[5]);
                    data.DEG = float.Parse(segments[6]);
                    data.CP = int.Parse(segments[7]);
                    datas.Add(data);

                }
            }
            onComplete?.Invoke();
        }
        else
        {
            Debug.LogError("Not found localization files !");
        }
    }
}
