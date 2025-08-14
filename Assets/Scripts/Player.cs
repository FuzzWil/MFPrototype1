using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI CharacterName; // Name of the player
    // public TextMeshProUGUI CharacterCombo; // Score of the player
    public TextMeshProUGUI CharacterHealth; // Health of the player
    public TextMeshProUGUI CharacterAttackPower; // Attack power of the player

    private string playerName = "Kailo"; // Name of the player, can be set in the Inspector
    [SerializeField] //will be visible in the Unity Inspector
    private float playerMaxHealth = 100f; // Maximum health of the player
    [SerializeField] //will be visible in the Unity Inspector
    private float playerHealth = 100f; // Current health of the player, initialized to maximum health
    [SerializeField] //will be visible in the Unity Inspector
    private float playerAttackPower = 10f; // Attack power of the player
    [SerializeField] //will be visible in the Unity Inspector
    
    // private float playerCombo = 0f; // Score of the player
    // [SerializeField] //will be visible in the Unity Inspector

    private float speed = 5f; // Speed of the player movement
    [SerializeField] //will be visible in the Unity Inspector
    private float jumpForce = 100f; // Force applied when the player jumps
    [SerializeField] //will be visible in the Unity Inspector
    private bool isGrounded = true;

    Rigidbody rb; // Handle physics interactions

    void Start()
    {
        // Initialize player settings if needed
        Debug.Log("Player initialized with speed: " + speed);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Handle player jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply an upward force for jumping
        }

        // Update player UI elements
        CharacterName.text = playerName;
        // CharacterCombo.text = "Combo: " + playerCombo.ToString();
        CharacterHealth.text = playerMaxHealth.ToString();
        // Update player health UI
        if (playerHealth <= 0)
        {
            CharacterHealth.text = "0";
            Debug.Log("Player is dead!");
            // Implement logic for player death, e.g., respawn or game over
        }
        else
        {
            CharacterHealth.text = playerHealth.ToString();
        }
        CharacterAttackPower.text = playerAttackPower.ToString();
    }
    
    void FixedUpdate()
    {
        // Handle player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new(moveHorizontal, 0.0f, moveVertical);

        movement = movement.normalized * speed * Time.deltaTime; // Normalize movement vector to ensure consistent speed in all directions
        transform.Translate(movement); // Move the player based on input

        // Prevent the player from sliding when colliding with objects
        rb.linearVelocity = Vector3.zero; // Reset velocity to prevent sliding
    }

    private void OnCollisionEnter(Collision collisionWtih)
    {
        // Handles collision with other objects
        if (collisionWtih.gameObject.CompareTag("ItemPickup"))
        {
            Debug.Log("Player found an item!");
        }

        if (collisionWtih.gameObject.CompareTag("ItemCollectible"))
        {
            Debug.Log("Player collected an item!");
            // Implement logic for item collection, e.g., increase score or inventory
            Destroy(collisionWtih.gameObject); // Destroy the item after collection
        }

        // Check if the player has landed back on the ground
        if (collisionWtih.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is back on the ground
            Debug.Log("Player is grounded.");
        }
    }

    private void OnCollisionExit(Collision collisionWtih)
    {
        // Handles the player stops colliding with pickup items
        if (collisionWtih.gameObject.CompareTag("ItemPickup"))
        {
            Debug.Log("Player left the item.");
        }

        // Check if the player has left the ground
        if (collisionWtih.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is in the air
            Debug.Log("Player is no longer grounded.");
        }
    }

}
