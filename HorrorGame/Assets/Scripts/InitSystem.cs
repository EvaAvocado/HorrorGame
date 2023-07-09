using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GamePush;

public class InitSystem : MonoBehaviour
{
    private void OnEnable()
    {
        GP_SDK.OnReady += OnReady;
    }

    private void OnReady()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDisable()
    {
        GP_SDK.OnReady -= OnReady;
    }
}