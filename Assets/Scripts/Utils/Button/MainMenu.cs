using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarkusSecundus.MultiInput;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        foreach (IMouse mouse in IInputProvider.Instance.ActiveMice)
        {
            mouse.IsActive = false;
            mouse.ShouldDrawCursor = false;
        }
    }

    public void ChangeScene(string nameOfScene)
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
