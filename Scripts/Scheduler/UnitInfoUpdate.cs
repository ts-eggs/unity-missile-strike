using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoUpdate : MonoBehaviour {

    public UnitDefinition unitDefinition;
    
    public Text textField;

    private float _counter = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (unitDefinition == null || textField == null)
        {
            return;
        }

        _counter = _counter + Time.deltaTime;
        float healthFactor = _counter / unitDefinition.currentTraningtime;
        textField.text = unitDefinition.unitName + " " + Mathf.Round(healthFactor * 100) + "%";

        if(healthFactor >= 1)
        {
            UnitInfoManager.current.removeUnitInfo(this.gameObject);
        }
    }
}
