using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#if UNITY_ADS
using UnityEngine.Advertisements;
//#endif

public class UnityAdControle : MonoBehaviour
{

    public static bool showAds = true;

    
    public static void ShowAd(){
        
        //#if UNITY_ADS            
            if(Advertisement.IsReady()) {
                Advertisement.Show();
            }
        //#endif

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
