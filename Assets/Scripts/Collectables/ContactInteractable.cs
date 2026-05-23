using UnityEngine;

public class ContactInteractable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Collectable collectable;
    void Awake()
    {
        collectable = GetComponent<Collectable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            collectable.Collect();
        }
    }
}
