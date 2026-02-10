using UnityEngine;
using UnityEngine.Tilemaps;

public class ZoneTilemapPlacer : MonoBehaviour
{
    [Header("Références aux Tilemaps")]
    public Tilemap playerZoneTilemap;
    public Tilemap enemyZoneTilemap;

    [Header("Tiles (assets)")]
    public TileBase JoueurCol;  
    public TileBase EnnemyCol;  

    [Header("Paramètres de placement")]
    public Vector2Int playerZoneStart = new Vector2Int(0, 0);
    public Vector2Int playerZoneSize = new Vector2Int(18, 14);
    public Vector2Int enemyZoneStart = new Vector2Int(0, 15);
    public Vector2Int enemyZoneSize = new Vector2Int(18, 14);

    [ContextMenu("Remplir les zones")]
    public void FillZones()
    {
        if (playerZoneTilemap == null || enemyZoneTilemap == null)
        {
            Debug.LogError("⚠️ Les Tilemaps ne sont pas assignées !");
            return;
        }

        ClearZones();

        FillArea(playerZoneTilemap, JoueurCol, playerZoneStart, playerZoneSize);
        FillArea(enemyZoneTilemap, EnnemyCol, enemyZoneStart, enemyZoneSize);

        Debug.Log("✅ Zones placées avec succès !");
    }

    [ContextMenu("Effacer les zones")]
    public void ClearZones()
    {
        if (playerZoneTilemap != null) playerZoneTilemap.ClearAllTiles();
        if (enemyZoneTilemap != null) enemyZoneTilemap.ClearAllTiles();
        Debug.Log("🧹 Zones effacées.");
    }

    private void FillArea(Tilemap tilemap, TileBase tile, Vector2Int start, Vector2Int size)
    {
        if (tile == null)
        {
            Debug.LogWarning($"⚠️ Pas de tile assignée pour {tilemap.name}");
            return;
        }

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3Int pos = new Vector3Int(start.x + x, start.y + y, 0);
                Vector3 posInWorld = new Vector3(pos.x * 0.64f, pos.y * 0.64f, 0);
                tilemap.SetTile(pos, tile); 
            }
        }
    }
}
