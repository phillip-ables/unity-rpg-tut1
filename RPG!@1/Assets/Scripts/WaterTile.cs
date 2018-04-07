using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterTile : Tile {
    [SerializeField]
    private Sprite[] waterSprites;

    [SerializeField]
    private Sprite preview;

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/WaterTile"]
    public static void CreateWaterTile()
    {
        //create a path inside our project
        string path = EditorUtility.SaveFilePanelInProject("Save Watertile", "New Watertile", "asset", "Save watertile", "Assets");
        if(path == "")
        {
            return;
        }
        //if path exist we create the asset in our asset folder
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WaterTile>(), path)
    }
#endif
}
