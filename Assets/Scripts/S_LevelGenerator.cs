using UnityEngine;

public class S_LevelGenerator : MonoBehaviour
{
    public bool generateOnStart = true; // Flag to determine if level should be generated on start
    public bool regenerate = false; // Flag to determine if level should be regenerated every frame

    public static S_LevelGenerator Instance { get; private set; } // Singleton instance


    //Generation variables
    public int matrixSizeX; // Size of the level in the X direction
    public int matrixSizeY; // Size of the level in the Y direction
    public GameObject[][] levelMatrix; // Matrix to represent the level layout
    private string[][] levelMatrixNames; // Matrix to store the names of the level pieces for debugging or reference
    public GameObject[] roomPrefabs; // Array of room prefabs to instantiate

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

        roomPrefabs = Resources.LoadAll<GameObject>("ReadyRooms"); // Load all room prefabs from the specified folder

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
        // Implement level generation logic here
        levelMatrix = new GameObject[matrixSizeX][]; // Initialize the level matrix
        levelMatrixNames = new string[matrixSizeX][]; // Initialize the level matrix names

        for (int x = 0; x < matrixSizeX; x++)
        {
            levelMatrix[x] = new GameObject[matrixSizeY];
            levelMatrixNames[x] = new string[matrixSizeY];
        }



    }

}
