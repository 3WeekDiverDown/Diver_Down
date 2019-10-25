using Diver_Down.Device;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diver_Down.Utility
{
    class Gauge
    {
        float m_maxValue;
        public float m_currentValue;
        float m_width;
        Rectangle m_bounds;
        Color m_color;
        Vector2 m_pos;


        public Gauge(Rectangle bounds,float startAmount,float maxValue,float width,Vector2 pos)
        {
            m_bounds = bounds;
            m_width = width;
            m_maxValue = maxValue;
            m_currentValue = startAmount;
            m_pos = pos;
        }
        public void Draw(Renderer renderer)
        {
            int width = (int)((m_currentValue / m_maxValue) * m_width);
            renderer.DrawTexture(
                "gauge"
                ,m_pos,
                new Rectangle(m_bounds.X,m_bounds.Y,width,m_bounds.Height)
                ,0);
            renderer.DrawTexture("fade", m_pos, m_bounds);
        }
    }
}
