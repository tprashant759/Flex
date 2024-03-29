﻿using System;
using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using XamarinFlex.Effects.TouchTracking;

namespace XamarinFlex.Views.SkiaSharp
{
    public partial class FingerPaintingPage : ContentPage
    {
        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        public FingerPaintingPage()
        {
            InitializeComponent();
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            try
            {

                switch (args.Type)
                {
                    case TouchActionType.Pressed:
                        if (!inProgressPaths.ContainsKey(args.Id))
                        {
                            SKPath path = new SKPath();
                            path.MoveTo(ConvertToPixel(args.Location));
                            inProgressPaths.Add(args.Id, path);
                            canvasView.InvalidateSurface();
                        }
                        break;

                    case TouchActionType.Moved:
                        if (inProgressPaths.ContainsKey(args.Id))
                        {
                            SKPath path = inProgressPaths[args.Id];
                            path.LineTo(ConvertToPixel(args.Location));
                            canvasView.InvalidateSurface();
                        }
                        break;

                    case TouchActionType.Released:
                        if (inProgressPaths.ContainsKey(args.Id))
                        {
                            completedPaths.Add(inProgressPaths[args.Id]);
                            inProgressPaths.Remove(args.Id);
                            canvasView.InvalidateSurface();
                        }
                        break;

                    case TouchActionType.Cancelled:
                        if (inProgressPaths.ContainsKey(args.Id))
                        {
                            inProgressPaths.Remove(args.Id);
                            canvasView.InvalidateSurface();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }
    
    SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }


        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            try
            {

                SKCanvas canvas = args.Surface.Canvas;
                canvas.Clear();

                foreach (SKPath path in completedPaths)
                {
                    canvas.DrawPath(path, paint);
                }

                foreach (SKPath path in inProgressPaths.Values)
                {
                    canvas.DrawPath(path, paint);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
