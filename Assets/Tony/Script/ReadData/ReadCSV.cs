using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    public int Id;
    public string Name;


    public List<int> Levels = new List<int>();
    public List<int> EXPNeeds = new List<int>();
    public List<int> ATKs = new List<int>();
    public List<float> DEGs = new List<float>();
    public List<int> CPs = new List<int>();



    public void ReadData()
    {
        var fileCsv = Resources.Load<TextAsset>($"{Id}_{Name}");
        if (fileCsv != null)
        {
            var csvText = fileCsv.text.Trim().Replace("\r\n", "\n");
            var lines = csvText.Split("\n");
            for (int i = 1; i < lines.Length; i++)
            {
                var segments = lines[i].Split(';');

                if (segments.Length > 0)
                {
                    Levels.Add(int.Parse(segments[2]));

                    EXPNeeds.Add(int.Parse(segments[3]));
                    ATKs.Add(int.Parse(segments[4]));
                    DEGs.Add(float.Parse(segments[5]));
                    CPs.Add(int.Parse(segments[6]));

                }
            }
        }
        else
        {
            Debug.LogError("Not found localization files !");
        }
    }
}
