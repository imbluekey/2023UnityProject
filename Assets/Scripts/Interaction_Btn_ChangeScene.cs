using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction_Btn_ChangeScene: MonoBehaviour
{
    public SpriteRenderer buttonSpriteRenderer; 
    public KeyCode interactionKey = KeyCode.E;
    public string sceneToLoad;

    private bool playerInRange = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Interaction Btn : Collision Object Name : " + collision.gameObject.name);
        if (ObjectNameDetection.HasString(collision.gameObject.name, "Player")) 
        {
            playerInRange = true;
            buttonSpriteRenderer.color = new Color(1f, 1f, 1f, 1f); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ObjectNameDetection.HasString(collision.gameObject.name, "Player"))
        {
            playerInRange = false;
            buttonSpriteRenderer.color = new Color(1f, 1f, 1f, 0f); 
        }
    }
    public void Start()
    {
        buttonSpriteRenderer = GetComponent<SpriteRenderer>();
        buttonSpriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            // ���⿡ ��ȣ�ۿ뿡 ���� ������ �߰��մϴ�.
            Debug.Log("Interaction : Changing Scene to [" + sceneToLoad + "]");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}

