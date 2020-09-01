using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Metodo para carregar uma scene
    /// </summary>
    /// <param name="nomeScene">Nome da scene que sera carregada</param>
    public void CarregaScene(string nomeScene)
    { 
        SceneManager.LoadScene(nomeScene);        
    }
}
