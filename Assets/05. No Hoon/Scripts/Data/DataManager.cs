using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nohoon
{
    public class DataManager : Singleton<DataManager>
    {
        //  new 로 생성하는거 방지 (항상 싱글톤을 보장)
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
            // text 파일이 textAsset에 담긴다. TextAsset 타입은 텍스트파일 에셋이라고 생각
            TextAsset textAsset = Resources.Load<TextAsset>(path);

            return JsonUtility.FromJson<Loader>(textAsset.text);
        }
    }
}

