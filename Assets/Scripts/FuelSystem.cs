using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    private GameManager gameManager;

    public bool overFuelBarrel = false;

    public float fuelLeft;
    public float maxFuel = 100;
    public float minFuel = 0;

    public float fuelBurnRate = 1;
    public float fuelReplishmentRate = 15;

    public Text fuelText;
    public GameObject fuelGuage;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        fuelLeft = maxFuel;
        InvokeRepeating(nameof(UpdateFuelLeft), 1, 1);
    }

    private void Update()
    {
        if (fuelLeft <= 0)
            gameManager.FuelDepleted();
    }

    private void UpdateFuelLeft()
    {
        if (overFuelBarrel)
            fuelLeft = Mathf.Clamp(fuelLeft + fuelReplishmentRate, minFuel, maxFuel);
        else
            fuelLeft = Mathf.Clamp(fuelLeft - fuelBurnRate, minFuel, maxFuel);
        // if (overFuelBarrel)
        //     fuelLeft = Mathf.Clamp(fuelLeft + fuelReplishmentRate * Time.deltaTime, minFuel, maxFuel);
        // else
        //     fuelLeft = Mathf.Clamp(fuelLeft - fuelBurnRate * Time.deltaTime, minFuel, maxFuel);
        UpdateFuelDisplay();
    }

    public void EnteredFuelBarrel()
    {
        overFuelBarrel = true;
    }

    public void ExitedFuelBarrel()
    {
        overFuelBarrel = false;
    }

    private void UpdateFuelDisplay()
    {
        UpdateFuelText();
        UpdateFuelGauge();
    }

    private void UpdateFuelText()
    {
        fuelText.text = fuelLeft.ToString();
    }

    private void UpdateFuelGauge()
    {
        Vector3 newScale = new Vector3(fuelLeft / 100f, 1, 1);
        fuelGuage.transform.localScale = newScale;

        float newPosX = -1 * (100 - fuelLeft) / 2;
        Vector3 newPosition = new Vector3(newPosX ,fuelGuage.transform.localPosition.y, fuelGuage.transform.localPosition.z);
        fuelGuage.transform.localPosition = newPosition;
    }
}
