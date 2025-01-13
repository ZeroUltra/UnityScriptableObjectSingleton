using System.Collections;
using UnityEngine;

/// <summary>
/// ____DESC:      
/// </summary>
public class ScriptableObjectTest : MonoBehaviour
{
    public TestScriptableObjectNoSingleton testScriptableObjectNoSingleton;
    // public Tested
    private void Start()
    {
        Debug.Log("TestScriptableObjectSingleton: "+ TestScriptableObjectSingleton.Instance.value);
        Debug.Log("TestScriptableObjectNoSingleton: "+testScriptableObjectNoSingleton.value);
    }
}