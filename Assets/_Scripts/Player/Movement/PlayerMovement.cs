using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using WasderGQ.Parkur._Scripts.Enums;
using WasderGQ.Parkur._Scripts.Inputs.Pc.CurserAndButtons;


namespace WasderGQ.Parkur._Scripts.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MainPlayer _mainPlayer;
        [SerializeField] private Curser _curser;
        [SerializeField] private Camera _fpsCamera;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private GameObject _head;
        [SerializeField] private Rigidbody _rigidbody;
        
        
        
        private NovaInputActions _novaInputActions;
        private InputAction _movement;
        private InputAction _lookAround;
        
        private void Awake()
        {
            _novaInputActions = new NovaInputActions();
        }

        private void OnEnable()
        {
            SetPlayerInputs();
            EnableInputActions();
            AttachFuncToInputActions();
        }
        private void OnDisable()
        {
            DisableInputActions();
        }
        private void SetPlayerInputs()
        {
            _movement = _novaInputActions.Player.Movement;
            _lookAround = _novaInputActions.Player.LookAround;
        }
        
        private void EnableInputActions()
        {
            _movement.Enable();
            _lookAround.Enable();
        }
        private void DisableInputActions()
        {
            _movement.Disable();
            _lookAround.Disable();
        }

        private void AttachFuncToInputActions()
        {
            _movement.performed += MovementTrigger;
            _lookAround.performed += LookAroundTrigger;
        }
        
        private void Update()
        {
           // HeadControlByCursor();
           
          
        }

        private async void HeadControlByCursor()
        {

            if (_curser.CurrentCurserStat == CurserStat.LockToMove && _mainPlayer.PlayerStatu == PlayerStatu.playable)
            {
                
                _curser.CurrentCurserStat = CurserStat.FreeToMove;
                await Task.Delay(100);
                _head.transform.rotation = new Quaternion(_curser.GetCurserLocalWorldPosition().x * _rotationSpeed ,_head.transform.rotation.y, _head.transform.rotation.z, _head.transform.rotation.w);
                _curser.CurrentCurserStat = CurserStat.LockToMove;
            }
        }

        private void MovementTrigger(InputAction.CallbackContext obj)
        {
            Debug.Log($"StraightWalking!! + {obj.ReadValue<Vector2>()}");
        }
        
        private void LookAroundTrigger(InputAction.CallbackContext obj)
        {
           
            SetOnBoarderValues(obj.ReadValue<Vector2>());
            Debug.Log($"LookinAround!! + {obj.ReadValue<Vector2>()}");
        }

        private void SetOnBoarderValues(Vector2 values)
        {
            Quaternion currentRotation = _head.transform.localRotation;
            _head.transform.rotation = Quaternion.Euler(currentRotation.x,currentRotation.y + values.x,currentRotation.z);
            Quaternion.
            
            
            
            
            /*
            float xRotation = _head.transform.rotation.x + values.y;
            float yRotation = _head.transform.rotation.y + values.x;

            if (xRotation > 45f)
            {
                Debug.Log($"More Than 45 fixed");
            }
            else if (xRotation < -45f)
            {
                Debug.Log($"Lower Than -45 fixed");
            }
            else
            {
                _head.transform.RotateAround(transform.position,Vector3.up,values.y);
                Debug.Log($"Z fixed (x)");
            }
            
            
            
            if (yRotation > 15f)
            {
                
                Debug.Log($"More Than 45 fixed");
            }
            else if (yRotation < -15f)
            {
                
                Debug.Log($"Lower Than -45 fixed");
            }
            else
            {
                _head.transform.RotateAround(transform.position,Vector3.right,values.x);
                Debug.Log($"Z fixed (x)");
            }
            */
            
           
        }
        
        
        
        private void Walk()
        {
            
            
            
            
            
        }

        private void AddVelocity()
        {
            
            
            
        }
    }
}
