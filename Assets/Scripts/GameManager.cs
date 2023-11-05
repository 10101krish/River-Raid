using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform startingPositionTransform;

    private new Camera camera;
    private Vector3 cameraDistanceFromCheckPoint;

    private Player player;
    private Vector3 playerDistanceFromCheckPoint;

    private Vector3 lastCheckPoint;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        camera = Camera.main;
    }

    private void Start()
    {
        lastCheckPoint = startingPositionTransform.position;
        cameraDistanceFromCheckPoint = camera.transform.position - startingPositionTransform.position;
        playerDistanceFromCheckPoint = player.transform.position - startingPositionTransform.position;
        player.ResetPlayer(lastCheckPoint + playerDistanceFromCheckPoint, lastCheckPoint + cameraDistanceFromCheckPoint);
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
        player.ResetPlayer(lastCheckPoint + playerDistanceFromCheckPoint, lastCheckPoint + cameraDistanceFromCheckPoint);
    }
}
