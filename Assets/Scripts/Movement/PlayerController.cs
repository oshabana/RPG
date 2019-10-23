using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        Collider colliderClicked;
        Animation combatAnimation;
        Inventory inventory;
        Rigidbody player;
        public Canvas canvas;
        Text infoBox;
        Collider[] hitColliders;

        private Vector3 moveDirection = Vector3.zero;
        public float speed = 2.0f;

        void Start()
        {
      
            inventory = GetComponent<Inventory>();
            player = GetComponent<Rigidbody>();
            infoBox = canvas.GetComponent<Text>();


        }

        void Update()
        {
            //if (InteractWithCombat()) return;

            InteractWithMovement();
            if (Input.GetMouseButtonDown(0))
            {
                InteractWithSourrondings();
            }
            
           

        }
        /*
                private bool InteractWithCombat()
                {
                    RaycastHit[] hits =  Physics.RaycastAll(GetMouseRay());
                    foreach (RaycastHit hit in hits) {
                        CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                        if (target == null) continue;

                        if (Input.GetMouseButtonDown(0)) {
                            GetComponent<Fighter>().Attack(target);
                            Debug.Log("Fighting");
                        }
                            return true;
                    }
                    return false;
                }
        */
        /*
        private bool InteractWithMovement()
        {



                    if (Input.GetMouseButtonDown(0))
                    { 
                        if (EventSystem.current.IsPointerOverGameObject() &&
                            EventSystem.current.currentSelectedGameObject != null)
                           {
                          Debug.Log("Here");
                            return false; 
                         }
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                                GetComponent<Mover>().MoveTo(hit.point);
                        }
                        return true;

                }


            return false;
        }
        */
        private void InteractWithMovement()
        {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= speed;
                player.AddForce(moveDirection);
                
        }
   
        void ProcessInteraction(RaycastHit hit)
        {

            string type = hit.collider.tag;

            if (type.Equals("Item"))
            {

                Item newItem = hit.collider.GetComponent<Item>();

                inventory.AddItem(newItem);
            }
            else if (type.Equals("Resource-Tree") ) {
                Debug.Log("Chopping...");

            } 

        }
        void InteractWithSourrondings() {
            hitColliders = Physics.OverlapSphere(player.position, 5f);
            foreach (Collider hit in hitColliders)
            {
               
                if (hit.tag.Equals("Tree"))
                {
                    
                    if (inventory.isItemPresent("Axe"))
                    {
                        hit.gameObject.GetComponent<Resource>().Chop(hit.gameObject);
                 
                    }
                    
                }

                else if (hit.tag.Equals("Rock"))
                {
                    if (inventory.isItemPresent("Pickaxe"))
                    {
                        hit.gameObject.GetComponent<Resource>().Mine(hit.gameObject);

                    }
                }
                else if (hit.tag.Equals("NPC"))
                {

                }
                
            }
        }
      
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Item")
            {
                GameObject itemPickedUp = collision.gameObject;
                
                Item item = itemPickedUp.GetComponent<Item>();

                inventory.AddItem(item);

            }
        }




        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
    
}

      

    
