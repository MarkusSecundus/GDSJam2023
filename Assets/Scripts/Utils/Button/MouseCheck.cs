using System.Collections;
using System.Collections.Generic;
using MarkusSecundus.MultiInput;
using MarkusSecundus.PhysicsSwordfight.Utils.Primitives;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class MouseCheck : MonoBehaviour
{
    IMouse mouseL = null;
    IMouse mouseR = null;

    [SerializeField] private Button buttonL;
    [SerializeField] private Button buttonR;
    [SerializeField] private string scene;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        buttonL.image.color = Color.white;
        buttonR.image.color = Color.white;

        if (mouseL != null)
        {
            buttonL.image.color = Color.green;
        }

        if (mouseR != null)
        {
            buttonR.image.color = Color.green;
        }

        foreach (IMouse mouse in IInputProvider.Instance.ActiveMice)
        {
            if ((buttonL.transform as RectTransform).GetRect().Contains(mouse.ViewportPosition))
            {
                buttonL.image.color = Color.grey;

                if (mouse.GetButtonDown(MouseKeyCode.RightButton))
                {
                    SaveLeftMouse(mouse);
                }
            }

            if ((buttonR.transform as RectTransform).GetRect().Contains(mouse.ViewportPosition))
            {
                buttonR.image.color = Color.grey;

                if (mouse.GetButtonDown(MouseKeyCode.LeftButton))
                {
                    SaveRightMouse(mouse);
                }
            }
        }

        if (mouseL != null && mouseR != null && mouseL != mouseR)
        {
            Debug.Log("CHANGE SCENES NOW");
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
