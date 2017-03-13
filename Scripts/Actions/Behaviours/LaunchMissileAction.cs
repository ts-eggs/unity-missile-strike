using System;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMissileAction : ActionBehavior
{
    public GameObject missilePrefab;

    public GameObject positionPrefab;

    public MissileDefinition missileDefinition;
    
    public override Action getClickAction()
    {
        return delegate ()
        {
            var playerInfo = Player.Default;

            if(missileDefinition == null)
            {
                missileDefinition = new MissileDefinition("missile", 10, 100, 3, 0.03f, 50);
            }

            if(playerInfo.energy < missileDefinition.cost)
            {
                Debug.Log("Not enough energy, this costs: " + missileDefinition.cost);
                return;
            }

            var go = GameObject.Instantiate(positionPrefab);
            var finder = go.AddComponent<FindLaunchPosition>();
            finder.missilePrefab = missilePrefab;
            finder.info = playerInfo;
            finder.missileDefinition = missileDefinition;
        };
    }
}
