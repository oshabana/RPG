using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{
    Collider hoverCollider;
    Text infoLabel;

    void Start()
    {

        // Canvas canvas = GetComponent<Canvas>();
        infoLabel = GetComponent<UnityEngine.UI.Text>();
        Debug.Log(infoLabel.text);
       
    }

    // Update is called once per frame
    void Update()
    {
        // InteractwithHover(infoLabel);
        OnMouseOver();

    }
    private void InteractwithHover(Text infoLabel)
    {

        RaycastHit hit;
        if (Physics.Raycast(GetMouseRay(), out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                hoverCollider = hit.collider;
                infoLabel.text = hoverCollider.name;

            }
        }

    }
    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    private string ProcessMouseOverText(Collider collider) {
        string tag = collider.tag;
        if (tag.Equals("Terrain"))
        {
            tag = "Walk here";
        }
        else if (tag.Equals("Player"))
        {
            tag = "Walk here";
        }
        return tag;




     }
    
    private void OnMouseOver()
    {
        RaycastHit hit;
        Debug.Log("Mouse over");
        if (Physics.Raycast(GetMouseRay(), out hit))
        {
            hoverCollider = hit.collider;
            infoLabel.text = ProcessMouseOverText(hoverCollider);
            
        }
    }
}
