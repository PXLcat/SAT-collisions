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
        List<SommetSelectionnable> listeSommetsAvecStatut;
        List<Arrete> arretes;

        public PolygonHitBox(List<Vector2> sommets)
        {
            arretes = new List<Arrete>();
            listeSommetsAvecStatut = new List<SommetSelectionnable>();
            foreach (Vector2 sommet in sommets)
            {
                listeSommetsAvecStatut.Add(new SommetSelectionnable(sommet));
            }


            for (int i = 0; i < sommets.Count - 1; i++)
            {
                arretes.Add(new Arrete(sommets.ElementAt(i), sommets.ElementAt(i + 1)));
            }
            arretes.Add(new Arrete(sommets.ElementAt(sommets.Count - 1), sommets.ElementAt(0)));

        }
        
        public void Update(Point cursorPosition)
        {
            //sélection par clic_____
            foreach (SommetSelectionnable sommetAvecStatut in listeSommetsAvecStatut)
            {
                Rectangle zoneClicSommet = new Rectangle((int)sommetAvecStatut.position.X - 5, (int)sommetAvecStatut.position.Y - 5, 10, 10);
                if (zoneClicSommet.Contains(cursorPosition))
                {
                    if (listeSommetsAvecStatut.Where(sommet => sommet.selected).Count()<2)
                    {
                        sommetAvecStatut.selected = !sommetAvecStatut.selected;
                    }
                    else if (sommetAvecStatut.selected)
                    {
                        sommetAvecStatut.selected = false;
                    }
                }
            }
            //_______________________
            //Vérif si il y a désormais une arrête de sélectionnée
            List<Vector2> listeSelection = new List<Vector2>();
            foreach (SommetSelectionnable sommetSelectione in listeSommetsAvecStatut.Where(sommet => sommet.selected))
            {
                listeSelection.Add(sommetSelectione.position);
            }
            foreach (Arrete arrete in arretes)
            {
                if (listeSelection.Contains(arrete.sommets[0])&& listeSelection.Contains(arrete.sommets[1]))
                {
                    arrete.selected = true;
                }
                else
                {
                    arrete.selected = false;
                }
                
            }
            //_______________________
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D segTexture)
        {
            foreach (SommetSelectionnable sommetAvecStatut in listeSommetsAvecStatut)
            {
                spriteBatch.Draw(segTexture, new Rectangle((int)sommetAvecStatut.position.X - 2, (int)sommetAvecStatut.position.Y - 2, 4, 4),
                    Color.White * (sommetAvecStatut.selected? 1 : 0.25f));
            }
            foreach (Arrete arrete in arretes)
            {
                arrete.Draw(spriteBatch, segTexture);
            }          
        }

    }
    public class SommetSelectionnable
    {
        public Vector2 position;
        public bool selected;


        public SommetSelectionnable(Vector2 position)
        {
            this.position = position;
            selected = false;
        }


    }

    public class Arrete
    {
        public Vector2[] sommets = new Vector2[2];
        double angleProjection;
        public bool selected;

        public Arrete(Vector2 sommet1, Vector2 sommet2)
        {
            sommets[0] = sommet1;
            sommets[1] = sommet2;

            angleProjection = CalculerAngleProjection(sommet1, sommet2); //?

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D segTexture)
        {
            LineRenderer.DrawLine(spriteBatch, segTexture, sommets[0], sommets[1], selected ? 1:0.25f);
            if (selected)
            {
                DrawProjections(spriteBatch, segTexture);
            }

        }

        private double CalculerAngleProjection(Vector2 sommet1, Vector2 sommet2)
        {
            double tangenteAlpha = Tools.TailleSegmentProjectionVertexSurX(sommet1, sommet2) /*=opposée */
                / sommet1.X/*=adjacente*/ ;
            double angleDegrees = Math.Tan(tangenteAlpha);

            return 0;
        }


        private void DrawProjections(SpriteBatch spriteBatch, Texture2D segTexture)
        {
                Rectangle arreteProjectionsurX = new Rectangle(Tools.BaseProjectionVertexSurX(sommets[0], sommets[1]), 0
                    , Tools.BaseProjectionVertexSurX(sommets[1], sommets[0]) - Tools.BaseProjectionVertexSurX(sommets[0], sommets[1])
                    , 4);

                spriteBatch.Draw(segTexture, arreteProjectionsurX, Color.White * 0.5f);
        }

        //il faut pas que l'angle soit regénéré tout le temps
    }
}
