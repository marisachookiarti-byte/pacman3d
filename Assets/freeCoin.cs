using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class freeCoin : MonoBehaviour
{
    private Boolean check = false;
    public GameObject coin;

    public void Start()
    {
        Invoke("changeCheck",1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == null||check) return;

        if (collision.gameObject.CompareTag("wall"))
        {
            Instantiate(coin, new Vector3(Random.Range(-12, 12), 1.5f, Random.Range(-12, 12)), gameObject.transform.rotation);
            Destroy(gameObject);
        }
        check = true;
    }
    private void changeCheck()
    {
        check = true;
    }
}
