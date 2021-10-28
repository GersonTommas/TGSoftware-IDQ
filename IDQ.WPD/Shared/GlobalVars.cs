using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace IDQ.WPF.Shared
{
    public class GlobalVars : Domain.Base.PropertyChangedBase
    {
        public static string colorWindowBackgroundOK => "DarkGreen";
        public static string colorWindowBackkgroundNO => "Red";
        public static string strFecha => DateTime.Today.ToString(@"yyyy/MM/dd");

        public static bool globalDebug = true;

        public static usuarioModel usuarioLogueado;


        public static void updateUsuarioLogueado(usuarioModel sentUsuario)
        {
            usuarioLogueado = sentUsuario;
            ContentWindow.updateUsuarioLogueado();
        }

        public static void nextTarget(object sender, bool reverse = false)
        {
            if (sender is not null)
            {
                FocusNavigationDirection direction = FocusNavigationDirection.Next; if (reverse) { direction = FocusNavigationDirection.Previous; }

                Control ctrl = (Control)sender;
                _ = ctrl.Focus();

                _ = ctrl.MoveFocus(new TraversalRequest(direction));
            }
        }

        public static void contabilizarCaja(cajaModel sentCaja, bool sentDescontar = false)
        {
            if (sentDescontar)
            {
                context.globalCajaActual.Efectivo -= Math.Round(sentCaja.Efectivo, 2);
                context.globalCajaActual.MercadoPago -= Math.Round(sentCaja.MercadoPago, 2);
            }
            else
            {
                context.globalCajaActual.Efectivo += Math.Round(sentCaja.Efectivo - sentCaja.Vuelto, 2);
                context.globalCajaActual.MercadoPago += Math.Round(sentCaja.MercadoPago, 2);
            }
        }


        static fechaModel _fechaActual;

        public static fechaModel returnFecha()
        {
            string tempStringFecha = strFecha;

            if (_fechaActual is null || _fechaActual.Fecha != tempStringFecha)
            {
                try { _fechaActual = context.globalDb.fechas.Local.Single(x => x.Fecha == tempStringFecha); }
                catch
                {
                    System.Collections.Generic.IEnumerable<fechaModel> tempFechas = context.globalDb.fechas.Local.Where(x => x.Fecha == "1111/11/11");
                    if (tempFechas.Any())
                    {
                        _fechaActual = tempFechas.First(); _fechaActual.Fecha = tempStringFecha; _ = context.globalDb.SaveChanges();
                    }
                    else
                    {
                        _fechaActual = new fechaModel() { Fecha = tempStringFecha }; context.globalDb.fechas.Local.Add(_fechaActual); context.globalDb.SaveChanges();
                    }
                }
            }

            return _fechaActual;
        }

        public static void resetProductoAgregado()
        {
            foreach (productoModel prd in context.globalAllProductos.Where(x => x.Agregado))
            {
                prd.Agregado = false;
            }
        }



        #region Export
        public static void exportToExcel(IEnumerable<ventaModel> sentVentas)
        {

            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IDQ3";
            _ = Directory.CreateDirectory(dirPath);

            Excel.Application excel = new Excel.Application
            {
                Visible = false,
                DisplayAlerts = false
            };

            Excel.Workbook workbook = excel.Workbooks.Add();

            Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;

            try
            {
                //sheet.Cells[1, 1].Value = "";

                workbook.SaveAs(dirPath + "\\testExcel.xlsx");
            }
            catch { }
        }
        /*
        /// <summary>
        /// Exports a list of objects to Excel. Objects go in the Rows while Object Properties go in the Columns
        /// </summary>
        /// <param name="objects">List of objects to export.</param>
        /// <param name="filePath">Location to save file to. Does not need to exist</param>
        /// <param name="fileName">Name of excel file</param>
        public static void exportToExcel<T>(IEnumerable<T> objects, string filePath, string fileName)
        {
            // Add \ to end of file name if it doesn't exist. Just want to be consistant
            if (!filePath.EndsWith(@"\"))
            {
                filePath += @"\";
            }

            // Create directory if it doesn't exist
            if (!Directory.Exists(filePath))
            {
                _ = Directory.CreateDirectory(filePath);
            }

            // Start Excel and get Application object. 
            Excel.Application excel = new Excel.Application
            {

                // Set it hidden and hide alerts
                Visible = false,
                DisplayAlerts = false
            };

            // Create a new workbook. 
            Excel.Workbook workbook = excel.Workbooks.Add();

            // Get the active sheet 
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;

            try
            {
                // Convert the list into a rectangular array that Excel can read
                object[,] data = GetObjectArray<T>(objects);

                // If at least one record got converted successfully
                if (data.Length > 1)
                {
                    // Get the range of cells that the data will go into. Size matches rectangular array size
                    string xlsRange = string.Format("A1:{0}{1}", new object[] { GetExcelColumn(data.GetLength(1)), data.GetLength(0) });

                    // Insert data into the specified range of cells
                    Excel.Range range = sheet.get_Range(xlsRange);
                    range.Value = data;

                    // Auto-Fit the columns
                    range.EntireColumn.AutoFit();
                }

                // Save workbook
                workbook.SaveAs(string.Format("{0}{1}", new object[] { filePath, fileName }), Excel.XlFileFormat.xlWorkbookNormal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Close
                sheet = null;
                workbook.Close();
                workbook = null;
                excel.Quit();
            }

            // Clean up 
            // NOTE: When in release mode, this does the trick 
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        /// Takes a List of objects objects and converts the objects and their properties into a rectangular array of objects
        /// </summary>
        /// <param name="objects">List of objects to flatten</param>
        /// <returns>Rectangular array where objects are stored in [0] and properties are stored in [1]</returns>
        static object[,] GetObjectArray<T>(IEnumerable<T> objects)
        {
            // Get list of object properties
            PropertyInfo[] properties = typeof(T).GetProperties();

            // Create rectangular array based on # of objects and # of object properties
            object[,] data = new object[objects.Count() + 1, properties.Length];

            // Loop through properties on object
            for (int j = 0; j < properties.Length; j++)
            {
                // Write the property name into the first row of the array
                data[0, j] = properties[j].Name.Replace("_", " ");

                // Loop through objects and write out the specified property of each one into the array
                for (int i = 0; i < objects.Count(); i++)
                {
                    data[i + 1, j] = properties[j].GetValue(objects.ElementAt(i), null);
                }
            }

            // Return rectangular array
            return data;
        }

        /// <summary>
        /// Takes an Integer and converts it into Excel's column header code.
        /// For example: 1 = A; 2 = B; 27 = AA;
        /// </summary>
        /// <param name="colNumber">Number of Column in Excel. 1 = A</param>
        /// <returns>string that Excel can use</returns>
        static string GetExcelColumn(int colNumber)
        {
            // If value is zero or less, return an empty string
            if (colNumber <= 0)
            {
                return string.Empty;
            }

            // If the value is less than or equal to 26 (Z), the column header
            // is only one character long. If it's greater, call this recursively
            // to get the first letter(s) of the column code.
            string first = colNumber <= 26 ? string.Empty : GetExcelColumn((int)Math.Floor((colNumber - 1) / 26.00));

            // Get the final letter in the column code
            int second = colNumber % 26;
            if (second == 0)
            {
                second = 26;
            }

            char finalLetter = (char)('A' + second - 1);            // Excel column header is the first part + the final character
            return string.Format("{0}{1}", new object[] { first, finalLetter });
        }

        static void releaseObject(object obj)
        {
            try
            {
                _ = System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        */
        #endregion // Export
    }
}