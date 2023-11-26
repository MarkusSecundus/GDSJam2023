using MarkusSecundus.MultiInput;
using MarkusSecundus.PhysicsSwordfight.Utils.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FootControl : MonoBehaviour
{
    enum Pressed
    {
        NONE,
        LEFT,
        RIGHT
    }

    IMouse mouseL, mouseR;

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
            SetMice(MouseCheck.mouseL, MouseCheck.mouseR);
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


    void SetMice(IMouse left, IMouse right)
    {
        mouseL = left;
        mouseR = right;

        mousePosL = left.Axes;
        mousePosR = right.Axes;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        handleCursor(left, footModelL, footL);
        handleCursor(right, footModelR, footR);

        void handleCursor(IMouse m, Renderer footModel, GameObject ball)
        {
            footModel.material.color = m.CursorColor;
            foreach (var r in ball.GetComponentsInChildren<Renderer>())
            {
                Debug.Log($"Setting color to {m.CursorColor}", this);
                r.material.SetColor("_EmissionColor", m.CursorColor) ;
            }
            m.ShouldDrawCursor = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (IInputProvider.Instance.ActiveMice.Count < 2)
        {
            return;
        }

        if (mouseR == null && mouseL == null)
        {
            SetMice(IInputProvider.Instance.ActiveMice.ElementAt(0), IInputProvider.Instance.ActiveMice.ElementAt(1));
        }
        
        float yangle = Camera.rotation.eulerAngles.y;

        if(!mouseL.IsAnyButtonPressed && !mouseR.IsAnyButtonPressed)
        {
            pressedFlag = Pressed.NONE;
            FallFoot(footR);
            FallFoot(footL);
        }

        if((pressedFlag == Pressed.NONE || pressedFlag == Pressed.LEFT) && mouseL.IsAnyButtonPressed)
        {
            pressedFlag = Pressed.LEFT;
            MoveLeftFoot(yangle);
            FallFoot(footR);
        }

        if ((pressedFlag == Pressed.NONE || pressedFlag == Pressed.RIGHT) && mouseR.IsAnyButtonPressed)
        {
            pressedFlag = Pressed.RIGHT;
            MoveRightFoot(yangle);
            FallFoot(footL);
        }
    }

    private GameObject _otherFoot(GameObject foot) => foot == footL ? footR : footL;
    private float _getGroundHeight(GameObject foot)
    {
        if (!Physics.Raycast(foot.transform.position, Vector3.down, out var info, LayerMask.NameToLayer("Wall")))
        {
            Debug.Log("Raycast hit nothing!");
            return starty;
        }

        return info.point.y;// + 0.5f;
    } 


    private void MoveLeftFoot(float yangle) => MoveFoot(yangle, mouseL, footL, ref mousePosL);
    private void MoveRightFoot(float yangle) => MoveFoot(yangle, mouseR, footR, ref mousePosR);

    private void MoveFoot(float yangle, IMouse mouse, GameObject foot, ref Vector2 mousePos)
    {
        Vector2 newPos = mouse.Axes;
        var groundY = _getGroundHeight(foot);

        if (foot.transform.position.y > groundY)
        {
            foot.transform.position = foot.transform.position + Quaternion.AngleAxis(yangle, Vector3.up) * new Vector3(newPos.x, 0, newPos.y) * multiplier;
        }
        mousePos = newPos;

        if (mouse.IsAnyButtonPressed)
        {
            if (foot.transform.position.y < groundY + maxHeight)
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
