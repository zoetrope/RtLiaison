// http://www.charlespetzold.com/blog/2009/01/Canonical-Splines-in-WPF-and-Silverlight.html
//TODO: WPF版(Shapeを継承したもの)だと、PointsのBindingに失敗する。なのでSilverlight版。

// CanonicalSpline.xaml.cs (c) 2009 by Charles Petzold (Silverlight version)
// www.charlespetzold.com/blog/2009/01/Canonical-Splines-in-WPF-and-Silverlight.htmlusing System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CanonicalSplineLib
{
    public partial class CanonicalSpline : UserControl
    {
        // Dependency Properties
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill",
                typeof(Brush),
                typeof(CanonicalSpline),
                new PropertyMetadata(null, OnPathPropertyChanged));

        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch",
                typeof(Stretch),
                typeof(CanonicalSpline),
                new PropertyMetadata(Stretch.None, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke",
                typeof(Brush),
                typeof(CanonicalSpline),
                new PropertyMetadata(null, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeDashArrayProperty =
            DependencyProperty.Register("StrokeDashArray",
                typeof(DoubleCollection),
                typeof(CanonicalSpline),
                new PropertyMetadata(null, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeDashCapProperty =
            DependencyProperty.Register("StrokeDashCap",
                typeof(PenLineCap),
                typeof(CanonicalSpline),
                new PropertyMetadata(PenLineCap.Flat, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeDashOffsetProperty =
            DependencyProperty.Register("StrokeDashOffset",
                typeof(double),
                typeof(CanonicalSpline),
                new PropertyMetadata(0.0, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeEndLineCapProperty =
            DependencyProperty.Register("StrokeEndLineCap",
                typeof(PenLineCap),
                typeof(CanonicalSpline),
                new PropertyMetadata(PenLineCap.Flat, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeLineJoinProperty =
            DependencyProperty.Register("StrokeLineJoin",
                typeof(PenLineJoin),
                typeof(CanonicalSpline),
                new PropertyMetadata(PenLineJoin.Miter, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeMiterLimitProperty =
            DependencyProperty.Register("StrokeMiterLimit",
                typeof(double),
                typeof(CanonicalSpline),
                new PropertyMetadata(10.0, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeStartLineCapProperty =
            DependencyProperty.Register("StrokeStartLineCap",
                typeof(PenLineCap),
                typeof(CanonicalSpline),
                new PropertyMetadata(PenLineCap.Flat, OnPathPropertyChanged));

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness",
                typeof(double),
                typeof(CanonicalSpline),
                new PropertyMetadata(1.0, OnPathPropertyChanged));

        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register("Points",
                typeof(PointCollection),
                typeof(CanonicalSpline),
                new PropertyMetadata(null, OnPathPropertyChanged));

        public static readonly DependencyProperty TensionProperty =
            DependencyProperty.Register("Tension",
                typeof(double),
                typeof(CanonicalSpline),
                new PropertyMetadata(Geometry.StandardFlatteningTolerance, OnPathPropertyChanged));

        public static readonly DependencyProperty TensionsProperty =
            DependencyProperty.Register("Tensions",
                typeof(DoubleCollection),
                typeof(CanonicalSpline),
                new PropertyMetadata(null, OnPathPropertyChanged));

        public static readonly DependencyProperty IsClosedProperty =
            DependencyProperty.Register("IsClosed",
                typeof(bool),
                typeof(CanonicalSpline),
                new PropertyMetadata(false, OnPathPropertyChanged));

        public static readonly DependencyProperty IsFilledProperty =
            DependencyProperty.Register("IsFilled",
                typeof(bool),
                typeof(CanonicalSpline),
                new PropertyMetadata(false, OnPathPropertyChanged));

        public static readonly DependencyProperty FillRuleProperty =
            DependencyProperty.Register("FillRule",
                typeof(FillRule),
                typeof(CanonicalSpline),
                new PropertyMetadata(FillRule.EvenOdd, OnPathPropertyChanged));

        public static readonly DependencyProperty ToleranceProperty =
            DependencyProperty.Register("Tolerance",
                typeof(double),
                typeof(CanonicalSpline),
                new PropertyMetadata(0.25, OnPathPropertyChanged));

        // Constructor
        public CanonicalSpline()
        {
            InitializeComponent();
        }

        // CLR Properties
        public Brush Fill
        {
            set { SetValue(FillProperty, value); }
            get { return (Brush)GetValue(FillProperty); }
        }

        public Stretch Stretch
        {
            set { SetValue(StretchProperty, value); }
            get { return (Stretch)GetValue(StretchProperty); }
        }

        public Brush Stroke
        {
            set { SetValue(StrokeProperty, value); }
            get { return (Brush)GetValue(StrokeProperty); }
        }

        public DoubleCollection StrokeDashArray
        {
            set { SetValue(StrokeDashArrayProperty, value); }
            get { return (DoubleCollection)GetValue(StrokeDashArrayProperty); }
        }

        public PenLineCap StrokeDashCap
        {
            set { SetValue(StrokeDashCapProperty, value); }
            get { return (PenLineCap)GetValue(StrokeDashCapProperty); }
        }

        public double StrokeDashOffset
        {
            set { SetValue(StrokeDashOffsetProperty, value); }
            get { return (double)GetValue(StrokeDashOffsetProperty); }
        }

        public PenLineCap StrokeEndLineCap
        {
            set { SetValue(StrokeEndLineCapProperty, value); }
            get { return (PenLineCap)GetValue(StrokeEndLineCapProperty); }
        }

        public PenLineJoin StrokeLineJoin
        {
            set { SetValue(StrokeLineJoinProperty, value); }
            get { return (PenLineJoin)GetValue(StrokeLineJoinProperty); }
        }

        public double StrokeMiterLimit
        {
            set { SetValue(StrokeMiterLimitProperty, value); }
            get { return (double)GetValue(StrokeMiterLimitProperty); }
        }

        public PenLineCap StrokeStartLineCap
        {
            set { SetValue(StrokeStartLineCapProperty, value); }
            get { return (PenLineCap)GetValue(StrokeStartLineCapProperty); }
        }

        public double StrokeThickness
        {
            set { SetValue(StrokeThicknessProperty, value); }
            get { return (double)GetValue(StrokeThicknessProperty); }
        }

        public PointCollection Points
        {
            set { SetValue(PointsProperty, value); }
            get { return (PointCollection)GetValue(PointsProperty); }
        }

        public double Tension
        {
            set { SetValue(TensionProperty, value); }
            get { return (double)GetValue(TensionProperty); }
        }

        public DoubleCollection Tensions
        {
            set { SetValue(TensionsProperty, value); }
            get { return (DoubleCollection)GetValue(TensionsProperty); }
        }

        public bool IsClosed
        {
            set { SetValue(IsClosedProperty, value); }
            get { return (bool)GetValue(IsClosedProperty); }
        }

        public bool IsFilled
        {
            set { SetValue(IsFilledProperty, value); }
            get { return (bool)GetValue(IsFilledProperty); }
        }

        public FillRule FillRule
        {
            set { SetValue(FillRuleProperty, value); }
            get { return (FillRule)GetValue(FillRuleProperty); }
        }

        public double Tolerance
        {
            set { SetValue(ToleranceProperty, value); }
            get { return (double)GetValue(ToleranceProperty); }
        }

        // Property-Changed handlers
        static void OnPathPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as CanonicalSpline).OnPropertyChanged(args);
        }

        void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            if (args.Property == FillProperty)
                path.Fill = Fill;

            else if (args.Property == StretchProperty)
                path.Stretch = Stretch;

            else if (args.Property == StrokeProperty)
                path.Stroke = Stroke;

            else if (args.Property == StrokeDashArrayProperty)
                path.StrokeDashArray = StrokeDashArray;

            else if (args.Property == StrokeDashCapProperty)
                path.StrokeDashCap = StrokeDashCap;

            else if (args.Property == StrokeDashOffsetProperty)
                path.StrokeDashOffset = StrokeDashOffset;

            else if (args.Property == StrokeEndLineCapProperty)
                path.StrokeEndLineCap = StrokeEndLineCap;

            else if (args.Property == StrokeLineJoinProperty)
                path.StrokeLineJoin = StrokeLineJoin;

            else if (args.Property == StrokeMiterLimitProperty)
                path.StrokeMiterLimit = StrokeMiterLimit;

            else if (args.Property == StrokeStartLineCapProperty)
                path.StrokeStartLineCap = StrokeStartLineCap;

            else if (args.Property == StrokeThicknessProperty)
                path.StrokeThickness = StrokeThickness;

            else if (args.Property == PointsProperty ||
                     args.Property == TensionProperty ||
                     args.Property == TensionsProperty ||
                     args.Property == IsClosedProperty ||
                     args.Property == IsFilledProperty ||
                     args.Property == ToleranceProperty)
            {
                PathGeometry pathGeometry = CanonicalSplineHelper.CreateSpline(Points, Tension, Tensions, IsClosed, IsFilled, Tolerance);

                if (pathGeometry != null)
                    pathGeometry.FillRule = FillRule;

                path.Data = pathGeometry;
            }

            else if (args.Property == FillRuleProperty)
            {
                if (path.Data is PathGeometry)
                {
                    PathGeometry pathGeometry = path.Data as PathGeometry;
                    path.Data = null;
                    pathGeometry.FillRule = FillRule;
                    path.Data = pathGeometry;
                }
            }
        }
    }
}
