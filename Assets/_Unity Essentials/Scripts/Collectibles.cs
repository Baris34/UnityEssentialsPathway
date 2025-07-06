using UnityEngine;

public class Collectibles : MonoBehaviour
{
	public float rotationSpeed = 20f;
    public GameObject OnCollectEffect;
    void Update()
    {
        transform.Rotate(0,rotationSpeed * Time.deltaTime, 0);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(OnCollectEffect, transform.position, transform.rotation);  
        }

    }
}
