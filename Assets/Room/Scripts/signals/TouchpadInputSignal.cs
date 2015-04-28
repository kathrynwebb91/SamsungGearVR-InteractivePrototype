using System;
using UnityEngine;
using strange.extensions.signal.impl;

namespace Demo {

	public enum TouchEvent{
		SwipeLeft,
		SwipeRight,
		SwipeUp,
		SwipeDown,
		Tap,
	}

	public class TouchpadInputSignal<TouchEvent> : Signal<TouchEvent> {}
	
}