using MarkusSecundus.MultiInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit trigger");
            DialogWindow.SetActive(true);
            foreach (IMouse mouse in IInputProvider.Instance.ActiveMice)
            {
                mouse.ShouldDrawCursor = false;
                mouse.IsActive = false;
            }

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
