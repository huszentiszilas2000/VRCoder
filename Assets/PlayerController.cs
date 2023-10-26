using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController characterController;
    public GameObject VRCamera;

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); //Megkeressük a karakter mozgató komponensünket.
    }
    void Update()
    {
        //A colliderünket ami végzi a mozgásunkat folyamatosan mozgatni kell a VRCamera objektummal egy vonalban. Ez azért fontos, mert ha mozgunk a térben akkor nem egy helyen lesz a fej és a mozgató colliderek, ez azt eredményezi, hogy teljesen szét csúszik az ahol a hitboxunk van és ahol a fejünk igazából.
        //Fontos, hogy localposition-t szedjük ki, mert a position az a világban lévõ pozicióját adja ki míg a localposition a parentnek való pozíciója. Képet itt lehet rajzolni
        //Mivel minden ember más nagyságba van ezért a fej magasságát ugyan úgy belekell vennünk. feltételezhetjük azt is, hogy a játkost gugolásra ösztönözzük a tovább jutás végett, így a hitboxát csökkenteni kell valahogy, hogy átférjen a lyukon.
        //De hogyan is jön ki ez ? A magasságot kiszámítjuk a fej(kamerától és ez lesz a heightunk). Ez nem elég, mert a Unity a úgy számol, hogy magasság/2 + irányba és - irányba ez azt jelenteni, hogy offsetelni kell a magasságot. VRCamera.localpositition.y magasság offset VRCamera.localpositition.y
        float headHeight = VRCamera.transform.localPosition.y;
        characterController.height = headHeight;
        characterController.center = new Vector3(VRCamera.transform.localPosition.x, headHeight/2, VRCamera.transform.localPosition.z);
        if (input.axis.magnitude > 0.1f)
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y)); //
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0));
        }
    }*/
}
