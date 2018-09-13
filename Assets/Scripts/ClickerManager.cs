using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour {

    [SerializeField]
    HexCell myClickedCell;

    static int layer = 8;
    int layerMask = 1 << layer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, layerMask) /*&& hit.transform.gameObject == myClickedCell.transform.gameObject*/)
            {
                hit.collider.gameObject.GetComponent<HexCell>();  // I somehow wanna click on a cell and see its index in HexGrid myGameBoard.
                // Maybe somehow reach the array from here?
                print("I've hit " + hit.collider.gameObject.ToString());
                Destroy(hit.transform.gameObject);
            }
            else
                print("No.");
        }
    }
}
