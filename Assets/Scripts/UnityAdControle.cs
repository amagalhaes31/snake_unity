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

    /// <summary>
    /// Metodo para mostrar Ad com recompensa
    /// </summary>
    [System.Obsolete]
    public static void ShowRewardAd()
    {
        //#if UNITY_ADS            
        if (Advertisement.IsReady())
        {

            var opcoes = new ShowOptions
            {
                resultCallback = TratarMostrarResultado
            };
            Advertisement.Show(opcoes);
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
//#if Unity_ADS
    public static void TratarMostrarResultado(ShowResult resultado)
    {

        switch (resultado)
        {
            case ShowResult.Finished:
                MenuPauseComp.Continue();
                break;

            case ShowResult.Skipped:
                MenuPauseComp.Restart();
                break;

            case ShowResult.Failed:
                Debug.LogError("Erro no Ad");
                break;
        }
    }
//#endif
}
