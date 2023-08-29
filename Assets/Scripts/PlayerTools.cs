using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("entrou no trigger");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Pegou foice");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
