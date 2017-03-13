using UnityEngine;

[System.Serializable]
public class MissileDefinition
{
    public MissileDefinition(string n, float mh, float c, float lt, float s, float d)
    {
        missileName = n;
        maxHealth = mh;
        cost = c;
        launchTime = lt;
        speed = s;
        damage = d;
    }

    public GameObject prefab;

    public string missileName;
    
    public float maxHealth = 10;

    public float cost = 100;

    public float launchTime = 3;

    public float speed = 0.03f;

    public float damage = 50;
}
