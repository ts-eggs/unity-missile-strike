using UnityEngine;

public class AiBuildBank: AiBuild
{
    public AiBuildBank(AiController c) : base(c) { }

    void Start()
    {
        weightMultiplier = 1;
        timePassed = 0;

        prefab = (GameObject) Resources.Load("Buildings/Bank", typeof(GameObject));
    }
    
    public override float getWeight()
    {
        return 90;
    }
}