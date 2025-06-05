using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

[Transaction(TransactionMode.Manual)]
public class DimCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIDocument uidoc = commandData.Application.ActiveUIDocument;
        Document doc = uidoc.Document;

        try
        {
            // Lấy view hiện tại
            View view = doc.ActiveView;

            // Lọc tường
            var collector = new FilteredElementCollector(doc, view.Id)
                .OfCategory(BuiltInCategory.OST_Walls)
                .OfClass(typeof(Wall));

            IList<Wall> walls = collector.Cast<Wall>().ToList();

            using (Transaction t = new Transaction(doc, "Auto Dimension Walls"))
            {
                t.Start();

                foreach (Wall wall in walls)
                {
                    LocationCurve location = wall.Location as LocationCurve;
                    if (location == null) continue;

                    XYZ p1 = location.Curve.GetEndPoint(0);
                    XYZ p2 = location.Curve.GetEndPoint(1);

                    ReferenceArray refArray = new ReferenceArray();
                    refArray.Append(new Reference(wall));

                    Line dimLine = Line.CreateBound(p1 + new XYZ(0, 1, 0), p2 + new XYZ(0, 1, 0));

                    doc.Create.NewDimension(view, dimLine, refArray);
                }

                t.Commit();
            }

            TaskDialog.Show("Success", $"Đã đặt kích thước cho {walls.Count} tường.");
            return Result.Succeeded;
        }
        catch (System.Exception ex)
        {
            message = ex.Message;
            return Result.Failed;
        }
    }
}
