using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaculoComportamento : MonoBehaviour
{
    [Tooltip("Lista dos obstáculos")]
    public GameObject[] walls;

    [Tooltip("Delay para reiniciar o jogo")]
    public float tempoEspera = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        walls = GameObject.FindGameObjectsWithTag("Wall");

        if (walls.Length > 0)
        {
            Debug.Log(walls);
        }
       
    }

    // Reinicia o jogo se houver uma colisão com as paredes
    void ResetaJogo()
    {
        Debug.Log("Method called after collision");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Entered on OnCollisionEnter");

        foreach (GameObject wall in walls)
        {
            if (collision.gameObject.Equals(wall))
            {
                Debug.Log("Snake collide");
                //Invoke("ResetaJogo", tempoEspera);
            }
        }
    }

}
