using UnityEngine;

[System.Serializable]
public class UnitDefinition
{
    public UnitDefinition(string n, float mh, float ct, float hf, float bf)
    {
        unitName = n;
        maxHealth = mh;
        currentTraningtime = ct;
        healthFactor = hf;
        buildFactor = bf;
    }

    public string unitName;
    
    public float maxHealth = 100;

    public float Cost = 0;

    public float trainingTime = 0;

    public GameObject prefab;

    public float currentTraningtime;

    public float healthFactor = 1;

    public float buildFactor = 1;
}
