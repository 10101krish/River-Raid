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
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Fuel")) || other.gameObject.layer.Equals(LayerMask.NameToLayer("Camera Boundary Front")))
            Destroy(gameObject);
    }
}
