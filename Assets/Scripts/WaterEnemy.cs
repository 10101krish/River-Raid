using UnityEngine;

public class WaterEnemy : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    public int direction = 1;

    public int score = 100;

    private void Update()
    {
        transform.position += direction * horizontalSpeed * Time.deltaTime * Vector3.right;
    }

    public int GetHitScore()
    {
        return score;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            direction *= -1;
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
        else
        {
            if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Bullet")))
                Debug.Log("Hit by Bullet");
            Destroy(gameObject);
        }
    }
}
