Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace Series_Funnel
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a new chart.
			Dim funnelChart As New ChartControl()

			' Create a funnel series.
			Dim series1 As New Series("A Funnel Series", ViewType.Funnel)

			' Add points to the series.
			series1.Points.Add(New SeriesPoint("A", 48.5))
			series1.Points.Add(New SeriesPoint("B", 29.6))
			series1.Points.Add(New SeriesPoint("C", 17.1))
			series1.Points.Add(New SeriesPoint("D", 13.3))
			series1.Points.Add(New SeriesPoint("E", 11.6))

			' Add the series to the chart.
			funnelChart.Series.Add(series1)

			' Adjust the view-type specific properties of the series.
			Dim myView As FunnelSeriesView = CType(series1.View, FunnelSeriesView)

			myView.Titles.Add(New SeriesTitle())
			myView.Titles(0).Text = series1.Name
			myView.HeightToWidthRatioAuto = False
			myView.HeightToWidthRatio = 1.5
			myView.PointDistance = 10

			' Adjust the point options of the series.
			Dim myPointOptions As FunnelPointOptions = CType(series1.Label.PointOptions, FunnelPointOptions)

			myPointOptions.PointView = PointView.ArgumentAndValues
			myPointOptions.PercentOptions.ValueAsPercent = True
			myPointOptions.ValueNumericOptions.Format = NumericFormat.Percent
			myPointOptions.ValueNumericOptions.Precision = 0

			' Specify the series labels position.
			CType(series1.Label, FunnelSeriesLabel).Position = FunnelSeriesLabelPosition.RightColumn

			' Hide the legend (if necessary).
			funnelChart.Legend.Visible = False

			' Add the chart to the form.
			funnelChart.Dock = DockStyle.Fill
			Me.Controls.Add(funnelChart)
		End Sub
	End Class
End Namespace