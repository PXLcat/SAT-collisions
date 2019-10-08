using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collisionsSAT
{
    public static class Tools
    {


        /// <summary>
        /// Pour un segment [AB] à projeter, cette méthode calcule l'absice du point A' en pixels
        /// </summary>
        /// <param name="sommetA"></param>
        /// <param name="sommetB"></param>
        /// <returns></returns>
        public static int BaseProjectionVertexSurX(Vector2 sommetA, Vector2 sommetB) //le X, le Y osef C'EST PAS BON
        {
            double xAprim = sommetA.X + sommetA.Y * (sommetB.Y - sommetA.Y) / (sommetB.X - sommetA.X);

            int result = (int)xAprim; //attention conversion

            return result;
        }

        /// <summary>
        /// Pour un segment [AB] à projeter, cette méthode calcule la taille du segment [(xA;0) A']
        /// Résultat en double pour utiliser dans d'autres calculs
        /// </summary>
        /// <param name="sommetA"></param>
        /// <param name="sommetB"></param>
        /// <returns></returns>
        public static double TailleSegmentProjectionVertexSurX(Vector2 sommetA, Vector2 sommetB) //le X, le Y osef C'EST PAS BON
        {
            double segment = sommetA.Y * (sommetB.Y - sommetA.Y) / (sommetB.X - sommetA.X);
            
            return segment;
        }
    }
}
