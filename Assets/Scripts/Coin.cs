using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Count
            var playerObject = other.GetComponent<Player>();

            playerObject.AddCoin();

            // Play sound
            
            Destroy(this.gameObject);
        }
    }
}
