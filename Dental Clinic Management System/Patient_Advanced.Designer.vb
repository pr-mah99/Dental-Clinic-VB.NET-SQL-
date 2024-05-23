<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Patient_Advanced
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Table3 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression2 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression3 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression4 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression5 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column6 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression6 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column7 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression7 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column8 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression8 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column9 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression9 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column10 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression10 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column11 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression11 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column12 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression12 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column13 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression13 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column14 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression14 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column15 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression15 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Patient_Advanced))
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailData1Vertical = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailData1VerticalFirstRow = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailData1VerticalRow_Even = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailData1VerticalLastRow_Even = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.HeaderData1Vertical = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.HeaderData1VerticalFirstRow = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.HeaderData1VerticalRow_Even = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.HeaderData1VerticalLastRow_Even = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.VerticalHeader = New DevExpress.XtraReports.UI.VerticalHeaderBand()
        Me.VerticalDetail = New DevExpress.XtraReports.UI.VerticalDetailBand()
        Me.pageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.pageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.label1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.table1 = New DevExpress.XtraReports.UI.XRTable()
        Me.tableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow10 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow11 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow12 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow13 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow14 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.table2 = New DevExpress.XtraReports.UI.XRTable()
        Me.tableRow15 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow16 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow17 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow18 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow19 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow20 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow21 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow22 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow23 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow24 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow25 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow26 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow27 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableRow28 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.tableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.tableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.table1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.table2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "localhost_Dental_Connection"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        ColumnExpression1.ColumnName = "Patient_id"
        Table3.Name = "Patient"
        ColumnExpression1.Table = Table3
        Column1.Expression = ColumnExpression1
        ColumnExpression2.ColumnName = "Patient_name"
        ColumnExpression2.Table = Table3
        Column2.Expression = ColumnExpression2
        ColumnExpression3.ColumnName = "Patient_age"
        ColumnExpression3.Table = Table3
        Column3.Expression = ColumnExpression3
        ColumnExpression4.ColumnName = "Patient_gender"
        ColumnExpression4.Table = Table3
        Column4.Expression = ColumnExpression4
        ColumnExpression5.ColumnName = "Patient_mobile"
        ColumnExpression5.Table = Table3
        Column5.Expression = ColumnExpression5
        ColumnExpression6.ColumnName = "Patient_email"
        ColumnExpression6.Table = Table3
        Column6.Expression = ColumnExpression6
        ColumnExpression7.ColumnName = "Problem"
        ColumnExpression7.Table = Table3
        Column7.Expression = ColumnExpression7
        ColumnExpression8.ColumnName = "Problem_Describe"
        ColumnExpression8.Table = Table3
        Column8.Expression = ColumnExpression8
        ColumnExpression9.ColumnName = "Date"
        ColumnExpression9.Table = Table3
        Column9.Expression = ColumnExpression9
        ColumnExpression10.ColumnName = "Patient_city"
        ColumnExpression10.Table = Table3
        Column10.Expression = ColumnExpression10
        ColumnExpression11.ColumnName = "Time"
        ColumnExpression11.Table = Table3
        Column11.Expression = ColumnExpression11
        ColumnExpression12.ColumnName = "username"
        ColumnExpression12.Table = Table3
        Column12.Expression = ColumnExpression12
        ColumnExpression13.ColumnName = "password"
        ColumnExpression13.Table = Table3
        Column13.Expression = ColumnExpression13
        ColumnExpression14.ColumnName = "allow"
        ColumnExpression14.Table = Table3
        Column14.Expression = ColumnExpression14
        ColumnExpression15.ColumnName = "Type_enter"
        ColumnExpression15.Table = Table3
        Column15.Expression = ColumnExpression15
        SelectQuery1.Columns.Add(Column1)
        SelectQuery1.Columns.Add(Column2)
        SelectQuery1.Columns.Add(Column3)
        SelectQuery1.Columns.Add(Column4)
        SelectQuery1.Columns.Add(Column5)
        SelectQuery1.Columns.Add(Column6)
        SelectQuery1.Columns.Add(Column7)
        SelectQuery1.Columns.Add(Column8)
        SelectQuery1.Columns.Add(Column9)
        SelectQuery1.Columns.Add(Column10)
        SelectQuery1.Columns.Add(Column11)
        SelectQuery1.Columns.Add(Column12)
        SelectQuery1.Columns.Add(Column13)
        SelectQuery1.Columns.Add(Column14)
        SelectQuery1.Columns.Add(Column15)
        SelectQuery1.Name = "Patient"
        SelectQuery1.Tables.Add(Table3)
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.BorderColor = System.Drawing.Color.Black
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1.0!
        Me.Title.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.Title.Name = "Title"
        '
        'PageInfo
        '
        Me.PageInfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.PageInfo.Name = "PageInfo"
        Me.PageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        '
        'DetailData1Vertical
        '
        Me.DetailData1Vertical.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DetailData1Vertical.BorderColor = System.Drawing.Color.White
        Me.DetailData1Vertical.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.DetailData1Vertical.BorderWidth = 2.0!
        Me.DetailData1Vertical.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.DetailData1Vertical.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DetailData1Vertical.Name = "DetailData1Vertical"
        Me.DetailData1Vertical.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.DetailData1Vertical.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'DetailData1VerticalFirstRow
        '
        Me.DetailData1VerticalFirstRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DetailData1VerticalFirstRow.BorderColor = System.Drawing.Color.White
        Me.DetailData1VerticalFirstRow.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.DetailData1VerticalFirstRow.BorderWidth = 2.0!
        Me.DetailData1VerticalFirstRow.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.DetailData1VerticalFirstRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DetailData1VerticalFirstRow.Name = "DetailData1VerticalFirstRow"
        Me.DetailData1VerticalFirstRow.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.DetailData1VerticalFirstRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'DetailData1VerticalRow_Even
        '
        Me.DetailData1VerticalRow_Even.BackColor = System.Drawing.Color.Transparent
        Me.DetailData1VerticalRow_Even.BorderColor = System.Drawing.Color.White
        Me.DetailData1VerticalRow_Even.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.DetailData1VerticalRow_Even.BorderWidth = 2.0!
        Me.DetailData1VerticalRow_Even.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.DetailData1VerticalRow_Even.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DetailData1VerticalRow_Even.Name = "DetailData1VerticalRow_Even"
        Me.DetailData1VerticalRow_Even.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.DetailData1VerticalRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'DetailData1VerticalLastRow_Even
        '
        Me.DetailData1VerticalLastRow_Even.BackColor = System.Drawing.Color.Transparent
        Me.DetailData1VerticalLastRow_Even.BorderColor = System.Drawing.Color.White
        Me.DetailData1VerticalLastRow_Even.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.DetailData1VerticalLastRow_Even.BorderWidth = 2.0!
        Me.DetailData1VerticalLastRow_Even.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.DetailData1VerticalLastRow_Even.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.DetailData1VerticalLastRow_Even.Name = "DetailData1VerticalLastRow_Even"
        Me.DetailData1VerticalLastRow_Even.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.DetailData1VerticalLastRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'HeaderData1Vertical
        '
        Me.HeaderData1Vertical.BackColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.HeaderData1Vertical.BorderColor = System.Drawing.Color.White
        Me.HeaderData1Vertical.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.HeaderData1Vertical.BorderWidth = 2.0!
        Me.HeaderData1Vertical.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.HeaderData1Vertical.ForeColor = System.Drawing.Color.White
        Me.HeaderData1Vertical.Name = "HeaderData1Vertical"
        Me.HeaderData1Vertical.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.HeaderData1Vertical.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'HeaderData1VerticalFirstRow
        '
        Me.HeaderData1VerticalFirstRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.HeaderData1VerticalFirstRow.BorderColor = System.Drawing.Color.White
        Me.HeaderData1VerticalFirstRow.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.HeaderData1VerticalFirstRow.BorderWidth = 2.0!
        Me.HeaderData1VerticalFirstRow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.HeaderData1VerticalFirstRow.ForeColor = System.Drawing.Color.White
        Me.HeaderData1VerticalFirstRow.Name = "HeaderData1VerticalFirstRow"
        Me.HeaderData1VerticalFirstRow.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.HeaderData1VerticalFirstRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'HeaderData1VerticalRow_Even
        '
        Me.HeaderData1VerticalRow_Even.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(131, Byte), Integer))
        Me.HeaderData1VerticalRow_Even.BorderColor = System.Drawing.Color.White
        Me.HeaderData1VerticalRow_Even.Borders = DevExpress.XtraPrinting.BorderSide.Right
        Me.HeaderData1VerticalRow_Even.BorderWidth = 2.0!
        Me.HeaderData1VerticalRow_Even.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.HeaderData1VerticalRow_Even.ForeColor = System.Drawing.Color.White
        Me.HeaderData1VerticalRow_Even.Name = "HeaderData1VerticalRow_Even"
        Me.HeaderData1VerticalRow_Even.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.HeaderData1VerticalRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'HeaderData1VerticalLastRow_Even
        '
        Me.HeaderData1VerticalLastRow_Even.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(131, Byte), Integer))
        Me.HeaderData1VerticalLastRow_Even.BorderColor = System.Drawing.Color.White
        Me.HeaderData1VerticalLastRow_Even.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.HeaderData1VerticalLastRow_Even.BorderWidth = 2.0!
        Me.HeaderData1VerticalLastRow_Even.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.HeaderData1VerticalLastRow_Even.ForeColor = System.Drawing.Color.White
        Me.HeaderData1VerticalLastRow_Even.Name = "HeaderData1VerticalLastRow_Even"
        Me.HeaderData1VerticalLastRow_Even.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.HeaderData1VerticalLastRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2, Me.XrLabel3})
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.pageInfo1, Me.pageInfo2})
        Me.BottomMargin.Name = "BottomMargin"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.label1})
        Me.ReportHeader.HeightF = 60.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'VerticalHeader
        '
        Me.VerticalHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.table1})
        Me.VerticalHeader.HeightF = 392.0!
        Me.VerticalHeader.Name = "VerticalHeader"
        Me.VerticalHeader.RepeatEveryPage = True
        Me.VerticalHeader.WidthF = 111.5183!
        '
        'VerticalDetail
        '
        Me.VerticalDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.table2})
        Me.VerticalDetail.HeightF = 392.0!
        Me.VerticalDetail.KeepTogether = True
        Me.VerticalDetail.Name = "VerticalDetail"
        Me.VerticalDetail.WidthF = 111.5183!
        '
        'pageInfo1
        '
        Me.pageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 5.0!)
        Me.pageInfo1.Name = "pageInfo1"
        Me.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.pageInfo1.SizeF = New System.Drawing.SizeF(315.0!, 23.0!)
        Me.pageInfo1.StyleName = "PageInfo"
        '
        'pageInfo2
        '
        Me.pageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(330.0!, 5.0!)
        Me.pageInfo2.Name = "pageInfo2"
        Me.pageInfo2.SizeF = New System.Drawing.SizeF(315.0!, 23.0!)
        Me.pageInfo2.StyleName = "PageInfo"
        Me.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.pageInfo2.TextFormatString = "Page {0} of {1}"
        '
        'label1
        '
        Me.label1.LocationFloat = New DevExpress.Utils.PointFloat(309.9109!, 10.0!)
        Me.label1.Name = "label1"
        Me.label1.SizeF = New System.Drawing.SizeF(203.1257!, 24.19433!)
        Me.label1.StyleName = "Title"
        Me.label1.Text = "تقرير المرضى باللغة العربية"
        '
        'table1
        '
        Me.table1.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.table1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.table1.Name = "table1"
        Me.table1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.tableRow1, Me.tableRow2, Me.tableRow3, Me.tableRow4, Me.tableRow5, Me.tableRow6, Me.tableRow7, Me.tableRow8, Me.tableRow9, Me.tableRow10, Me.tableRow11, Me.tableRow12, Me.tableRow13, Me.tableRow14})
        Me.table1.SizeF = New System.Drawing.SizeF(111.5183!, 392.0!)
        '
        'tableRow1
        '
        Me.tableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell1})
        Me.tableRow1.Name = "tableRow1"
        Me.tableRow1.Weight = 0.071428571428571425R
        '
        'tableRow2
        '
        Me.tableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell2})
        Me.tableRow2.Name = "tableRow2"
        Me.tableRow2.Weight = 0.071428571428571425R
        '
        'tableRow3
        '
        Me.tableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell3})
        Me.tableRow3.Name = "tableRow3"
        Me.tableRow3.Weight = 0.071428571428571425R
        '
        'tableRow4
        '
        Me.tableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell4})
        Me.tableRow4.Name = "tableRow4"
        Me.tableRow4.Weight = 0.071428571428571425R
        '
        'tableRow5
        '
        Me.tableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell5})
        Me.tableRow5.Name = "tableRow5"
        Me.tableRow5.Weight = 0.071428571428571425R
        '
        'tableRow6
        '
        Me.tableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell6})
        Me.tableRow6.Name = "tableRow6"
        Me.tableRow6.Weight = 0.071428571428571425R
        '
        'tableRow7
        '
        Me.tableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell7})
        Me.tableRow7.Name = "tableRow7"
        Me.tableRow7.Weight = 0.071428571428571425R
        '
        'tableRow8
        '
        Me.tableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell8})
        Me.tableRow8.Name = "tableRow8"
        Me.tableRow8.Weight = 0.071428571428571425R
        '
        'tableRow9
        '
        Me.tableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell9})
        Me.tableRow9.Name = "tableRow9"
        Me.tableRow9.Weight = 0.071428571428571425R
        '
        'tableRow10
        '
        Me.tableRow10.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell10})
        Me.tableRow10.Name = "tableRow10"
        Me.tableRow10.Weight = 0.071428571428571425R
        '
        'tableRow11
        '
        Me.tableRow11.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell11})
        Me.tableRow11.Name = "tableRow11"
        Me.tableRow11.Weight = 0.071428571428571425R
        '
        'tableRow12
        '
        Me.tableRow12.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell12})
        Me.tableRow12.Name = "tableRow12"
        Me.tableRow12.Weight = 0.071428571428571425R
        '
        'tableRow13
        '
        Me.tableRow13.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell13})
        Me.tableRow13.Name = "tableRow13"
        Me.tableRow13.Weight = 0.071428571428571425R
        '
        'tableRow14
        '
        Me.tableRow14.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell14})
        Me.tableRow14.Name = "tableRow14"
        Me.tableRow14.Weight = 0.071428571428571425R
        '
        'tableCell1
        '
        Me.tableCell1.Multiline = True
        Me.tableCell1.Name = "tableCell1"
        Me.tableCell1.StyleName = "HeaderData1VerticalFirstRow"
        Me.tableCell1.Text = "رقم المريض" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tableCell1.Weight = 1.431346678609716R
        Me.tableCell1.WordWrap = False
        '
        'tableCell2
        '
        Me.tableCell2.Multiline = True
        Me.tableCell2.Name = "tableCell2"
        Me.tableCell2.StyleName = "HeaderData1VerticalRow_Even"
        Me.tableCell2.Text = "اسم المريض" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tableCell2.Weight = 3.2699627658113846R
        Me.tableCell2.WordWrap = False
        '
        'tableCell3
        '
        Me.tableCell3.Multiline = True
        Me.tableCell3.Name = "tableCell3"
        Me.tableCell3.StyleName = "HeaderData1Vertical"
        Me.tableCell3.Text = "عمر المريض" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tableCell3.Weight = 2.0716879215264665R
        Me.tableCell3.WordWrap = False
        '
        'tableCell4
        '
        Me.tableCell4.Multiline = True
        Me.tableCell4.Name = "tableCell4"
        Me.tableCell4.StyleName = "HeaderData1VerticalRow_Even"
        Me.tableCell4.Text = "الجنس" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tableCell4.Weight = 5.24833413983137R
        Me.tableCell4.WordWrap = False
        '
        'tableCell5
        '
        Me.tableCell5.Name = "tableCell5"
        Me.tableCell5.StyleName = "HeaderData1Vertical"
        Me.tableCell5.Text = "الهاتف"
        Me.tableCell5.Weight = 4.8315345664846889R
        Me.tableCell5.WordWrap = False
        '
        'tableCell6
        '
        Me.tableCell6.Name = "tableCell6"
        Me.tableCell6.StyleName = "HeaderData1VerticalRow_Even"
        Me.tableCell6.Text = "البريد الالكتروني"
        Me.tableCell6.Weight = 3.1690407907440394R
        Me.tableCell6.WordWrap = False
        '
        'tableCell7
        '
        Me.tableCell7.Name = "tableCell7"
        Me.tableCell7.StyleName = "HeaderData1Vertical"
        Me.tableCell7.Text = "المشكلة"
        Me.tableCell7.Weight = 1.1616069823635988R
        Me.tableCell7.WordWrap = False
        '
        'tableCell8
        '
        Me.tableCell8.Name = "tableCell8"
        Me.tableCell8.StyleName = "HeaderData1VerticalRow_Even"
        Me.tableCell8.Text = "وصف المشكلة"
        Me.tableCell8.Weight = 1.0R
        Me.tableCell8.WordWrap = False
        '
        'tableCell9
        '
        Me.tableCell9.Name = "tableCell9"
        Me.tableCell9.StyleName = "HeaderData1Vertical"
        Me.tableCell9.Text = "تايخ اول حظور"
        Me.tableCell9.Weight = 0.5360803036487366R
        Me.tableCell9.WordWrap = False
        '
        'tableCell10
        '
        Me.tableCell10.Name = "tableCell10"
        Me.tableCell10.StyleName = "HeaderData1VerticalRow_Even"
        Me.tableCell10.Text = "السكن"
        Me.tableCell10.Weight = 2.0716879215264665R
        Me.tableCell10.WordWrap = False
        '
        'tableCell11
        '
        Me.tableCell11.Name = "tableCell11"
        Me.tableCell11.StyleName = "HeaderData1Vertical"
        Me.tableCell11.Text = "اسم المستخدم"
        Me.tableCell11.Weight = 1.5755498641913637R
        Me.tableCell11.WordWrap = False
        '
        'tableCell12
        '
        Me.tableCell12.Name = "tableCell12"
        Me.tableCell12.StyleName = "HeaderData1VerticalRow_Even"
        Me.tableCell12.Text = "كلمة المرور"
        Me.tableCell12.Weight = 1.5375148515745274R
        Me.tableCell12.WordWrap = False
        '
        'tableCell13
        '
        Me.tableCell13.Name = "tableCell13"
        Me.tableCell13.StyleName = "HeaderData1Vertical"
        Me.tableCell13.Text = "السماح"
        Me.tableCell13.Weight = 0.62129322980017521R
        Me.tableCell13.WordWrap = False
        '
        'tableCell14
        '
        Me.tableCell14.Name = "tableCell14"
        Me.tableCell14.StyleName = "HeaderData1VerticalLastRow_Even"
        Me.tableCell14.Text = "نوع  الادخال"
        Me.tableCell14.Weight = 1.8240551096290185R
        Me.tableCell14.WordWrap = False
        '
        'table2
        '
        Me.table2.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.table2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.table2.Name = "table2"
        Me.table2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.tableRow15, Me.tableRow16, Me.tableRow17, Me.tableRow18, Me.tableRow19, Me.tableRow20, Me.tableRow21, Me.tableRow22, Me.tableRow23, Me.tableRow24, Me.tableRow25, Me.tableRow26, Me.tableRow27, Me.tableRow28})
        Me.table2.SizeF = New System.Drawing.SizeF(111.5183!, 392.0!)
        '
        'tableRow15
        '
        Me.tableRow15.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell15})
        Me.tableRow15.Name = "tableRow15"
        Me.tableRow15.Weight = 0.071428571428571425R
        '
        'tableRow16
        '
        Me.tableRow16.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell16})
        Me.tableRow16.Name = "tableRow16"
        Me.tableRow16.Weight = 0.071428571428571425R
        '
        'tableRow17
        '
        Me.tableRow17.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell17})
        Me.tableRow17.Name = "tableRow17"
        Me.tableRow17.Weight = 0.071428571428571425R
        '
        'tableRow18
        '
        Me.tableRow18.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell18})
        Me.tableRow18.Name = "tableRow18"
        Me.tableRow18.Weight = 0.071428571428571425R
        '
        'tableRow19
        '
        Me.tableRow19.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell19})
        Me.tableRow19.Name = "tableRow19"
        Me.tableRow19.Weight = 0.071428571428571425R
        '
        'tableRow20
        '
        Me.tableRow20.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell20})
        Me.tableRow20.Name = "tableRow20"
        Me.tableRow20.Weight = 0.071428571428571425R
        '
        'tableRow21
        '
        Me.tableRow21.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell21})
        Me.tableRow21.Name = "tableRow21"
        Me.tableRow21.Weight = 0.071428571428571425R
        '
        'tableRow22
        '
        Me.tableRow22.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell22})
        Me.tableRow22.Name = "tableRow22"
        Me.tableRow22.Weight = 0.071428571428571425R
        '
        'tableRow23
        '
        Me.tableRow23.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell23})
        Me.tableRow23.Name = "tableRow23"
        Me.tableRow23.Weight = 0.071428571428571425R
        '
        'tableRow24
        '
        Me.tableRow24.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell24})
        Me.tableRow24.Name = "tableRow24"
        Me.tableRow24.Weight = 0.071428571428571425R
        '
        'tableRow25
        '
        Me.tableRow25.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell25})
        Me.tableRow25.Name = "tableRow25"
        Me.tableRow25.Weight = 0.071428571428571425R
        '
        'tableRow26
        '
        Me.tableRow26.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell26})
        Me.tableRow26.Name = "tableRow26"
        Me.tableRow26.Weight = 0.071428571428571425R
        '
        'tableRow27
        '
        Me.tableRow27.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell27})
        Me.tableRow27.Name = "tableRow27"
        Me.tableRow27.Weight = 0.071428571428571425R
        '
        'tableRow28
        '
        Me.tableRow28.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.tableCell28})
        Me.tableRow28.Name = "tableRow28"
        Me.tableRow28.Weight = 0.071428571428571425R
        '
        'tableCell15
        '
        Me.tableCell15.CanGrow = False
        Me.tableCell15.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Patient_id]")})
        Me.tableCell15.Name = "tableCell15"
        Me.tableCell15.StyleName = "DetailData1VerticalFirstRow"
        Me.tableCell15.StylePriority.UseTextAlignment = False
        Me.tableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.tableCell15.Weight = 0.37862629215608989R
        Me.tableCell15.WordWrap = False
        '
        'tableCell16
        '
        Me.tableCell16.CanGrow = False
        Me.tableCell16.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Patient_name]")})
        Me.tableCell16.Name = "tableCell16"
        Me.tableCell16.StyleName = "DetailData1VerticalRow_Even"
        Me.tableCell16.Weight = 0.37862629215608989R
        Me.tableCell16.WordWrap = False
        '
        'tableCell17
        '
        Me.tableCell17.CanGrow = False
        Me.tableCell17.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Patient_age]")})
        Me.tableCell17.Name = "tableCell17"
        Me.tableCell17.StyleName = "DetailData1Vertical"
        Me.tableCell17.StylePriority.UseTextAlignment = False
        Me.tableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.tableCell17.Weight = 0.37862629215608989R
        Me.tableCell17.WordWrap = False
        '
        'tableCell18
        '
        Me.tableCell18.CanGrow = False
        Me.tableCell18.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Patient_gender]")})
        Me.tableCell18.Name = "tableCell18"
        Me.tableCell18.StyleName = "DetailData1VerticalRow_Even"
        Me.tableCell18.Weight = 0.37862629215608989R
        Me.tableCell18.WordWrap = False
        '
        'tableCell19
        '
        Me.tableCell19.CanGrow = False
        Me.tableCell19.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Patient_mobile]")})
        Me.tableCell19.Name = "tableCell19"
        Me.tableCell19.StyleName = "DetailData1Vertical"
        Me.tableCell19.Weight = 0.37862629215608989R
        Me.tableCell19.WordWrap = False
        '
        'tableCell20
        '
        Me.tableCell20.CanGrow = False
        Me.tableCell20.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Patient_email]")})
        Me.tableCell20.Name = "tableCell20"
        Me.tableCell20.StyleName = "DetailData1VerticalRow_Even"
        Me.tableCell20.Weight = 0.37862629215608989R
        Me.tableCell20.WordWrap = False
        '
        'tableCell21
        '
        Me.tableCell21.CanGrow = False
        Me.tableCell21.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Problem]")})
        Me.tableCell21.Name = "tableCell21"
        Me.tableCell21.StyleName = "DetailData1Vertical"
        Me.tableCell21.Weight = 0.37862629215608989R
        Me.tableCell21.WordWrap = False
        '
        'tableCell22
        '
        Me.tableCell22.CanGrow = False
        Me.tableCell22.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Problem_Describe]")})
        Me.tableCell22.Name = "tableCell22"
        Me.tableCell22.StyleName = "DetailData1VerticalRow_Even"
        Me.tableCell22.Weight = 0.37862629215608989R
        Me.tableCell22.WordWrap = False
        '
        'tableCell23
        '
        Me.tableCell23.CanGrow = False
        Me.tableCell23.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Date]")})
        Me.tableCell23.Name = "tableCell23"
        Me.tableCell23.StyleName = "DetailData1Vertical"
        Me.tableCell23.Weight = 0.37862629215608989R
        Me.tableCell23.WordWrap = False
        '
        'tableCell24
        '
        Me.tableCell24.CanGrow = False
        Me.tableCell24.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Patient_city]")})
        Me.tableCell24.Name = "tableCell24"
        Me.tableCell24.StyleName = "DetailData1VerticalRow_Even"
        Me.tableCell24.Weight = 0.37862629215608989R
        Me.tableCell24.WordWrap = False
        '
        'tableCell25
        '
        Me.tableCell25.CanGrow = False
        Me.tableCell25.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[username]")})
        Me.tableCell25.Name = "tableCell25"
        Me.tableCell25.StyleName = "DetailData1Vertical"
        Me.tableCell25.Weight = 0.37862629215608989R
        Me.tableCell25.WordWrap = False
        '
        'tableCell26
        '
        Me.tableCell26.CanGrow = False
        Me.tableCell26.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[password]")})
        Me.tableCell26.Name = "tableCell26"
        Me.tableCell26.StyleName = "DetailData1VerticalRow_Even"
        Me.tableCell26.Weight = 0.37862629215608989R
        Me.tableCell26.WordWrap = False
        '
        'tableCell27
        '
        Me.tableCell27.CanGrow = False
        Me.tableCell27.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[allow]")})
        Me.tableCell27.Name = "tableCell27"
        Me.tableCell27.StyleName = "DetailData1Vertical"
        Me.tableCell27.Weight = 0.37862629215608989R
        Me.tableCell27.WordWrap = False
        '
        'tableCell28
        '
        Me.tableCell28.CanGrow = False
        Me.tableCell28.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Type_enter]")})
        Me.tableCell28.Name = "tableCell28"
        Me.tableCell28.StyleName = "DetailData1VerticalLastRow_Even"
        Me.tableCell28.Weight = 0.37862629215608989R
        Me.tableCell28.WordWrap = False
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 25.8!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(79.16666!, 34.16667!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(650.0!, 65.83333!)
        Me.XrLabel2.StyleName = "Title"
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "نظــــــــــام ادارة عيــــــــــــــادة اســـــــــــــــــــــــنان"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Astute SSi", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(240.0048!, 11.16666!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(365.1445!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Dental Clinic Management System"
        '
        'Patient_Advanced
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.VerticalHeader, Me.VerticalDetail})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.DataMember = "Patient"
        Me.DataSource = Me.SqlDataSource1
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(14, 17, 100, 100)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.PageInfo, Me.DetailData1Vertical, Me.DetailData1VerticalFirstRow, Me.DetailData1VerticalRow_Even, Me.DetailData1VerticalLastRow_Even, Me.HeaderData1Vertical, Me.HeaderData1VerticalFirstRow, Me.HeaderData1VerticalRow_Even, Me.HeaderData1VerticalLastRow_Even})
        Me.Version = "20.1"
        Me.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        CType(Me.table1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.table2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailData1Vertical As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailData1VerticalFirstRow As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailData1VerticalRow_Even As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailData1VerticalLastRow_Even As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents HeaderData1Vertical As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents HeaderData1VerticalFirstRow As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents HeaderData1VerticalRow_Even As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents HeaderData1VerticalLastRow_Even As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents pageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents pageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents label1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents VerticalHeader As DevExpress.XtraReports.UI.VerticalHeaderBand
    Friend WithEvents table1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents tableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow10 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow11 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow12 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow13 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow14 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents VerticalDetail As DevExpress.XtraReports.UI.VerticalDetailBand
    Friend WithEvents table2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents tableRow15 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow16 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow17 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow18 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow19 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow20 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow21 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow22 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow23 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow24 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow25 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow26 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow27 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents tableRow28 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents tableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
End Class
