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
                    ""name"": ""StartPlayback"",
                    ""type"": ""Button"",
                    ""id"": ""9356bbc5-2fc0-4e10-83c5-8fb3a7baf6c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopPlayback"",
                    ""type"": ""Button"",
                    ""id"": ""c3a26a22-2057-4734-a099-a766bd05b150"",
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
                },
                {
                    ""name"": ""MenuShowHide"",
                    ""type"": ""Button"",
                    ""id"": ""598c1c3c-500b-45d1-951d-c80222f3123d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseGSRCalibrationValue"",
                    ""type"": ""Button"",
                    ""id"": ""0c48737e-39f6-47cf-9607-b0e018ef2c4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DecreaseGSRCalibrationValue"",
                    ""type"": ""Button"",
                    ""id"": ""7c876a91-0964-4730-baca-93020f503719"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleOperatorDataDisplay"",
                    ""type"": ""Button"",
                    ""id"": ""cae7cf6e-d501-42bb-968e-5fa629887062"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleInteractiveMusic"",
                    ""type"": ""Button"",
                    ""id"": ""1b3f418f-ada9-4cc3-a239-d00a11f092d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuitApplication"",
                    ""type"": ""Button"",
                    ""id"": ""b8ac7ebf-daaf-497f-9786-d731dc1c921e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                    ""path"": ""<Keyboard>/f1"",
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
                    ""path"": ""<Keyboard>/f2"",
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
                    ""path"": ""<Keyboard>/f9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleNeuLog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57857603-4515-41f0-b15a-39d196497fff"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuShowHide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cdd6826-92b3-4bd3-acf1-2d857413d658"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseGSRCalibrationValue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac21542a-6e96-489a-a4fd-3a4b87d9e196"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DecreaseGSRCalibrationValue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4038824f-cd9d-49ff-8965-9106a4cc64ea"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleOperatorDataDisplay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""741537e9-faed-4977-82dd-f52cc81faaba"",
                    ""path"": ""<Keyboard>/f4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleInteractiveMusic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""2bdce997-a7bb-45b6-ada4-da3154d60803"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopPlayback"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""14a4875b-4658-4b02-84c1-2408ec5046d6"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopPlayback"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""83c9b7be-cda2-4a6d-b288-4fdb99abcdeb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopPlayback"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""27dc50ba-3a42-4c3b-88fe-b01c7dfb77d8"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitApplication"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""3f71e2ae-fa0c-4610-91eb-da8c673324b6"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitApplication"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e847a30c-f68d-42ca-92ce-e12e4634e990"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuitApplication"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_StartPlayback = m_Keyboard.FindAction("StartPlayback", throwIfNotFound: true);
        m_Keyboard_StopPlayback = m_Keyboard.FindAction("StopPlayback", throwIfNotFound: true);
        m_Keyboard_ToggleSubtitlesPress = m_Keyboard.FindAction("ToggleSubtitlesPress", throwIfNotFound: true);
        m_Keyboard_ToggleDisplayOfEmotionalData = m_Keyboard.FindAction("ToggleDisplayOfEmotionalData", throwIfNotFound: true);
        m_Keyboard_ToggleNeuLog = m_Keyboard.FindAction("ToggleNeuLog", throwIfNotFound: true);
        m_Keyboard_MenuShowHide = m_Keyboard.FindAction("MenuShowHide", throwIfNotFound: true);
        m_Keyboard_IncreaseGSRCalibrationValue = m_Keyboard.FindAction("IncreaseGSRCalibrationValue", throwIfNotFound: true);
        m_Keyboard_DecreaseGSRCalibrationValue = m_Keyboard.FindAction("DecreaseGSRCalibrationValue", throwIfNotFound: true);
        m_Keyboard_ToggleOperatorDataDisplay = m_Keyboard.FindAction("ToggleOperatorDataDisplay", throwIfNotFound: true);
        m_Keyboard_ToggleInteractiveMusic = m_Keyboard.FindAction("ToggleInteractiveMusic", throwIfNotFound: true);
        m_Keyboard_QuitApplication = m_Keyboard.FindAction("QuitApplication", throwIfNotFound: true);
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
    private readonly InputAction m_Keyboard_StartPlayback;
    private readonly InputAction m_Keyboard_StopPlayback;
    private readonly InputAction m_Keyboard_ToggleSubtitlesPress;
    private readonly InputAction m_Keyboard_ToggleDisplayOfEmotionalData;
    private readonly InputAction m_Keyboard_ToggleNeuLog;
    private readonly InputAction m_Keyboard_MenuShowHide;
    private readonly InputAction m_Keyboard_IncreaseGSRCalibrationValue;
    private readonly InputAction m_Keyboard_DecreaseGSRCalibrationValue;
    private readonly InputAction m_Keyboard_ToggleOperatorDataDisplay;
    private readonly InputAction m_Keyboard_ToggleInteractiveMusic;
    private readonly InputAction m_Keyboard_QuitApplication;
    public struct KeyboardActions
    {
        private @InputControls m_Wrapper;
        public KeyboardActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartPlayback => m_Wrapper.m_Keyboard_StartPlayback;
        public InputAction @StopPlayback => m_Wrapper.m_Keyboard_StopPlayback;
        public InputAction @ToggleSubtitlesPress => m_Wrapper.m_Keyboard_ToggleSubtitlesPress;
        public InputAction @ToggleDisplayOfEmotionalData => m_Wrapper.m_Keyboard_ToggleDisplayOfEmotionalData;
        public InputAction @ToggleNeuLog => m_Wrapper.m_Keyboard_ToggleNeuLog;
        public InputAction @MenuShowHide => m_Wrapper.m_Keyboard_MenuShowHide;
        public InputAction @IncreaseGSRCalibrationValue => m_Wrapper.m_Keyboard_IncreaseGSRCalibrationValue;
        public InputAction @DecreaseGSRCalibrationValue => m_Wrapper.m_Keyboard_DecreaseGSRCalibrationValue;
        public InputAction @ToggleOperatorDataDisplay => m_Wrapper.m_Keyboard_ToggleOperatorDataDisplay;
        public InputAction @ToggleInteractiveMusic => m_Wrapper.m_Keyboard_ToggleInteractiveMusic;
        public InputAction @QuitApplication => m_Wrapper.m_Keyboard_QuitApplication;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @StartPlayback.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStartPlayback;
                @StartPlayback.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStartPlayback;
                @StartPlayback.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStartPlayback;
                @StopPlayback.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStopPlayback;
                @StopPlayback.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStopPlayback;
                @StopPlayback.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnStopPlayback;
                @ToggleSubtitlesPress.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleSubtitlesPress;
                @ToggleDisplayOfEmotionalData.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleDisplayOfEmotionalData;
                @ToggleNeuLog.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleNeuLog;
                @ToggleNeuLog.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleNeuLog;
                @ToggleNeuLog.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleNeuLog;
                @MenuShowHide.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMenuShowHide;
                @MenuShowHide.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMenuShowHide;
                @MenuShowHide.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMenuShowHide;
                @IncreaseGSRCalibrationValue.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseGSRCalibrationValue;
                @IncreaseGSRCalibrationValue.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseGSRCalibrationValue;
                @IncreaseGSRCalibrationValue.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnIncreaseGSRCalibrationValue;
                @DecreaseGSRCalibrationValue.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseGSRCalibrationValue;
                @DecreaseGSRCalibrationValue.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseGSRCalibrationValue;
                @DecreaseGSRCalibrationValue.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDecreaseGSRCalibrationValue;
                @ToggleOperatorDataDisplay.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleOperatorDataDisplay;
                @ToggleOperatorDataDisplay.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleOperatorDataDisplay;
                @ToggleOperatorDataDisplay.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleOperatorDataDisplay;
                @ToggleInteractiveMusic.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleInteractiveMusic;
                @ToggleInteractiveMusic.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleInteractiveMusic;
                @ToggleInteractiveMusic.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnToggleInteractiveMusic;
                @QuitApplication.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnQuitApplication;
                @QuitApplication.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnQuitApplication;
                @QuitApplication.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnQuitApplication;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartPlayback.started += instance.OnStartPlayback;
                @StartPlayback.performed += instance.OnStartPlayback;
                @StartPlayback.canceled += instance.OnStartPlayback;
                @StopPlayback.started += instance.OnStopPlayback;
                @StopPlayback.performed += instance.OnStopPlayback;
                @StopPlayback.canceled += instance.OnStopPlayback;
                @ToggleSubtitlesPress.started += instance.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.performed += instance.OnToggleSubtitlesPress;
                @ToggleSubtitlesPress.canceled += instance.OnToggleSubtitlesPress;
                @ToggleDisplayOfEmotionalData.started += instance.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.performed += instance.OnToggleDisplayOfEmotionalData;
                @ToggleDisplayOfEmotionalData.canceled += instance.OnToggleDisplayOfEmotionalData;
                @ToggleNeuLog.started += instance.OnToggleNeuLog;
                @ToggleNeuLog.performed += instance.OnToggleNeuLog;
                @ToggleNeuLog.canceled += instance.OnToggleNeuLog;
                @MenuShowHide.started += instance.OnMenuShowHide;
                @MenuShowHide.performed += instance.OnMenuShowHide;
                @MenuShowHide.canceled += instance.OnMenuShowHide;
                @IncreaseGSRCalibrationValue.started += instance.OnIncreaseGSRCalibrationValue;
                @IncreaseGSRCalibrationValue.performed += instance.OnIncreaseGSRCalibrationValue;
                @IncreaseGSRCalibrationValue.canceled += instance.OnIncreaseGSRCalibrationValue;
                @DecreaseGSRCalibrationValue.started += instance.OnDecreaseGSRCalibrationValue;
                @DecreaseGSRCalibrationValue.performed += instance.OnDecreaseGSRCalibrationValue;
                @DecreaseGSRCalibrationValue.canceled += instance.OnDecreaseGSRCalibrationValue;
                @ToggleOperatorDataDisplay.started += instance.OnToggleOperatorDataDisplay;
                @ToggleOperatorDataDisplay.performed += instance.OnToggleOperatorDataDisplay;
                @ToggleOperatorDataDisplay.canceled += instance.OnToggleOperatorDataDisplay;
                @ToggleInteractiveMusic.started += instance.OnToggleInteractiveMusic;
                @ToggleInteractiveMusic.performed += instance.OnToggleInteractiveMusic;
                @ToggleInteractiveMusic.canceled += instance.OnToggleInteractiveMusic;
                @QuitApplication.started += instance.OnQuitApplication;
                @QuitApplication.performed += instance.OnQuitApplication;
                @QuitApplication.canceled += instance.OnQuitApplication;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnStartPlayback(InputAction.CallbackContext context);
        void OnStopPlayback(InputAction.CallbackContext context);
        void OnToggleSubtitlesPress(InputAction.CallbackContext context);
        void OnToggleDisplayOfEmotionalData(InputAction.CallbackContext context);
        void OnToggleNeuLog(InputAction.CallbackContext context);
        void OnMenuShowHide(InputAction.CallbackContext context);
        void OnIncreaseGSRCalibrationValue(InputAction.CallbackContext context);
        void OnDecreaseGSRCalibrationValue(InputAction.CallbackContext context);
        void OnToggleOperatorDataDisplay(InputAction.CallbackContext context);
        void OnToggleInteractiveMusic(InputAction.CallbackContext context);
        void OnQuitApplication(InputAction.CallbackContext context);
    }
}
