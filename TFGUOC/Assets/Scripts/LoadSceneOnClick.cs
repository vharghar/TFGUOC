using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour
{
   
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Single);
    }

    public void UnloadByIndex(int sceneIndex)
    {
        SceneManager.UnloadSceneAsync(sceneIndex, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        
        
    }

 



}
