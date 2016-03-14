using System;
using System.Windows;
using System.Windows.Media.Effects;

// Wrapper for the Mandelbrout Set PixelShader
namespace Fractals
{
    internal class MandelbrotEffect : ShaderEffect
    {
        private readonly PixelShader _mandelbrotPs = new PixelShader
        {
            UriSource = new Uri(@"mandel.ps", UriKind.RelativeOrAbsolute)
        };

        public MandelbrotEffect()
        {
            PixelShader = _mandelbrotPs;
            UpdateShaderValue(MaxIterProperty);
            UpdateShaderValue(PowerProperty);
            UpdateShaderValue(BailoutProperty);
            UpdateShaderValue(OffsetProperty);
            UpdateShaderValue(SizeProperty);
        }

        public static readonly DependencyProperty MaxIterProperty =
            DependencyProperty.Register("MaxIter", typeof (double), typeof (MandelbrotEffect),
                new UIPropertyMetadata(32.0, PixelShaderConstantCallback(0))); // register(c0)

        public double MaxIter
        {
            get { return (double) GetValue(MaxIterProperty); }
            set { SetValue(MaxIterProperty, value); }
        }

        public static readonly DependencyProperty PowerProperty =
            DependencyProperty.Register("Power", typeof (Point),
                typeof (MandelbrotEffect), new UIPropertyMetadata(new Point(2, 0),
                    PixelShaderConstantCallback(1))); // register(c1)

        public Point Power
        {
            get { return (Point) GetValue(PowerProperty); }
            set { SetValue(PowerProperty, value); }
        }

        public static readonly DependencyProperty BailoutProperty =
            DependencyProperty.Register("Bailout", typeof (double),
                typeof (MandelbrotEffect),
                new UIPropertyMetadata(4.0, PixelShaderConstantCallback(2))); // register(c2)

        public double Bailout
        {
            get { return (double) GetValue(BailoutProperty); }
            set { SetValue(BailoutProperty, value); }
        }

        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register("Offset", typeof (Point),
                typeof (MandelbrotEffect), new UIPropertyMetadata(new Point(-3.1, -1.5), // (-2, 3)
                    PixelShaderConstantCallback(3))); // register(c3)

        public Point Offset
        {
            get { return (Point) GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof (Point),
                typeof (MandelbrotEffect), new UIPropertyMetadata(new Point(0.35, 0.35), // (0.25,0.25)
                    PixelShaderConstantCallback(4))); // register(c4)

        public Point Size
        {
            get { return (Point) GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
    }
}
