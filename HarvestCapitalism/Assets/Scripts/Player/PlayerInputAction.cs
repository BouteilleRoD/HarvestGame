// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInputAction.inputactions'

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
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""779b8919-c9d6-431e-be72-fba401deca72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenInventory"",
                    ""type"": ""Button"",
                    ""id"": ""7ee965b8-86a3-445a-b8bc-42ce259801a0"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""734ae0b2-f83a-4809-8687-5e31604850f0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6404a8c-27b9-42d9-89b2-9bb0a89cf6a5"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenInventory"",
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
        m_KeyboardMouse_Interact = m_KeyboardMouse.FindAction("Interact", throwIfNotFound: true);
        m_KeyboardMouse_OpenInventory = m_KeyboardMouse.FindAction("OpenInventory", throwIfNotFound: true);
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
    private readonly InputAction m_KeyboardMouse_Interact;
    private readonly InputAction m_KeyboardMouse_OpenInventory;
    public struct KeyboardMouseActions
    {
        private @PlayerInputAction m_Wrapper;
        public KeyboardMouseActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_KeyboardMouse_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_KeyboardMouse_Vertical;
        public InputAction @Attack => m_Wrapper.m_KeyboardMouse_Attack;
        public InputAction @Interact => m_Wrapper.m_KeyboardMouse_Interact;
        public InputAction @OpenInventory => m_Wrapper.m_KeyboardMouse_OpenInventory;
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
                @Interact.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnInteract;
                @OpenInventory.started -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.performed -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnOpenInventory;
                @OpenInventory.canceled -= m_Wrapper.m_KeyboardMouseActionsCallbackInterface.OnOpenInventory;
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
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
            }
        }
    }
    public KeyboardMouseActions @KeyboardMouse => new KeyboardMouseActions(this);
    public interface IKeyboardMouseActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnOpenInventory(InputAction.CallbackContext context);
    }
}
