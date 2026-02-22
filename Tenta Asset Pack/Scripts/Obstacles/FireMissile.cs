using UnityEngine;

public class FireMissile : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private Transform instantiationTransform;
    [SerializeField] private float instanceLifeTime;
    [SerializeField] private float ShotCooldown = 2f;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDirection;
    private void Start()
    {
        if (instantiationTransform == null)
        {
            instantiationTransform = transform;
        }
    }

    private void Update()
    {
        ShotCooldown -= Time.deltaTime;
        if (ShotCooldown <= 0)
        {
            InstantiatePrefab();
        }
    }
    
    public void InstantiatePrefab()
    {
        GameObject instance = Instantiate(objectToInstantiate, instantiationTransform.position, instantiationTransform.rotation);
        if (instanceLifeTime > 0)
        {
            Destroy(instance, instanceLifeTime);
        }
        Rigidbody2D instantiationRB = instance.GetComponent<Rigidbody2D>();
        Vector2 newPos = instantiationRB.position + new Vector2(bulletSpeed * bulletDirection, 0) * Time.fixedDeltaTime;
        instantiationRB.MovePosition(newPos);
        ShotCooldown = 2f;
    }
}
