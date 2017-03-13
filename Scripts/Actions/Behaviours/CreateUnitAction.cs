using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateUnitAction : ActionBehavior
{
    public string unitName;

    public float maxHealth = 100;

    public float Cost = 0;

    public float trainingTime = 0;

    public bool fly = false;

    public GameObject prefab;

    private PlayerSetupDefinition info;
    
    private UnitDefinition _unitInfo;
    
    void Start()
    {
        info = GetComponent<Player>().info;
        showOnSelect = true;
    }
    
    public override Action getClickAction()
    {
        return delegate () {
            if (info.money < Cost)
            {
                Debug.Log("Cannot Create, It costs " + Cost);
                return;
            }

            float buildFactor = (1 - info.buildTime) > 0.2 ? (1 - info.buildTime) : 0.2f;
            float currentTrainingTime = trainingTime * buildFactor;
            UnitInfoManager.current.addUnitInfo(new UnitDefinition(unitName, maxHealth, currentTrainingTime, 0, buildFactor));
            StartCoroutine(build(currentTrainingTime));
        };
    }

    IEnumerator build(float time)
    {
        info.money -= Cost;
        yield return new WaitForSeconds(time);
        build();
    }

    private void build()
    {
        var go = (GameObject)GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
        go.AddComponent<Player>().info = info;
        go.AddComponent<RightClickNavigation>().fly = fly;
        go.AddComponent<ActionSelect>();
    }
}
