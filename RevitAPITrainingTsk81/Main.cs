using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingTsk81
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        //Задание 8.1 Экспорт в IFC Экспортируйте модель из файлов упражнений в формат IFC с помощью приложения.
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;



            IFCExportOptions ifcExportOptions = new IFCExportOptions();


            //метод экспорта в IFC
            using (var ts = new Transaction(doc, "export IFC"))

            {
                ts.Start();
                doc.Export(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "export.ifc", ifcExportOptions);
                ts.Commit();
            }

            TaskDialog.Show("Мессадж", "Экспорт завершен. Ищите файл на рабочем столе");
            return Result.Succeeded;
        }
    }
}
