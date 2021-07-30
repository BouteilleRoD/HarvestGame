// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""Keyboard/Mouse"",
            ""id"": ""bde706d7-a981-4485-b9d9-c6115a34c54f"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""7e6b8df0-70aa-4ede-b5c4-801b090a6867"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""9dd0ed94-05ad-404c-a5be-843798cfbe06"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""6a41d241-3a48-4655-8f8c-3d7ddfaffc4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""XAxis"",
                    ""id"": ""92fd2eea-787d-4ff7-89ba-79c560fc7b3e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d6e550a6-513a-4d28-a500-cf90a6650b59"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d4bff6ae-c5ba-46cf-99bb-db82419b456f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ZAxis"",
                    ""id"": ""897d3fc5-7de9-4ebf-b91e-a4f7ee7fb568"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9caf4818-168b-4c6e-a6d1-e3c6de08518b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cf66a16c-051b-4113-b9da-16cf2795dac2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3b8f8544-b1da-4518-8ede-a6c27c327199"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard/Mouse
        m_KeyboardMouse = asset.FindActionMap("Keyboard/Mouse", throwIfNotFound: true);
        m_KeyboardMouse_Horizontal = m_KeyboardMouse.FindAction("Horizontal", throwIfNotFound: true);
        m_KeyboardMouse_Vertical = m_KeyboardMouse.FindAction("Vertical", throwIfNotFound: true);
        m_KeyboardMouse_Attack = m_KeyboardMouse.FindAction("Attack", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Keyboard/Mouse
    private readonly InputActionMap m_KeyboardMouse;
    private IKeyboardMouseActions m_KeyboardMouseActionsCallbackInterface;
    private readonly InputAction m_KeyboardMouse_Horizontal;
    private readonly InputAction m_KeyboardMouse_Vertical;
    private readonly InputAction m_KeyboardMouse_Attack;
    public struct KeyboardMouseActions
    {
        private @PlayerInputAction m_Wrapper;
        public KeyboardMouseActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_KeyboardMouse_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_KeyboardMouse_Vertical;
        public InputAction @Attack => m_Wrapper.m_KeyboardMouse_Attack;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardMouseActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnVertical;
                @Attack.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_KeyboardMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public KeyboardMouseActions @KeyboardMouse => new KeyboardMouseActions(this);
    public interface IKeyboardMouseActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
