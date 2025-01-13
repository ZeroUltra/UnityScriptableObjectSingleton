using System.Collections;
using UnityEngine;
using UnityScriptableObjectSingleton.Editor;
/// <summary>
/// ____DESC:      
/// </summary>
[CreateAssetMenu(fileName = "TestEditorScriptableObjectSingleton", menuName = "Test/TestEditorScriptableObjectSingleton", order = 0)]

public class TestEditorScriptableObjectSingleton : ScriptableObjectSingletonEditor<TestEditorScriptableObjectSingleton>
{
    public int value;
}