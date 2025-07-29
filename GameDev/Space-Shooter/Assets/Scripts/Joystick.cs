using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.UI {
	[AddComponentMenu("UI/Joystick", 36), RequireComponent(typeof(RectTransform))]
	public class Joystick : UIBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

		[SerializeField, Tooltip("The child graphic that will be moved around")]
		RectTransform _joystickGraphic;
		public RectTransform JoystickGraphic {
			get { return _joystickGraphic; }
			set {
				_joystickGraphic = value;
				UpdateJoystickGraphic();
			}
		}

		[SerializeField]
		Vector2 _axis;

		[SerializeField, Tooltip("How fast the joystick will go back to the center")]
		float _spring = 25;
		public float Spring {
			get { return _spring; }
			set { _spring = value; }
		}

		[SerializeField,  Tooltip("How close to the center that the axis will be output as 0")]
		float _deadZone = .1f;
		public float DeadZone {
			get { return _deadZone; }
			set { _deadZone = value; }
		}

		[Tooltip("Customize the output that is sent in OnValueChange")]
		public AnimationCurve outputCurve = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));

		public JoystickMoveEvent OnValueChange;

		public Vector2 JoystickAxis {
			get {
				Vector2 outputPoint = _axis.magnitude > _deadZone ? _axis : Vector2.zero;
				float magnitude = outputPoint.magnitude;

				outputPoint *= outputCurve.Evaluate(magnitude);

				return outputPoint;
			}
			set { SetAxis(value); }
		}

		RectTransform _rectTransform;
		public RectTransform rectTransform {
			get {
				if(!_rectTransform) _rectTransform = transform as RectTransform;

				return _rectTransform;
			}
		}

		bool _isDragging;

		[HideInInspector]
		bool dontCallEvent;

		public void OnBeginDrag(PointerEventData eventData) {
			if(!IsActive())
				return;

			EventSystem.current.SetSelectedGameObject(gameObject, eventData);

			Vector2 newAxis = transform.InverseTransformPoint(eventData.position);

			newAxis.x /= rectTransform.sizeDelta.x * .5f;
			newAxis.y /= rectTransform.sizeDelta.y * .5f;

			SetAxis(newAxis);

			_isDragging = true;
			dontCallEvent = true;
		}

		public void OnEndDrag(PointerEventData eventData) {
			_isDragging = false;
		}

		public void OnDrag(PointerEventData eventData) {
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out _axis);

			_axis.x /= rectTransform.sizeDelta.x * .5f;
			_axis.y /= rectTransform.sizeDelta.y * .5f;

			SetAxis(_axis);

			dontCallEvent = true;
		}

		void OnDeselect() {
			_isDragging = false;
		}


		void Update() {
			if(_isDragging)
				if(!dontCallEvent)
					if(OnValueChange != null) OnValueChange.Invoke(JoystickAxis);
		}

		void LateUpdate() {
			if(!_isDragging)
				if(_axis != Vector2.zero) {
					Vector2 newAxis = _axis - (_axis * Time.unscaledDeltaTime * _spring);

					if(newAxis.sqrMagnitude <= .0001f)
						newAxis = Vector2.zero;

					SetAxis(newAxis);
				}

			dontCallEvent = false;
		}
		
#if UNITY_EDITOR
		protected override void OnValidate() {
        		base.OnValidate();
            		UpdateJoystickGraphic();
        	}
#endif

		public void SetAxis(Vector2 axis) {
			_axis = Vector2.ClampMagnitude(axis, 1);

			Vector2 outputPoint = _axis.magnitude > _deadZone ? _axis : Vector2.zero;
			float magnitude = outputPoint.magnitude;

			outputPoint *= outputCurve.Evaluate(magnitude);

			if(!dontCallEvent)
				if(OnValueChange != null)
					OnValueChange.Invoke(outputPoint);

			UpdateJoystickGraphic();
		}

		void UpdateJoystickGraphic() {
			if(_joystickGraphic)
				_joystickGraphic.localPosition = _axis * Mathf.Max(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y) * .5f;
		}

		[System.Serializable]
		public class JoystickMoveEvent : UnityEvent<Vector2> { }
	}
}

#if UNITY_EDITOR
static class JoystickGameObjectCreator {
	[MenuItem("GameObject/UI/Joystick", false, 2000)]
	static void Create() {
		GameObject go = new GameObject("Joystick", typeof(Joystick));

		Canvas canvas = Selection.activeGameObject ? Selection.activeGameObject.GetComponent<Canvas>() : null;

		Selection.activeGameObject = go;

		if(!canvas)
			canvas = Object.FindObjectOfType<Canvas>();

		if(!canvas) {
			canvas = new GameObject("Canvas", typeof(Canvas), typeof(RectTransform), typeof(GraphicRaycaster)).GetComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		}

		if(canvas)
			go.transform.SetParent(canvas.transform, false);

		GameObject background = new GameObject("Background", typeof(Image));
		GameObject graphic = new GameObject("Graphic", typeof(Image));

		background.transform.SetParent(go.transform, false);
		graphic.transform.SetParent(go.transform, false);

		background.GetComponent<Image>().color = new Color(1, 1, 1, .86f);

		RectTransform backgroundTransform = graphic.transform as RectTransform;
		RectTransform graphicTransform = graphic.transform as RectTransform;

		graphicTransform.sizeDelta = backgroundTransform.sizeDelta * .5f;

		Joystick joystick = go.GetComponent<Joystick>();
		joystick.JoystickGraphic = graphicTransform;
	}
}
#endif