using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace Series_Funnel {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            ChartControl funnelChart = new ChartControl();

            // Create a funnel series.
            Series series1 = new Series("A Funnel Series", ViewType.Funnel);
            
            // Add points to the series.
            series1.Points.Add(new SeriesPoint("A", 48.5));
            series1.Points.Add(new SeriesPoint("B", 29.6));
            series1.Points.Add(new SeriesPoint("C", 17.1));
            series1.Points.Add(new SeriesPoint("D", 13.3));
            series1.Points.Add(new SeriesPoint("E", 11.6));

            // Add the series to the chart.
            funnelChart.Series.Add(series1);

            // Adjust the view-type specific properties of the series.
            FunnelSeriesView myView = (FunnelSeriesView)series1.View;

            myView.Titles.Add(new SeriesTitle());
            myView.Titles[0].Text = series1.Name;
            myView.HeightToWidthRatioAuto = false;
            myView.HeightToWidthRatio = 1.5;
            myView.PointDistance = 10;

            // Adjust the point options of the series.
            FunnelPointOptions myPointOptions = (FunnelPointOptions)series1.Label.PointOptions;

            myPointOptions.PointView = PointView.ArgumentAndValues;
            myPointOptions.PercentOptions.ValueAsPercent = true;
            myPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            myPointOptions.ValueNumericOptions.Precision = 0;

            // Specify the series labels position.
            ((FunnelSeriesLabel)series1.Label).Position = FunnelSeriesLabelPosition.RightColumn;

            // Hide the legend (if necessary).
            funnelChart.Legend.Visible = false;

            // Add the chart to the form.
            funnelChart.Dock = DockStyle.Fill;
            this.Controls.Add(funnelChart);
        }
    }
}