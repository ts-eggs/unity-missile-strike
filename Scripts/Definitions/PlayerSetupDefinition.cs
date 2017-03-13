using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSetupDefinition {

    public string name;

    public Transform location;

    public Color accentColor;
    
    public List<GameObject> availableBuildings = new List<GameObject>();

    private List<GameObject> _activeBuildings= new List<GameObject>();

    public List<GameObject> activeBuildings { get { return _activeBuildings;  } }
    
    public bool isAi;

    public float money;

    public float energy;

    private float _buildTime;

    public float buildTime { get { return _buildTime; } set { _buildTime = value; } }
}
