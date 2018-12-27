using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
namespace com.ztgame.ioc
{
    public class UIJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        /// <summary>
        /// 摇杆最大半径
        /// 以像素为单位
        /// </summary>
        public float JoyStickRadius = 80;
        /// <summary>
        /// 摇杆重置所诉
        /// </summary>
        public float JoyStickResetSpeed = 2.0f;
        /// <summary>
        /// thumb物体的Transform组件
        /// </summary>
        public RectTransform thumbTransform;
        /// <summary>
        /// 是否触摸了虚拟摇杆
        /// </summary>
        private bool isTouched = false;
        /// <summary>
        /// 虚拟摇杆的默认位置
        /// </summary>
        private Vector2 originPosition;
        /// <summary>
        /// 虚拟摇杆的移动方向
        /// </summary>
        private Vector2 touchedAxis;
        public Vector2 TouchedAxis
        {
            get
            {
                if (touchedAxis.magnitude < JoyStickRadius)
                    return touchedAxis.normalized / JoyStickRadius;
                return touchedAxis.normalized;
            }
        }
        /// <summary>
        /// 定义触摸开始事件委托
        /// </summary>
        public delegate void JoyStickTouchBegin(Vector2 vec);
        /// <summary>
        /// 定义触摸过程事件委托
        /// </summary>
        /// <param name="vec">虚拟摇杆的移动方向</param>
        public delegate void JoyStickTouchMove(Vector2 vec);
        /// <summary>
        /// 定义触摸结束事件委托
        /// </summary>
        public delegate void JoyStickTouchEnd();
        /// <summary>
        /// 注册触摸开始事件
        /// </summary>
        public event JoyStickTouchBegin OnJoyStickTouchBegin;
        /// <summary>
        /// 注册触摸过程事件
        /// </summary>
        public event JoyStickTouchMove OnJoyStickTouchMove;
        /// <summary>
        /// 注册触摸结束事件
        /// </summary>
        public event JoyStickTouchEnd OnJoyStickTouchEnd;
        void Start()
        {
            //初始化虚拟摇杆的默认方向
            if (thumbTransform == null) thumbTransform = this.GetComponent<RectTransform>();
            originPosition = thumbTransform.anchoredPosition;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            isTouched = true;
            touchedAxis = GetJoyStickAxis(eventData);
            if (this.OnJoyStickTouchBegin != null)
                this.OnJoyStickTouchBegin(TouchedAxis);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            isTouched = false;
            thumbTransform.anchoredPosition = originPosition;
            touchedAxis = Vector2.zero;
            if (this.OnJoyStickTouchEnd != null)
                this.OnJoyStickTouchEnd();
        }
        public void OnDrag(PointerEventData eventData)
        {
            touchedAxis = GetJoyStickAxis(eventData);
            if (this.OnJoyStickTouchMove != null)
                this.OnJoyStickTouchMove(TouchedAxis);
        }
        void Update()
        {
            //当虚拟摇杆移动到最大半径时摇杆无法拖动
            //为了确保被控制物体可以继续移动
            //在这里手动触发OnJoyStickTouchMove事件
            if (isTouched && touchedAxis.magnitude >= JoyStickRadius)
            {
                if (this.OnJoyStickTouchMove != null)
                    this.OnJoyStickTouchMove(TouchedAxis);
            }
            //松开虚拟摇杆后让虚拟摇杆回到默认位置
            if (!isTouched && thumbTransform.anchoredPosition.magnitude > originPosition.magnitude)
                thumbTransform.anchoredPosition -= TouchedAxis * Time.deltaTime * JoyStickResetSpeed;
        }
        /// <summary>
        /// 返回虚拟摇杆的偏移量
        /// </summary>
        /// <returns>The joy stick axis.</returns>
        /// <param name="eventData">Event data.</param>
        private Vector2 GetJoyStickAxis(PointerEventData eventData)
        {
            //获取手指位置的世界坐标
            Vector3 worldPosition;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(thumbTransform,
                     eventData.position, eventData.pressEventCamera, out worldPosition))
                thumbTransform.position = worldPosition;
            //获取摇杆的偏移量
            Vector2 touchAxis = thumbTransform.anchoredPosition - originPosition;
            //摇杆偏移量限制
            if (touchAxis.magnitude >= JoyStickRadius)
            {
                touchAxis = touchAxis.normalized * JoyStickRadius;
                thumbTransform.anchoredPosition = touchAxis;
            }
            return touchAxis;
        }


        #region 震屏效果
        public enum CameraMode { None, ToLeft, ToRight, ToUp, ToDown, Move }

        private bool isMove = false;
        private float moveOffSet = 0;
        private CameraMode cameraMode = CameraMode.None;
        private Transform cameraTransform;

        public void initCamera(Transform transform)
        {
            this.cameraTransform = transform;
        }

        void CameraShakeMove()
        {
            StartCoroutine(ShakeMove());
        }

        IEnumerator ShakeMove()
        {
            if (this.cameraTransform == null)
            {
                yield return null;
            }
            Vector3 vector = new Vector3(0, 0, 0);
            Vector3 revertVector = new Vector3(0, 0, 0);
            float dlTime = 0.02f;
            if (this.cameraMode == CameraMode.ToLeft)
            {
                vector.x = 0.08f;
                revertVector.x = -vector.x;
            }
            else if (this.cameraMode == CameraMode.ToRight)
            {
                vector.x = -0.08f;
                revertVector.x = -vector.x;
            }
            else if (this.cameraMode == CameraMode.ToUp)
            {
                vector.z = -0.08f;
                revertVector.z = -vector.z;
            }
            else if (this.cameraMode == CameraMode.ToDown)
            {
                vector.z = 0.08f;
                revertVector.z = -vector.z;
            }
            else if (this.cameraMode == CameraMode.Move)
            {
                vector.x = -this.moveOffSet;
                revertVector.x = -vector.x;

                cameraTransform.position += vector;

                yield return new WaitForSeconds(dlTime);

                cameraTransform.position += revertVector;

                vector.z = this.moveOffSet;
                revertVector.z = -vector.z;

                cameraTransform.position += vector;

                yield return new WaitForSeconds(dlTime);

                cameraTransform.position += revertVector;
            }

            if (this.cameraMode != CameraMode.Move)
            {
                cameraTransform.position += vector;

                yield return new WaitForSeconds(dlTime);

                cameraTransform.position += revertVector;
            }
            this.cameraMode = CameraMode.None;
            isMove = false;
        }
        public void setCameraMode(CameraMode mode, EnumShakeOffset shake = EnumShakeOffset.offset1)
        {
            if(this.cameraMode != CameraMode.None)
            {
                return;
            }
            this.cameraMode = mode;
            float offSet = 0;
            switch (shake)
            {
                case EnumShakeOffset.offset1:
                    offSet = 0.08f * 3;
                    break;
                case EnumShakeOffset.offset2:
                    offSet = 0.16f * 3;
                    break;
                case EnumShakeOffset.offset3:
                    offSet = 0.32f * 3;
                    break;
            }
            this.moveOffSet = offSet;
            this.CameraShakeMove();
        }

        #endregion
    }
}