using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Camera camera;
    private GameManager gameManager;

    public float movementSpeed = 2f;
    public Vector3 direction = Vector3.zero;
    public float anglechange = 35f;

    public float verticalSpeed = 0f;
    public float verticalSpeedAtRespawn = 0.2f;
    public float manualVerticalSpeedChangeFactor = 0.5f;
    public float automaticVerticalSpeedChangeFactor = 0.25f;

    public float maxVerticalSpeed = 1.5f;
    public float minVerticalSpeed = 0f;

    public GameObject bulletPrefab;
    public float bulletVerticalSpeed = 10f;

    private void Awake()
    {
        camera = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            FireBullet();
        CheckMovementInput();
        UpdatePosition();
        UpdateRotation();
    }

    private void CheckMovementInput()
    {
        direction.x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        verticalSpeed += Input.GetAxis("Vertical") * manualVerticalSpeedChangeFactor * Time.deltaTime;
        verticalSpeed += automaticVerticalSpeedChangeFactor * Time.deltaTime;
        verticalSpeed = Mathf.Clamp(verticalSpeed, minVerticalSpeed, maxVerticalSpeed);
    }

    private void UpdatePosition()
    {
        direction.y = verticalSpeed * Time.deltaTime;
        camera.transform.position += Time.deltaTime * verticalSpeed * Vector3.up;
        transform.position += direction;
    }

    private void UpdateRotation()
    {
        if (direction.x > 0)
            transform.eulerAngles = anglechange * Vector3.up;
        else if (direction.x < 0)
            transform.eulerAngles = -1 * anglechange * Vector3.up;
        else
            transform.eulerAngles = 0 * Vector3.up;
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.up * 0.75f, quaternion.identity);
        bullet.GetComponent<Bullet>().SetVerticalSpeed(bulletVerticalSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameManager.PlayerCollidedWithObstacle();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Bridge")))
            gameManager.SetCheckPoint(other.gameObject.transform.position);
    }

    public void ResetPlayer(Vector3 playerPosition, Vector3 cameraPosition)
    {
        gameObject.transform.position = playerPosition;
        camera.transform.position = cameraPosition;
        verticalSpeed = verticalSpeedAtRespawn;
    }
}
