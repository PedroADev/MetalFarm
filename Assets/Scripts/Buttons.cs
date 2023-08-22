using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void novoJogo()
    {
        SceneManager.LoadScene("Fase 1");
        //PhotonNetwork.LoadLevel("Seletor de Fase");
    }

    public void sair()
    {
        Application.Quit();
    }
}
