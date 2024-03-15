using UnityEngine;

public class ParticleAligner : MonoBehaviour
{
    private ParticleSystem.MainModule psMain;

    private void Start()
    {
        psMain = GetComponent<ParticleSystem>().main;
    }

    private void Update()
    {
        psMain.startRotation = -transform.rotation.eulerAngles.z * Mathf.Rad2Deg;
    }
}