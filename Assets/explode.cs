using UnityEngine;
using System.Threading.Tasks;

public class explode : MonoBehaviour
{
    public Health h;
    public GameObject explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        h.onDeath.AddListener(exploding);
        explosion.SetActive(false);
    }

    private async void exploding()
    {
        explosion.SetActive(true);
        explosion.transform.parent = null;
        int scale = 1;
        while (scale<=5)
        {
            explosion.transform.localScale = scale*new Vector3(1,1,1);
            scale++;
            await Task.Yield();
        }
    }
}
