using UnityEngine;

public class MovingPlatformsX : MonoBehaviour
{
    private Vector3 pos;
    public float moveDir = 0.1f; // Moved outside of Start() to make it accessible globally
    public float StartPos;
    public float EndPos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x -= moveDir; // Changed 0.1 to moveDir to use the public variable
        transform.position = pos; // Fixed typo in transform
        if (pos.x < EndPos) 
            moveDir = -0.01f; // Added 'f' to ensure it's treated as a float
        if (pos.x > StartPos) 
            moveDir = 0.01f; // Added 'f' to ensure it's treated as a float
    }
}
