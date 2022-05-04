<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="WebForm1.aspx.vb" Inherits="ASPxPivotGridCustomServerModeSort.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v22.1, Version=22.1.1.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v22.1, Version=22.1.1.0, Culture=neutral, 
PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v22.1, Version=22.1.1.0, Culture=neutral, 
PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" 
            DataSourceID="EntityServerModeDataSource1" EnableTheming="True" Theme="Metropolis" 
            oncustomservermodesort="ASPxPivotGrid1_CustomServerModeSort" IsMaterialDesign="False">
            <Fields>
                <dx:PivotGridField ID="fieldOrderMonth" Area="ColumnArea" AreaIndex="1" 
                    Caption="Month" GroupInterval="DateMonth" 
                    UnboundFieldName="fieldOrderMonth">
                    <DataBindingSerializable>
                        <dx:DataSourceColumnBinding ColumnName="OrderDate" GroupInterval="DateMonth" />
                    </DataBindingSerializable>
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldPrice" Area="DataArea" AreaIndex="0" 
                    Caption="Price">
                    <DataBindingSerializable>
                        <dx:DataSourceColumnBinding ColumnName="Extended_Price" />
                    </DataBindingSerializable>
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldOrderYear" Area="ColumnArea" AreaIndex="0" 
                Caption="Year" GroupInterval="DateYear" UnboundFieldName="fieldOrderYear">
                    <DataBindingSerializable>
                        <dx:DataSourceColumnBinding ColumnName="OrderDate" GroupInterval="DateYear" />
                    </DataBindingSerializable>
                </dx:PivotGridField>
                <dx:PivotGridField ID="fieldCategoryName" Area="RowArea" AreaIndex="0" Caption="Category" Name="fieldCategoryName" >
                    <DataBindingSerializable>
                        <dx:DataSourceColumnBinding ColumnName="CategoryName" />
                    </DataBindingSerializable>
                </dx:PivotGridField>
            </Fields>
        </dx:ASPxPivotGrid>
        <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" 
            runat="server" 
            ContextTypeName="ASPxPivotGridCustomServerModeSort.nwindEntities" 
            OnSelecting="EntityServerModeDataSource1_Selecting" 
            TableName="SalesPersons" />
    </div>
    </form>
</body>
</html>