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
    }

    public void OnCollisionEnter(Collision collision) {

        foreach (GameObject wall in walls)
        {
            if (collision.gameObject.Equals(wall))
            {
                Invoke("ResetaJogo", tempoEspera);
            }
        }
    }

    // Reinicia o jogo se houver uma colisão com as paredes
    void ResetaJogo() {
        Debug.Log("Method called after collision");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
