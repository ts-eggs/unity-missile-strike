using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCradle : MonoBehaviour {

    public static CameraCradle current;

    public float speed = 20;

    public int minScroll = 15;

    public int maxScroll = 30;

    private float currentY = 0;

    void Start()
    {
        current = this;
        currentY = transform.position.y;
    }
    
    void Update()
    {
        // moving
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 input = GetInput();
            Vector3 direction = GetInputDirection2D(input);
            transform.position += direction * input.magnitude * speed * Time.deltaTime;
        }

        // scrolling
        if(Input.mouseScrollDelta.y != 0)
        {
            float y = Input.mouseScrollDelta.y * speed * Time.deltaTime;
            
            if (Input.mouseScrollDelta.y > 0 && Camera.main.gameObject.transform.position.y > minScroll)
            {
                transform.Translate(0, 0, y);
            }

            if (Input.mouseScrollDelta.y < 0 && Camera.main.gameObject.transform.position.y < maxScroll)
            {
                transform.Translate(0, 0, y);
            }

            currentY = transform.position.y;
        }
        
    }

    public void moveToPosition(Vector3 position)
    {
        position.y = currentY;
        transform.position = position;
    }

    Vector3 GetInputDirection2D(Vector3 input)
    {
        Vector3 direction = Camera.main.transform.TransformDirection(input);
        direction.y = 0;
        return direction.normalized;
    }

    Vector3 GetInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
