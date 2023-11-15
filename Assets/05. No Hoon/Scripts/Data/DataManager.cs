using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nohoon
{
    public class DataManager : Singleton<DataManager>
    {
        //  new �� �����ϴ°� ���� (�׻� �̱����� ����)
        protected DataManager() { }

        public Dictionary<string,Menu> menuDictionary = new Dictionary<string, Menu>();

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            menuDictionary = LoadJson<MenuData,string,Menu>("MenuData").CreateDictionary();
        }

        Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
        {
            // text ������ textAsset�� ����. TextAsset Ÿ���� �ؽ�Ʈ���� �����̶�� ����
            TextAsset textAsset = Resources.Load<TextAsset>(path);

            return JsonUtility.FromJson<Loader>(textAsset.text);
        }
    }
}

