using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBuildingSite : MonoBehaviour {
    
    public float maxBuildDistance = 4;

    public float cost = 0;

    public float buildingTime = 5;

    public GameObject buildingPrefab;

    public GameObject constructionPrefab;

    public PlayerSetupDefinition info;

    Renderer rend;
    Color red = new Color(1, 0, 0, 0.5f);
    Color green = new Color(0, 1, 0, 0.5f);

    void Start()
    {
        MouseManager.current.enabled = false;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(this.gameObject);
            return;
        }
          
        var tempTarget = Manager.current.ScreenPointToMapPosition(Input.mousePosition);

        if(tempTarget.HasValue == false)
        {
            return;
        }

        transform.position = tempTarget.Value;

        foreach(var b in info.activeBuildings)
        {
            if (Vector3.Distance(transform.position, b.transform.position) < maxBuildDistance)
            {
                rend.material.color = red;
                return;
            }
        }

        if(Manager.current.isGameObjectSaveToPlace(gameObject))
        {
            rend.material.color = green;

            if(Input.GetMouseButtonDown(0))
            {

                if (info.money < cost)
                {
                    Debug.Log("Not enough, this costs: " + cost);
                    return;
                }

                construct();
            }
        }
        else
        {
            rend.material.color = red;
        }
	}

    void construct()
    {
        var construction = GameObject.Instantiate(constructionPrefab);
        construction.transform.position = transform.position;
        construction.AddComponent<Player>().info = info;

        var constructor = construction.AddComponent<Construction>();
        constructor.buildingPrefab = buildingPrefab;
        constructor.info = info;
        constructor.buildingTime = buildingTime;
        info.money -= cost;

        var cba = buildingPrefab.GetComponent<CreateBuildingAction>();

        if (cba.removeOnCreate || !Input.GetKeyDown(KeyCode.LeftShift))
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        MouseManager.current.enabled = true;
    }
}
