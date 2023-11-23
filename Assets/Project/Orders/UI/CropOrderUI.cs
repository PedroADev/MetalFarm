using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropOrderUI : MonoBehaviour
{
    [SerializeField] private Image cropImage;
    [SerializeField] private TMP_Text amountText;
    
    public void Initialize(CropData cropData)
    {
        cropImage.sprite = cropData.crop.sprite;
        amountText.text = "x" + cropData.amount;
    }
}
