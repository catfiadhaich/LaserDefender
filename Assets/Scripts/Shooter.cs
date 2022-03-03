using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;

    [Header("AI")]
    [SerializeField] private float firingRate = 0.75f;
    [SerializeField] private float firingTimeVariance = 0.5f;
    [SerializeField] private float minFiringRate = 0.1f;
    [SerializeField] private bool useAI = false;

    [HideInInspector]
    public bool isShooting;
    
    private Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        if (useAI) 
        {
            isShooting = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire() 
    {
        if (isShooting && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuously());
        } 
        else if (!isShooting && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously() 
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                                transform.position,
                                                Quaternion.identity
            );

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
        
            yield return new WaitForSeconds(getRandomShotTime());
        }
    }

    public float getRandomShotTime()
    {
        float spawnTime = Random.Range(firingRate - firingTimeVariance,
                                        firingRate + firingTimeVariance);
        return Mathf.Clamp(spawnTime, minFiringRate, float.MaxValue);   
    }
}
