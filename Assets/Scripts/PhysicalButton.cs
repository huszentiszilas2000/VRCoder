using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PhysicalButton : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isPressed = false;
    public GameObject press;
    public UnityEvent Pressed;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed == false && other.gameObject.name == "RightHand")
        {
            press.transform.localPosition = new Vector3(0, 0, 0);
            audioSource.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RightHand")
        {
            press.transform.localPosition = new Vector3(0, 0, 1.15f);
            Pressed.Invoke();
            isPressed = false;
        }
    }
}
