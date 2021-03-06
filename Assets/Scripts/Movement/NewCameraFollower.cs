﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class NewCameraFollower : MonoBehaviour
    {
        Camera cam;
        [SerializeField] Transform player; // The object this object will track
        [SerializeField] Vector3 offset = new Vector3(0, 30, -30);     //Camera to player offset mainly used for intialization
        float scroll_delta_wheel;
        [SerializeField] float max_zoom = 9.5f;
        [SerializeField] float min_zoom = -9.5f;
        float zoom = 0;
        Vector3 zoom_offset = new Vector3(0,0,0);
        Vector3 rotation_offset = new Vector3(0,0,0);

     

    void Start()
    {
    
        cam = GetComponent<Camera>();
        cam.transform.position = offset + player.position;

        float original_y = offset.y;
        float original_z = offset.z;
      
    }

    // Update is called once per frame

    void Update()
    {

            // cam.transform.position = player.position;

            scroll_delta_wheel = Input.mouseScrollDelta.y;
            if (scroll_delta_wheel != 0)
            { 
                mouseScrollLock(scroll_delta_wheel);
                
            }
        
            cam.transform.position = offset + player.position + zoom_offset;
            
        }

        //
        void mouseScrollLock(float zoom_delta)
        {
            if (zoom_delta + zoom > min_zoom -1 && zoom_delta + zoom < max_zoom +1)
            {
                zoom += zoom_delta;
                zoom_offset.y = -zoom;
                zoom_offset.z = zoom;
            }

        }
        


    }


}
