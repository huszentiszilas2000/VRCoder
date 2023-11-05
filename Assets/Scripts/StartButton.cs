using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class StartButton : Component
{
    public AudioSource audioSource;
    public bool isPressed = false;
    public GameObject press;
    public GameObject socket;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( isPressed == false && other.gameObject.name == "RightHand" && other.gameObject.GetComponent<XRDirectInteractor>() != null && other.gameObject.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0 )
        {
            press.transform.localPosition = new Vector3(0, 0.186f, 0);
            audioSource.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.name == "RightHand" && other.gameObject.GetComponent<XRDirectInteractor>() != null && other.gameObject.GetComponent<XRDirectInteractor>().interactablesSelected.Count == 0 )
        {
            press.transform.localPosition = new Vector3(0, 0.333f, 0);
            StartPressed();
            isPressed = false;
        }
    }

    public void StartPressed()
    {
        if(socket.GetComponent<RopeSocket>() == null)
        {
            Debug.LogError("Start Button: No plug is connected!");
            return;
        }

        if(socket.GetComponent<RopeSocket>().GetComponentCorrect(gameObject) == null)
        {
            Debug.LogError("Start Button: No next call connected!");
            return;
        }

        if (socket.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponentInParent<IComponent>() == null)
        {
            Debug.LogError("Start Button: Assert!");
            return;
        }
        StartCoroutine(socket.GetComponent<RopeSocket>().GetComponentCorrect(gameObject).GetComponentInParent<IComponent>().RunComponent());
        //StopCoroutine(nextCall.GetComponent<IComponent>().RunComponent());
    }

    public void StopPressed()
    {
        StopAllCoroutines();
    }
}
