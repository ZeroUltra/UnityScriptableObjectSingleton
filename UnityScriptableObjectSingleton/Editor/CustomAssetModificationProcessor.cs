using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityScriptableObjectSingleton.Runtime;

namespace UnityScriptableObjectSingleton.Editor
{
    public class CustomAssetModificationProcessor : AssetModificationProcessor
    {
        private static void OnWillCreateAsset(string assetPath)
        {
            //先创建文件,在创建.meta文件
            //如果创建之后是meta文件,说明是新创建的资源
            if (Path.GetExtension(assetPath) == ".meta")
            {
                assetPath = assetPath.Replace(".meta", "");
                //延迟为了保证资源已经创建(且已经为重命名之后的)
                EditorApplication.delayCall += () =>
                {
                    PostScriptableObjectSingleton(assetPath);
                };
            }
        }

        private static void PostScriptableObjectSingleton(string assetPath)
        {
            if (Path.GetExtension(assetPath) == ".asset")
            {
                var obj = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
                if (obj != null && obj is ScriptableObject scriptable)
                {
                    var type = scriptable.GetType();
                    if (typeof(ISingletion).IsAssignableFrom(type))
                    {
                        // EditorApplication.delayCall += () =>
                        //{
                        var listTarget = Helper.FindAllScriptableObject()
                                          .Where(item => item.GetType() == type) //筛选相同类型
                                          .Where(item => AssetDatabase.GetAssetPath(item) != assetPath).ToArray();//筛选不是该路径的

                        // ==1说明其他的路径存在一个单例,需要删除最新的资源
                        if (listTarget.Length == 1)
                        {
                            //删除新创建的资源
                            AssetDatabase.DeleteAsset(assetPath);
                            Debug.Log($"(Instance) [{type.Name}] Exists");
                            EditorGUIUtility.PingObject(listTarget[0]);
                        }
                    }
                }
            }
        }

    }
}
