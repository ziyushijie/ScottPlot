﻿using SkiaSharp;

namespace ScottPlot;

/// <summary>
/// Implement this interface to create a custom grid
/// </summary>
public interface IGrid
{
    public void Render(SKSurface surface, PixelRect dataRect, AxisViews.IAxisView axisView);
}
