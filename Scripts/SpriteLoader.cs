/* Pick a Pair - Memory Game
 * Spriteloader.cs Script
 * Albert-Jan Scherrenburg
 * Student Number 1684118 */

// Used Libraries
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

// Used in Card.cs to load in images
namespace Assets.Scripts
{
    class SpriteLoader : MonoBehaviour
    {
        public Sprite LoadSprite(string file, float PixelsPerUnit = 100.0f)
        {
            print(file);
            // Loads a PNG image from disk to a Texture2D, assigns texture to a new sprite and returns its reference
            var texture = LoadTexture(file);
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), PixelsPerUnit);

            return sprite;
        }

        private Texture2D LoadTexture(string file)
        {
            // Loads a PNG file from disk to a Texture2D
            // Returns null if load fails
            if (File.Exists(file))
            {
                var data = File.ReadAllBytes(file);
                // Creates new "empty" texture
                var texture = new Texture2D(2, 2);
                // Loads the imagedata into the texture (size is set automatically)
                if (texture.LoadImage(data))
                    // If data = readable -> return texture
                    return texture;
            }
            // Return null if load failed
            return null;
        }
    }
}
