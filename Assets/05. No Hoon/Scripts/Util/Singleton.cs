using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nohoon
{
    /// <summary>
    /// ���׸��� �̿��� �̱��� ���� Ŭ����
    /// </summary>
    /// <typeparam name="T">�̱������� �� Ŭ����</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;
        private static object _lock = new object();
        private static bool isApplicationQuit = false;

        public static T Instance
        {
            get
            {
                //  lock : �ڵ尡 ������ �Ϸ�Ǳ� ������ �������� ȣ�⿡�� �ߺ����� ������� ����
                if (isApplicationQuit)
                    return null;

                lock(_lock)
                {
                    //  ���� Scene�� �̱��� ���� Ȯ��
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();

                        //  ���� Scene�� ���� ���� �ʴ´ٸ�
                        //if(instance == null)
                        //{
                        //    //  �ش� ������Ʈ�� �̸��� ã�Ƽ�
                        //    //  ������Ʈ�� �̸����� ���� ������Ʈ ã�´�
                        //    string componentName = typeof(T).ToString();
                        //    GameObject findObject = GameObject.Find(componentName);

                        //    //  �ش� ������Ʈ�� �̸��� ������Ʈ�� ���������ʴ´ٸ� ����
                        //    if (findObject == null)
                        //        findObject = new GameObject(componentName);

                        //    //  ������ ������Ʈ�� ������Ʈ �߰�
                        //    instance = findObject.AddComponent<T>();

                        //    //  �� ����Ǿ ��ü ����
                        //    //DontDestroyOnLoad(instance);
                        //}
                    }
                    return instance;
                }
            }
        }
    }
}

