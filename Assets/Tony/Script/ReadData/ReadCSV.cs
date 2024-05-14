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

public class ReadCSV : MonoBehaviour
{

    [SerializeField] private CharacterData characterData;
    [SerializeField]private List<Data> datas;

    public List<Data> Datas { get => datas;  }

    private void Awake()
    {
        ReadData();
    }
    public void ReadData()
    {
        if (characterData != null)
        {
            var csvText = characterData.csvFile.text.Trim().Replace("\r\n", "\n");
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
                    Datas.Add(data);

                }
            }
        }
        else
        {
            Debug.LogError("Not found localization files !");
        }
    }
}
