using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    //public GameObject bomb;

    public float radius = 200f;
    public float power = 100f;
    public float upForce = 100f;

   

    public void Explode()
    {
        Invoke("Explosion", 3);
    }
    public void Explosion()
    {
        VFXManager.Instance.PlayBombFX(transform.position);
        Vector3 explosionPosition = gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Zombie"))
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                }
                hit.GetComponent<Enemy>().ResetDelayed(0.1f);
                Debug.Log("Zombiye değdiii");
            }           
        }
        transform.parent.gameObject.SetActive(false);
    }
}
