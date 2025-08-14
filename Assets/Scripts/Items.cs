using UnityEngine;

public class Items : MonoBehaviour
{
    void Start()
    {
        // Initialize item settings if needed
        Debug.Log("Item initialized: " + name);
    }

    void Update()
    {
        // Handle item behavior if necessary
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Item " + name + " picked up!");
            // Implement logic for item pickup
            Destroy(gameObject); //Certain items may be destroyed after a certain time
        }
    }
}
