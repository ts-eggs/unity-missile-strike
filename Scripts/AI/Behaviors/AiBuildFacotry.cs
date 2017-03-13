using UnityEngine;

public class AiBuildFactory: AiBuild
{
    public AiBuildFactory(AiController c) : base(c) { }

    void Start()
    {
        weightMultiplier = 1;
        timePassed = 0;

        prefab = (GameObject) Resources.Load("Buildings/Factory", typeof(GameObject));
    }
    
    public override float getWeight()
    {
        return 89;
    }
}