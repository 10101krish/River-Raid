using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform startingPositionTransform;

    private new Camera camera;
    private Vector3 cameraDistanceFromCheckPoint;

    private Player player;
    private Vector3 playerDistanceFromCheckPoint;

    private Vector3 lastCheckPoint;

    private FuelSystem fuelSystem;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        fuelSystem = FindObjectOfType<FuelSystem>();
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

    public void PlayerNowOverFuelBarrel()
    {
        fuelSystem.EnteredFuelBarrel();
    }

    public void PlayerNolongOverFuelBarrel()
    {
        fuelSystem.ExitedFuelBarrel();
    }

    public void FuelDepleted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
