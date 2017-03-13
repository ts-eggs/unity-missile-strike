using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBuild: AiBehavior
{
    public AiController controller;

    private PlayerSetupDefinition playerInfo;

    internal GameObject prefab;
    
    public AiBuild(AiController c)
    {
        controller = c;
    }
    
    void Start()
    {
        weightMultiplier = 1;
        timePassed = 0;
    }

    public override void execute(PlayerSetupDefinition info)
    {
        playerInfo = info;
        obsolete = true;

        float buildFactor = (1 - info.buildTime) > 0.2 ? (1 - info.buildTime) : 0.2f;
        float currentTrainingTime = prefab.GetComponent<CreateBuildingAction>().buildingTime * buildFactor;
        StartCoroutine(build(currentTrainingTime));
    }

    public override float getWeight()
    {
        return 100;
    }

    IEnumerator build(float time)
    {
        playerInfo.money -= prefab.GetComponent<CreateBuildingAction>().cost;
        yield return new WaitForSeconds(time);
        build();
    }

    private void build()
    {
        var go = (GameObject) GameObject.Instantiate(prefab);
        go.transform.position = controller.buildPos;
        go.AddComponent<Player>().info = playerInfo;
        go.GetComponent<MarkColor>().playerInfo = playerInfo;

        var cba = go.GetComponent<CreateBuildingAction>();
        playerInfo.availableBuildings.AddRange(cba.newBuildings);
        controller.setBuildingBehaviours(cba.removeOnCreate, this);
    }
}
