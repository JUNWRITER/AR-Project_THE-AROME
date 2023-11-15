using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nohoon
{
    /// <summary>
    /// 제네릭을 이용한 싱글톤 패턴 클래스
    /// </summary>
    /// <typeparam name="T">싱글톤으로 할 클래스</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;
        private static object _lock = new object();
        private static bool isApplicationQuit = false;

        public static T Instance
        {
            get
            {
                //  lock : 코드가 실행이 완료되기 전까지 연속적인 호출에도 중복실행 허용하지 않음
                if (isApplicationQuit)
                    return null;

                lock(_lock)
                {
                    //  현재 Scene에 싱글톤 존재 확인
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();

                        //  현재 Scene에 존재 하지 않는다면
                        //if(instance == null)
                        //{
                        //    //  해당 컴포넌트의 이름을 찾아서
                        //    //  컴포넌트의 이름으로 게임 오브젝트 찾는다
                        //    string componentName = typeof(T).ToString();
                        //    GameObject findObject = GameObject.Find(componentName);

                        //    //  해당 컴포넌트의 이름의 오브젝트가 존재하지않는다면 생성
                        //    if (findObject == null)
                        //        findObject = new GameObject(componentName);

                        //    //  생성된 오브젝트에 오브젝트 추가
                        //    instance = findObject.AddComponent<T>();

                        //    //  씬 변경되어도 객체 유지
                        //    //DontDestroyOnLoad(instance);
                        //}
                    }
                    return instance;
                }
            }
        }
    }
}

