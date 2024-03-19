using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public int score;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public GameObject infoText;
    private Vector3 reset;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        infoText.SetActive(false);
        reset = transform.position;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString() + " of the 30"; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Respawn")) 
        {
            transform.position = reset;
            movementX = 0.0f;
            movementY = 0.0f;
            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
        }
        if (other.gameObject.CompareTag("Checkpoint")) 
        {
            reset = transform.position;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Sign")) 
        {
            infoText.SetActive(true);
        }
        if (other.gameObject.CompareTag("Finish")) 
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
