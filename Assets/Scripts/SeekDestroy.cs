using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekDestroy : MonoBehaviour
{
    private DestroyableComponent _destroyableComponent;
    public int killTime;

    private Coroutine c_Destroy;
    
    public void OnTriggerEnter(Collider other) //ao permanecer no colisor alheio
    {
        _destroyableComponent = other.gameObject.GetComponent<DestroyableComponent>();

        if (_destroyableComponent != null) //o alvo deve ter a tag "Victim"
        {
            c_Destroy = StartCoroutine(DestroyItem(killTime));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (_destroyableComponent == null) return;
        
        //Verifica se a corotina existe/esta sendo executada
        if(c_Destroy != null) StopCoroutine(c_Destroy);
    }

    private void DestroyTarget()
    {
        _destroyableComponent.DestroyComponent();
    }
    
    private IEnumerator DestroyItem(float time)
    {
        print("Começou");
        yield return new WaitForSeconds(time);
        DestroyTarget();
    }
}