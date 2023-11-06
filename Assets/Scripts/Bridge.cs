using UnityEngine;

public class Bridge : MonoBehaviour
{
    private GameManager gameManager;

    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Bullet")))
        {
            spriteRenderer.enabled = false;
            boxCollider2D.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Camera Boundary Front")))
        {
            gameManager.SpawnNewLevel(transform.position);
        }
        else if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Camera Boundary Back")))
        {
            gameManager.DestroyPreviousLevel();
        }
        
    }
}
