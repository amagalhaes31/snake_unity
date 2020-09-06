using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaculoComportamento : MonoBehaviour
{

    [Tooltip("Delay para reiniciar o jogo")]
    public float tempoEspera = 2.0f;

    public static int paredeColisao = 0;

    public void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Entered on OnCollisionEnter");
        
        if (collision.gameObject.GetComponent<SnakeComportamento>())
        {
            // Avisa que houve uma colisão nas paredes         
            paredeColisao = 1;

            // Reseta o jogo
            Invoke("ResetaJogo", tempoEspera);
        }

    }

    /// <summary>
    /// Reinicia o jogo
    /// </summary>
    void ResetaJogo()
    {
        Debug.Log("Method called after collision");        

        // Desativa a colisão nas paredes 
        paredeColisao = 0;
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
