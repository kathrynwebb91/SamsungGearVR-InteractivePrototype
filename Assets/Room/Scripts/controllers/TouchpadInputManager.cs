// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;

using UnityEngine;

using strange.extensions.mediation.impl;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

namespace Demo
{
	public class TouchpadInputManager : InputManager
	{
        [Inject]
		public TouchpadInputSignal<TouchEvent> touchInputSignal { get; set;}

		public TouchpadInputManager ()
		{
			OVRTouchpad.TouchHandler += RecieveInput;
			touchInputSignal = new TouchpadInputSignal<TouchEvent>();
		}

		public void RecieveInput(object sender, EventArgs args)
		{
			var touchArgs = (OVRTouchpad.TouchArgs)args;
			OVRTouchpad.TouchEvent touchEvent = touchArgs.TouchType;
			Debug.Log ("Touch event");
			
			switch (touchEvent) {
			case OVRTouchpad.TouchEvent.SingleTap:
				//Debug.Log ("SINGLE CLICK\n");
				touchInputSignal.Dispatch(TouchEvent.Tap);
				break;
				
			case OVRTouchpad.TouchEvent.Left:
				//Debug.Log ("LEFT SWIPE\n");
				touchInputSignal.Dispatch(TouchEvent.SwipeLeft);
				break;
				
			case OVRTouchpad.TouchEvent.Right:
				//Debug.Log ("RIGHT SWIPE\n");
				touchInputSignal.Dispatch(TouchEvent.SwipeRight);
				break;
				
			case OVRTouchpad.TouchEvent.Up:
				//Debug.Log ("UP SWIPE\n");
				touchInputSignal.Dispatch(TouchEvent.SwipeUp);
				break;
				
			case OVRTouchpad.TouchEvent.Down:
				//Debug.Log ("DOWN SWIPE\n");
				touchInputSignal.Dispatch(TouchEvent.SwipeDown);
				break;
			}
		}

	}
}

