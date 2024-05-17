using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tony
{
    [Serializable]
    public class PetData
    {
        public string PetID;
        public string PetName;
        public int Level;
        public int EXPNeed;
        public int ATK;
        public int HP;
        public float ATKR;
        public float ATKS;
        public float CR;
        public float CD;
        public float CP;
        public int LevelSkill1;
        public int LevelSkill2;
        public int LevelSkill3;

    }
    public class ReadPetCSV<T> : IReadCSV<PetData>
    {
        private Pet pet;
        private List<PetData> datas = new List<PetData>();
        private TextAsset textAsset;
        public ReadPetCSV(Pet pet)
        {
            this.pet=pet;
            this.textAsset = pet.CSVFIle;
        }
        public List<PetData> GetData()
        {
            return datas;
        }
        public void ReadData(Action onComplete)
        {
            if (textAsset != null)
            {
                var csvText = textAsset.text.Trim().Replace("\r\n", "\n");
                var lines = csvText.Split("\n");
                for (int i = 1; i < 21; i++)
                {
                    var segments = lines[i].Split(',');
               
                    if (segments.Length > 0)
                    {
                        PetData data = new PetData();
    
                        data.PetID = !string.IsNullOrWhiteSpace(segments[0]) ? segments[0] : "";
                        data.PetName = !string.IsNullOrWhiteSpace(segments[1]) ? segments[1] : "";
                        
                        data.Level = int.Parse(segments[2]);
                        data.EXPNeed = int.Parse(segments[3]);
                        data.ATK = int.Parse(segments[4]);
                        data.HP = int.Parse(segments[5]);
                        data.ATKR = float.Parse(segments[6]);
                        data.ATKS = float.Parse(segments[7]);
                        data.CR = float.Parse(segments[8]);
                        data.CD = float.Parse(segments[9]);
                        data.CP = float.Parse(segments[10]);
                        data.LevelSkill1 = int.Parse(segments[11]);
                        data.LevelSkill2 = int.Parse(segments[12]);
                        data.LevelSkill3 = int.Parse(segments[13]);
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
}
