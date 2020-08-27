using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

[RequireComponent(typeof(Rigidbody))]
public class SnakeComportamento : MonoBehaviour
{

    public Rigidbody rb;

    // Variáveis utilizadas no projeto
    [Tooltip("Velocidade do snake")]
    [Range(0,10)]
    public float velocidadeSnake = 1.0f;

    public float DelayTime = 0.5f;

    public GameObject Body;
    
    private float delayCounter = 0;

    private Vector3 direction = Vector3.right;

    private List<Transform> body = new List<Transform>();

    private bool SnakeBodyCollision = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        EnableRagdoll();    
    }

    // Habilitar o rigidbody para controlar e detectar colisões
    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SnakeBodyCollision) return;

        // Contagem do Tempo 
        delayCounter += Time.deltaTime;

        // Deslocaento da snake        
        if (Input.GetKeyDown(KeyCode.W) && (direction != -Vector3.forward)) {
            direction = Vector3.forward;
        } 
        else if(Input.GetKeyDown(KeyCode.S) && (direction != Vector3.forward)) {
            direction = -Vector3.forward;
        } 
        else if(Input.GetKeyDown(KeyCode.D) && (direction != -Vector3.right)) {
            direction = Vector3.right;
        }
        else if(Input.GetKeyDown(KeyCode.A) && (direction != -Vector3.right)) {
            direction = -Vector3.right;
        }
        
        // Verifica colisão entre a cabeça e o corpo da snake
        if (CheckCollisionBody(direction))
        {
            SnakeBodyCollision = false;
            return;
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
        }
    }

    // Verifica se houce uma colisão com o corpo da snake
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
}
