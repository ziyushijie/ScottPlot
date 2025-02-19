﻿using ScottPlot.Control.EventArgs;

namespace ScottPlot.Control.Interactions;

public class Default : IPlotInteractions
{
    public void MouseDown(IPlotControl sender, MouseDownEventArgs e)
    {
    }

    public void MouseUp(IPlotControl sender, MouseUpEventArgs e)
    {
        if (e.Handled)
            return;


        switch (e.Button)
        {
            case MouseButton.Mouse3:
                if (!e.CancelledDrag)
                {
                    sender.Plot.MouseZoomRectangleClear(applyZoom: false);
                    sender.Plot.AutoScale();
                }
                break;
            default:
                return;
        }

        sender.Refresh();
    }

    public void MouseMove(IPlotControl sender, MouseMoveEventArgs e)
    {

    }

    public void MouseDrag(IPlotControl sender, MouseDragEventArgs e)
    {
        if (e.Handled)
            return;

        switch (e.Button)
        {
            case MouseButton.Mouse1:
                if (e.PressedKeys.Contains(Key.Alt))
                {
                    sender.Plot.MouseZoomRectangle(e.From, e.To);
                }
                else
                {
                    Pixel panTo = e.To;
                    panTo.X = e.PressedKeys.Contains(Key.Shift) ? e.From.X : panTo.X;
                    panTo.Y = e.PressedKeys.Contains(Key.Ctrl) ? e.From.Y : panTo.Y;

                    sender.Plot.MousePan(e.MouseDown.AxisLimits, e.From, panTo);
                }
                break;
            case MouseButton.Mouse2:
                sender.Plot.MouseZoom(e.MouseDown.AxisLimits, e.From, e.To);
                break;
            case MouseButton.Mouse3:
                sender.Plot.MouseZoomRectangle(e.From, e.To);
                break;
            default:
                return;
        }

        sender.Refresh();
    }

    public void DoubleClick(IPlotControl sender, MouseDownEventArgs e)
    {
        if (e.Handled)
            return;

        sender.Plot.Benchmark.IsVisible = !sender.Plot.Benchmark.IsVisible;

        sender.Refresh();
    }

    public void MouseWheel(IPlotControl sender, MouseWheelEventArgs e)
    {
        if (e.Handled)
            return;

        double fracX = e.DeltaY > 0 ? 1.15 : .85;
        double fracY = e.DeltaY > 0 ? 1.15 : .85;
        sender.Plot.MouseZoom(fracX, fracY, e.Position);

        sender.Refresh();
    }

    public void MouseDragEnd(IPlotControl sender, MouseDragEventArgs e)
    {
        if (e.Handled)
            return;

        if (e.Button == MouseButton.Mouse3 || (e.Button == MouseButton.Mouse1 && e.PressedKeys.Contains(Key.Alt)))
        {
            sender.Plot.MouseZoomRectangleClear(applyZoom: true);
            sender.Refresh();
        }
    }

    public void KeyDown(IPlotControl sender, KeyDownEventArgs e)
    {
    }

    public void KeyUp(IPlotControl sender, KeyUpEventArgs e)
    {
    }
}
