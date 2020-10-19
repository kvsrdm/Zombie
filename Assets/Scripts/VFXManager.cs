using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance = null;
    public ParticleSystem bombFX;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayBombFX(Vector3 position) {
        bombFX.transform.position = position;
        bombFX.Play();
    }
}
