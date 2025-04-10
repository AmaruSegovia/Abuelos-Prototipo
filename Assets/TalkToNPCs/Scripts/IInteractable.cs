using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(Transform interactorTransform);
    Transform GetTransform();
    void OnPlayerNearby();
    void OnPlayerFar();
    string GetInteractText();
}
