using UnityEngine;
using System.Collections;

public class MarkColor : MonoBehaviour {

	public MeshRenderer[] Renderers;

    public PlayerSetupDefinition playerInfo;

	// Use this for initialization
	void Start () {
		var color = playerInfo != null ? playerInfo.accentColor : Player.Default.accentColor;
        
        foreach (var r in Renderers) {
			r.material.color = color;
		}
	}
}
