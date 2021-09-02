using UnityEngine;

/// <summary>
/// The class definition for a projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float m_Lifespan = 3f;
    public GameObject particle;
    void Start()
    {
        Destroy(gameObject, m_Lifespan);
    }
    void OnCollisionEnter(Collision theCollision)
    {
        Destroy(gameObject);
        Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
    }
}
