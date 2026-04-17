using UnityEngine;

public class S_LevelPiece : MonoBehaviour
{
    public string pieceName; // Name of the level piece
    public bool[] pieceConnections = new bool[4]; // Array to represent connections (North, South, East, West)
    public GameObject northConnection; // Reference to the north connection point
    public GameObject southConnection; // Reference to the south connection point
    public GameObject eastConnection; // Reference to the east connection point
    public GameObject westConnection; // Reference to the west connection point

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
