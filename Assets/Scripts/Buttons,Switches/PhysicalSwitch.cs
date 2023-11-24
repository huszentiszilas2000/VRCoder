using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalSwitch : MonoBehaviour
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
            Pressed.Invoke();
            isPressed = true;
        }
    }

    public void TurnOff()
    {
        press.transform.localPosition = new Vector3(0, 1.4f, 0);
        isPressed = false;
    }
}
