using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public HexCell cellPrefab;

    [SerializeField]
    HexCell[] cells;

    GameObject[][] boardRows = new GameObject[16][];  // Makes 16 empty things vertikalt. Rows.
    int[] rowLengths = new int[] { 1, 2, 3, 4, 13, 12, 11, 10, 9, 10, 11, 12, 13, 4, 3, 2, 1 };  // Antalet celler i varje rad.
    float[] rowStartXCoordinate = new float[] { 0f, -10f, -20f, -30f, -80f, -70f, -60f, -50f, -40f, -50f, -60f, -70f, -80f, -30f, -20f, -10f, 0f };  // För att skapa själva mönstret måste jag definiera varje rad börjar, annars börjar alla på samma plats och det ser knäppt ut.

    public Text cellLabelPrefab;

    Canvas gridCanvas;

    HexMesh hexMesh;

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[121]; // Alla celler (121 st) i en array.

        for (int z = 0, i = 0; z < boardRows.Length; z++) // Goes through 16 times (rad).
        {
            for (int x = 0; x < rowLengths[z]; x++) //Hämtar vilken rad, går igenom det indexet i rowLengths (z-värdet), X är det som ökar
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void Start()
    {
        //hexMesh.Triangulate(cells);
    }

    void CreateCell(int x, int z, int i)  // x = vilken plats i raden (rowLengths), max är 1, 2, 3, 4, 13... , z = vilken rad(testGrid), i = ett värde för vilken initiering det är, den ökar för varje.
    {
        Vector3 position;
        position.x = x * (HexMetrics.innerRadius * 2f) + rowStartXCoordinate[z] ; // + /*(HexMetrics.innerRadius * 2f)*/ +rowStartXCoordinate[z] /*negativt obs*/;    // innerRadius * 2f equals around 16f. 
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        Debug.Log(i.ToString());

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab); 
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = x.ToString() + "\n" + z.ToString();
    }
}
