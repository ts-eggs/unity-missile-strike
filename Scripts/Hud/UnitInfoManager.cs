using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitInfoManager : MonoBehaviour {

    public static UnitInfoManager current;
    
    public GameObject box;

    public GameObject unitInfo;
    
    private List<GameObject> _unitInfos = new List<GameObject>();

    private int height = 25;

    public UnitInfoManager()
    {
        current = this;
    }

    public void addUnitInfo(UnitDefinition unitDefinition)
    {
        var ui = GameObject.Instantiate(unitInfo, box.transform, false);
        var lp = ui.transform.localPosition;
        lp.y -= (height * _unitInfos.Count);
        ui.transform.localPosition = lp;

        var infoText = ui.GetComponentInChildren<Text>();
        infoText.text = unitDefinition.unitName + " 0%";

        var update = ui.AddComponent<UnitInfoUpdate>();
        update.unitDefinition = unitDefinition;
        update.textField = infoText;

        _unitInfos.Add(ui);
    }

    public void removeUnitInfo(GameObject prefab)
    {
        _unitInfos.Remove(prefab);
        Destroy(prefab);

        foreach(var ui in _unitInfos)
        {
            var lp = ui.transform.localPosition;
            lp.y += height;
            ui.transform.localPosition = lp;
        }
    }
}
