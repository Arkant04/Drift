//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Assets/Script/Controles/Controles.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controles: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""23c62a9c-7e27-408e-9eb3-45faa532a5a1"",
            ""actions"": [
                {
                    ""name"": ""FrenoMano"",
                    ""type"": ""Button"",
                    ""id"": ""ab2b9d4c-5e55-4f3f-a00a-758f7b02e2ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aceleracion"",
                    ""type"": ""Button"",
                    ""id"": ""22d586e0-509c-429a-9e05-5de9fb23567f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Giro"",
                    ""type"": ""Value"",
                    ""id"": ""e927f5de-f9eb-4f8f-aa2e-6fb27eba5900"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Freno"",
                    ""type"": ""Button"",
                    ""id"": ""61997783-3d17-4091-8e86-f99e80425605"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""d9958b11-d65b-44ec-a898-4d8451e7e6bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""64baad9c-6dc7-4af2-a766-03383ce0f745"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aeeef9cd-58ce-4b5c-8ae7-a781c78e3d2b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrenoMano"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f629dbf7-133b-4cac-9672-28b3199fc020"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrenoMano"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c10aaa5-8710-4354-9a65-daeef4fb79e8"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrenoMano"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2918d7d-16ec-45e8-a984-4ba24566c1eb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aceleracion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c3b05e0-9dad-4cb1-9766-54894aefa0a8"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aceleracion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39b1fb68-67bd-4491-a117-87f382e2db84"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aceleracion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""900a4a82-4fb7-48f7-97fc-6285e555c65d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Freno"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fcd2192-857f-4373-ab03-31385402169e"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Freno"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""A/D"",
                    ""id"": ""4ae93b3e-5256-4330-a988-619b8db53cd6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Giro"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6a861ced-34d6-42f3-a873-feb54cae1947"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Giro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9f9515ec-5dd0-46ca-bfc1-aac356d94e70"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Giro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""cruzeta"",
                    ""id"": ""aac233d4-9ea2-41c3-b073-8fb2a93aec2e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Giro"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a3b99bf6-cc77-4137-aeb7-62f5c2b45828"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Giro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""491b38d0-b21a-4129-be79-76e51b709dfe"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Giro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b2ed8893-a4eb-44fb-bcb0-962967027c87"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37c88301-8b36-45e0-b644-8b946cc2c803"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_FrenoMano = m_Movement.FindAction("FrenoMano", throwIfNotFound: true);
        m_Movement_Aceleracion = m_Movement.FindAction("Aceleracion", throwIfNotFound: true);
        m_Movement_Giro = m_Movement.FindAction("Giro", throwIfNotFound: true);
        m_Movement_Freno = m_Movement.FindAction("Freno", throwIfNotFound: true);
        m_Movement_Dash = m_Movement.FindAction("Dash", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_FrenoMano;
    private readonly InputAction m_Movement_Aceleracion;
    private readonly InputAction m_Movement_Giro;
    private readonly InputAction m_Movement_Freno;
    private readonly InputAction m_Movement_Dash;
    private readonly InputAction m_Movement_Jump;
    public struct MovementActions
    {
        private @Controles m_Wrapper;
        public MovementActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @FrenoMano => m_Wrapper.m_Movement_FrenoMano;
        public InputAction @Aceleracion => m_Wrapper.m_Movement_Aceleracion;
        public InputAction @Giro => m_Wrapper.m_Movement_Giro;
        public InputAction @Freno => m_Wrapper.m_Movement_Freno;
        public InputAction @Dash => m_Wrapper.m_Movement_Dash;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @FrenoMano.started += instance.OnFrenoMano;
            @FrenoMano.performed += instance.OnFrenoMano;
            @FrenoMano.canceled += instance.OnFrenoMano;
            @Aceleracion.started += instance.OnAceleracion;
            @Aceleracion.performed += instance.OnAceleracion;
            @Aceleracion.canceled += instance.OnAceleracion;
            @Giro.started += instance.OnGiro;
            @Giro.performed += instance.OnGiro;
            @Giro.canceled += instance.OnGiro;
            @Freno.started += instance.OnFreno;
            @Freno.performed += instance.OnFreno;
            @Freno.canceled += instance.OnFreno;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @FrenoMano.started -= instance.OnFrenoMano;
            @FrenoMano.performed -= instance.OnFrenoMano;
            @FrenoMano.canceled -= instance.OnFrenoMano;
            @Aceleracion.started -= instance.OnAceleracion;
            @Aceleracion.performed -= instance.OnAceleracion;
            @Aceleracion.canceled -= instance.OnAceleracion;
            @Giro.started -= instance.OnGiro;
            @Giro.performed -= instance.OnGiro;
            @Giro.canceled -= instance.OnGiro;
            @Freno.started -= instance.OnFreno;
            @Freno.performed -= instance.OnFreno;
            @Freno.canceled -= instance.OnFreno;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnFrenoMano(InputAction.CallbackContext context);
        void OnAceleracion(InputAction.CallbackContext context);
        void OnGiro(InputAction.CallbackContext context);
        void OnFreno(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
