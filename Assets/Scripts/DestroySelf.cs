using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision) //ao entrar no colisor alheio
    {
        if (collision.gameObject.CompareTag("HitboxEspada")) //o objeto criado no golpe da espada deve ter a tag "HitboxEspada"
        {
            Destroy(gameObject);
        }
    }
}
