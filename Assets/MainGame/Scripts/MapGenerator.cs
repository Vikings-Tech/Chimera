using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MapGenerator : MonoBehaviour
{

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public bool autoUpdate;
    [SerializeField]
    List<GameObject> treePrefab;

    private void Start()
    {
        mapWidth = 160;
        mapHeight = 160;
        GenerateMap();
    }

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, 0.00007f);
        for (int i = 0; i < mapWidth; i += 2)
        {
            for (int j = 0; j < mapHeight; j += 2)
            {
                if (noiseMap[i, j] > 0.4f)
                {
                    GameObject clone = Instantiate(treePrefab[(i + j) % 8], new Vector3(80 - i, 2, 80 - j), Quaternion.identity, gameObject.transform);
                    clone.transform.eulerAngles = new Vector3(-90, clone.transform.eulerAngles.y, clone.transform.eulerAngles.z);
                }
            }
        }
    }

}