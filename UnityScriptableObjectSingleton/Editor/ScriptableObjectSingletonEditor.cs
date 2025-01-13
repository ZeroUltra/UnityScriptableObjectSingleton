using UnityEditor;
using UnityEngine;
using UnityScriptableObjectSingleton.Runtime;
namespace UnityScriptableObjectSingleton.Editor
{
    public class ScriptableObjectSingletonEditor<T> : ScriptableObject, ISingletion where T : ScriptableObject
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Helper.FindScriptableObject<T>();
                    if (_instance == null)
                    {
                        Debug.LogError("Can't find the instance of " + typeof(T).Name);
                    }
                }
                return _instance;
            }
        }

    }
}