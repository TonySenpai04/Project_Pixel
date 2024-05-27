using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    [Serializable]
    public class EnemyData
    {
        public string EnemyID;
        public string EnemyName;
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
    public class ReadEnemyCSV<T> : IReadCSV<EnemyData>
    {
        private Enemy enemy;
        private List<EnemyData> datas = new List<EnemyData>();
        private TextAsset textAsset;
        public ReadEnemyCSV(Enemy enemy)
        {
            this.enemy = enemy;
            this.textAsset = enemy.CSVFIle;
        }
        public List<EnemyData> GetData()
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
                        EnemyData data = new EnemyData();

                        data.EnemyID =!string.IsNullOrWhiteSpace(segments[0]) ? segments[0] : "";
                        data.EnemyName = !string.IsNullOrWhiteSpace(segments[1]) ? segments[1] : "";

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
