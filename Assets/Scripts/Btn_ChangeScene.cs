using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_ChangeScene : MonoBehaviour
{
    public string sceneToLoad;

    public void OnClick()
    {
        Debug.Log("Interaction : Changing Scene to [" + sceneToLoad + "]");
        SceneManager.LoadScene(sceneToLoad);
    }

}

