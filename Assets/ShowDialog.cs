using MarkusSecundus.MultiInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDialog : MonoBehaviour
{
    [SerializeField] GameObject DialogWindow;
    bool loaded = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var mouse in IInputProvider.Instance.ActiveMice)
        {
            mouse.ShouldDrawCursor = true;
            mouse.IsActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (loaded) return;
            loaded = true;

            DialogWindow.SetActive(true);

            TextAssigner ta = DialogWindow.transform.Find("Canvas/Image").GetComponent<TextAssigner>();
            ta.loadQuestion(IDCard.Instance);

            //GameObject buttonNext = DialogWindow.transform.Find("Canvas/Image/ButtonNext").GetComponent<GameObject>();
            //buttonNext.SetActive(false);

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
