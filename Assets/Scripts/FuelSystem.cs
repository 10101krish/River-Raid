using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    private GameManager gameManager;

    private bool overFuelBarrel = false;

    public float fuelLeft;
    public float maxFuel = 100;
    public float minFuel = 0;

    public float fuelBurnRate = 1;
    public float fuelReplishmentRate = 15;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        fuelLeft = maxFuel;
    }

    private void Update()
    {
        if (overFuelBarrel)
            fuelLeft = Mathf.Clamp(fuelLeft + fuelReplishmentRate * Time.deltaTime, minFuel, maxFuel);
        else
            fuelLeft = Mathf.Clamp(fuelLeft - fuelBurnRate * Time.deltaTime, minFuel, maxFuel);
        
        if (fuelLeft <= 0)
            gameManager.FuelDepleted();
    }

    public void EnteredFuelBarrel()
    {
        overFuelBarrel = true;
    }

    public void ExitedFuelBarrel()
    {
        overFuelBarrel = false;
    }
}
