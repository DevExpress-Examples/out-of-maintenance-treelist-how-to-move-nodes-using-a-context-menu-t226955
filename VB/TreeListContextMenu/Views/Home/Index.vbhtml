@Code
  ViewBag.Title = "TreeList - How to move nodes using a context menu"
End Code
<style>
    .cutRow {
        background-color: lightblue;
    }
</style>
<script>
    function OnCallbackError(s, e) {
        // if (e.message == "You're trying to move a parent node to its child") - uncomment this line to reset styles only in certain cases
        myCallback = false;            
    }
    var myCallback = false;
    function OnBeginCallback(s, e) {
        if (e.command == "CustomCallback") {
            myCallback = true;
        }

    }
    var copyNodeKey = null;
    var currentNodeKey = null;
    function OnContextMenu(s, e) {
        if (e.objectType != 'Node') return;
        s.SetFocusedNodeKey(e.objectKey);
        var mouseX = ASPxClientUtils.GetEventX(e.htmlEvent);
        var mouseY = ASPxClientUtils.GetEventY(e.htmlEvent);
        ShowMenu(e.objectKey, mouseX, mouseY);
    }
    var currentNodeKey = -1;
    function ShowMenu(nodeKey, x, y) {
        clientPopupMenu.ShowAtPos(x, y);
        currentNodeKey = nodeKey;
        var menu = ASPxClientPopupMenu.Cast(clientPopupMenu);
        menu.GetItemByName("paste").SetEnabled(copyNodeKey != null);
           
    }
    function OnEndCallback(s, e) {
        if (myCallback) {
            ResetValues();
        }
    }
    function ResetValues() {                       
        currentNodeKey = null; copyNodeKey = null;
    }
    function ProcessNodeClick(itemName) {
        switch (itemName) {
            case "cut":
                {
                    if (copyNodeKey != currentNodeKey) {
                        $("tr[rowKey='" + copyNodeKey + "']").removeClass("cutRow");
                        $("tr[rowKey='" + currentNodeKey + "']").addClass("cutRow");
                        copyNodeKey = currentNodeKey;
                    }
                    break;
                }
            case "paste":
                {
                    if (copyNodeKey == null) {
                        alert("There is nothing to paste");
                        return;
                    }
                    TreeList.PerformCallback({ employeeID: copyNodeKey, reportsTo: currentNodeKey });
                       
                    break;
                }
        }
    }
</script>

<h2>@ViewBag.Title</h2>
@Html.Action("TreeListPartial")


@Html.DevExpress().PopupMenu(Sub(settings)

    settings.Name = "clientPopupMenu"
    settings.AllowSelectItem = False
    settings.Items.Add("Cut","cut")
    settings.Items.Add("Paste", "paste")
    settings.ClientSideEvents.ItemClick = "function(s, e) { ProcessNodeClick (e.item.name);}"
    
End Sub).GetHtml()
