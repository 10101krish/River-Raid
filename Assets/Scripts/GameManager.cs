using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform startingBridgeTransform;
    private Vector3 lastCheckPoint;

    private new Camera camera;
    private Vector3 cameraDistanceFromCheckPoint;

    private Player player;
    private Vector3 playerDistanceFromCheckPoint;

    public GameObject[] levelPrefabs;
    public GameObject previousLevel;
    public GameObject currentLevel;
    public GameObject nextLevel;

    private Vector3 levelDistanceFromCheckPoint;

    private FuelSystem fuelSystem;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        fuelSystem = FindObjectOfType<FuelSystem>();
        camera = Camera.main;
    }

    private void Start()
    {
        lastCheckPoint = startingBridgeTransform.position;
        cameraDistanceFromCheckPoint = camera.transform.position - startingBridgeTransform.position;
        playerDistanceFromCheckPoint = player.transform.position - startingBridgeTransform.position;
        levelDistanceFromCheckPoint = currentLevel.transform.position - startingBridgeTransform.position;
        player.ResetPlayer(lastCheckPoint + playerDistanceFromCheckPoint, lastCheckPoint + cameraDistanceFromCheckPoint);
    }

    public Vector3 GetLastCheckPoint()
    {
        return lastCheckPoint;
    }

    public void SetCheckPoint(Vector3 newCheckPointPosition)
    {
        Debug.Log("Checkpoint Changed");
        lastCheckPoint = newCheckPointPosition;
        previousLevel = currentLevel;
        currentLevel = nextLevel;
    }

    public void PlayerCollidedWithObstacle()
    {
        player.ResetPlayer(lastCheckPoint + playerDistanceFromCheckPoint, lastCheckPoint + cameraDistanceFromCheckPoint);
        DestroyNextLevel();
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

    public void SpawnNewLevel(Vector3 bridgeTransformPosition)
    {
        Vector3 nextLevelPosition = bridgeTransformPosition + levelDistanceFromCheckPoint;
        int randomLevelIndex = UnityEngine.Random.Range(0, levelPrefabs.Length);
        nextLevel = Instantiate(levelPrefabs[randomLevelIndex], nextLevelPosition, quaternion.identity);
    }

    public void DestroyPreviousLevel()
    {
        if (previousLevel)
            Destroy(previousLevel);
    }

    private void DestroyNextLevel()
    {
        if (nextLevel && nextLevel != currentLevel)
            Destroy(nextLevel);
    }
}
