using UnityEngine;

public class AiBuildPower: AiBuild
{
    public AiBuildPower(AiController c) : base(c) { }

    void Start()
    {
        weightMultiplier = 1;
        timePassed = 0;

        prefab = (GameObject)Resources.Load("Buildings/Power", typeof(GameObject));
    }
    
    public override float getWeight()
    {
        return 88;
    }
}
