using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void LoadLevel(string sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
