using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDataFromCSV : MonoBehaviour
{
    public ReadCSV readCSV;

    public int Level;
    public int EXPNeed;
    public int ATK;
    public int HP;
    public float DEG;
    public int CP;
    public int inputLevel;
    private void Update()
    {
        if (inputLevel >= 1)
        {
            ChangeLevel();
        }
    }
    public void ChangeLevel()
    {
        foreach (var item in readCSV.Datas)
        {
            if(item.Level == inputLevel)
            {
                this.Level=item.Level;
                this.EXPNeed=item.EXPNeed;
                this.ATK=item.ATK;
                this.HP=item.HP;
                this.DEG=item.DEG;
                this.CP=item.CP;
             
            }
        }
    }

}
