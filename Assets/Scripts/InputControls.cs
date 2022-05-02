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
                    ""type"": ""Button"",
                    ""id"": ""ee4b1705-3ab8-4df4-a36b-da260cfbdafe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseValence"",
                    ""type"": ""Button"",
                    ""id"": ""a74dc899-73ce-4626-bdb7-d36c4dbaa3df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseArousal"",
                    ""type"": ""Button"",
                    ""id"": ""3227545a-847c-4710-9b19-f5df3ff2a43b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseArousal"",
                    ""type"": ""Button"",
                    ""id"": ""15126d01-9590-4f26-867e-49fa62c50717"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartPlayback"",
                    ""type"": ""Button"",
                    ""id"": ""9356bbc5-2fc0-4e10-83c5-8fb3a7baf6c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleSubtitlesPress"",
                    ""type"": ""Button"",
                    ""id"": ""d5b1047f-6473-4a0e-8641-080c521203a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleDisplayOfEmotionalData"",
                    ""type"": ""Button"",
                    ""id"": ""3d58f27f-4208-445e-8885-5073005f5a17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleNeuLog"",
                    ""type"": ""Button"",
                    ""id"": ""a47d603f-20d6-47f7-8c2d-211b04de7a65"",
                    ""expectedControlType"": ""Button"",
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
                    ""path"": ""<Keyboard>/j"",
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
                    ""path"": ""<Keyboard>/i"",
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
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseArousal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14a68e4f-11d6-4e6a-94cd-9dfdf4d541e0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartPlayback"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96e35371-de35-45c6-9c53-26d0d6e6ecb3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleSubtitlesPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bc0ab86-f7b4-4b33-8467-8e7ce7259d48"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDisplayOfEmotionalData"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b22be02-55bd-4c7e-9636-5414f175b254"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleNeuLog"",
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
        m_Keyboard_StartPlayback = m_Keyboard.FindAction("StartPlayback", throwIfNotFound: true);
        m_Keyboard_ToggleSubtitlesPress = m_Keyboard.FindAction("ToggleSubtitlesPress", throwIfNotFound: true);
        m_Keyboard_ToggleDisplayOfEmotionalData = m_Keyboard.FindAction("ToggleDisplayOfEmotionalData", throwIfNotFound: true);
        m_Keyboard_ToggleNeuLog = m_Keyboard.FindAction("ToggleNeuLog", throwIfNotFound: true);
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
    private readonly InputAction m_Keyboard_StartPlayback;
    private readonly InputAction m_Keyboard_ToggleSubtitlesPress;
    private readonly InputAction m_Keyboard_ToggleDisplayOfEmotionalData;
    private readonly InputAction m_Keyboard_ToggleNeuLog;
    public struct KeyboardActions
    {
        private @InputControls m_Wrapper;
        public KeyboardActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @IncreaseValence => m_Wrapper.m_Keyboard_IncreaseValence;
        public InputAction @DecreaseValence => m_Wrapper.m_Keyboard_DecreaseValence;
        public InputAction @IncreaseArousal => m_Wrapper.m_Keyboard_IncreaseArousal;
        public InputAction @DecreaseArousal => m_Wrapper.m_Keyboard_DecreaseArousal;
        public InputAction @StartPlayback => m_Wrapper.m_Keyboard_StartPlayback;
        public InputAction @ToggleSubtitlesPress => m_Wrapper.m_Keyboard_ToggleSubtitlesPress;
        public InputAction @ToggleDisplayOfEmotionalData => m_Wrapper.m_Keyboard_ToggleDisplayOfEmotionalData;
        public InputAction @ToggleNeuLog => m_Wrapper.m_Keyboard_ToggleNeuLog;
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
                @StartPlayback.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStartPlayback;
                @StartPlayback.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStartPlayback;
                @StartPlayback.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStartPlayback;
                @ToggleSubtitlesPress.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleSubtitlesPress;
                @ToggleDisplayOfEmotionalData.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleDisplayOfEmotionalData;
                @ToggleNeuLog.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleNeuLog;
                @ToggleNeuLog.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleNeuLog;
                @ToggleNeuLog.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleNeuLog;
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
                @StartPlayback.started += instance.OnStartPlayback;
                @StartPlayback.performed += instance.OnStartPlayback;
                @StartPlayback.canceled += instance.OnStartPlayback;
                @ToggleSubtitlesPress.started += instance.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.performed += instance.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.canceled += instance.OnToggleSubtitlesPress;
                @ToggleDisplayOfEmotionalData.started += instance.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.performed += instance.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.canceled += instance.OnToggleDisplayOfEmotionalData;
                @ToggleNeuLog.started += instance.OnToggleNeuLog;
                @ToggleNeuLog.performed += instance.OnToggleNeuLog;
                @ToggleNeuLog.canceled += instance.OnToggleNeuLog;
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
        void OnStartPlayback(InputAction.CallbackContext context);
        void OnToggleSubtitlesPress(InputAction.CallbackContext context);
        void OnToggleDisplayOfEmotionalData(InputAction.CallbackContext context);
        void OnToggleNeuLog(InputAction.CallbackContext context);
    }
}
