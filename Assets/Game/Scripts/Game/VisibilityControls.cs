using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityControls : MonoBehaviour
{
    public CanvasGroup controlsUI;
    [SerializeField] private float value;
    public Player player;

    public void OpacityControls(float value, bool restart)
    {
        controlsUI = GameObject.FindGameObjectWithTag("Controls").GetComponent<CanvasGroup>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        controlsUI.alpha = value;
        player.RestartControls(restart);
    }

}
