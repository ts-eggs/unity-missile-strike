using System;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuildingAction : ActionBehavior
{
    public GameObject buildingPrefab;

    public GameObject ghostBuildingPrefab;

    public GameObject constructionPrefab;

    public float maxBuildDistance = 3;

    public float cost = 0;

    public float buildingTime = 5;

    private GameObject active = null;

    public List<GameObject> newBuildings = new List<GameObject>();

    public bool removeOnCreate = false;

    public override Action getClickAction()
    {
        return delegate ()
        {
            var playerInfo = Player.Default;

            if(playerInfo.money < cost)
            {
                Debug.Log("Not enough, this costs: " + cost);
                return;
            }

            var go = GameObject.Instantiate(ghostBuildingPrefab);
            var finder = go.AddComponent<FindBuildingSite>();
            finder.buildingPrefab = buildingPrefab;
            finder.constructionPrefab = constructionPrefab;
            finder.maxBuildDistance = maxBuildDistance;
            finder.info = playerInfo;
            finder.cost = cost;
            finder.buildingTime = buildingTime;
            active = go;
        };
    }
}
