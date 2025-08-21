using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast to move the boss in random directions
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
        {
            // If the raycast hits something, move the boss towards that direction
            Vector3 targetPosition = hit.point;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);
        }
        else
        {
            // If nothing is hit, move the boss in a random direction
            Vector3 randomDirection = Random.insideUnitSphere * 5f;
            transform.position += randomDirection * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Boss activated!");
            // Implement logic for boss activation
            Destroy(gameObject); //Certain bosses may be destroyed after a certain time
        }
    }
}
