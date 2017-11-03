using UnityEditor;
using UnityEngine;

public class AddMission
{
    [MenuItem("Mission/Add mission")]
    [MenuItem("Assets/Mission/Add mission")]
    public static void CreateNewMission()
    {
        var asset = ScriptableObject.CreateInstance<MissionScriptableObject>();

        AssetDatabase.CreateAsset(asset, "Assets/ScriptableObjects/Missions/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
