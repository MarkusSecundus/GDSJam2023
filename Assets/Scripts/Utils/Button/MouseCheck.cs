using System.Collections;
using System.Collections.Generic;
using MarkusSecundus.MultiInput;
using MarkusSecundus.PhysicsSwordfight.Utils.Primitives;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseCheck : MonoBehaviour
{
    public static IMouse mouseL = null;
    public static IMouse mouseR = null;

    [SerializeField] private Button buttonL;
    [SerializeField] private Button buttonR;
    [SerializeField] private string scene;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        foreach (IMouse mouse in IInputProvider.Instance.ActiveMice)
        {
            mouse.IsActive = true;
            mouse.ShouldDrawCursor = true;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        buttonL.image.color = Color.white;
        buttonR.image.color = Color.white;

        if (mouseL != null)
        {
            buttonL.image.color = mouseL.CursorColor;
        }

        if (mouseR != null)
        {
            buttonR.image.color = mouseR.CursorColor;
        }

        foreach (IMouse mouse in IInputProvider.Instance.ActiveMice)
        {
            //mouse.ViewportPosition = new Vector2(50, 50);

            if ((buttonL.transform as RectTransform).GetRect().Contains(mouse.ViewportPosition))
            {
                buttonL.image.color = buttonL.image.color.WithAlpha(0.5f);

                if (mouse.GetButtonDown(MouseKeyCode.RightButton))
                {
                    SaveLeftMouse(mouse);
                }
            }

            if ((buttonR.transform as RectTransform).GetRect().Contains(mouse.ViewportPosition))
            {
                buttonR.image.color = buttonR.image.color.WithAlpha(0.5f);

                if (mouse.GetButtonDown(MouseKeyCode.LeftButton))
                {
                    SaveRightMouse(mouse);
                }
            }
        }

        if (mouseL != null && mouseR != null && mouseL != mouseR)
        {
            SceneManager.LoadScene(scene);
        }
    }

    void SaveRightMouse(IMouse mouse)
    {
        mouseR = mouse;
        if (mouseL == mouseR)
        {
            mouseL = null;
        }
    }

    void SaveLeftMouse(IMouse mouse)
    {
        mouseL = mouse;
        if (mouseL == mouseR)
        {
            mouseR = null;
        }
    }
}
