using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // Add this line

public class S_LayoutController : MonoBehaviour
{
    [System.Serializable]
    public class GameObjectList
    {
        public List<GameObject> subList = new List<GameObject>();
    }

    public GameObject[] anchors;
    public List<GameObjectList> possiblePieces;


    public bool generateOnStart = true; // Flag to determine if level should be generated on start
    public bool regenerate = false; // Flag to determine if level should be regenerated every frame

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (generateOnStart)
        {
            GenerateLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (regenerate)
        {
            GenerateLevel();
            regenerate = false; // Reset the flag to prevent continuous regeneration
        }
    }

    void GenerateLevel()
    {
        if (anchors.Length != possiblePieces.Count)
        {
            Debug.Log("anchor list size is not equal to possible piece list size");
            return;
        }
        for (int i = 0; i < anchors.Length; i++)
        {
            int randomIndex = Random.Range(0, possiblePieces[i].subList.Count);
            GameObject pieceToBeInstantiated = possiblePieces[i].subList[randomIndex];
            Debug.Log("selected " + pieceToBeInstantiated.name);
            GameObject.Instantiate(pieceToBeInstantiated, anchors[i].transform, false);
        }
    }

}
