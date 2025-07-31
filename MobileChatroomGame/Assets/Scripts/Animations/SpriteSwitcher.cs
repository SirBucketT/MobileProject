using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animations{
	public class SpriteSwitcher : MonoBehaviour{
		[SerializeField] Image image;
		[SerializeField] string path;
		[SerializeField] int fileQuantity;
		[SerializeField] bool playOnce;
		
		float animationDelay = 1 / 24f;
		List<Sprite> sprites;
		int currentSprite;
		float timePassed;
		bool isLoaded;

		void OnEnable(){
			currentSprite = 0;
			if (!isLoaded){
				LoadSprites();
			}
			image.sprite = sprites[currentSprite];
		}

		void LoadSprites(){
			sprites = new List<Sprite>();
			for (var i = 1; i <= fileQuantity; i++){
				var fileIndex = i.ToString();

				fileIndex = i switch{
					< 10 => "000" + fileIndex,
					< 100 => "00" + fileIndex,
					< 1000 => "0" + fileIndex,
					_ => fileIndex
				};

				var imagePath = $"{path}{fileIndex}";
				sprites.Add(Resources.Load<Sprite>(imagePath));
			}
		}
		
		void Update(){
			timePassed += Time.deltaTime;
			image.sprite = sprites[currentSprite];
			if (timePassed >= animationDelay){
				Change();
			}
		}

		void Change(){
			currentSprite++;
			timePassed = 0;
			if (currentSprite != sprites.Count)  return;

			if (playOnce){
				currentSprite = sprites.Count - 1;
			} else {
				currentSprite = 0;
			}
		}
		void OnDisable(){
			currentSprite = 0;
			image.sprite = sprites[currentSprite];
		}
	}
}