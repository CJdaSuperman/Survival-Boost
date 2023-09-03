using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Manages the input for the game
    /// </summary>
    public class InputManager
    {
#if UNITY_ANDROID || UNITY_IOS
        private const int FirstFinger  = 0;
        private const int SecondFinger = 1;

        public static float RotationDirection(bool boost, float rotationSensitivity)
        {
            if (Input.touchCount > 0)
            {
                Touch dragFinger;

                // More than one finger on the screen means the first finger is
                // being used to boost ship; use the second finger to know the
                // rotation; all other fingers get ignored
                if (Input.touchCount > 1)
                {
                    dragFinger = Input.GetTouch(SecondFinger);
                }
                // If there is one finger on the screen, and it's not pressing
                // the boost button, get rotation
                else if (!boost)
                {
                    dragFinger = Input.GetTouch(FirstFinger);
                }
                // If there's one finger on the screen, but ship is currently boosting,
                // do not rotate
                else
                {
                    return 0f;
                }

                return dragFinger.phase == TouchPhase.Moved ? dragFinger.deltaPosition.x * rotationSensitivity : 0f;
            }
            
            return 0f;
        }
#else
        private const string HorizontalAxis = "Horizontal";

        public static bool IsBoosting()
        {
#if UNITY_STANDALONE_WIN || UNITY_WEBGL
            return Input.GetKey(KeyCode.Space);
#else
            return false;
#endif
        }

        public static float RotationDirection(float rotationSensitivity) => Input.GetAxis(HorizontalAxis) * rotationSensitivity;

        public static bool PauseGame()
        {
#if UNITY_STANDALONE_WIN || UNITY_WEBGL
            return Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape);
#else
            return false;
#endif
        }
#endif
    }
}