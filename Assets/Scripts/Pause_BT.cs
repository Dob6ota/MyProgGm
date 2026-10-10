using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Pause_BT : MonoBehaviour
{
    public GameObject panel;

    public void Pause()
    {
        bool panelActive = false;
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            panelActive = true;
            panel.SetActive(panelActive);
        }
        else
            Time.timeScale = 1f;
            panel.SetActive(panelActive);
    }
}
