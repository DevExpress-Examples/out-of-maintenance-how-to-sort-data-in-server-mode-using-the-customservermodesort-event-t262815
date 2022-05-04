using System;
using DevExpress.XtraPivotGrid;
using System.Collections;
using DevExpress.Data.Linq;
using DevExpress.Web.ASPxPivotGrid;

namespace ASPxPivotGridCustomServerModeSort
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sets fields' sort mode to Custom to raise the CustomServerModeSort event.
            fieldOrderMonth.SortMode = PivotSortMode.Custom;
            fieldCategoryName.SortMode = PivotSortMode.Custom;           
        }

        protected void EntityServerModeDataSource1_Selecting(object sender, 
            LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = "OrderID";
            e.QueryableSource = new ASPxPivotGridCustomServerModeSort.NWindEntities().SalesPersons;
        }

        protected void ASPxPivotGrid1_CustomServerModeSort(object sender, CustomServerModeSortEventArgs e)
        {
            // Sorting using a cross area object.
            if (e.Field.ID == "fieldOrderMonth")
            {
                // Sets the cross area key, by which the "Month" field will be sorted. 
                // In this example, it's one of the "Category" cross area field values.
                CrossAreaKey sorting = e.GetCrossAreaKey(new object[] { "Dairy Products" });

                // Sets the result of the "Month" field's values comparison 
                // by the cross area key object and the "Price" field.
                e.Result = Comparer.Default.Compare(
                    e.GetCellValue1(sorting, fieldPrice), 
                    e.GetCellValue2(sorting, fieldPrice)
                );
                
                // Allows you to change the "Month" field's sort order without lose of sorting.
                if (fieldOrderMonth.SortOrder == PivotSortOrder.Descending) e.Result *= -1;
            }

            // Direct sorting without using a cross area object. 
            if (e.Field.ID == "fieldCategoryName")
            {
                // Sets the result of "Category" field's values comparison by the Year and Price fields.
                e.Result = Comparer.Default.Compare(
                    e.GetCellValue1(new object[] { "1996" }, fieldPrice),
                    e.GetCellValue2(new object[] { "1996" }, fieldPrice)
                );

                // Allows you to change the "Category" field's sort order without lose of sorting.
                if (fieldCategoryName.SortOrder == PivotSortOrder.Descending) e.Result *= -1;
            }
        }
    }
}