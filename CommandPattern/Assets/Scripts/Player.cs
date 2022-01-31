using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float gravityScale = 5f;
    public float speed = 6f;

    public Rigidbody player;
    public CommandInvoker invoker;
    public Vector3 jump;

    public bool isGrounded;
    public bool hasCheat = false;

    private int keys;
    public GameState gameState;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f,2.0f,0.0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.MovePosition(transform.position + dir * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCheat)
        {
            if (collision.gameObject.tag == "Water" || collision.gameObject.tag == "Fire" || collision.gameObject.tag == "enemy")
            {
                invoker.ResetScene();
                SceneManager.LoadScene("Game");
            }
        }
        
        if (collision.gameObject.tag == "Key")
        {
            keys++;
            gameState.notify(0);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "door")
        {
            if(keys == 2 || hasCheat)
            {
                SceneManager.LoadScene("Win");
            }
               
        }

        if (collision.gameObject.tag == "cheat")
        {
            hasCheat = true;
            Destroy(collision.gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ResetTag")
        {
            gameState.notify(0);
            invoker.ResetCommand();
        }
        if(other.gameObject.tag == "ResetTag1")
        {
            gameState.notify(1);
            invoker.ResetCommand();
        }
    }
}
