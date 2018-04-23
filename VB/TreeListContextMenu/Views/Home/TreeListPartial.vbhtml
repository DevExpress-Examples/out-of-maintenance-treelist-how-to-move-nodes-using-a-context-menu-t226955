@ModelType System.Collections.IEnumerable
           
@Html.DevExpress().TreeList(Sub(settings)
    settings.Name = "TreeList"
    settings.KeyFieldName = "EmployeeID"
    settings.ParentFieldName = "ReportsTo"
    settings.CallbackRouteValues = new with { .Controller = "Home", .Action = "TreeListPartial" }
    settings.CustomActionRouteValues = new with { .Controller = "Home", .Action = "TreeListMovePartial" }
    

    settings.HtmlRowPrepared = Sub (sender, e) 
        If e.RowKind = TreeListRowKind.Data Then
			e.Row.Attributes.Add("rowKey", e.NodeKey)
 End If
    End Sub
    settings.ClientSideEvents.BeginCallback = "OnBeginCallback"
    settings.ClientSideEvents.CallbackError = "OnCallbackError"
    settings.ClientSideEvents.EndCallback = "OnEndCallback"
    settings.ClientSideEvents.ContextMenu = "OnContextMenu"
    settings.Columns.Add("FirstName")
    settings.Columns.Add("LastName")
   
    settings.Columns.Add("ReportsTo")

   
End Sub).SetEditErrorText(CStr(ViewData("EditError"))).Bind(Model).GetHtml()

