using UnityEngine;

public class AirEnemy : MonoBehaviour
{
    private GameManager gameManager;

    public float horizontalSpeed = 2f;
    public int direction = 1;

    public int score = 100;

    private new Camera camera;
    private float leftMargin;
    private float rightMargin;

    private void Awake()
    {
        camera = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        leftMargin = camera.ViewportToWorldPoint(Vector3.zero).x - 1;
        rightMargin = camera.ViewportToWorldPoint(Vector3.right).x + 1;
    }

    private void Update()
    {
        transform.position += direction * horizontalSpeed * Time.deltaTime * Vector3.right;
        if (transform.position.x <= leftMargin || transform.position.x >= rightMargin)
        {
            direction *= -1;
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Bullet")))
        {
            gameManager.BulletCollidedWithObstacle(score);
            Destroy(gameObject);
        }
    }
}
