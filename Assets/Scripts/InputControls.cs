// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""71c03045-bffc-409b-a52f-d81aff5f4c3c"",
            ""actions"": [
                {
                    ""name"": ""IncreaseValence"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ee4b1705-3ab8-4df4-a36b-da260cfbdafe"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseValence"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a74dc899-73ce-4626-bdb7-d36c4dbaa3df"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseArousal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3227545a-847c-4710-9b19-f5df3ff2a43b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseArousal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""15126d01-9590-4f26-867e-49fa62c50717"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b1cde0a0-f6d3-4f92-88bc-ebdab99e0c11"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseValence"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""322610eb-6280-4470-a35e-39f8063d0690"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseValence"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""076fc29e-b5a6-459d-9111-c0c45c186aaa"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseArousal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed59aece-a96e-40db-9a0d-20cd8652b11f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseArousal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_IncreaseValence = m_Keyboard.FindAction("IncreaseValence", throwIfNotFound: true);
        m_Keyboard_DecreaseValence = m_Keyboard.FindAction("DecreaseValence", throwIfNotFound: true);
        m_Keyboard_IncreaseArousal = m_Keyboard.FindAction("IncreaseArousal", throwIfNotFound: true);
        m_Keyboard_DecreaseArousal = m_Keyboard.FindAction("DecreaseArousal", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_IncreaseValence;
    private readonly InputAction m_Keyboard_DecreaseValence;
    private readonly InputAction m_Keyboard_IncreaseArousal;
    private readonly InputAction m_Keyboard_DecreaseArousal;
    public struct KeyboardActions
    {
        private @InputControls m_Wrapper;
        public KeyboardActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @IncreaseValence => m_Wrapper.m_Keyboard_IncreaseValence;
        public InputAction @DecreaseValence => m_Wrapper.m_Keyboard_DecreaseValence;
        public InputAction @IncreaseArousal => m_Wrapper.m_Keyboard_IncreaseArousal;
        public InputAction @DecreaseArousal => m_Wrapper.m_Keyboard_DecreaseArousal;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @IncreaseValence.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseValence;
                @IncreaseValence.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseValence;
                @IncreaseValence.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseValence;
                @DecreaseValence.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseValence;
                @DecreaseValence.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseValence;
                @DecreaseValence.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseValence;
                @IncreaseArousal.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseArousal;
                @IncreaseArousal.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseArousal;
                @IncreaseArousal.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseArousal;
                @DecreaseArousal.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseArousal;
                @DecreaseArousal.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseArousal;
                @DecreaseArousal.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseArousal;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @IncreaseValence.started += instance.OnIncreaseValence;
                @IncreaseValence.performed += instance.OnIncreaseValence;
                @IncreaseValence.canceled += instance.OnIncreaseValence;
                @DecreaseValence.started += instance.OnDecreaseValence;
                @DecreaseValence.performed += instance.OnDecreaseValence;
                @DecreaseValence.canceled += instance.OnDecreaseValence;
                @IncreaseArousal.started += instance.OnIncreaseArousal;
                @IncreaseArousal.performed += instance.OnIncreaseArousal;
                @IncreaseArousal.canceled += instance.OnIncreaseArousal;
                @DecreaseArousal.started += instance.OnDecreaseArousal;
                @DecreaseArousal.performed += instance.OnDecreaseArousal;
                @DecreaseArousal.canceled += instance.OnDecreaseArousal;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnIncreaseValence(InputAction.CallbackContext context);
        void OnDecreaseValence(InputAction.CallbackContext context);
        void OnIncreaseArousal(InputAction.CallbackContext context);
        void OnDecreaseArousal(InputAction.CallbackContext context);
    }
}
