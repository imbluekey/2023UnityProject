using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToStart : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
