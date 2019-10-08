using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collisionsSAT
{
    public class PolygonHitBox
    {
        List<Vector2> sommets;
        List<Arrete> arretes;

        public PolygonHitBox(List<Vector2> sommets)
        {
            arretes = new List<Arrete>();
            this.sommets = sommets;
         
            for (int i=0; i< sommets.Count-1; i++)
            {
                arretes.Add(new Arrete(sommets.ElementAt(i), sommets.ElementAt(i+1)));
            }
            arretes.Add(new Arrete(sommets.ElementAt(sommets.Count - 1), sommets.ElementAt(0)));

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D segTexture)
        {
            foreach (Vector2 sommet in sommets)
            {
                spriteBatch.Draw(segTexture, new Rectangle((int)sommet.X - 2, (int)sommet.Y - 2, 4, 4), Color.White);
            }
            foreach (Arrete arrete in arretes)
            {
                LineRenderer.DrawLine(spriteBatch, segTexture, arrete.sommets[0] , arrete.sommets[1]);
            }
            
        }
    }
    public class Arrete
    {
        public Vector2[] sommets = new Vector2[2];
        double angleProjection;

        public Arrete(Vector2 sommet1, Vector2 sommet2)
        {
            sommets[0] = sommet1;
            sommets[1] = sommet2;

            angleProjection = CalculerAngleProjection(sommet1, sommet2);

        }

        private double CalculerAngleProjection(Vector2 sommet1, Vector2 sommet2)
        {
            double tangenteAlpha = Tools.TailleSegmentProjectionVertexSurX(sommet1, sommet2) /*=opposée */
                / sommet1.X/*=adjacente*/ ;
            double angleDegrees = Math.Tan(tangenteAlpha);

            return 0;
        }

        //il faut pas que l'angle soit regénéré tout le temps
    }
}
