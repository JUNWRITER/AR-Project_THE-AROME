using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nohoon
{
    [Serializable]
    public class Menu
    {
        public string name;
        public string info;
        public int price;
    }

    [Serializable]
    public class MenuData : ILoader<string, Menu>
    {
        public List<Menu> menus = new List<Menu>();

        public Dictionary<string, Menu> CreateDictionary()
        {
            Dictionary<string,Menu> menuDictionary = new Dictionary<string, Menu>();

            foreach(Menu menu in menus)
            {
                menuDictionary.Add(menu.name, menu);
            }

            return menuDictionary;
        }
    }
}

