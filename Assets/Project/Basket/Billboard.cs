using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cameraToLook;
    public bool alignNotLook = true;

    private void Awake()
    {
        if(cameraToLook == null) cameraToLook = Camera.main;
    }

    [ContextMenu("Update Billboard")]
    public void UpdateBillboard()
    {
        if(cameraToLook == null) cameraToLook = Camera.main;
        
        if (alignNotLook)
            transform.forward = cameraToLook.transform.forward;
        else
            transform.LookAt(cameraToLook.transform, Vector3.up);
    }

    private void LateUpdate()
    {
        if (alignNotLook)
            transform.forward = cameraToLook.transform.forward;
        else
            transform.LookAt(cameraToLook.transform, Vector3.up);
    }
}
