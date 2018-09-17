using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour {

    [SerializeField]
    HexCell myClickedCell;

    public Material clickedMaterial;
    public Material unClickMyMATERIAL;


    //static int layer = 8;
    //int layerMask = 1 << layer; 
    // Had an idea on using layermasks with the raycast instead of GetComponent before. Keeping this variable if I need it in the future for some reason.

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<HexCell>() == true)
            {                  
                print("Hello! My index is... " + hit.collider.gameObject.GetComponent<HexCell>().row.ToString() + "," + hit.collider.gameObject.GetComponent<HexCell>().col);
                //print("And my position in the world is..." + hit.collider.transform.position.ToString());
                hit.collider.gameObject.GetComponent<HexCell>().WhoAreMyNeighbors();
                hit.collider.gameObject.GetComponent<Renderer>().material = clickedMaterial;
            }
            else
                print("Area out of bounds");
        }
    }
}
