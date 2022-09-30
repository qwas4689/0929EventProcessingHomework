using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerState : MonoBehaviour
{
    private TextMeshProUGUI PlayerNowStateText;

    public UnityEvent<float, int, int> BurnMagicState = new UnityEvent<float, int, int>();
    public UnityEvent<float, int, int> PoisonMagicState = new UnityEvent<float, int, int>();
    public UnityEvent CurseMagicState = new UnityEvent();
    public UnityEvent<int> PhysicsMagicState = new UnityEvent<int>();

    private void Start()
    {
        PlayerNowStateText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BurnMagicState.Invoke(5f, 5, 4);
            PlayerNowStateText.text = "Burn Magic";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PoisonMagicState.Invoke(3f, 2, 2);
            PlayerNowStateText.text = "Poison Magic";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CurseMagicState.Invoke();
            PlayerNowStateText.text = "Curse Magic";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PhysicsMagicState.Invoke(10);
            PlayerNowStateText.text = "Physics Magic";
        }
    }
}
