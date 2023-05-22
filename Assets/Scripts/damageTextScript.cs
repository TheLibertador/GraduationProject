using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextScript : MonoBehaviour
{
    private Transform mainCameraTransform;
    private TextMeshPro textMeshPro;
    private float fadeDuration = 2f;
    private float fadeTimer = 0f;
    private float rotationSpeed = 5f;

    void Start()
    {
        // Get the main camera's transform
        mainCameraTransform = Camera.main.transform;

        // Get the TextMeshPro component from the current GameObject
        textMeshPro = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        // Calculate the target rotation based on the main camera's position and the GameObject's position
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - mainCameraTransform.position, Vector3.up);

        // Smoothly rotate the GameObject towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Calculate the angle difference between the GameObject's forward vector and the main camera's forward vector
        float angleDifference = Vector3.SignedAngle(transform.forward, mainCameraTransform.forward, Vector3.up);

        // Flip the GameObject horizontally based on the angle difference
        if (angleDifference > 90f || angleDifference < -90f)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        // Calculate the alpha value based on the fade timer and duration
        float alpha = 1f - Mathf.Clamp01(fadeTimer / fadeDuration);

        // Update the color of the TextMeshPro text with the calculated alpha
        textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);

        // Increase the fade timer
        fadeTimer += Time.deltaTime;

        // If the fade timer exceeds the fade duration, destroy the GameObject
        if (fadeTimer >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}