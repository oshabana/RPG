using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Interactable
{ 
    public class Interactable : MonoBehaviour
    {
    //enum Interaction {attack, gather, speak, pick, build, upgrade }; uneeded so far

    //TODO: Establish way to figure out the interaction
    


        public string ProcessInteraction(Collider collider) {

            string type = collider.tag;

             return type;            
         }
    }
}