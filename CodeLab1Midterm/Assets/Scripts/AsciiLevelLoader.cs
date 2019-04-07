﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + "/Level0.txt";
        if(!File.Exists(filePath))
            File.WriteAllText(filePath,"X");

        string[] NumOfLines = File.ReadAllLines(filePath);
        
        for (int y = 0; y < NumOfLines.Length; y++)
        {
            string line = NumOfLines[y];
            for (int x = 0; x < line.Length; x++)
            {
                GameObject tile;
                switch (line[x])
                {
                    case 'X':
                        tile = Instantiate(Resources.Load("Prefabs/Wall"), transform) as GameObject;
                        break;
                    case 'P':
                        tile = Instantiate(Resources.Load("Prefabs/Player"), transform) as GameObject;
                        break;
                    case 'E':
                        tile = Instantiate(Resources.Load("Prefabs/Enemy"), transform) as GameObject;
                        break;
                    case 'G':
                        tile = Instantiate(Resources.Load("Prefabs/Ground"), transform) as GameObject;
                        break;
                    default:
                        tile = null;
                        break;
                    
                }

                if (tile != null)
                    tile.transform.position =Vector3.zero + Vector3.right * (x-line.Length/2) + -Vector3.up * (y-NumOfLines.Length/2) + Vector3.forward * 3f;
                

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
