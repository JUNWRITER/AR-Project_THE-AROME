using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MenuInfo
{
    public string name;
    public string info;
    public string allergy;
    public int price;

    public MenuInfo()
    {

    }

    public MenuInfo(string name, string info, int price)
    {
        this.name = name;
        this.info = info;
        this.price = price;
    }

    public MenuInfo(string name, string info, string allergy, int price)
    {
        this.name = name;
        this.info = info;
        this.allergy = allergy;
        this.price = price;
    }
}
