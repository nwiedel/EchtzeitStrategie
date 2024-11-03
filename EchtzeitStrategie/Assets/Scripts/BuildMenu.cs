using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    /// <summary>
    /// Zeiger auf das zu erstellende Gameobjekt
    /// </summary>
    public GameObject objectToSpawn;

    /// <summary>
    /// Zeiger auf die zu erstellende Einheit
    /// /// </summary>
    public GameObject unitToSpawn;

    public GameObject instance;
    public GameObject tempUnit, tempBase;

    /// <summary>
    /// Logik zum erzeugen eines Base-Gebäudes
    /// </summary>
    public void SpawnBuilding()
    {
        // Instantialte Building
        instance = Instantiate(objectToSpawn);
        // Disable Collider
        instance.GetComponentInChildren<Collider>().enabled = false;
    }

    /// <summary>
    /// Logik zum erzeugen einer Einheit
    /// </summary>
    public void SpawnUnit()
    {
        if(GameObject.FindGameObjectWithTag("Base") != null)
        {
            // Instatiate Unit
            tempUnit = Instantiate(unitToSpawn);
            // Search for Base
            tempBase = GameObject.FindGameObjectWithTag("Base");
            // Ändere Position
            tempUnit.transform.position =
                tempBase.transform.position + new Vector3(2, 0, 2);
        }
        
    }

    /// <summary>
    /// Unity Methode
    /// </summary>
    private void Update()
    {
        if(instance != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Ground")
                {
                    instance.transform.position = hit.point;
                } 
            }

            if (Input.GetButtonDown("Fire1"))
            {
                // Enable Collider
                instance.GetComponentInChildren<Collider>().enabled = true;
                // Place Building
                instance = null;
            }
        }

        // Bauprozess abbrechen
        if (Input.GetButtonDown("Cancel"))
        {
            Destroy(instance);
        }
    }
}
