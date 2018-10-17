using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;


public class loadScene : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbBtnObj;

    void Start()
    {
        vbBtnObj = GameObject.Find("VirtualButton");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        StartCoroutine(loadMainScene());
        Debug.Log("BTN PRESSED");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("BTN Released");
    }

    IEnumerator loadMainScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Scene2opening");
    }
}
