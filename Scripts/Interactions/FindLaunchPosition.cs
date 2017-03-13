using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLaunchPosition: MonoBehaviour {
    
    public GameObject missilePrefab;
    
    public PlayerSetupDefinition info;

    public MissileDefinition missileDefinition;

    Renderer rend;
    Color red = new Color(1, 0, 0, 0.5f);
    Color green = new Color(0, 1, 0, 0.5f);

    private float _counter = 0;

    private bool _launched = false;

    void Start()
    {
        MouseManager.current.enabled = false;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update () {
        if(_launched)
        {
            _counter += Time.deltaTime;

            // TODO: show countdown

            if(_counter >= missileDefinition.launchTime)
            {
                launch();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(this.gameObject);
            return;
        }
          
        var tempTarget = Manager.current.ScreenPointToMapPosition(Input.mousePosition);

        if(tempTarget.HasValue == false)
        {
            return;
        }

        transform.position = tempTarget.Value;
        
        if(Manager.current.isMissileSaveToLaunch(gameObject))
        {
            rend.material.color = green;

            if(Input.GetMouseButtonDown(0))
            {

                if (info.energy < missileDefinition.cost)
                {
                    Debug.Log("Not enough energy, this costs: " + missileDefinition.cost);
                    return;
                }

                _launched = true;
                
            }
        }
        else
        {
            rend.material.color = red;
        }
	}

    void launch()
    {
        var missile = GameObject.Instantiate(missilePrefab);
        missile.transform.position = transform.position;
        missile.AddComponent<Player>().info = info;

        //set missile script props
        
        if (!Input.GetKeyDown(KeyCode.LeftShift))
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        MouseManager.current.enabled = true;
    }
}
