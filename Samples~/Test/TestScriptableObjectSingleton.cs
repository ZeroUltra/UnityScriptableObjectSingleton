using System.Collections;
using UnityEngine;
using UnityScriptableObjectSingleton.Editor;
using UnityScriptableObjectSingleton.Runtime;
/// <summary>
/// ____DESC:      
/// </summary>
[CreateAssetMenu(fileName = "TestScriptableObjectSingleton", menuName = "Test/TestScriptableObjectSingleton", order = 0)]
public class TestScriptableObjectSingleton : ScriptableObject, ISingletion
{
    //手动实现Instance
    private static TestScriptableObjectSingleton _instance;
    public static TestScriptableObjectSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<TestScriptableObjectSingleton>("TestScriptableObjectSingleton");
                if (_instance == null)
                {
                    Debug.LogError("Can't find the instance of TestScriptableObjectSingleton");
                }
            }
            return _instance;
        }
    }
    public int value;
}