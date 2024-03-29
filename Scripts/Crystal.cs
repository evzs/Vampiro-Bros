using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crystal : ItemAbstract
{

    public override void Collect()
    {
        GameManager.Instance.AddCrystal();
    }

}