using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDataFromCSV : MonoBehaviour
{
    public ReadCSV readCSV;

    public int Level;
    public int EXPNeed;
    public int ATK;
    public float DEG;
    public int CP;

    public void ChangeLevel(int inputLevel)
    {
        Level = readCSV.Levels[inputLevel - 1];
        EXPNeed = readCSV.EXPNeeds[inputLevel - 1];
        ATK = readCSV.ATKs[inputLevel - 1];
        DEG = readCSV.DEGs[inputLevel - 1];
        CP = readCSV.CPs[inputLevel - 1];
    }

}
