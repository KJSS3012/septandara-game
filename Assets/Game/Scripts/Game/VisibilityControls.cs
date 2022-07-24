using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityControls : MonoBehaviour
{
    public CanvasGroup controlsUI;
    [SerializeField] private float value;
    public Player player;
    public GameObject[] enemysInScene;

    private void Start()
    {
        enemysInScene = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void OpacityControls(float value, bool restart)
    {
        controlsUI = GameObject.FindGameObjectWithTag("Controls").GetComponent<CanvasGroup>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        controlsUI.alpha = value;
        player.RestartControls(restart);
    }

    public void EnemysPause(bool pause)
    {
        if (enemysInScene.Length > 0)
        {
            for (int i = 0; i < enemysInScene.Length; i++)
            {
                enemysInScene[i].gameObject.GetComponent<Enemy>().PauseEnemy(pause);
            }
        }
    }

}
