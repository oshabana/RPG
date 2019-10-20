﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using UnityEngine.UI;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour {

        Collider colliderClicked;
        Animation combatAnimation;

        void Start () {
          

        }

        void Update ()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            
            print("Nothing to do");

        }

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

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            if (Physics.Raycast(GetMouseRay(), out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}