using UnityEngine;

public class Player : MonoBehaviour
{
    public new Camera camera;

    public float movementSpeed = 2f;
    public Vector3 direction = Vector3.zero;
    public float anglechange = 35f;

    public float verticalSpeed = 0f;
    public float manualVerticalSpeedChangeFactor = 0.5f;
    public float automaticVerticalSpeedChangeFactor = 0.25f;

    public float maxVerticalSpeed = 1.5f;
    public float minVerticalSpeed = 0f;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        CheckInput();
        UpdatePosition();
        UpdateRotation();
    }

    private void CheckInput()
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
}
