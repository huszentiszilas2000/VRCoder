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
    public float xOg;
    public float yOg;
    public float zOg;
    public float xNew;
    public float yNew;
    public float zNew;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed == false && other.gameObject.name == "RightHand")
        {
            press.transform.localPosition = new Vector3(xOg, yOg, zOg);
            audioSource.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RightHand")
        {
            press.transform.localPosition = new Vector3(xNew, yNew, zNew);
            Pressed.Invoke();
            isPressed = false;
        }
    }
}
