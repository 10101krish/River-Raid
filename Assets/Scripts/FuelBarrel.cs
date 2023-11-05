using UnityEngine;

public class FuelBarrel : MonoBehaviour
{
    public int score = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Bullet")))
        {
            Debug.Log("Hit by Bullet");
            Destroy(gameObject);
        }
    }
}
