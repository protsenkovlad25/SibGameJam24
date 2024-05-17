using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeverGenerator : MonoBehaviour
{
    [SerializeField] Chunk m_StartChunk;
    [SerializeField] List<Chunk> m_ChunkPrefabs;

    List<Chunk> m_Chunks;

    int m_ChunksCount = 5;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        m_Chunks = new List<Chunk>();

        m_Chunks.Add(m_StartChunk);

        for(int i = 0; i< m_ChunksCount-1; i++)
        {
            var c = CreateNewChunk();

            ConnectChunks(m_Chunks.Last(),c);

            m_Chunks.Add(c);
        }
    }
    void ConnectChunks(Chunk oldChunk, Chunk newChunk)
    {
        newChunk.transform.position += newChunk.Start -  oldChunk.End;
    }
    Chunk CreateNewChunk()
    {
        var chunk = Instantiate(m_ChunkPrefabs[Random.Range(0, m_ChunkPrefabs.Count)]);

        return chunk;
    }

    void Update()
    {
        
    }
}
