using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private string petName;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private int currentLevel;
}
