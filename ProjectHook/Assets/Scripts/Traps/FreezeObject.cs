using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject particle;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(FreezeManager.instance.GetFrozen() == false)
                FreezeManager.instance.Freeze();
                Destroy(Instantiate(particle, transform.position, Quaternion.identity),5f);
        }
    }
    private void Start() {
        Destroy(gameObject, 3f);
    }
    private void Update() {
        if(transform.rotation.y == 180)
            transform.Translate(Vector3.right * 1 * Time.deltaTime * speed);
        else
            transform.Translate(Vector3.right * -1 * Time.deltaTime * speed);
    }
}
