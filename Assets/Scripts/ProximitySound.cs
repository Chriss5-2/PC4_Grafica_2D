using System;
using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 15f;
    public float minDistance = 1f;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        float volume = 2f - Mathf.InverseLerp(minDistance, maxDistance, distance);

        volume = Mathf.Clamp01(volume);

        audioSource.volume = volume;
    }
}
