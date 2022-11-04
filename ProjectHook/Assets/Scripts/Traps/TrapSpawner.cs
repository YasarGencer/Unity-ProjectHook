using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject trap;
    [SerializeField] private Transform spawnPos;
    [SerializeField] float timer, animTime;

    Animator anim;
    float timeLeft;
    private void Start() {
        anim = GetComponent<Animator>();
        StartCoroutine(StartCountdown());
    }
    public IEnumerator StartCountdown()
    {
        timeLeft = timer;
        while (timeLeft > 0)
        {
            if(timeLeft == animTime)
                anim.SetTrigger("Shoot");
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }
        Instantiate(trap,spawnPos.position, transform.rotation);
        StartCoroutine(StartCountdown());
    }
}
