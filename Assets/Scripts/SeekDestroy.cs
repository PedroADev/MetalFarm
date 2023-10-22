using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekDestroy : MonoBehaviour
{
    public int killTime;
    public int timer;
    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( isColliding)
        {
            timer=Time.deltaTime;
        }
        
    }

    public void OnTriggerStay(Collider2D collision) //ao permanecer no colisor alheio
    {
        isColliding = true;
        if (collision.gameObject.CompareTag("Victim")) //o alvo deve ter a tag "Victim"
        {
            if (timer >= killTime)
            {
                Destroy(collision.gameObject);
            }
        } 
    }

    public void OnTriggerExit(Collider2D collision)
    {
        isColliding = false;
    }
