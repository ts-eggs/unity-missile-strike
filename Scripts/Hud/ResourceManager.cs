using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public Text moneyField;
    public Text energyField;

    // Update is called once per frame
    void Update()
    {
        moneyField.text = (int)Player.Default.money + " $";
        energyField.text = (int)Player.Default.energy + " K";
    }
}
