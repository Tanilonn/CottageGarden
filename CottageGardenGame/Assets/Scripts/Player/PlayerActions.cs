// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Garden"",
            ""id"": ""a6433155-e217-4e8f-bf20-58081e80f016"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cae4d016-bbe6-48f4-807d-2560c4ba4dcf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""UseTool"",
                    ""type"": ""Button"",
                    ""id"": ""e22fbf3d-6670-495e-a9d8-7447cc97142d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PlantSeed"",
                    ""type"": ""Button"",
                    ""id"": ""71f9c8c6-0fa8-4572-9b57-1b7711eef5fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0fea70e0-e9e7-42f9-9144-2bb8dc5249b2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""79e5c9ce-4898-45fa-84d0-3b8cf5297358"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e428e43c-b221-4fcc-b10c-41a8ed3dfe8c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""93dcdfd3-738a-4655-afd0-c5d0d0c8b815"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a8b9421a-d33c-4c80-9ab8-a5728d1abd1b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arrow"",
                    ""id"": ""1f34eb71-b0d4-4cfa-bcd9-61551917c5ed"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bc504e20-b009-43d0-bf18-eb77e52cad16"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4661842d-5808-4b58-9c18-c5ae9342e24c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f1442fea-3dd2-4830-ad08-2afda2312209"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""658b5fe0-6027-455a-b032-a49f90f05979"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b6d1a17b-6f9f-4dd6-8442-8afc04cb398e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseTool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c10a9cf6-70ff-4484-a169-0eeedd522246"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlantSeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Garden
        m_Garden = asset.FindActionMap("Garden", throwIfNotFound: true);
        m_Garden_Move = m_Garden.FindAction("Move", throwIfNotFound: true);
        m_Garden_UseTool = m_Garden.FindAction("UseTool", throwIfNotFound: true);
        m_Garden_PlantSeed = m_Garden.FindAction("PlantSeed", throwIfNotFound: true);
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

    // Garden
    private readonly InputActionMap m_Garden;
    private IGardenActions m_GardenActionsCallbackInterface;
    private readonly InputAction m_Garden_Move;
    private readonly InputAction m_Garden_UseTool;
    private readonly InputAction m_Garden_PlantSeed;
    public struct GardenActions
    {
        private @PlayerActions m_Wrapper;
        public GardenActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Garden_Move;
        public InputAction @UseTool => m_Wrapper.m_Garden_UseTool;
        public InputAction @PlantSeed => m_Wrapper.m_Garden_PlantSeed;
        public InputActionMap Get() { return m_Wrapper.m_Garden; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GardenActions set) { return set.Get(); }
        public void SetCallbacks(IGardenActions instance)
        {
            if (m_Wrapper.m_GardenActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GardenActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GardenActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GardenActionsCallbackInterface.OnMove;
                @UseTool.started -= m_Wrapper.m_GardenActionsCallbackInterface.OnUseTool;
                @UseTool.performed -= m_Wrapper.m_GardenActionsCallbackInterface.OnUseTool;
                @UseTool.canceled -= m_Wrapper.m_GardenActionsCallbackInterface.OnUseTool;
                @PlantSeed.started -= m_Wrapper.m_GardenActionsCallbackInterface.OnPlantSeed;
                @PlantSeed.performed -= m_Wrapper.m_GardenActionsCallbackInterface.OnPlantSeed;
                @PlantSeed.canceled -= m_Wrapper.m_GardenActionsCallbackInterface.OnPlantSeed;
            }
            m_Wrapper.m_GardenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @UseTool.started += instance.OnUseTool;
                @UseTool.performed += instance.OnUseTool;
                @UseTool.canceled += instance.OnUseTool;
                @PlantSeed.started += instance.OnPlantSeed;
                @PlantSeed.performed += instance.OnPlantSeed;
                @PlantSeed.canceled += instance.OnPlantSeed;
            }
        }
    }
    public GardenActions @Garden => new GardenActions(this);
    public interface IGardenActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnUseTool(InputAction.CallbackContext context);
        void OnPlantSeed(InputAction.CallbackContext context);
    }
}
