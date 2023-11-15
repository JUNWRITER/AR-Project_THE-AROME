using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] 
public class Food
{ 
    public string foodName;
    public int foodPrice;
    public string foodInfo;
}

[Serializable]
public class FoodArr
{
    public Food[] foods;
}