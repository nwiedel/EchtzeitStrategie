using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf das zu erstellende Gameobjekt
    /// </summary>
    public GameObject objectToSpawn;

    public GameObject instance;

    /// <summary>
    /// Logik zum erzeugen eines Gameobjekt
    /// </summary>
    public void SpawnBuilding()
    {
        // Instantialte Unit
       instance = Instantiate(objectToSpawn);
    }

    private void Update()
    {
        if(instance != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                instance.transform.position = hit.point;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                // Place Building
                instance = null;
            }
        }

        
    }
}
