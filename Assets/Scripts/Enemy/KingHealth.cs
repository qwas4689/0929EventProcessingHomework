using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KingHealth : MonoBehaviour
{
    public UnityEvent<GameObject> KingDie = new UnityEvent<GameObject>();

    public int HP { get; set; }

    private int CurseDieHP;
    public PlayerInput playerInput;

    void Start()
    {
        HP = 1000;
        CurseDieHP = HP / 10;
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        playerInput.ClickKing.AddListener(Hit);
    }

    private void Hit(float time, int count, int damage)
    {
        StartCoroutine(Hitting(time, count, damage));
    }

    IEnumerator Hitting(float time, int count, int damage)
    {
        while (--count + 1 == 0)
        {
            yield return new WaitForSeconds(time);

            HP -= damage;

            if (HP > CurseDieHP)
            {
                KingDie.Invoke(gameObject);
            }
            if (HP < 0)
            {
                KingDie.Invoke(gameObject);
            }
        }
    }

}
