using UnityEngine;

public class ExpandManager : MonoBehaviour {
    
    public GameObject expandable = null;
    
    public void expand()
    {
        if (expandable == null)
        {
            return;
        }

        expandable.SetActive(!expandable.activeSelf);
    }
}
