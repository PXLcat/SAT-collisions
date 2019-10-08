using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collisionsSAT
{
    public static class LineRenderer // from David Gouveia on gamedev.stackexchange
    {

        public static void DrawLine(this SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 end)
        {
            spriteBatch.Draw(texture, start, null, Color.White,
                             (float)Math.Atan2(end.Y - start.Y, end.X - start.X),
                             new Vector2(0f, (float)texture.Height / 2),
                             new Vector2(Vector2.Distance(start, end), 1f),
                             SpriteEffects.None, 0f);
        }
    }
}
/*The texture passed to the method should have size 1xN where N is the thickness of my ine. I'll give an example further below but first an usage example:

spriteBatch.Begin();
spriteBatch.DrawLine(lineTexture, new Vector2(20, 20), new Vector2(120, 120));
spriteBatch.DrawLine(lineTexture, new Vector2(120, 20), new Vector2(220, 60));
spriteBatch.DrawLine(lineTexture, new Vector2(20, 240), new Vector2(220, 100));
spriteBatch.End();
*/