using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class SnakeComportamento : MonoBehaviour
{

    public Rigidbody rb;

    [SerializeField]
    private GameObject menuGameOverPanel;

    // Variáveis utilizadas no projeto
    [Tooltip("Velocidade do snake")]
    [Range(0,10)]
    public float velocidadeSnake = 1.0f;

    public float DelayTime = 0.5f;

    public GameObject Body;
    
    private float delayCounter = 0;

    private Vector3 direction = Vector3.right;

    private List<Transform> body = new List<Transform>();

    [Tooltip("Particle system para destruição da maça")]
    public GameObject destruicao;

    [Tooltip("Acesso para o componente Text -> PontosAtual")]
    Text txtPontosAtual;
    
    [Tooltip("Acesso para o componente Text -> PontosMaximo")]
    Text txtPontosMaximo;

    [Tooltip("Acesso para o componente Text -> Vidas")]
    Text txtVidas;

    [Tooltip("Acesso para o componente Text -> You lose")]
    Text txtLose;

    // Variavel de controle para parar a cena
    public static int cenaParada; 

    private void ContaNumeroVidas() {
       
       // Decrementa a variavel vida
        MenuPrincipal.vidas--;

        // Atualiza o valor das vidas da snake
        txtVidas = GameObject.Find("Canvas/Vidas").GetComponent<Text>();        
        txtVidas.text= $"Life: {MenuPrincipal.vidas.ToString()}";

        txtLose.enabled = true;

        // Se não possuir mais vidas, Game Over, então carregar a cena inicial
        if (MenuPrincipal.vidas == 0)
        {                
            
            // Avisa para travar a cena
            cenaParada = 1;

            GameOver();

            // Chama a cena inicial após 5 segundos
            //Invoke("CarregaInitialScene", 5.0f); 
        } 
        else 
        {
            // Avisa para travar a cena
            cenaParada = 1;

            // Chama a cena inicial após 5 segundos
            Invoke("CarregaMainScene", 3.0f); 
        }     
    }

    // Start is called before the first frame update
    void Start()
    {
        // Referencia ao Rigidbody
        rb = GetComponent<Rigidbody>(); 

        // Limpa e atualiza o valor do score atual
        MenuPrincipal.pontosAtual = 0;
        txtPontosAtual = GameObject.Find("Canvas/PontosAtual").GetComponent<Text>();
        txtPontosAtual.text= $"Score: {MenuPrincipal.pontosAtual.ToString()}";

        // Atualiza o valor do score máximo
        txtPontosMaximo = GameObject.Find("Canvas/PontosMaximo").GetComponent<Text>();        
        txtPontosMaximo.text= $"High Score: {MenuPrincipal.pontosMaximo.ToString()}"; 

        // Atualiza o valor das vidas da snake
        txtVidas = GameObject.Find("Canvas/Vidas").GetComponent<Text>();        
        txtVidas.text= $"Life: {MenuPrincipal.vidas.ToString()}"; 


        // Mostra You Lose quando o jogador perde uma vida
        txtLose = GameObject.Find("Canvas/Lose").GetComponent<Text>();
        // Desabilita a mensagem "You lose" na cena principal do jogo
        txtLose.enabled = false;

        // Habilita a cena
        cenaParada = 0;          

    }

    // Update is called once per frame
    void Update()
    {   
        // Retorna se o jogo estiver pausado
        if (MenuPauseComp.pausado || cenaParada == 1) {
            return;
        }  

        // Contagem do Tempo 
        delayCounter += Time.deltaTime;

        // Deslocaento da snake        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (direction != -Vector3.forward)) {            // Para cima
            direction = Vector3.forward;
        } 
        else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))&& (direction != Vector3.forward)) {        // Para baixo
            direction = -Vector3.forward;
        } 
        else if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && (direction != -Vector3.right)) {       // Para direita
            direction = Vector3.right;
        }
        else if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && (direction != Vector3.right)) {         // Para esquerda
            direction = -Vector3.right;
        }
        
        // Verifica colisão entre a cabeça e o corpo da snake ou nas paredes
        if (CheckCollisionBody(direction) || ObstaculoComportamento.paredeColisao == 1)
        {   
            ContaNumeroVidas();
        }


        // Verifica se houve TimeOut e então a snake anda pelo plano
        if (delayCounter > DelayTime) 
        {
            var lastHeadPosition = transform.position;

            transform.forward = direction;
            
            transform.Translate(transform.forward * velocidadeSnake, Space.World);

            if (body.Count > 0) {
                
                var shiftBody = body[body.Count - 1];
                
                body.Remove(shiftBody);
                
                body.Insert(0, shiftBody);
                
                body[body.Count - 1].position = lastHeadPosition;
            }
            
            delayCounter = 0;
        }
    }

    // Verifica se aconteceu uma colisão com a maça
    private void OnTriggerEnter(Collider other) {
        
        if(other.tag.Equals("Apple")) 
        {            
            Destroy(other.gameObject);

            var b = Instantiate(Body);

            if (body.Count > 0) 
            {
                b.transform.position = body[body.Count - 1].position;
            }
            else 
            {
                b.transform.position = transform.position - transform.forward;
            }
            
            body.Add(b.transform);

            
            // Incrementa o valor dos pontos atuais
            MenuPrincipal.pontosAtual += 100;
            txtPontosAtual = GameObject.Find("Canvas/PontosAtual").GetComponent<Text>();
            txtPontosAtual.text= $"Score: {MenuPrincipal.pontosAtual.ToString()}";


            // Atualiza o valor do score máximo
            if (MenuPrincipal.pontosAtual > MenuPrincipal.pontosMaximo) MenuPrincipal.pontosMaximo = MenuPrincipal.pontosAtual;
            txtPontosMaximo = GameObject.Find("Canvas/PontosMaximo").GetComponent<Text>();        
            txtPontosMaximo.text= $"High Score: {MenuPrincipal.pontosMaximo.ToString()}"; 
        }
    }

    // Verifica se houve uma colisão com o corpo da snake
    private bool CheckCollisionBody(Vector3 direction)
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, direction, out hit, 1))
        {            
            return hit.transform.tag.Equals("Body");
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Metodo para carregar uma scene
    /// </summary>
    /// <param name="nomeScene">Nome da scene que sera carregada</param>
    public void CarregaScene(string nomeScene)
    {
        SceneManager.LoadScene(nomeScene);
    }

    public void TouchedObject()
    {

        if (destruicao != null)
        {
            Debug.Log("Destruicao is not null");
            
            var particles = Instantiate(destruicao, transform.position, Quaternion.identity);
            
        }

    }

    public void GameOver()
    {
        var gameOverMenu = GetGameOverMenu();
        gameOverMenu.SetActive(true);
    }

    /// <summary>
    /// Carrega Cena Inicial
    /// </summary>
    void CarregaInitialScene()
    {
        // Carrega a tela inicial do jogo
        CarregaScene("InitialScene"); 
    }


    /// <summary>
    /// Carrega Cena Principal
    /// </summary>
    void CarregaMainScene()
    {
        // Carrega a tela inicial do jogo
        CarregaScene("MainScene"); 
    }

    /// <summary>
    /// Busca o MenuGameOver
    /// </summary>
    /// <returns>O GameObject MenuGameOver</returns>
    GameObject GetGameOverMenu()
    {
        return GameObject.Find("Canvas").transform.Find("MenuGameOver").gameObject;
    }
}
