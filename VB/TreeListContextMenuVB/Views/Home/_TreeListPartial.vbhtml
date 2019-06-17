@Html.DevExpress().TreeList(Sub(settings)
                                     settings.Name = "TreeList"
                                     settings.KeyFieldName = "EmployeeID"
                                     settings.ParentFieldName = "ReportsTo"
                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListPartial"}
                                     settings.CustomActionRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListMovePartial"}
                                     settings.HtmlRowPrepared = Sub(sender, e)
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
                                     settings.SettingsBehavior.AutoExpandAllNodes = True
                                 End Sub).SetEditErrorText(CType(ViewData("EditError"), String)).Bind(Model).GetHtml()