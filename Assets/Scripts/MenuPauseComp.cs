using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseComp : MonoBehaviour
{
    public static bool pausado;

    [SerializeField]
    private GameObject menuPausePanel;

    /// <sumary>
    /// Metodo para reinicializar a scene
    /// </summary>
    public static void Restart(){

        MenuPrincipal.vidas = 3;
        MenuPrincipal.pontosAtual = 0;
        MenuPrincipal.pontosMaximo = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void Continue()
    {
        MenuPrincipal.vidas = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowRewardAd()
    {
        UnityAdControle.ShowRewardAd();
    }

    /// <sumary>
    /// Metodo para reinicializar a scene
    /// </summary>
    /// <param name="isPausado"></param>
    public void Pause(bool isPausado){
        
        pausado = isPausado;

        // Se o jogo estiver pausado, timescale recebe 0
        Time.timeScale = (pausado) ? 0 : 1;

        // Habilta/Desabilita o menu Pause
        menuPausePanel.SetActive(pausado);
    }


    /// <summary>
    /// Metodo para carregar uma scene
    /// </summary>
    /// <param name="nomeScene">Nome da scene que sera carregada</param>
    public void CarregaScene(string nomeScene)
    {
        SceneManager.LoadScene(nomeScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa a variavel
        pausado = false;

        // Inicializa com o jogo (pause = false)
        Pause(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
