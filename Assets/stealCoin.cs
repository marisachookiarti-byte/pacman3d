using System;
using UnityEngine;

public class stealCoin : MonoBehaviour
{
    public GameObject stolenCoin;
    public GameObject coin;
    public Health h;
    private Boolean found;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stolenCoin.SetActive(false);
        h.onDeath.AddListener(releaseCoin);
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("coin"))
        {
            Debug.Log("coin");
            Destroy(other.gameObject);
            stolenCoin.SetActive(true);
            stolenCoin.GetComponent<Collider>().enabled = false;
            found = true;
        }
    }
    public void releaseCoin()
    {
        if(found)
        Instantiate(coin, stolenCoin.transform.position, stolenCoin.transform.rotation);
    }
}
