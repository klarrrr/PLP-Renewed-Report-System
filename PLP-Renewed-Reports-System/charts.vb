Imports System.IO
Imports System.Windows.Media
Imports LiveCharts
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient
Imports OxyPlot
Imports OxyPlot.Axes

Module charts
    Private ReadOnly con As New MySqlConnection("server=localhost;username=root;password=;database=plpportal_db")
    Public Property MySeriesCollection As SeriesCollection
    Private gap As Integer

    Sub PieChart(ByRef PiePanel As Panel, profNameLbl As String)
        gap = 1

        con.Open()

        Dim profName As String = profNameLbl.Replace("Prof. ", "")

        Dim bcmd As New MySqlCommand("select r.reason_id, r.reason, count(*) as reportCount " &
                                    "from reports as rp " &
                                    "left join reasons as r on rp.reason = r.reason " &
                                    "where rp.teacher = '" & profName & "' " &
                                    "AND YEAR(rp.consultation_date) = YEAR(CURDATE()) " &
                                    "group bY r.reason_id, r.reason " &
                                    "order by r.reason_id", con)

        Dim reasons As New List(Of String)()
        Dim reportCounts As New List(Of Integer)()
        Dim bdr As MySqlDataReader = bcmd.ExecuteReader()

        While bdr.Read()
            reasons.Add(bdr("reason").ToString())
            reportCounts.Add(Convert.ToInt32(bdr("reportCount")))
        End While

        bdr.Close()
        con.Close()

        MySeriesCollection = New SeriesCollection
        Dim greenShades As List(Of Color) = GenerateGreenShades(reasons.Count)

        For i As Integer = 0 To reasons.Count() - 1
            MySeriesCollection.Add(New PieSeries With {
                .Title = reasons(i),
                .Values = New ChartValues(Of Integer) From {reportCounts(i)},
                .DataLabels = True,
                .LabelPoint = Function(chartPoint) String.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation),
                .Fill = New SolidColorBrush(greenShades(i))
            })
        Next

        Dim pieChart As New WinForms.PieChart With {        ' Create a PieChart control for WinForms
            .Series = MySeriesCollection,                   ' Assign the series collection to the PieChart control's Series property
            .LegendLocation = LegendLocation.Right,         ' Optionally set the legend position (if you need the legend)
            .Dock = DockStyle.Fill                          ' Set the chartnotenote's size to fit inside the panel (optional)
        }

        PiePanel.Controls.Clear()
        PiePanel.Controls.Add(pieChart)
    End Sub

    Sub ColumnBarChart(ByRef BarChartPanel As Panel)
        gap = 2
        MySeriesCollection = New SeriesCollection

        con.Open()

        Dim bcmd As New MySqlCommand("SELECT 
                                        p.name, 
                                        COUNT(*) AS profCount 
                                    FROM 
                                        reports AS pc 
                                    INNER JOIN 
                                        profinfo AS p 
                                    ON 
                                        pc.teacher = p.name 
                                    WHERE 
                                        YEAR(pc.consultation_date) = YEAR(CURDATE()) 
                                    GROUP BY 
                                        p.name;
                                    ", con)

        Dim names As New List(Of String)()
        Dim reportCounts As New List(Of Integer)()

        Dim bdr As MySqlDataReader = bcmd.ExecuteReader()

        While bdr.Read()
            names.Add(bdr("name").ToString())
            reportCounts.Add(Convert.ToInt32(bdr("profCount")))
        End While

        bdr.Close()
        con.Close()

        Dim greenShades As List(Of Color) = GenerateGreenShades(names.Count)

        For i As Integer = 0 To names.Count() - 1
            MySeriesCollection.Add(New ColumnSeries With {
                .Title = names(i),
                .Values = New ChartValues(Of Integer) From {reportCounts(i)},
                .DataLabels = True,
                .Fill = New SolidColorBrush(greenShades(i))
            })
        Next

        Dim BarChart As New WinForms.CartesianChart With {
            .Series = MySeriesCollection,
            .LegendLocation = LegendLocation.Right,
            .Dock = DockStyle.Fill
        }

        BarChartPanel.Controls.Clear()
        BarChartPanel.Controls.Add(BarChart)
    End Sub
    Sub RowBarChart(ByRef BarChartPanel As Panel)
        gap = 1
        MySeriesCollection = New SeriesCollection

        ' Open the database connection
        con.Open()

        ' Modify the query to use LEFT JOIN to include reasons without reports
        Dim pcmd As New MySqlCommand("
                                    SELECT 
                                        r.reason_id, 
                                        r.reason, 
                                        COUNT(rp.report_id) AS ReportCount 
                                    FROM 
                                        reasons AS r 
                                    LEFT JOIN 
                                        reports AS rp 
                                    ON 
                                        r.reason = rp.reason 
                                    WHERE 
                                        YEAR(rp.consultation_date) = YEAR(CURDATE()) OR rp.consultation_date IS NULL
                                    GROUP BY 
                                        r.reason_id, r.reason 
                                    ORDER BY 
                                        r.reason_id;
                                    ", con)

        Dim reasons As New List(Of String)()
        Dim reportCounts As New List(Of Integer)()

        Dim pdr As MySqlDataReader = pcmd.ExecuteReader()

        ' Process the query results
        While pdr.Read()
            Dim reason As String = pdr("reason").ToString()
            Dim reportCount As Integer = If(IsDBNull(pdr("ReportCount")), 0, Convert.ToInt32(pdr("ReportCount")))

            Console.WriteLine($"Reason: {reason}, ReportCount: {reportCount}") ' Debugging output

            reasons.Add(reason)
            reportCounts.Add(reportCount)
        End While

        pdr.Close()
        con.Close()

        ' Generate shades of green based on the number of reasons
        Dim greenShades As List(Of Color) = GenerateGreenShades(reasons.Count)

        ' Create the bar chart series
        For i As Integer = 0 To reasons.Count() - 1
            MySeriesCollection.Add(New RowSeries With {
            .Title = reasons(i),
            .Values = New ChartValues(Of Integer) From {reportCounts(i)},
            .DataLabels = True,
            .Fill = New SolidColorBrush(greenShades(i))
        })
        Next

        ' Initialize the bar chart
        Dim BarChart As New WinForms.CartesianChart With {
            .Series = MySeriesCollection,
            .LegendLocation = LegendLocation.Right,
            .Dock = DockStyle.Fill
        }

        ' Add the chart to the panel
        BarChartPanel.Controls.Clear()
        BarChartPanel.Controls.Add(BarChart)
    End Sub

    Sub ReportsChart(ByRef LinePanel As Panel, ByRef DataGrid As DataGridView)
        LinePanel.Controls.Clear()

        Dim plotModel As New OxyPlot.PlotModel() With {
            .Title = "Yearly Report Count"
        }

        Dim monthlyReportCounts As New Dictionary(Of Integer, Integer)()

        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("ConsultationDate").Value IsNot Nothing Then
                Dim reportDate As DateTime = Convert.ToDateTime(row.Cells("ConsultationDate").Value)

                If reportDate.Year = Date.Today.Year Then
                    Dim month As Integer = reportDate.Month

                    If monthlyReportCounts.ContainsKey(month) Then
                        monthlyReportCounts(month) += 1
                    Else
                        monthlyReportCounts.Add(month, 1)
                    End If
                End If
            End If
        Next

        Dim months As New List(Of String)() From {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        }

        Dim counts As New List(Of Integer)()

        For month As Integer = 1 To 12
            If monthlyReportCounts.ContainsKey(month) Then
                counts.Add(monthlyReportCounts(month))
            Else
                counts.Add(0)
            End If
        Next

        Dim lineSeries As New OxyPlot.Series.LineSeries With {
            .Title = "Monthly Report Count",
            .MarkerType = OxyPlot.MarkerType.Circle,
            .MarkerSize = 4,
            .LineStyle = OxyPlot.LineStyle.Solid,
            .Color = OxyPlot.OxyColor.FromRgb(0, 64, 0),
            .TextColor = OxyColor.FromRgb(46, 46, 46),
            .LabelFormatString = "{1}",
            .StrokeThickness = 2
        }

        For month As Integer = 0 To 11
            lineSeries.Points.Add(New DataPoint(month, counts(month)))
        Next

        plotModel.Series.Add(lineSeries)

        Dim xAxis As New OxyPlot.Axes.CategoryAxis With {
            .Position = OxyPlot.Axes.AxisPosition.Bottom,
            .Title = "Month",
            .TickStyle = OxyPlot.Axes.TickStyle.Inside
        }

        For Each buwan In months
            xAxis.Labels.Add(buwan)
        Next

        plotModel.Axes.Add(xAxis)

        Dim MaxReport As Integer = monthlyReportCounts.Values.DefaultIfEmpty(0).Max()

        Dim numberOfIntervals As Integer = 5
        Dim interval = Math.Ceiling(MaxReport / (numberOfIntervals - 1))
        If interval = 0 Then interval = 1

        Dim yAxis As New OxyPlot.Axes.LinearAxis With {
            .Position = OxyPlot.Axes.AxisPosition.Left,
            .Title = "Report Count",
            .Minimum = 0,
            .TickStyle = TickStyle.Inside,
            .Maximum = Math.Ceiling((MaxReport + interval) / interval) * interval
        }

        plotModel.Axes.Add(yAxis)

        Dim plotView As New WindowsForms.PlotView() With {
            .Model = plotModel,
            .Dock = DockStyle.Fill
        }

        LinePanel.Controls.Add(plotView)
    End Sub
    Private Function GenerateGreenShades(count As Integer) As List(Of Color)
        Dim greenShades As New List(Of Color)
        Dim baseGreen As Integer = 40
        Dim Gradient As Integer
        If gap = 1 Then
            Gradient = 15
        ElseIf gap = 2 Then
            Gradient = 5
        End If

        For i As Integer = 0 To count - 1
            Dim red As Integer = 0
            Dim green As Integer = Math.Min(baseGreen + (i * Gradient), 255)
            Dim blue As Integer = 0

            greenShades.Add(Color.FromRgb(red, green, blue))
        Next

        Return greenShades
    End Function
    Public Function ConvertPanelToITextSharpImage(panel As Panel) As iTextSharp.text.Image
        Dim bmp As New Bitmap(panel.Width, panel.Height)
        panel.DrawToBitmap(bmp, panel.ClientRectangle)
        Using ms As New MemoryStream()
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png) ' Save as PNG to the MemoryStream
            ms.Seek(0, SeekOrigin.Begin)
            Return iTextSharp.text.Image.GetInstance(ms)
        End Using
    End Function
End Module
