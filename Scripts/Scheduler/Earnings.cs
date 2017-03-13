using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earnings : MonoBehaviour {

    public float moneyPerSecond = 0;

    public float energyPerSecond = 0;

    public float buildingTimeImprovement = 0;

    private PlayerSetupDefinition playerInfo;

	// Use this for initialization
	void Start ()
    {
        playerInfo = GetComponent<Player>().info;
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerInfo.money += moneyPerSecond * Time.deltaTime;
        playerInfo.energy += energyPerSecond * Time.deltaTime;
    }
}
