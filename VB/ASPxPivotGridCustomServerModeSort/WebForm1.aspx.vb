Imports System
Imports DevExpress.XtraPivotGrid
Imports System.Collections
Imports DevExpress.Data.Linq
Imports DevExpress.Web.ASPxPivotGrid

Namespace ASPxPivotGridCustomServerModeSort
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsPostBack) AndAlso (Not IsCallback) Then
                Dim field As PivotGridField = ASPxPivotGrid1.Fields("Year")
                ASPxPivotGrid1.BeginUpdate()
                Try
                    field.FilterValues.Clear()
                    field.FilterValues.Add(1996)
                    field.FilterValues.FilterType = DevExpress.XtraPivotGrid.PivotFilterType.Included
                Finally
                    ASPxPivotGrid1.EndUpdate()
                End Try
            End If

            ' Sets fields' sort mode to Custom to raise the CustomServerModeSort event.
            fieldOrderMonth.SortMode = PivotSortMode.Custom
            fieldCategoryName.SortMode = PivotSortMode.Custom
        End Sub

        Protected Sub EntityServerModeDataSource1_Selecting(ByVal sender As Object, ByVal e As LinqServerModeDataSourceSelectEventArgs)
            e.KeyExpression = "OrderID"
            e.QueryableSource = (New ASPxPivotGridCustomServerModeSort.NWindEntities()).SalesPersons
        End Sub

        Protected Sub ASPxPivotGrid1_CustomServerModeSort(ByVal sender As Object, ByVal e As CustomServerModeSortEventArgs)
            ' Sorting using a cross area object.
            If e.Field.ID = "fieldOrderMonth" Then
                ' Sets the cross area key, by which the "Month" field will be sorted. 
                ' In this example, it's one of the "Category" cross area field values.
                Dim sorting As CrossAreaKey = e.GetCrossAreaKey(New Object() { "Dairy Products" })

                ' Sets the result of the "Month" field's values comparison 
                ' by the cross area key object and the "Price" field.
                e.Result = Comparer.Default.Compare(e.GetCellValue1(sorting, fieldPrice), e.GetCellValue2(sorting, fieldPrice))

                ' Allows you to change the "Month" field's sort order without lose of sorting.
                If fieldOrderMonth.SortOrder = PivotSortOrder.Descending Then
                    e.Result *= -1
                End If
            End If

            ' Direct sorting without using a cross area object. 
            If e.Field.ID = "fieldCategoryName" Then
                ' Sets the result of "Category" field's values comparison by the Year and Price fields.
                e.Result = Comparer.Default.Compare(e.GetCellValue1(New Object() { "1996" }, fieldPrice), e.GetCellValue2(New Object() { "1996" }, fieldPrice))

                ' Allows you to change the "Category" field's sort order without lose of sorting.
                If fieldCategoryName.SortOrder = PivotSortOrder.Descending Then
                    e.Result *= -1
                End If
            End If
        End Sub
    End Class
End Namespace