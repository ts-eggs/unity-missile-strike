using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

    public float confustion = 0.3f;

    public float frequency = 3;

    public PlayerSetupDefinition playerInfo;

    private float waited = 0;

    internal Vector3 buildPos = new Vector3();

    private int buildPosChangeDirection = 0;

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AiBuildBase>().controller = this;
        buildPos = playerInfo.location.position;
        buildPos.y += 1;
    }
	
	// Update is called once per frame
	void Update () {
        waited += Time.deltaTime;

        if(waited < frequency)
        {
            return;
        }

        float bestAiValue = float.MinValue;
        AiBehavior bestAi = null;

        foreach(var ai in gameObject.GetComponents<AiBehavior>())
        {
            if (ai.obsolete)
            {
                continue;
            }

            if(ai is AiBuild && ((AiBuild)ai).prefab.GetComponent<CreateBuildingAction>().cost > playerInfo.money)
            {
                continue;
            }

            ai.timePassed += waited;
            var aiValue = ai.getWeight() * ai.weightMultiplier + Random.Range(0, confustion);
            
            if (aiValue> bestAiValue)
            {
                bestAiValue = aiValue;
                bestAi = ai;
            }
        }
        
        if (bestAi != null)
        {
            bestAi.execute(playerInfo);
            waited = 0;
        }
	}

    public void setBuildingBehaviours(bool removeOnDelete, AiBehavior removeBehaviour)
    {
        if (removeOnDelete && removeBehaviour != null)
        {
            Destroy(removeBehaviour);
        }
        
        foreach (var b in playerInfo.availableBuildings)
        {
            addBehaviour(b.name);
        }

        if(buildPosChangeDirection == 0)
        {
            buildPos.x += 5;
            buildPosChangeDirection = 1;
        }
        else if (buildPosChangeDirection == 1)
        {
            buildPos.z += 5;
            buildPosChangeDirection = 0;
        }
    }

    private void addBehaviour(string buildingName)
    {
        switch (buildingName)
        {
            case "Bank":
                if (gameObject.GetComponent<AiBuildBank>() == null)
                {
                    gameObject.AddComponent<AiBuildBank>().controller = this;
                }

                break;
            case "Factory":
                if (gameObject.GetComponent<AiBuildFactory>() == null)
                {
                    gameObject.AddComponent<AiBuildFactory>().controller = this;
                }

                break;
            case "Power":
                if (gameObject.GetComponent<AiBuildPower>() == null)
                {
                    gameObject.AddComponent<AiBuildPower>().controller = this;
                }

                break;
            case "Radar":
                if (gameObject.GetComponent<AiBuildRadar>() == null)
                {
                    gameObject.AddComponent<AiBuildRadar>().controller = this;
                }

                break;
        }
    }
}
