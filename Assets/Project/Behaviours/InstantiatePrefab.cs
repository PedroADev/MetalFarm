using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public void InstantiatePrefabAtPosition(GameObject prefab)
    {
        Instantiate(prefab, transform.position, quaternion.identity);
    }
}
