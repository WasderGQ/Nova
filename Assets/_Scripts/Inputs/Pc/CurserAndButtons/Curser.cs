using UnityEngine;
using WasderGQ.Parkur._Scripts.Enums;


namespace WasderGQ.Parkur._Scripts.Inputs.Pc.CurserAndButtons
{
    public class Curser : MonoBehaviour
    {
        public CurserStat CurrentCurserStat { get; set; }

        private void Update()
        {
            RefreshCurserPosition();
        }

        private void RefreshCurserPosition()
        {
            switch (CurrentCurserStat)
            {
                case CurserStat.FreeToMove:
                    transform.localPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    break;
                case CurserStat.LockToMove:
                    transform.localPosition = new Vector3(0,0,0);
                    break;
            }
        }
        
        private void Start()
        {
            OnStartSetMouseStat();
        }

        private void OnStartSetMouseStat()
        {
            CurrentCurserStat = CurserStat.LockToMove;
        }
        
        public Vector3 GetCurserWorldPosition()
        {
            return this.transform.position;
        }

        public Vector3 GetCurserLocalWorldPosition()
        {
            return transform.localPosition;
        }
    }
}
