using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core {
    public class FollowCamera : MonoBehaviour
    {
        Camera cam;
        [SerializeField] Transform player; // The object this object will track
        [SerializeField] Vector3 offset = new Vector3(0, 60, -60);     //Camera to player offset mainly used for intialization
        
        //Values for updating
        float distance_x;
        float distance_y;
        float distance_z;


        Vector3 currentDistanceFromPlayer = new Vector3(0,0,0);

        void Start()
        {

            cam = GetComponent<Camera>();
            cam.transform.position = offset + player.position;

            distance_x = cam.transform.position.x;
            distance_y = cam.transform.position.y;
            distance_z = cam.transform.position.z;

            Vector3 currentDistanceFromPlayer = new Vector3(distance_x,distance_y,distance_z);
            
        }

        // Update is called once per frame
        void Update()
        {
        
           // cam.transform.position = player.position;
            

            if (Input.mouseScrollDelta.y != 0)
            {
                mouseScrollLock();
            }
               cam.transform.position = player.position + currentDistanceFromPlayer;
             //  cam.transform.position = cam.transform.position - currentDistanceFromPlayer ;
           // cam.transform.position = offset + player.position;


        }

        //
        void mouseScrollLock() {
            float cam_x = cam.transform.position.x;
            float cam_y = cam.transform.position.y;
            float cam_z = cam.transform.position.z;
            float player_y = player.transform.position.y;
            float player_z = player.transform.position.z;
          
            if ((cam_y >= player_y + 6 || cam_z <= player_z - 6) && Input.mouseScrollDelta.y > 0 ) //Zoom in lock
            {
                ChangeZoomDistance(Input.mouseScrollDelta.y);
                distance_x = player.position.x - cam.transform.position.x;
                distance_y = player.position.y - cam.transform.position.y;
                distance_z = player.position.z - cam.transform.position.z;
                UpdateDistance(distance_x,distance_y,distance_z,currentDistanceFromPlayer);

            }
   
            if ((cam_y <= player_y + 25 || cam_z >= player_z - 25) && Input.mouseScrollDelta.y < 0) //Zoom out lock
            {
                ChangeZoomDistance(Input.mouseScrollDelta.y);
                distance_x =  cam.transform.position.x - player.position.x;
                distance_y = cam.transform.position.y - player.position.y;
                distance_z =  cam.transform.position.z - player.position.z;
                UpdateDistance(distance_x, distance_y, distance_z, currentDistanceFromPlayer);
            }
        }

        //Moves the camera by how ever much the wheel was moved in the x and y (Input.mouseScrollDelta.y)
        void ChangeZoomDistance(float delta_scroll_y) { 
            Vector3 scrollPos = new Vector3(0, -delta_scroll_y , delta_scroll_y );
            cam.transform.position += scrollPos;
        }
        Vector3 UpdateDistance(float x, float y, float z, Vector3 storage) {
            storage.x = player.position.x - x;
            storage.y = player.position.y - y;
            storage.z = player.position.z - z;

            return storage;
        }
   
    }


}
