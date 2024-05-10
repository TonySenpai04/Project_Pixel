using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tony
{
    public abstract class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] protected bool isPressed;
        [SerializeField] protected MovementController movementController;
        [SerializeField] protected Button btn;

        public virtual void Start()
        {
            btn=GetComponent<Button>();
        }
        public virtual void Update()
        {

        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
           isPressed=true;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
            movementController.StopMovement();
        }

    }
}
