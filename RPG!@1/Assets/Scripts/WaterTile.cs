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


                if (HasWater(tilemap, nPos))
                {
                    tilemap.RefreshTile(nPos);
                }
            }

        }
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {//change tile data for us when you refresh a tile
        string composition = string.Empty;

        for ( int x = -1; x <= 1; x++)
        {
            for (int y=-1; y <= 1; y++)
            {
                if (HasWater(tilemap, new Vector3Int(position.x + x, position.y + y, position.z))
                {
                    composition += 'W';
                }
                else
                {
                    composition += 'E';
                }
            }
        }


        tileData.sprite = waterSprites[0];
    }

    private bool HasWater(ITilemap tilemap, Vector3Int position)
    {


        return tilemap.GetTile(position) == this;
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
