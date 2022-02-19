using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDot : MonoBehaviour
{
    float x0 = -13f; float y0 = 20.5f;
    string[] lines = System.IO.File.ReadAllLines("./Assets/Scripts/Map.txt"); 
    [SerializeField]
    GameObject _smallDot;
    // Start is called before the first frame update
    void Start()
    {
        int height = lines.Length;
        int width = lines[0].Length;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
                if (lines[y][x] == ' ')
                {
                    
                    Vector2 pos = new Vector2(x0 + x, y0 - y);
                    Instantiate(_smallDot, pos,transform.rotation);
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
