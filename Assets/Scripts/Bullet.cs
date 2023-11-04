using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float verticalSpeed;

    public void SetVerticalSpeed(float verticalSpeed)
    {
        this.verticalSpeed = verticalSpeed;
    }

    private void Update()
    {
        transform.position = transform.position + Vector3.up * verticalSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        Destroy(gameObject);
    }
}
