using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Transform target;
        [SerializeField] float weaponRange = 2f;
        private void update() {
            if(target != null && target.GetComponent<CombatTarget>() != null)
            {
                GetComponent<Mover>().MoveTo(target.position);
                Debug.Log("Attacking");
                
            }

        }
        public void Attack(CombatTarget combatTarget) {
            target = combatTarget.transform;
        }
    }
}