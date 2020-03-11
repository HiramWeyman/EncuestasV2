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

        public FileResult generarPDFResultados1(int id)
        {
            List<encuesta_mostrarPreguntas2CLS> list;
            List<encuesta_mostrarPreguntas2CLS> list2;
            List<encuesta_mostrarPreguntas2CLS> list3;
            List<encuesta_mostrarPreguntas2CLS> list4;

            int w = 0;
            int x = 0;
            int y = 0;
            int z = 0;
            using (var db = new csstdura_encuestaEntities())
            {
                list = (from resultados in db.encuesta_resultados
                        join det_encuesta in db.encuesta_det_encuesta
                        on resultados.resu_denc_id equals det_encuesta.denc_id
                        where resultados.resu_usua_id == id
                        && det_encuesta.denc_parte == 1
                        select new encuesta_mostrarPreguntas2CLS
                        {
                            resu_usua_id = id,
                            denc_descrip = det_encuesta.denc_descrip,
                            resu_resultado = resultados.resu_resultado,
                            denc_parte = det_encuesta.denc_parte,
                        }).ToList();

                list2 = (from resultados in db.encuesta_resultados
                         join det_encuesta in db.encuesta_det_encuesta
                         on resultados.resu_denc_id equals det_encuesta.denc_id
                         where resultados.resu_usua_id == id
                         && det_encuesta.denc_parte == 2
                         select new encuesta_mostrarPreguntas2CLS
                         {
                             resu_usua_id = id,
                             denc_descrip = det_encuesta.denc_descrip,
                             resu_resultado = resultados.resu_resultado,
                             denc_parte = det_encuesta.denc_parte,
                         }).ToList();

                list3 = (from resultados in db.encuesta_resultados
                         join det_encuesta in db.encuesta_det_encuesta
                         on resultados.resu_denc_id equals det_encuesta.denc_id
                         where resultados.resu_usua_id == id
                         && det_encuesta.denc_parte == 3
                         select new encuesta_mostrarPreguntas2CLS
                         {
                             resu_usua_id = id,
                             denc_descrip = det_encuesta.denc_descrip,
                             resu_resultado = resultados.resu_resultado,
                             denc_parte = det_encuesta.denc_parte,
                         }).ToList();

                list4 = (from resultados in db.encuesta_resultados
                         join det_encuesta in db.encuesta_det_encuesta
                         on resultados.resu_denc_id equals det_encuesta.denc_id
                         where resultados.resu_usua_id == id
                         && det_encuesta.denc_parte == 4
                         select new encuesta_mostrarPreguntas2CLS
                         {
                             resu_usua_id = id,
                             denc_descrip = det_encuesta.denc_descrip,
                             resu_resultado = resultados.resu_resultado,
                             denc_parte = det_encuesta.denc_parte,
                         }).ToList();


                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                int id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                String num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();

                iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
                iTextSharp.text.Font font = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

                Document doc = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE, 30, 30, 10, 10);
                byte[] buffer;
                using (MemoryStream ms = new MemoryStream())
                {

                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();
                    Paragraph espacio = new Paragraph(" ");
                    Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 40.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                    Paragraph firma = new Paragraph("FIRMA");
                    Paragraph title = new Paragraph("Consultoría y Soluciones en Seguridad en el Trabajo", font1);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
      
                    Paragraph title2 = new Paragraph("CUESTIONARIO I", font1);
                    title2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title2);
                    doc.Add(espacio);

                    Paragraph Nombre_emp = new Paragraph("NOMBRE DEL EMPLEADO: "+nombreEmpleado, font1);
                    Nombre_emp.Alignment = Element.ALIGN_LEFT;
                    doc.Add(Nombre_emp);
                    doc.Add(espacio);

                    Paragraph seccion1 = new Paragraph("I.- Acontecimiento traumático severo ", font1);
                    seccion1.Alignment = Element.ALIGN_LEFT;
                    doc.Add(seccion1);
                    doc.Add(espacio);

                    //Creando la tabla
                    PdfPTable tabla = new PdfPTable(2);
                    tabla.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas
                    float[] valores = new float[2] { 150,30 };
                    tabla.SetWidths(valores);

                    //Creando celdas agregando contenido
                    PdfPCell celda1 = new PdfPCell(new Phrase("Pregunta", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda1);

                    PdfPCell celda2 = new PdfPCell(new Phrase("Respuesta", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda2);

                 

                    //Poniendo datos en la la tabla
                 
                    int nroregistros = list.Count();
                    for (int i = 0; i < nroregistros; i++)
                    {
                        if (list[i].resu_resultado == "SI")
                        {
                            w = 1;
                        }
                        tabla.AddCell(new PdfPCell(new Phrase(list[i].denc_descrip.ToString(), font)));
                        tabla.AddCell(new PdfPCell(new Phrase(list[i].resu_resultado.ToString(), font)));
          
                       // tabla.AddCell(new PdfPCell(new Phrase(listaUser[i].usua_presento, font))).HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    }
                    //Agregando la tabla al documento
                    doc.Add(tabla);
                    if (w.Equals(1))
                    {
                        Chunk chunk = new Chunk("El trabajador requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);

                        
                    }
                    else
                    {

                        Chunk chunk = new Chunk("El Trabajador no requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);

                    }
                    doc.Add(espacio);

                    //Tabla2
                    Paragraph seccion2 = new Paragraph("II.- Recuerdos persistentes sobre el acontecimiento ", font1);
                    seccion2.Alignment = Element.ALIGN_LEFT;
                    doc.Add(seccion2);
                    doc.Add(espacio);

                    //Creando la tabla
                    PdfPTable tabla2 = new PdfPTable(2);
                    tabla2.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas            
                    tabla2.SetWidths(valores);

                    //Creando celdas agregando contenido
                    celda1 = new PdfPCell(new Phrase("Pregunta", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla2.AddCell(celda1);

                    celda2 = new PdfPCell(new Phrase("Respuesta", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla2.AddCell(celda2);



                    //Poniendo datos en la la tabla
         
                    int nroregistros2 = list2.Count();
                    for (int i = 0; i < nroregistros2; i++)
                    {
                        if (list2[i].resu_resultado == "SI")
                        {
                            x = 1;
                        }
                        tabla2.AddCell(new PdfPCell(new Phrase(list2[i].denc_descrip.ToString(), font)));
                        tabla2.AddCell(new PdfPCell(new Phrase(list2[i].resu_resultado.ToString(), font)));

                    }
                    //Agregando la tabla al documento
                    doc.Add(tabla2);
                    if (x.Equals(1))
                    {
                        Chunk chunk = new Chunk("El trabajador requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);


                    }
                    else
                    {

                        Chunk chunk = new Chunk("El Trabajador no requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);

                    }
                    doc.Add(espacio);

                    //Tabla3
                    Paragraph seccion3 = new Paragraph("III.- Esfuerzo por evitar circunstancias parecidas o asociadas al acontecimiento ", font1);
                    seccion3.Alignment = Element.ALIGN_LEFT;
                    doc.Add(seccion3);
                    doc.Add(espacio);

                    //Creando la tabla
                    PdfPTable tabla3 = new PdfPTable(2);
                    tabla3.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas            
                    tabla3.SetWidths(valores);

                    //Creando celdas agregando contenido
                    celda1 = new PdfPCell(new Phrase("Pregunta", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla3.AddCell(celda1);

                    celda2 = new PdfPCell(new Phrase("Respuesta", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla3.AddCell(celda2);



                    //Poniendo datos en la la tabla

                    int nroregistros3 = list3.Count();
                    for (int i = 0; i < nroregistros3; i++)
                    {
                        if (list3[i].resu_resultado == "SI")
                        {
                            y =y+ 1;
                        }
                        tabla3.AddCell(new PdfPCell(new Phrase(list3[i].denc_descrip.ToString(), font)));
                        tabla3.AddCell(new PdfPCell(new Phrase(list3[i].resu_resultado.ToString(), font)));

                    }
                    //Agregando la tabla al documento
                    doc.Add(tabla3);
                    if (y>=3)
                    {
                        Chunk chunk = new Chunk("El trabajador requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);


                    }
                    else
                    {

                        Chunk chunk = new Chunk("El Trabajador no requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);

                    }
                    doc.Add(espacio);

                    //Tabla4
                    Paragraph seccion4 = new Paragraph("IV.- Afectación ", font1);
                    seccion4.Alignment = Element.ALIGN_LEFT;
                    doc.Add(seccion4);
                    doc.Add(espacio);
                    //Creando la tabla
                    PdfPTable tabla4 = new PdfPTable(2);
                    tabla4.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas            
                    tabla4.SetWidths(valores);

                    //Creando celdas agregando contenido
                    celda1 = new PdfPCell(new Phrase("Pregunta", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla4.AddCell(celda1);

                    celda2 = new PdfPCell(new Phrase("Respuesta", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla4.AddCell(celda2);



                    //Poniendo datos en la la tabla

                    int nroregistros4 = list4.Count();
                    for (int i = 0; i < nroregistros4; i++)
                    {
                        if (list4[i].resu_resultado == "SI")
                        {
                            z = z + 1;
                        }
                        tabla4.AddCell(new PdfPCell(new Phrase(list4[i].denc_descrip.ToString(), font)));
                        tabla4.AddCell(new PdfPCell(new Phrase(list4[i].resu_resultado.ToString(), font)));

                    }
                    //Agregando la tabla al documento
                    doc.Add(tabla4);
                    if (y >= 2)
                    {
                        Chunk chunk = new Chunk("El trabajador requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);


                    }
                    else
                    {

                        Chunk chunk = new Chunk("El Trabajador no requiere valoración clínica ", font1);
                        chunk.SetBackground(BaseColor.YELLOW);
                        Paragraph p = new Paragraph(chunk);
                        p.Alignment = Element.ALIGN_LEFT;
                        doc.Add(p);

                    }
                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(espacio);

                    doc.Add(linea);
                    firma.Alignment = Element.ALIGN_CENTER;
                    doc.Add(firma);
                    doc.Close();

                    buffer = ms.ToArray();

                }
                return File(buffer, "application/pdf");


            }

        }

    }
}