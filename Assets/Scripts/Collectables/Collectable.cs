using System.Collections;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public bool isCurrentlyCollectable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Collect();
    public abstract void Setup();
    public void Awake()
    {
        Setup();
    }

    public virtual IEnumerator CollectAnimation()
    {
        isCurrentlyCollectable = false;
        Vector3 startScale = transform.localScale;
        Vector3 bigScale = transform.localScale * 1.2f;
        float duration = 0.2f;
        float time = 0f;
        
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = Mathf.SmoothStep(0f, 1f, t);
            transform.localScale = Vector3.Lerp(startScale, bigScale, t);
            yield return null;
        }

        duration = 0.5f;
        time = 0f;
        
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            t = Mathf.SmoothStep(0f, 1f, t);
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
