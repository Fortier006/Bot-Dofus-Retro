﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Bot_Dofus_1._29._1.Controles.ControlMapa.Celdas
{
    public class CeldaMapa
    {
        public short id;
        private Point[] mapa_puntos;
        public CeldaEstado estado { get; set; }
        public Brush CustomBrush { get; set; }
        public Pen CustomBorderPen { get; set; }
        public Pen MouseOverPen { get; set; }
        public Rectangle Rectangulo { get; private set; }
        public Point Centro => new Point((Puntos[0].X + Puntos[2].X) / 2, (Puntos[1].Y + Puntos[3].Y) / 2);

        public CeldaMapa(short _id)
        {
            id = _id;
            estado = CeldaEstado.NO_CAMINABLE;
        }

        public Point[] Puntos
        {
            get => mapa_puntos;
            set
            {
                mapa_puntos = value;
                RefreshBounds();
            }
        }

        public void RefreshBounds()
        {
            int x = Puntos.Min(entry => entry.X);
            int y = Puntos.Min(entry => entry.Y);

            int width = Puntos.Max(entry => entry.X) - x;
            int height = Puntos.Max(entry => entry.Y) - y;

            Rectangulo = new Rectangle(x, y, width, height);
        }

        public void dibujar_Color(Graphics g, Color borderColor, Color? fillingColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLines(Puntos);

                if (fillingColor != null)
                {
                    using (SolidBrush brush = new SolidBrush(fillingColor.Value))
                    {
                        g.FillPath(brush, path);
                    }
                }

                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        public virtual void dibujar_Celda_Id(ControlMapa parent, Graphics g)
        {
            StringFormat formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(id.ToString(), parent.Font, Brushes.Black, new RectangleF(Rectangulo.X, Rectangulo.Y, Rectangulo.Width, Rectangulo.Height), formato);
        }

        public void dibujar_FillPie(Graphics g, Color color, float size)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillPie(brush, Puntos[1].X - size / 2, Puntos[1].Y + 4.2f, size, size, 0, 360);
            }
        }

        public void dibujar_Obstaculo(Graphics g, Color borderColor, Color fillingColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                Point[] newPoints = new Point[15];

                newPoints[0] = new Point(Puntos[0].X, Puntos[0].Y - 10);
                newPoints[1] = new Point(Puntos[1].X, Puntos[1].Y - 10);
                newPoints[2] = new Point(Puntos[2].X, Puntos[2].Y - 10);
                newPoints[3] = new Point(Puntos[3].X, Puntos[3].Y - 10);
                newPoints[4] = new Point(Puntos[0].X, Puntos[0].Y - 10);

                newPoints[5] = new Point(Puntos[0].X, Puntos[0].Y - 10);
                newPoints[6] = new Point(Puntos[3].X, Puntos[3].Y - 10);
                newPoints[7] = Puntos[3];
                newPoints[8] = Puntos[0];
                newPoints[9] = new Point(Puntos[0].X, Puntos[0].Y - 10);

                newPoints[10] = new Point(Puntos[3].X, Puntos[3].Y - 10);
                newPoints[11] = new Point(Puntos[2].X, Puntos[2].Y - 10);
                newPoints[12] = Puntos[2];
                newPoints[13] = Puntos[3];
                newPoints[14] = new Point(Puntos[3].X, Puntos[3].Y - 10);

                path.AddLines(newPoints);

                using (SolidBrush brush = new SolidBrush(fillingColor))
                    g.FillPath(brush, path);

                using (Pen pen = new Pen(borderColor))
                    g.DrawPath(pen, path);
            }
        }

        public bool esta_En_Rectangulo(Rectangle rectangulo) => Rectangulo.IntersectsWith(rectangulo);
        public bool esta_En_Rectangulo(RectangleF rectangulo) => Rectangulo.IntersectsWith(Rectangle.Ceiling(rectangulo));
    }
}
