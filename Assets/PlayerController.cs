using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public GameObject VRCamera;

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); //Megkeress�k a karakter mozgat� komponens�nket.
    }
    void Update()
    {
        //A collider�nket ami v�gzi a mozg�sunkat folyamatosan mozgatni kell a VRCamera objektummal egy vonalban. Ez az�rt fontos, mert ha mozgunk a t�rben akkor nem egy helyen lesz a fej �s a mozgat� colliderek, ez azt eredm�nyezi, hogy teljesen sz�t cs�szik az ahol a hitboxunk van �s ahol a fej�nk igaz�b�l.
        //Fontos, hogy localposition-t szedj�k ki, mert a position az a vil�gban l�v� pozici�j�t adja ki m�g a localposition a parentnek val� poz�ci�ja. K�pet itt lehet rajzolni
        //Mivel minden ember m�s nagys�gba van ez�rt a fej magass�g�t ugyan �gy belekell venn�nk. felt�telezhetj�k azt is, hogy a j�tkost gugol�sra �szt�n�zz�k a tov�bb jut�s v�gett, �gy a hitbox�t cs�kkenteni kell valahogy, hogy �tf�rjen a lyukon.
        //De hogyan is j�n ki ez ? A magass�got kisz�m�tjuk a fej(kamer�t�l �s ez lesz a heightunk). Ez nem el�g, mert a Unity a �gy sz�mol, hogy magass�g/2 + ir�nyba �s - ir�nyba ez azt jelenteni, hogy offsetelni kell a magass�got. VRCamera.localpositition.y magass�g offset VRCamera.localpositition.y
        float headHeight = characterController.height;
        characterController.center = new Vector3(VRCamera.transform.localPosition.x, headHeight/2, VRCamera.transform.localPosition.z);
    }
}
