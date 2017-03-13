using UnityEngine;

public class AiBuildBase : AiBuild
{
    public AiBuildBase(AiController c) : base(c) {}

    void Start()
    {
        weightMultiplier = 1;
        timePassed = 0;

        prefab = (GameObject) Resources.Load("Buildings/Base", typeof (GameObject));
    }
    
    public override float getWeight()
    {
        return 100;
    }
}