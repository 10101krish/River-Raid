using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 lastCheckPoint;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        lastCheckPoint = new Vector3(0, -7.5f, 0);
        player.ResetPlayer(lastCheckPoint);
    }

    public Vector3 GetLastCheckPoint()
    {
        return lastCheckPoint;
    }

    public void SetCheckPoint(Vector3 newCheckPointPosition)
    {
        lastCheckPoint = newCheckPointPosition;
    }

    public void PlayerCollidedWithObstacle()
    {
        player.ResetPlayer(lastCheckPoint);
    }
}
