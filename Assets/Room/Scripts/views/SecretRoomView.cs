using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo{

public class SecretRoomView : View
{

	public ObjectState     	state;
	private Drop			drop;
	//private Drop			drop;
	
	void Awake()
	{
		state = this.GetComponent<ObjectState>();
		drop = this.GetComponent<Drop>();
	}
	
	public void receivedInteraction(TouchEvent evt)
	{
			print ("recieved interaction");
		if(state.hit || state.selected)
		{
			switch (evt)
			{
			case TouchEvent.Tap:
					drop.drop();
				
				break;
			case TouchEvent.SwipeLeft:

				
				break;
			case TouchEvent.SwipeRight:
				

				break;
			case TouchEvent.SwipeUp:

				break;
			case TouchEvent.SwipeDown:

				break;
			}
		}
	}

}

}