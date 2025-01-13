using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityScriptableObjectSingleton.Editor
{
    /// <summary>
    /// ____DESC:
    /// </summary>
    public class Helper
    {
        public static T FindScriptableObject<T>(string[] searchInFolders = null) where T : ScriptableObject
        {
            if (searchInFolders == null)
            {
                searchInFolders = new string[] { "Assets" };
            }
            var assetGUID = AssetDatabase.FindAssets("t:ScriptableObject", searchInFolders);
            foreach (var item in assetGUID)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(item);
                var obj = AssetDatabase.LoadMainAssetAtPath(assetPath);
                //找到目标
                if (obj is T t)
                {
                    return t;
                }
            }
            return null;
        }

        public static List<ScriptableObject> FindAllScriptableObject(string[] searchInFolders = null) 
        {
            if (searchInFolders == null)
            {
                searchInFolders = new string[] { "Assets" };
            }
            var assetGUID = AssetDatabase.FindAssets("t:ScriptableObject", searchInFolders);
            List<ScriptableObject> list = new List<ScriptableObject>(assetGUID.Length);
            foreach (var item in assetGUID)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(item);
                var obj = AssetDatabase.LoadMainAssetAtPath(assetPath);
                if (obj is ScriptableObject so)
                {
                    list.Add(so);
                }
            }
            return list;
        }


        ///// <summary>
        ///// 检查资源是否存在
        ///// </summary>
        ///// <typeparam name="T">资源类型 例如:ScriptableObject MonoScript...</typeparam>
        ///// <param name="assetType">资源的类型</param>
        ///// <param name="filter">查找过滤条件 例如:t:GameObject</param>
        ///// <returns></returns>
        //public static T CheckAssetExists<T>(System.Type assetType, string filter = null) where T : Object
        //{
        //    List<T> listResult = FindAllAssets<T>(filter);
        //    var target = listResult.Find(item => item.GetType() == assetType);
        //    return target;
        //}
    }
}