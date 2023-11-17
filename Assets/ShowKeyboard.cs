using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class ShowKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public NonNativeKeyboard keyboard;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void OpenKeyboard()
    {
        keyboard.InputField = inputField;
        keyboard.PresentKeyboard();
    }

    public void HideKeyboard()
    {
        keyboard.InputField = null;
        keyboard.Close();
    }


}
