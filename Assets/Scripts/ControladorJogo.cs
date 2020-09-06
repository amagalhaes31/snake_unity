using UnityEngine;
using UnityEngine.Advertisements;


public class ControladorJogo : MonoBehaviour
{

    [Tooltip("Referência para a maça")]
    public GameObject apple;

    // Start is called before the first frame update
    void Start()
    {
        // Workaround
        Advertisement.Initialize("2586158");            // Developed ID
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            Debug.Log("Touch");

            var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            DestroyObject(pos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Pega novas posições em X e Y aleatórios
        var PostionX = Random.Range(-20.0f, 20.0f);
        var PostionZ = Random.Range(-20.0f, 20.0f);

        // Instancia o objeto maçã
        Instantiate(apple, new Vector3(PostionX, 0.0f, PostionZ), Quaternion.identity);
        
    }

    private static void DestroyObject(Vector3 touch)
    {

        // TODO - google how to send message using OntriggerEnter
        Ray touchRay = Camera.main.ScreenPointToRay(touch);

        RaycastHit hit;

        if (Physics.Raycast(touchRay, out hit))
            hit.transform.SendMessage("TouchedObject", 
                SendMessageOptions.DontRequireReceiver);
    }

}
