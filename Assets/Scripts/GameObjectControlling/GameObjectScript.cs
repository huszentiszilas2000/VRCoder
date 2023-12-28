using UnityEngine;

public class GameObjectScript : MonoBehaviour
{
    [SerializeField]
    public GameObject variableGameObject;

    private void Update()
    {
        if (variableGameObject == null)
            Destroy(this.gameObject);
    }
}
