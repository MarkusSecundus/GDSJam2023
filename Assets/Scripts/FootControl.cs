using MarkusSecundus.MultiInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootControl : MonoBehaviour
{
    Vector2 mousePosL;
    Vector2 mousePosR;

    float starty;
    [SerializeField] float maxHeight;

    [SerializeField] GameObject footL;
    [SerializeField] GameObject footR;
    [SerializeField] GameObject IKtargetL;
    [SerializeField] GameObject IKtargetR;
    [SerializeField] Transform Camera;
    [SerializeField] Transform IKroot;

    // Start is called before the first frame update
    void Start()
    {
        if (MouseCheck.mouseL != null && MouseCheck.mouseR != null)
        {
            mousePosL = MouseCheck.mouseL.ViewportPosition;
            mousePosR = MouseCheck.mouseR.ViewportPosition;
        }

        starty = footL.transform.position.y;
    }

    private void LateUpdate()
    {
        IKroot.position = (footL.transform.position + footR.transform.position) / 2;
        IKroot.forward = -Vector3.Cross(footR.transform.position - footL.transform.position, Vector3.up);
        Transform armature = IKroot.Find("Armature");
        armature.eulerAngles = IKroot.eulerAngles + new Vector3(-90, 0, 0);
        //IKroot.eulerAngles = footR.transform.eulerAngles + new Vector3(-90, 0, 0);
        //IKroot.up = Vector3.up;

        IKtargetL.transform.position = footL.transform.position;
        IKtargetR.transform.position = footR.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IInputProvider.Instance.ActiveMice.Count < 2)
        {
            return;
        }

        if (MouseCheck.mouseR == null && MouseCheck.mouseL == null)
        {
            foreach (var mouse in IInputProvider.Instance.ActiveMice)
            {
                if (MouseCheck.mouseR == null) MouseCheck.mouseR = mouse;
                else if (MouseCheck.mouseL == null)
                {
                    MouseCheck.mouseL = mouse;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
                }
            }
        }

        float yangle = Camera.rotation.eulerAngles.y;

        Vector2 newPosL = MouseCheck.mouseL.ViewportPosition;

        if (footL.transform.position.y > starty)
        {
            Vector2 deltaPos = newPosL - mousePosL;
            footL.transform.position = footL.transform.position + Quaternion.AngleAxis(yangle, Vector3.up) * new Vector3(deltaPos.x, 0, deltaPos.y) * 0.02f;
            //mousePosL = newPosL;
        }
        else
        {
            //MouseCheck.mouseL.ViewportPosition = mousePosL;
        }
        mousePosL = newPosL;

        if (MouseCheck.mouseL.IsAnyButtonPressed)
        {
            if (footL.transform.position.y < starty + maxHeight)
            {
                footL.transform.position = footL.transform.position + Vector3.up * Time.deltaTime * 3;
            }
        }
        else
        {
            if (footL.transform.position.y > starty)
            {
                footL.transform.position = footL.transform.position - Vector3.up * Time.deltaTime * 3;
            }
        }

        Vector2 newPosR = MouseCheck.mouseR.ViewportPosition;


        if (footR.transform.position.y > starty)
        {
            Vector2 deltaPos = newPosR - mousePosR;
            footR.transform.position = footR.transform.position + Quaternion.AngleAxis(yangle, Vector3.up) * new Vector3(deltaPos.x, 0, deltaPos.y) * 0.02f;
            //mousePosR = newPosR;

        }
        else
        {
            //MouseCheck.mouseR.ViewportPosition = mousePosR;
        }
        mousePosR = newPosR;

        if (MouseCheck.mouseR.IsAnyButtonPressed)
        {
            if (footR.transform.position.y < starty + maxHeight)
            {
                footR.transform.position = footR.transform.position + Vector3.up * Time.deltaTime * 3;
            }
        }
        else
        {
            if (footR.transform.position.y > starty)
            {
                footR.transform.position = footR.transform.position - Vector3.up * Time.deltaTime * 3;
            }
        }
    }
}
