using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterTile : Tile {
    [SerializeField]
    private Sprite[] waterSprites;

    [SerializeField]
    private Sprite preview;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {//make sure we refresh all the tiles
        for(int y = -1; y <= 1; y++)//check all your neighbors
        {
            for(int x = -1; x <= 1; x++)
            {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);

            }

        }
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {//change tile data for us when you refresh a tile
        tileData.sprite = waterSprites[0];
    }
    



#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/WaterTile")]
    public static void CreateWaterTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Watertile", "New Watertile", "asset", "Save watertile", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WaterTile>(), path);
    }
#endif
}
