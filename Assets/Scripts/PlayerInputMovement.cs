using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputMovement : MonoBehaviour {

    public bool IgnoreGuiFingers = true;

    public int RequiredFingerCount;

    public LeanSelectable RequiredSelectable;

    public Camera Camera;
#if UNITY_EDITOR
    protected virtual void Reset()
    {
        if (RequiredSelectable == null)
        {
            RequiredSelectable = GetComponent<LeanSelectable>();
        }
    }
#endif

    protected virtual void Update()
    {
        // If we require a selectable and it isn't selected, cancel translation
        if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
        {
            return;
        }

        // Get the fingers we want to use
        var fingers = LeanTouch.GetFingers(IgnoreGuiFingers, RequiredFingerCount, RequiredSelectable);

        // Calculate the screenDelta value based on these fingers
        var screenDelta = LeanGesture.GetScreenDelta(fingers);

        //Swipe Left or Right
        if (screenDelta.x < -Mathf.Abs(screenDelta.y) || screenDelta.x > Mathf.Abs(screenDelta.y))
        {
            Translate(screenDelta);
        }

        // Perform the translation
        //sTranslate(screenDelta);
    }

    private void Translate(Vector2 screenDelta)
    {
        // If camera is null, try and get the main camera, return true if a camera was found
        if (LeanTouch.GetCamera(ref Camera) == true)
        {
            // Screen position of the transform
            var screenPosition = Camera.WorldToScreenPoint(transform.position);

            // Add the deltaPosition
            screenPosition += (Vector3)screenDelta;

            // Convert back to world space
            Vector3 xPos = Camera.ScreenToWorldPoint(screenPosition);
            Vector3 newPos = new Vector3(xPos.x, transform.position.y, transform.position.x);
            transform.position = newPos;
        }
    }

    protected virtual void OnEnable()
    {
        LeanTouch.OnFingerSwipe += OnFingerSwipe;
    }

    protected virtual void OnDisable()
    {
        LeanTouch.OnFingerSwipe -= OnFingerSwipe;
    }

    private void OnFingerSwipe(LeanFinger finger)
    {
        var swipe = finger.SwipeScreenDelta;

        if (swipe.x < -Mathf.Abs(swipe.y)) // swipe left
        {
            //Translate(swipe);
        }

        if (swipe.x > Mathf.Abs(swipe.y)) // swipe right
        {
            //Translate(swipe);
        }

        if (swipe.y < -Mathf.Abs(swipe.x)) // swipe down
        {
           
        }

        if (swipe.y > Mathf.Abs(swipe.x)) // swipe up
        {

        }
    }
}
