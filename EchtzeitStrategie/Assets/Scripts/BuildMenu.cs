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
        // Disable Collider
        instance.GetComponentInChildren<Collider>().enabled = false;
    }

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
