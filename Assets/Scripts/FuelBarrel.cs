using UnityEngine;

public class FuelBarrel : MonoBehaviour
{
    private GameManager gameManager;

    public int score = 100;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Bullet")))
        {
            gameManager.BulletCollidedWithObstacle(score);
            Destroy(gameObject);
        }
    }
}
