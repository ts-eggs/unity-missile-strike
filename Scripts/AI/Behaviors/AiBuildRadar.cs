using UnityEngine;

public class AiBuildRadar: AiBuild
{
    public AiBuildRadar(AiController c) : base(c) { }

    void Start()
    {
        weightMultiplier = 1;
        timePassed = 0;

        prefab = (GameObject)Resources.Load("Buildings/Radar", typeof(GameObject));
    }
    
    public override float getWeight()
    {
        return 80;
    }
}