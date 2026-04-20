using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class S_LevelGenerator : MonoBehaviour
{
    public bool generateOnStart = true; // Flag to determine if level should be generated on start
    public bool regenerate = false; // Flag to determine if level should be regenerated every frame

    public static S_LevelGenerator Instance { get; private set; } // Singleton instance

    public List<GameObject> possibleLayouts;
    public GameObject currentLayout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Implementing Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

    }

    // Update is called once per frame
    void Start()
    {
        if (generateOnStart)
        {
            GenerateLevel();
        }



    }

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
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        currentLayout = GameObject.Instantiate(possibleLayouts[Random.Range(0, possibleLayouts.Count)]);
        currentLayout.transform.parent = this.transform;


    }

}
