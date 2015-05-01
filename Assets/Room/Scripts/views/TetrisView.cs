using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo {

	public class TetrisView : View {

		private ChangeColour frameColour;
		private GameObject frame;
		private int numberOfBlocks = 1;
		private GameObject currentBlock;
		private ArrayList placedBlocks = new ArrayList();
		private TetrisBlockState blockState;

		override protected void Awake()
		{
			base.Awake();
			frameColour = gameObject.GetComponentInChildren<ChangeColour>();
			frame = gameObject.transform.FindChild("TetrisFrame").gameObject;

			currentBlock = generateNewBlock ();
			currentBlock.AddComponent<TetrisBlockState> ();
			blockState =  currentBlock.GetComponent<TetrisBlockState>();
		}

		void moveBlock(GameObject block){
			iTween.MoveBy (block, new Vector3 (0, -5, 0), 0.1F);
		}

		void addBlock(){
			currentBlock = generateNewBlock ();
		}

		GameObject generateNewBlock(){

			//Randomly choose new block
			int typenum = Random.Range(0, ((int)TetrisBlockState.BlockType.NumberOfTypes - 1));
			string blockType = ((TetrisBlockState.BlockType)typenum).ToString ();
			GameObject newBlock = (GameObject)Instantiate(Resources.Load("Prefabs/" + blockType+"Block", typeof(GameObject)),transform.position, transform.rotation);

			//Position new block
			newBlock.transform.parent = this.gameObject.transform;
			float ydisp = 84 - 12.5F;
			float xdisp = 7.5F; 
			newBlock.transform.localPosition = new Vector3(0,ydisp,xdisp);

			return newBlock;
		}

		//TODO Swipe to rotate, tap to place
		public void receivedInteraction(TouchEvent evt)
		{
			//if(state.hit || state.selected)
			//{
				switch (evt)
				{
				case TouchEvent.Tap:

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
			//}
		}

		//TODO Use collisions as trigger to stop movement
		void Update(){
			if (currentBlock) {
				moveBlock (currentBlock);
			}
		}

	}
}