using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]

public class ClampGrabController : MonoBehaviour
{
    [SerializeField] private float maxGrabDistance = 0.1f;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }
    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            // Получи interactor который держит
            var interactor = grabInteractable.interactorsSelecting[0];

            // Дистанция между объектом и attach точкой руки
            float distance = Vector3.Distance(
                transform.position,
                interactor.GetAttachTransform(grabInteractable).position
            );

            // Если далеко - отпусти
            if (distance > maxGrabDistance)
            {
                grabInteractable.interactionManager.CancelInteractableSelection(
                    (IXRSelectInteractable)grabInteractable
                );
            }
        }
    }
}
