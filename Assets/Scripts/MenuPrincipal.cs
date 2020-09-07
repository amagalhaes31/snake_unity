using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{

    public static int vidas = 3;
    public static int pontosAtual = 0;
    public static int pontosMaximo = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa os atributos (vida e pontuações)
        vidas = 3;
        pontosAtual = 0;
        pontosMaximo = 0;
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

        //#if UNITY_ADS
            // Mostra um anuncio
            if(UnityAdControle.showAds)
            {
                UnityAdControle.ShowAd();
            }
        //#endif

        SceneManager.LoadScene(nomeScene);     


    }
}
