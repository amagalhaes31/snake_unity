using UnityEngine;

public class ControladorJogo : MonoBehaviour
{

    [Tooltip("Referência para a maça")]
    public GameObject apple;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Pega novas posições em X e Y aleatórios
        var PostionX = Random.Range(-20.0f, 20.0f);
        var PostionZ = Random.Range(-20.0f, 20.0f);

        // Instancia o objeto maçã
        Instantiate(apple, new Vector3(PostionX, 0.0f, PostionZ), Quaternion.identity);

        other.gameObject.SendMessage("TouchedObject", SendMessageOptions.DontRequireReceiver);

 
    }

}
