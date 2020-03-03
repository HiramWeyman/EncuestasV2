using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncuestasV2.Filters;
using EncuestasV2.Models;
using System.Data.Entity.Validation;
using System.Text;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using Font = iTextSharp.text.Font;

namespace EncuestasV2.Controllers
{
    [AccederAdmin]

    public class PdfController : Controller
    {
        // GET: Pdf
        public ActionResult Index()
        {
            return View();
        }

        //Generar Reportes en PDF
        public FileResult GenerarPdfEmpresas()
        {
            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

            Document doc = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE, 5, 5, 0, 0);
            Byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {

                PdfWriter.GetInstance(doc, ms);
                doc.Open();
                Paragraph title = new Paragraph("Listado de Empresas", font1);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph espacio = new Paragraph(" ");
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(8);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[8] { 10, 40, 20, 20, 30, 30, 40, 40 };
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("ID", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Descripción", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Estatus", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase("Empleados", font));
                celda4.BackgroundColor = new BaseColor(240, 240, 240);
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda4);

                PdfPCell celda5 = new PdfPCell(new Phrase("Dirección", font));
                celda5.BackgroundColor = new BaseColor(240, 240, 240);
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda5);

                PdfPCell celda6 = new PdfPCell(new Phrase("Telefono", font));
                celda6.BackgroundColor = new BaseColor(240, 240, 240);
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda6);

                PdfPCell celda7 = new PdfPCell(new Phrase("Contacto", font));
                celda7.BackgroundColor = new BaseColor(240, 240, 240);
                celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda7);

                PdfPCell celda8 = new PdfPCell(new Phrase("Correo", font));
                celda8.BackgroundColor = new BaseColor(240, 240, 240);
                celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda8);

                //Poniendo datos en la la tabla
                List<encuesta_empresaCLS> listaEmp = (List<encuesta_empresaCLS>)Session["ListaEmp"];
                int nroregistros = listaEmp.Count();
                for (int i = 0; i < nroregistros; i++)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_id.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_descrip.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_estatus.ToString(), font))).HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_no_trabajadores.ToString(), font))).HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_direccion.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_telefono.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_person_contac.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaEmp[i].emp_correo.ToString(), font)));


                }
                //Agregando la tabla al documento
                doc.Add(tabla);
                doc.Close();

                buffer = ms.ToArray();

            }
            return File(buffer, "application/pdf");

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Generar PDF Usuarios
        public FileResult GenerarPDFUsuarios()
        {
            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

            Document doc = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE, 5, 5, 0, 0);
            Byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {

                PdfWriter.GetInstance(doc, ms);
                doc.Open();
                Paragraph title = new Paragraph("Listado de Empleados", font1);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph espacio = new Paragraph(" ");
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(11);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[11] { 10, 40, 40, 23, 47, 25, 17, 22, 30, 27, 19 };
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("ID", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Nombre", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Empresa", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase("Estatus", font));
                celda4.BackgroundColor = new BaseColor(240, 240, 240);
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda4);

                PdfPCell celda5 = new PdfPCell(new Phrase("Usuario", font));
                celda5.BackgroundColor = new BaseColor(240, 240, 240);
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda5);

                PdfPCell celda6 = new PdfPCell(new Phrase("Género", font));
                celda6.BackgroundColor = new BaseColor(240, 240, 240);
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda6);

                PdfPCell celda7 = new PdfPCell(new Phrase("Edad", font));
                celda7.BackgroundColor = new BaseColor(240, 240, 240);
                celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda7);

                PdfPCell celda8 = new PdfPCell(new Phrase("Edo Civil", font));
                celda8.BackgroundColor = new BaseColor(240, 240, 240);
                celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda8);

                PdfPCell celda9 = new PdfPCell(new Phrase("Tipo Puesto", font));
                celda9.BackgroundColor = new BaseColor(240, 240, 240);
                celda9.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda9);

                PdfPCell celda10 = new PdfPCell(new Phrase("Tipo personal", font));
                celda10.BackgroundColor = new BaseColor(240, 240, 240);
                celda10.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda10);

                PdfPCell celda11 = new PdfPCell(new Phrase("Presento", font));
                celda11.BackgroundColor = new BaseColor(240, 240, 240);
                celda11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda11);

                //Poniendo datos en la la tabla
                List<encuesta_usuariosCLS> listaUser = (List<encuesta_usuariosCLS>)Session["ListaUser"];
                int nroregistros = listaUser.Count();
                for (int i = 0; i < nroregistros; i++)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].usua_id.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].usua_nombre.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].empleado_empresa.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].usua_estatus.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].usua_n_usuario.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].empleado_genero.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].empleado_edad.ToString(), font))).HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].empleado_edocivil.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].empleado_tipopuesto.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].empleado_tipopersonal.ToString(), font)));
                    tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].usua_presento, font))).HorizontalAlignment = PdfPCell.ALIGN_CENTER;


                }
                //Agregando la tabla al documento
                doc.Add(tabla);
                doc.Close();

                buffer = ms.ToArray();

            }
            return File(buffer, "application/pdf");

        }
    }
}