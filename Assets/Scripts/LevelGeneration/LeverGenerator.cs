using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeverGenerator : MonoBehaviour
{

    [SerializeField] float m_GameLength;


    [SerializeField] Chunk m_StartChunk;
    [SerializeField] List<Chunk> m_ChunkPrefabs;

    List<Chunk> m_Chunks;

    int m_ChunksCount = 6;

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
            CreateAndConnect();
        }
    }
    void CreateAndConnect()
    {
        var c = CreateNewChunk();

        ConnectChunks(m_Chunks.Last(), c);

        m_Chunks.Add(c);
    }
    void ConnectChunks(Chunk oldChunk, Chunk newChunk)
    {
        newChunk.transform.eulerAngles = new Vector3(0, 0, oldChunk.End.eulerAngles.z);
        newChunk.transform.position += oldChunk.End.position - newChunk.Start.position;
    }
    Chunk CreateNewChunk()
    {
        var chunk = Instantiate(m_ChunkPrefabs[Random.Range(0, m_ChunkPrefabs.Count)]);

        return chunk;
    }

    void FixedUpdate()
    {
        if (m_Chunks[0].IsEnded)
        {
            Destroy(m_Chunks[0].gameObject);
            m_Chunks.RemoveAt(0);
            CreateAndConnect();
        }
    }
}
