using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCreator : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    [SerializeField] private int numberOfCells;
    [SerializeField] private Vector3 initPoint;

    private void Start()
    {
        
        for (int i = 0; i < numberOfCells; i++)
        {
            float x = Random.Range(-180f, 180f);
            float y = Random.Range(-180f, 180f);
            float z = Random.Range(-180f, 180f);
        
            Vector3 rot = new Vector3(x, y, z);
            Instantiate(cell, initPoint, Quaternion.Euler(rot));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
