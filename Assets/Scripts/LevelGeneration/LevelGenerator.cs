using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Chunk m_StartChunk;
    [SerializeField] private List<Chunk> m_ChunkPrefabs;
    [SerializeField] private int m_ChunksCount;

    private List<Chunk> m_Chunks;

    public List<Chunk> Chunks => m_Chunks;

    public void Init()
    {
        m_Chunks = new List<Chunk>();
        m_Chunks.Add(m_StartChunk);

        for (int i = 0; i < m_ChunksCount - 1; i++)
            CreateAndConnect();
    }

    private void CreateAndConnect()
    {
        Chunk newChunk = CreateNewChunk();

        ConnectChunks(m_Chunks.Last(), newChunk);

        m_Chunks.Add(newChunk);
    }

    private void ConnectChunks(Chunk oldChunk, Chunk newChunk)
    {
        newChunk.transform.eulerAngles = new Vector3(0, 0, oldChunk.End.eulerAngles.z);
        newChunk.transform.position += oldChunk.End.position - newChunk.Start.position;
    }

    private Chunk CreateNewChunk()
    {
        Chunk chunk = Instantiate(m_ChunkPrefabs[Random.Range(0, m_ChunkPrefabs.Count)]);
        chunk.Init();

        ChangeWallsSprites(chunk);

        return chunk;
    }

    private void ChangeWallsSprites(Chunk chunk)
    {
        float procent = 1 - ((PlayerData.GameLength / 5f) * PlayerData.Level - PlayerData.FallingDistance) / (PlayerData.GameLength / 5f);
        Debug.Log("Procent - " + procent);

        List<Sprite> wallSprites = new List<Sprite>();
        List<Sprite> backWallSprites = new List<Sprite>();

        int wallsSpritesCount = (int)(15 * procent);
        int backWallsSpritesCount = (int)(10 * procent);

        for (int i = 0; i < wallsSpritesCount; i++)
        {
            wallSprites.Add(PlayerData.NextLevelConfig.WallsSprites[Random.Range(0, PlayerData.NextLevelConfig.WallsSprites.Count)]);
        }
        for (int i = 0; i < 15 - wallsSpritesCount; i++)
        {
            wallSprites.Add(PlayerData.LevelConfig.WallsSprites[Random.Range(0, PlayerData.LevelConfig.WallsSprites.Count)]);
        }

        for (int i = 0; i < backWallsSpritesCount; i++)
        {
            backWallSprites.Add(PlayerData.NextLevelConfig.BackWallsSprites[Random.Range(0, PlayerData.NextLevelConfig.BackWallsSprites.Count)]);
        }
        for (int i = 0; i < 10 - backWallsSpritesCount; i++)
        {
            backWallSprites.Add(PlayerData.LevelConfig.BackWallsSprites[Random.Range(0, PlayerData.LevelConfig.BackWallsSprites.Count)]);
        }

        foreach (var wall in chunk.Walls)
        {
            wall.Sprites.Clear();
            wall.Sprites.AddRange(wallSprites);
        }

        foreach (var backWall in chunk.BackWalls)
        {
            backWall.Sprites.Clear();
            backWall.Sprites.AddRange(backWallSprites);
        }
    }

    private void FixedUpdate()
    {
        if (m_Chunks[0].IsEnded)
        {
            Destroy(m_Chunks[0].gameObject);
            m_Chunks.RemoveAt(0);

            CreateAndConnect();
        }
    }
}
