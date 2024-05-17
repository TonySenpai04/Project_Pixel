using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public interface IReadCSV<T>
    {
        void ReadData(Action onComplete);
        List<T> GetData();
    }
}