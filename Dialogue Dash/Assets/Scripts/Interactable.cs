
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public abstract void Interact();
}
