using MarkusSecundus.MultiInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootControl : MonoBehaviour
{
    enum Pressed
    {
        NONE,
        LEFT,
        RIGHT
    }

    Vector2 mousePosL;
    Vector2 mousePosR;
    Pressed pressedFlag;

    float starty;
    [SerializeField] float maxHeight;

    [SerializeField] GameObject footL;
    [SerializeField] GameObject footR;
    [SerializeField] GameObject IKtargetL;
    [SerializeField] GameObject IKtargetR;
    [SerializeField] Transform Camera;
    [SerializeField] Transform IKroot;
    [SerializeField] float multiplier;
    [SerializeField] Renderer footModelL;
    [SerializeField] Renderer footModelR;

    // Start is called before the first frame update
    void Start()
    {
        if (MouseCheck.mouseL != null && MouseCheck.mouseR != null)
        {
            mousePosL = MouseCheck.mouseL.Axes;
            mousePosR = MouseCheck.mouseR.Axes;
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

        if(!MouseCheck.mouseL.IsAnyButtonPressed && !MouseCheck.mouseR.IsAnyButtonPressed)
        {
            pressedFlag = Pressed.NONE;
            FallFoot(footR);
            FallFoot(footL);
        }

        if((pressedFlag == Pressed.NONE || pressedFlag == Pressed.LEFT) && MouseCheck.mouseL.IsAnyButtonPressed)
        {
            pressedFlag = Pressed.LEFT;
            MoveLeftFoot(yangle);
            FallFoot(footR);
        }

        if ((pressedFlag == Pressed.NONE || pressedFlag == Pressed.RIGHT) && MouseCheck.mouseR.IsAnyButtonPressed)
        {
            pressedFlag = Pressed.RIGHT;
            MoveRightFoot(yangle);
            FallFoot(footL);
        }
    }

    private void MoveLeftFoot(float yangle) => MoveFoot(yangle, MouseCheck.mouseL, footL, ref mousePosL);
    private void MoveRightFoot(float yangle) => MoveFoot(yangle, MouseCheck.mouseR, footR, ref mousePosR);

    private void MoveFoot(float yangle, IMouse mouse, GameObject foot, ref Vector2 mousePos)
    {
        Vector2 newPos = mouse.Axes;
        if (foot.transform.position.y > starty)
        {
            Vector2 deltaPos = newPos - mousePos;
            foot.transform.position = foot.transform.position + Quaternion.AngleAxis(yangle, Vector3.up) * new Vector3(newPos.x, 0, newPos.y) * multiplier;
            //mousePos = newPos;
        }
        mousePos = newPos;

        if (mouse.IsAnyButtonPressed)
        {
            if (foot.transform.position.y < starty + maxHeight)
            {
                foot.transform.position = foot.transform.position + Vector3.up * Time.deltaTime * 3;
            }
        }
        else
        {
            FallFoot(foot);
        }
    }

    void FallFoot(GameObject foot)
    {
        if (foot.transform.position.y > starty)
        {
            foot.transform.position = foot.transform.position - Vector3.up * Time.deltaTime * 3;
        }
    }
}
