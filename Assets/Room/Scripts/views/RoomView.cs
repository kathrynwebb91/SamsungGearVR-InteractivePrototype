using System;

using UnityEngine;

using strange.extensions.context.impl;

namespace Demo {
	public class RoomView : ContextView {
		
		void Awake() {
			this.context = new RoomContext(this);

		}

	}
}