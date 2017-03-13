using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour {
    
    public GameObject buildingPrefab;
    
    public PlayerSetupDefinition info;

    public float buildingTime = 5;

    private float _counter = 0;

    private int _buildingHeight = 2;
    
    void Start()
    {
        var sui_construction = this.GetComponent<ShowUnitInfo>();
        var sui_building = buildingPrefab.GetComponent<ShowUnitInfo>();
        sui_construction.unitName = sui_building.unitName;
        sui_construction.profileImage = sui_building.profileImage;
        sui_construction.maxHealth = sui_building.maxHealth;
        sui_construction.currentHealth = 0;

        var cba = buildingPrefab.GetComponent<CreateBuildingAction>();

        if (cba.removeOnCreate)
        {
            info.availableBuildings.Remove(buildingPrefab);
        }

        Vector3 scale = gameObject.transform.localScale;
        scale.y = 0;
        gameObject.transform.localScale = scale;
   }
    
    void Update ()
    {
        _counter = _counter + Time.deltaTime;

        float buildFactor = (1 - info.buildTime) > 0.2 ? (1 - info.buildTime) : 0.2f;
        float currentBuildTime = buildingTime * buildFactor;
        float healthFactor = _counter / currentBuildTime;

        Vector3 scale = gameObject.transform.localScale;
        scale.y = healthFactor * _buildingHeight;
        gameObject.transform.localScale = scale;

        var sui_construction = this.GetComponent<ShowUnitInfo>();
        sui_construction.setCurrentHealth(Mathf.Round(sui_construction.maxHealth * healthFactor));

        if (_counter >= currentBuildTime)
        {
            scale.y = _buildingHeight;
            gameObject.transform.localScale = scale;
            sui_construction.setCurrentHealth(sui_construction.maxHealth);
            build();
        }
    }
    
    void build()
    {
        var go = GameObject.Instantiate(buildingPrefab);
        go.transform.position = transform.position;
        go.AddComponent<Player>().info = info;
        go.GetComponent<MarkColor>().playerInfo = info;
        var wasSelected = GetComponent<Interactive>().selected;
        GetComponent<Interactive>().deselect();
        Destroy(this.gameObject);
        
        info.buildTime += go.GetComponent<Earnings>().buildingTimeImprovement;
        info.availableBuildings.AddRange(go.GetComponent<CreateBuildingAction>().newBuildings);
        ActionsManager.current.clearButtons();
        ActionsManager.current.addPlayerButtons();

        if (wasSelected)
        {
            go.AddComponent<SelectAfterInit>().interactive = go.GetComponent<Interactive>();
        }
    }
}
