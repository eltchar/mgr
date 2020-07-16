using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{

    public Transform maincamt;
    
    Quaternion base_rot;
    Quaternion curr_rot;

    Vector3 base_pos;
    Vector3 cur_pos;

    // Start is called before the first frame update
    void Start()
    {
        base_rot= maincamt.rotation;
        base_pos= maincamt.position;
        curr_rot= maincamt.rotation;
        cur_pos= maincamt.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.R))
        {
            maincamt.SetPositionAndRotation(base_pos,base_rot);
        }
        if (Input.GetKey(KeyCode.W))
        {
            maincamt.Rotate(0.1f,0.0f,0.0f,Space.Self);
        }
 
        if (Input.GetKey(KeyCode.S))
        {
            maincamt.Rotate(-0.1f,0.0f,0.0f,Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            maincamt.Rotate(0.0f,0.1f,0.0f,Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            maincamt.Rotate(0.0f,-0.1f,0.0f,Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            maincamt.Rotate(0.0f,0.0f,0.1f,Space.Self);
        }

        if (Input.GetKey(KeyCode.E))
        {
            maincamt.Rotate(0.0f,0.0f,-0.1f,Space.Self);
        }
        // -------------------Code for Zooming Out------------
    if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView<=1250)
                Camera.main.fieldOfView +=2;
            if (Camera.main.orthographicSize<=3000)
                                Camera.main.orthographicSize +=0.5f;
 
        }
    // ---------------Code for Zooming In------------------------
     if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView>2)
                Camera.main.fieldOfView -=2;
            if (Camera.main.orthographicSize>=1)
                                Camera.main.orthographicSize -=0.5f;
        }
       
    // -------Code to switch camera between Perspective and Orthographic--------
     if (Input.GetKeyUp(KeyCode.B ))
    {
        if (Camera.main.orthographic==true)
            Camera.main.orthographic=false;
        else
            Camera.main.orthographic=true;
    }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            maincamt.Translate(1.0f,0.0f,0.0f,Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            maincamt.Translate(-1.0f,0.0f,0.0f,Space.Self);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            maincamt.Translate(0.0f,1.0f,0.0f,Space.Self);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            maincamt.Translate(0.0f,-1.0f,0.0f,Space.Self);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            maincamt.Translate(0.0f, 0.0f, 1.0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.C))
        {
            maincamt.Translate(0.0f, 0.0f, -1.0f, Space.Self);
        }
            curr_rot = maincamt.rotation;
        cur_pos= maincamt.position;
    }
}
