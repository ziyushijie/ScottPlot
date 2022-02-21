﻿using Microsoft.Maui.Graphics;

namespace ScottPlot.Axes;

public class LeftAxis : AxisBase, IAxis
{
    public LeftAxis(string text = "")
    {
        Label.Text = text;
        Edge = Edge.Left;
        Orientation = Orientation.Vertical;
    }

    public void Draw(ICanvas canvas, PlotConfig info)
    {
        float xLeft = 0;
        float yCenter = info.DataRect.VerticalCenter;
        Label.Draw(canvas, xLeft, yCenter, -90);
    }
}
