using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;



namespace WasderGQ.Parkur._Scripts.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        #region PlayerVariableBoarder

        [SerializeField] private readonly float _headUpXBoarderAngle = 320f;
        [SerializeField] private readonly float _headDownXBoarderAngle = 60f;
        [SerializeField] private readonly float _headMiddleXBoarderAngle = (320f + 60f) / 2f;
        [SerializeField] private readonly float _headRightBoarderAngle = 135f;
        [SerializeField] private readonly float _headLeftBoarderAngle = 45f;
        [SerializeField] private readonly float _walkSpeed = 2f;
        [SerializeField] private readonly float _movespeed = 10f;
        #endregion
        
        
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
            _movement.canceled += StopMovement;
        }
        
        private async void Update()
        {
          
        }

        private void StopMovement(InputAction.CallbackContext obj)
        {
            //_rigidbody.velocity = new Vector3(0, 0);
            Debug.Log(obj.ReadValue<Vector2>());
        }

        private void MovementTrigger(InputAction.CallbackContext obj)
        {
           Vector2 direction = obj.ReadValue<Vector2>();
           Vector2 directionOnSpeed = direction * _movespeed;
           transform.position += new Vector3(directionOnSpeed.y,0,-directionOnSpeed.x);
           //_rigidbody.AddForce(new Vector3(directionOnSpeed.x, directionOnSpeed.y)); 
           Debug.Log($"StraightWalking!! + {directionOnSpeed}");
            
          
        }
        
        private void LookAroundTrigger(InputAction.CallbackContext obj)
        {
            SetValueOnBoarderOfAngles(obj.ReadValue<Vector2>());
           // Debug.Log($"LookinAround!! + {obj.ReadValue<Vector2>()}");
        }

        private void SetValueOnBoarderOfAngles(Vector2 values)
        {
            Vector3 rotationEulerOfHead = _head.transform.eulerAngles;
            Vector3 rotationEulerOfPlayer = transform.eulerAngles;
            float newXAngleOfBody = rotationEulerOfHead.x + values.y;
            float newYAngleOfBody = rotationEulerOfPlayer.y + values.x;
           
            
            
           /* if (newYAngleOfBody > _headRightBoarderAngle && newXAngleOfBody < 180f)
            {
                newYAngleOfBody = _headRightBoarderAngle;
            }
            else if (newYAngleOfBody < _headLeftBoarderAngle && newYAngleOfBody > 0f)
            {
                newYAngleOfBody = _headLeftBoarderAngle;
                
            }*/
            
            
            if (newXAngleOfBody < _headUpXBoarderAngle && newXAngleOfBody >_headMiddleXBoarderAngle)
            {
                newXAngleOfBody = _headUpXBoarderAngle;
            }
            else if (newXAngleOfBody > _headDownXBoarderAngle && newXAngleOfBody <_headMiddleXBoarderAngle)
            {
                newXAngleOfBody = _headDownXBoarderAngle;
            }
            _head.transform.localEulerAngles = new Vector3(newXAngleOfBody,0f, 0f);
            transform.eulerAngles = new Vector3(0f,newYAngleOfBody, 0f);
            
        }
        
        
        
        private void Walk(Vector2 directions)
        {
            StableWalk(_walkSpeed, directions);



        }
        
        
        
        
        private IEnumerator SlowlyAccelerationWalk()
        {
            
            yield return null;

            Debug.Log("Coroutine started!");

            yield return new WaitForSeconds(1);

            Debug.Log("Coroutine ended!");
            
        }

        private void StableWalk(float walkSpeed,Vector2 directions)
        {
            _rigidbody.velocity = new Vector3(_walkSpeed * directions.x, _walkSpeed * directions.y, 0);

        }
    }
}
