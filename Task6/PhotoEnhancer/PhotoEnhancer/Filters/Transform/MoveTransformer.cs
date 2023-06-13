using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class MoveTransformer : ITransformer<MoveParameters>
    {
        double movePercent { get; set; }

        public Size ResultSize { get; private set; }

        public void Initialize(Size size, MoveParameters parameters)
        {
            movePercent = parameters.MoveInPercent / 100;
            ResultSize = size;
        }

        public Point? MapPoint(Point point)
        {
            return new Point(point.X, (point.Y + (int)(movePercent * ResultSize.Height)) % ResultSize.Height);
        }
    }
}