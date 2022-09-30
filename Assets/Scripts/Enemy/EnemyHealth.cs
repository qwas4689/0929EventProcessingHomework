using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public UnityEvent<GameObject> EnemyDie = new UnityEvent<GameObject>();

    public int HP { get; set; }

    private int CurseDieHP;
    private bool isCurse { get; set; }

    public PlayerInput playerInput;
    public PlayerState playerState;

    void Start()
    {
        HP = 100;
        CurseDieHP = HP / 10;

        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        playerState = GameObject.Find("Player").GetComponent<PlayerState>();
        playerInput.ClickEnemy.AddListener(Hit);
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
                EnemyDie.Invoke(gameObject);
            }
            if (HP < 0)
            {
                EnemyDie.Invoke(gameObject);
            }
        }
    }
}
