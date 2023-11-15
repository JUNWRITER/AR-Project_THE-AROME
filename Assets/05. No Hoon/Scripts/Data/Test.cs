using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nohoon;

namespace Nohoon
{
    public class Test : MonoBehaviour
    {

        private void Start()
        {
            Dictionary<string, Menu> menuDic = DataManager.Instance.menuDictionary;
            
            
            foreach (var menu in menuDic)
            {
                Debug.Log($"Name : {menu.Key},  Info : {menu.Value.info}, Prece : {menu.Value.price}");
            }
        }
    }
}

