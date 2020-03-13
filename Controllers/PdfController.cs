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
                        PdfPCell celda3 = new PdfPCell(new Phrase(list[i].denc_descrip.ToString(), font));             
                        celda3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                        PdfPCell celda4 = new PdfPCell(new Phrase(list[i].resu_resultado.ToString(), font));
                        celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                        tabla.AddCell(celda3);
                        tabla.AddCell(celda4);
          
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
                        PdfPCell celda3 = new PdfPCell(new Phrase(list2[i].denc_descrip.ToString(), font));
                        celda3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                        PdfPCell celda4 = new PdfPCell(new Phrase(list2[i].resu_resultado.ToString(), font));
                        celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                        tabla2.AddCell(celda3);
                        tabla2.AddCell(celda4);

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
                        PdfPCell celda3 = new PdfPCell(new Phrase(list3[i].denc_descrip.ToString(), font));
                        celda3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                        PdfPCell celda4 = new PdfPCell(new Phrase(list3[i].resu_resultado.ToString(), font));
                        celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                        tabla3.AddCell(celda3);
                        tabla3.AddCell(celda4);

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

                        Chunk chunk = new Chunk("El trabajador no requiere valoración clínica ", font1);
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
                        PdfPCell celda3 = new PdfPCell(new Phrase(list4[i].denc_descrip.ToString(), font));
                        celda3.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                        PdfPCell celda4 = new PdfPCell(new Phrase(list4[i].resu_resultado.ToString(), font));
                        celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                        tabla4.AddCell(celda3);
                        tabla4.AddCell(celda4);

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

                        Chunk chunk = new Chunk("El trabajador no requiere valoración clínica ", font1);
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

        public FileResult generarPDFGuiaII(int id)
        {

            string CondicionesAmbienteTrabajoRes = "";
            string CargaTrabajoRes = "";
            string FaltaControlSobreTrabajoRes = "";
            string JornadaTrabajoRes = "";
            string InfluenciaTrabajoFueraCentroLaboralRes = "";
            string LiderazgoRes = "";
            string RelacionesTrabajoRes = "";
            string ViolenciaRes = "";
            string nombreEmpleado;
            int CondicionesAmbienteTrabajo;
            int CargaTrabajo;
            int FaltaControlSobreTrabajo;
            int JornadaTrabajo;
            int InfluenciaTrabajoFueraCentroLaboral;
            int Liderazgo;
            int RelacionesTrabajo;
            int Violencia;

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();

                //resultados en el ambiente de trabajo
                if (CondicionesAmbienteTrabajo < 3) { CondicionesAmbienteTrabajoRes = "Nulo o Despreciable"; }
                else if (CondicionesAmbienteTrabajo >= 3 && CondicionesAmbienteTrabajo <= 5) { CondicionesAmbienteTrabajoRes = "Bajo"; }
                else if (CondicionesAmbienteTrabajo >= 5 && CondicionesAmbienteTrabajo < 7) { CondicionesAmbienteTrabajoRes = "Medio"; }
                else if (CondicionesAmbienteTrabajo >= 7 && CondicionesAmbienteTrabajo < 9) { CondicionesAmbienteTrabajoRes = "Alto"; }
                else if (CondicionesAmbienteTrabajo >= 9) { CondicionesAmbienteTrabajoRes = "Muy Alto"; }


                //condiciones en el ambiente de trabajo
                CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 2 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();

                //resultados en carga de trabajo
                if (CargaTrabajo < 12) { CargaTrabajoRes = "Nulo o Despreciable"; }
                else if (CargaTrabajo >= 12 && CargaTrabajo < 16) { CargaTrabajoRes = "Bajo"; }
                else if (CargaTrabajo >= 16 && CargaTrabajo < 20) { CargaTrabajoRes = "Medio"; }
                else if (CargaTrabajo >= 20 && CargaTrabajo < 24) { CargaTrabajoRes = "Alto"; }
                else if (CargaTrabajo >= 24) { CargaTrabajoRes = "Muy Alto"; }


                //falta de control sobre el trabajo
                FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();

                //resultados en falta de control sobre el trabajo
                if (FaltaControlSobreTrabajo < 5) { FaltaControlSobreTrabajoRes = "Nulo o Despreciable"; }
                else if (FaltaControlSobreTrabajo >= 5 && FaltaControlSobreTrabajo < 8) { FaltaControlSobreTrabajoRes = "Bajo"; }
                else if (FaltaControlSobreTrabajo >= 8 && FaltaControlSobreTrabajo < 11) { FaltaControlSobreTrabajoRes = "Medio"; }
                else if (FaltaControlSobreTrabajo >= 11 && FaltaControlSobreTrabajo < 14) { FaltaControlSobreTrabajoRes = "Alto"; }
                else if (FaltaControlSobreTrabajo >= 14) { FaltaControlSobreTrabajoRes = "Muy Alto"; }

                //jornada de trabajo
                JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (34,35) ").FirstOrDefault();

                //resultados en jornada de trabajo
                if (JornadaTrabajo < 1) { JornadaTrabajoRes = "Nulo o Despreciable"; }
                else if (JornadaTrabajo >= 1 && JornadaTrabajo < 2) { JornadaTrabajoRes = "Bajo"; }
                else if (JornadaTrabajo >= 2 && JornadaTrabajo < 4) { JornadaTrabajoRes = "Medio"; }
                else if (JornadaTrabajo >= 4 && JornadaTrabajo < 6) { JornadaTrabajoRes = "Alto"; }
                else if (JornadaTrabajo >= 6) { JornadaTrabajoRes = "Muy Alto"; }

                //Interferencia en la relación trabajo-familia
                InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (36,37) ").FirstOrDefault();

                //resultados en InfluenciaTrabajoFueraCentroLaboral
                if (InfluenciaTrabajoFueraCentroLaboral < 1) { InfluenciaTrabajoFueraCentroLaboralRes = "Nulo o Despreciable"; }
                else if (InfluenciaTrabajoFueraCentroLaboral >= 1 && InfluenciaTrabajoFueraCentroLaboral < 2) { InfluenciaTrabajoFueraCentroLaboralRes = "Bajo"; }
                else if (InfluenciaTrabajoFueraCentroLaboral >= 2 && InfluenciaTrabajoFueraCentroLaboral < 4) { InfluenciaTrabajoFueraCentroLaboralRes = "Medio"; }
                else if (InfluenciaTrabajoFueraCentroLaboral >= 4 && InfluenciaTrabajoFueraCentroLaboral < 6) { InfluenciaTrabajoFueraCentroLaboralRes = "Alto"; }
                else if (InfluenciaTrabajoFueraCentroLaboral >= 6) { InfluenciaTrabajoFueraCentroLaboralRes = "Muy Alto"; }

                //Liderazgo
                Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (43,44,45,47,48) ").FirstOrDefault();

                //resultados en Liderazgo
                if (Liderazgo < 3) { LiderazgoRes = "Nulo o Despreciable"; }
                else if (Liderazgo >= 3 && Liderazgo < 5) { LiderazgoRes = "Bajo"; }
                else if (Liderazgo >= 5 && Liderazgo < 8) { LiderazgoRes = "Medio"; }
                else if (Liderazgo >= 8 && Liderazgo < 11) { LiderazgoRes = "Alto"; }
                else if (Liderazgo >= 11) { LiderazgoRes = "Muy Alto"; }

                //Relaciones en el trabajo
                RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                          " from encuesta_det_encuesta, encuesta_resultados " +
                                                          " where denc_encu_id = 2 " +
                                                          " and resu_denc_id = denc_id " +
                                                          " and resu_usua_id = " + id + " " +
                                                          " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();

                //resultados en Relaciones en el trabajo
                if (RelacionesTrabajo < 5) { RelacionesTrabajoRes = "Nulo o Despreciable"; }
                else if (RelacionesTrabajo >= 5 && RelacionesTrabajo < 8) { RelacionesTrabajoRes = "Bajo"; }
                else if (RelacionesTrabajo >= 8 && RelacionesTrabajo < 11) { RelacionesTrabajoRes = "Medio"; }
                else if (RelacionesTrabajo >= 11 && RelacionesTrabajo < 14) { RelacionesTrabajoRes = "Alto"; }
                else if (RelacionesTrabajo >= 14) { RelacionesTrabajoRes = "Muy Alto"; }


                //Violencia
                Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 2 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();

                //resultados en Violencia
                if (Violencia < 7) { ViolenciaRes = "Nulo o Despreciable"; }
                else if (Violencia >= 7 && Violencia < 10) { ViolenciaRes = "Bajo"; }
                else if (Violencia >= 10 && Violencia < 13) { ViolenciaRes = "Medio"; }
                else if (Violencia >= 13 && Violencia < 16) { ViolenciaRes = "Alto"; }
                else if (Violencia >= 16) { ViolenciaRes = "Muy Alto"; }



                nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
            }


            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                Paragraph title2 = new Paragraph("CUESTIONARIO II", font1);
                title2.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);
                doc.Add(title2);
                doc.Add(espacio);

                Paragraph Nombre_emp = new Paragraph("NOMBRE DEL EMPLEADO: " + nombreEmpleado, font1);
                Nombre_emp.Alignment = Element.ALIGN_LEFT;
                doc.Add(Nombre_emp);
                doc.Add(espacio);

                Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL EN LOS CENTROS DE TRABAJO. ", font2);
                seccion1.Alignment = Element.ALIGN_LEFT;
                doc.Add(seccion1);
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[3] { 150, 30 ,30};
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Dominio", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase(CondicionesAmbienteTrabajo.ToString(), font));
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda5 = new PdfPCell(new Phrase(CargaTrabajo.ToString(), font));
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda6 = new PdfPCell(new Phrase(FaltaControlSobreTrabajo.ToString(), font));
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda7 = new PdfPCell(new Phrase(JornadaTrabajo.ToString(), font));
                celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda8 = new PdfPCell(new Phrase(InfluenciaTrabajoFueraCentroLaboral.ToString(), font));
                celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda9 = new PdfPCell(new Phrase(Liderazgo.ToString(), font));
                celda9.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda10 = new PdfPCell(new Phrase(RelacionesTrabajo.ToString(), font));
                celda10.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda11 = new PdfPCell(new Phrase(Violencia.ToString(), font));
                celda11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                //Poniendo datos en la la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                tabla.AddCell(celda4);
                tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Carga de trabajo", font)));
                tabla.AddCell(celda5);
                tabla.AddCell(new PdfPCell(new Phrase(CargaTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Falta de control sobre el trabajo", font)));
                tabla.AddCell(celda6);
                tabla.AddCell(new PdfPCell(new Phrase(FaltaControlSobreTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Jornada de trabajo", font)));
                tabla.AddCell(celda7);
                tabla.AddCell(new PdfPCell(new Phrase(JornadaTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Interferencia en la relación trabajo-familia", font)));
                tabla.AddCell(celda8);
                tabla.AddCell(new PdfPCell(new Phrase(InfluenciaTrabajoFueraCentroLaboralRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Liderazgo", font)));
                tabla.AddCell(celda9);
                tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Relaciones en el Trabajo", font)));
                tabla.AddCell(celda10);
                tabla.AddCell(new PdfPCell(new Phrase(RelacionesTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Violencia", font)));
                tabla.AddCell(celda11);
                tabla.AddCell(new PdfPCell(new Phrase(ViolenciaRes.ToString(), font)));

                //Agregando la tabla al documento
                doc.Add(tabla);
                
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

        public FileResult generaPDFGuiaIICat(int id)
        {

            string AmbienteTrabajoRes = "";
            string FactoresPropiosActividadRes = "";
            string OrganizacionTiempoTrabajoRes = "";
            string LiderazgoRelacionesTrabajoRes = "";
            string nombreEmpleado;

            int CondicionesAmbienteTrabajo;
            int CargaTrabajo;
            int FaltaControlSobreTrabajo;
            int JornadaTrabajo;
            int InfluenciaTrabajoFueraCentroLaboral;
            int Liderazgo;
            int RelacionesTrabajo;
            int Violencia;

            int AmbienteTrabajo;
            int FactoresPropiosActividad;
            int OrganizacionTiempoTrabajo;
            int LiderazgoRelacionesTrabajo;

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();




                //condiciones en el ambiente de trabajo
                CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                             " from encuesta_det_encuesta, encuesta_resultados " +
                                                             " where denc_encu_id = 2 " +
                                                             " and resu_denc_id = denc_id " +
                                                             " and resu_usua_id = " + id + " " +
                                                             " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();


                //falta de control sobre el trabajo
                FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();


                //jornada de trabajo
                JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (34,35) ").FirstOrDefault();



                //Interferencia en la relación trabajo-familia
                InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (36,37) ").FirstOrDefault();


                //Liderazgo
                Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (43,44,45,47,48) ").FirstOrDefault();



                //Relaciones en el trabajo
                RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();



                //Violencia
                Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();


                nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                AmbienteTrabajo = CondicionesAmbienteTrabajo;
                FactoresPropiosActividad = CargaTrabajo + FaltaControlSobreTrabajo;
                OrganizacionTiempoTrabajo = JornadaTrabajo + InfluenciaTrabajoFueraCentroLaboral;
                LiderazgoRelacionesTrabajo = Liderazgo + RelacionesTrabajo + Violencia;


                //resultados en AmbienteTrabajo
                if (AmbienteTrabajo < 3) { AmbienteTrabajoRes = "Nulo o Despreciable"; }
                else if (AmbienteTrabajo >= 3 && AmbienteTrabajo < 5) { AmbienteTrabajoRes = "Bajo"; }
                else if (AmbienteTrabajo >= 5 && AmbienteTrabajo < 7) { AmbienteTrabajoRes = "Medio"; }
                else if (AmbienteTrabajo >= 7 && AmbienteTrabajo < 9) { AmbienteTrabajoRes = "Alto"; }
                else if (AmbienteTrabajo >= 9) { AmbienteTrabajoRes = "Muy Alto"; }

                //resultados en FactoresPropiosActividad
                if (FactoresPropiosActividad < 10) { FactoresPropiosActividadRes = "Nulo o Despreciable"; }
                else if (FactoresPropiosActividad >= 10 && FactoresPropiosActividad < 20) { FactoresPropiosActividadRes = "Bajo"; }
                else if (FactoresPropiosActividad >= 20 && FactoresPropiosActividad < 30) { FactoresPropiosActividadRes = "Medio"; }
                else if (FactoresPropiosActividad >= 30 && FactoresPropiosActividad < 40) { FactoresPropiosActividadRes = "Alto"; }
                else if (FactoresPropiosActividad >= 40) { FactoresPropiosActividadRes = "Muy Alto"; }

                //resultados en OrganizacionTiempoTrabajo
                if (OrganizacionTiempoTrabajo < 4) { OrganizacionTiempoTrabajoRes = "Nulo o Despreciable"; }
                else if (OrganizacionTiempoTrabajo >= 4 && OrganizacionTiempoTrabajo < 6) { OrganizacionTiempoTrabajoRes = "Bajo"; }
                else if (OrganizacionTiempoTrabajo >= 6 && OrganizacionTiempoTrabajo < 9) { OrganizacionTiempoTrabajoRes = "Medio"; }
                else if (OrganizacionTiempoTrabajo >= 9 && OrganizacionTiempoTrabajo < 12) { OrganizacionTiempoTrabajoRes = "Alto"; }
                else if (OrganizacionTiempoTrabajo >= 12) { OrganizacionTiempoTrabajoRes = "Muy Alto"; }

                //resultados en LiderazgoRelacionesTrabajo
                if (LiderazgoRelacionesTrabajo < 10) { LiderazgoRelacionesTrabajoRes = "Nulo o Despreciable"; }
                else if (LiderazgoRelacionesTrabajo >= 10 && LiderazgoRelacionesTrabajo < 18) { LiderazgoRelacionesTrabajoRes = "Bajo"; }
                else if (LiderazgoRelacionesTrabajo >= 18 && LiderazgoRelacionesTrabajo < 28) { LiderazgoRelacionesTrabajoRes = "Medio"; }
                else if (LiderazgoRelacionesTrabajo >= 28 && LiderazgoRelacionesTrabajo < 38) { LiderazgoRelacionesTrabajoRes = "Alto"; }
                else if (LiderazgoRelacionesTrabajo >= 38) { LiderazgoRelacionesTrabajoRes = "Muy Alto"; }
            }



            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                Paragraph title2 = new Paragraph("CUESTIONARIO II", font1);
                title2.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);
                doc.Add(title2);
                doc.Add(espacio);

                Paragraph Nombre_emp = new Paragraph("NOMBRE DEL EMPLEADO: " + nombreEmpleado, font1);
                Nombre_emp.Alignment = Element.ALIGN_LEFT;
                doc.Add(Nombre_emp);
                doc.Add(espacio);

                Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL EN LOS CENTROS DE TRABAJO. ", font2);
                seccion1.Alignment = Element.ALIGN_LEFT;
                doc.Add(seccion1);
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[3] { 150, 30, 30 };
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Categoría", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase(AmbienteTrabajo.ToString(), font));
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda5 = new PdfPCell(new Phrase(FactoresPropiosActividad.ToString(), font));
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda6 = new PdfPCell(new Phrase(OrganizacionTiempoTrabajo.ToString(), font));
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda7 = new PdfPCell(new Phrase(LiderazgoRelacionesTrabajo.ToString(), font));
                celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                //Poniendo datos en la la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                tabla.AddCell(celda4);
                tabla.AddCell(new PdfPCell(new Phrase(AmbienteTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Factores propios de la actividad", font)));
                tabla.AddCell(celda5);
                tabla.AddCell(new PdfPCell(new Phrase(FactoresPropiosActividadRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Organización del tiempo de trabajo", font)));
                tabla.AddCell(celda6);
                tabla.AddCell(new PdfPCell(new Phrase(OrganizacionTiempoTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Liderazgo y relaciones en el trabajo", font)));
                tabla.AddCell(celda7);
                tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRelacionesTrabajoRes.ToString(), font)));

            

                //Agregando la tabla al documento
                doc.Add(tabla);

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

        public FileResult generaPDFGuiaIIFinal(int id)
        {

            int CondicionesAmbienteTrabajo;
            int CargaTrabajo;
            int FaltaControlSobreTrabajo;
            int JornadaTrabajo;
            int InfluenciaTrabajoFueraCentroLaboral;
            int Liderazgo;
            int RelacionesTrabajo;
            int Violencia;
            int CalificacionFinalCuestionario;
            string nombreEmpleado;
            string CalificacionFinalCuestionarioRes = "";
            string riesgo = "";

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();




                //condiciones en el ambiente de trabajo
                CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                             " from encuesta_det_encuesta, encuesta_resultados " +
                                                             " where denc_encu_id = 2 " +
                                                             " and resu_denc_id = denc_id " +
                                                             " and resu_usua_id = " + id + " " +
                                                             " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();


                //falta de control sobre el trabajo
                FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();


                //jornada de trabajo
                JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (34,35) ").FirstOrDefault();



                //Interferencia en la relación trabajo-familia
                InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (36,37) ").FirstOrDefault();


                //Liderazgo
                Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (43,44,45,47,48) ").FirstOrDefault();



                //Relaciones en el trabajo
                RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();



                //Violencia
                Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();


                nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                CalificacionFinalCuestionario = CondicionesAmbienteTrabajo + CargaTrabajo + FaltaControlSobreTrabajo +
                                                          JornadaTrabajo + InfluenciaTrabajoFueraCentroLaboral + Liderazgo +
                                                          RelacionesTrabajo + Violencia;
                if (CalificacionFinalCuestionario < 20) { CalificacionFinalCuestionarioRes = "Nulo o Despreciable"; riesgo = "El riesgo resulta despreciable por lo que no se requiere medidas adicionales."; }
                else if (CalificacionFinalCuestionario >= 20 && CalificacionFinalCuestionario < 45) { CalificacionFinalCuestionarioRes = "Bajo"; riesgo = "Es necesario una mayor difusión de la política de prevención de riesgos psicosociales y programas para: la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral."; }
                else if (CalificacionFinalCuestionario >= 45 && CalificacionFinalCuestionario < 70) { CalificacionFinalCuestionarioRes = "Medio"; riesgo = "Medio	Se requiere revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión, mediante un Programa de intervención."; }
                else if (CalificacionFinalCuestionario >= 70 && CalificacionFinalCuestionario < 90) { CalificacionFinalCuestionarioRes = "Alto"; riesgo = "Se requiere realizar un análisis de cada categoría y dominio, de manera que se puedan determinar las acciones de intervención apropiadas a través de un Programa de intervención, que podrá incluir una evaluación específica1 y deberá incluir una campaña de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión."; }
                else if (CalificacionFinalCuestionario >= 90) { CalificacionFinalCuestionarioRes = "Muy Alto"; riesgo = "Se requiere realizar el análisis de cada categoría y dominio para establecer las acciones de intervención apropiadas, mediante un Programa de intervención que deberá incluir evaluaciones específicas1, y contemplar campañas de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión."; }

            }



            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                Paragraph title2 = new Paragraph("CUESTIONARIO II", font1);
                title2.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);
                doc.Add(title2);
                doc.Add(espacio);

                Paragraph Nombre_emp = new Paragraph("NOMBRE DEL EMPLEADO: " + nombreEmpleado, font1);
                Nombre_emp.Alignment = Element.ALIGN_LEFT;
                doc.Add(Nombre_emp);
                doc.Add(espacio);

                Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL EN LOS CENTROS DE TRABAJO. ", font2);
                seccion1.Alignment = Element.ALIGN_LEFT;
                doc.Add(seccion1);
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[4] { 30, 30, 30 ,150};
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Resultado Final", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase("Necesidad de acción", font));
                celda4.BackgroundColor = new BaseColor(240, 240, 240);
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda4);

                PdfPCell celda5 = new PdfPCell(new Phrase(CalificacionFinalCuestionario.ToString(), font));
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda6 = new PdfPCell(new Phrase(CalificacionFinalCuestionarioRes.ToString(), font));
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda7 = new PdfPCell(new Phrase(riesgo.ToString(), font));
                celda7.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;


                //Poniendo datos en la la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Calificación final del cuestionario", font)));
                tabla.AddCell(celda5);
                tabla.AddCell(celda6);
                tabla.AddCell(celda7);

                //Agregando la tabla al documento
                doc.Add(tabla);

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

        public FileResult generarPDFGuiaIII(int id)
        {

            string CondicionesAmbienteTrabajoRes = "";
            string CargaTrabajoRes = "";
            string FaltaControlSobreTrabajoRes = "";
            string JornadaTrabajoRes = "";
            string InterferenciaRelacionTrabajoFamiliaRes = "";
            string LiderazgoRes = "";
            string RelacionesTrabajoRes = "";
            string ViolenciaRes = "";
            string ReconocimientoDesempeñoRes = "";
            string InsuficienteSentidoRes = "";
            string nombreEmpleado;
            int CondicionesAmbienteTrabajo;
            int CargaTrabajo;
            int FaltaControlSobreTrabajo;
            int JornadaTrabajo;
            int InterferenciaRelacionTrabajoFamilia;
            int Liderazgo;
            int RelacionesTrabajo;
            int Violencia;
            int ReconocimientoDesempeño;
            int InsuficienteSentido;

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (69,70,71,72,73) ").FirstOrDefault();

                //resultados en el ambiente de trabajo
                if (CondicionesAmbienteTrabajo < 5) { CondicionesAmbienteTrabajoRes = "Nulo o Despreciable"; }
                else if (CondicionesAmbienteTrabajo >= 5 && CondicionesAmbienteTrabajo < 9) { CondicionesAmbienteTrabajoRes = "Bajo"; }
                else if (CondicionesAmbienteTrabajo >= 9 && CondicionesAmbienteTrabajo < 11) { CondicionesAmbienteTrabajoRes = "Medio"; }
                else if (CondicionesAmbienteTrabajo >= 11 && CondicionesAmbienteTrabajo < 14) { CondicionesAmbienteTrabajoRes = "Alto"; }
                else if (CondicionesAmbienteTrabajo >= 14) { CondicionesAmbienteTrabajoRes = "Muy Alto"; }


                //condiciones en el ambiente de trabajo
                CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();

                //resultados en carga de trabajo
                if (CargaTrabajo < 15) { CargaTrabajoRes = "Nulo o Despreciable"; }
                else if (CargaTrabajo >= 15 && CargaTrabajo < 21) { CargaTrabajoRes = "Bajo"; }
                else if (CargaTrabajo >= 21 && CargaTrabajo < 27) { CargaTrabajoRes = "Medio"; }
                else if (CargaTrabajo >= 27 && CargaTrabajo < 37) { CargaTrabajoRes = "Alto"; }
                else if (CargaTrabajo >= 37) { CargaTrabajoRes = "Muy Alto"; }


                //falta de control sobre el trabajo
                FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();

                //resultados en falta de control sobre el trabajo
                if (FaltaControlSobreTrabajo < 11) { FaltaControlSobreTrabajoRes = "Nulo o Despreciable"; }
                else if (FaltaControlSobreTrabajo >= 11 && FaltaControlSobreTrabajo < 16) { FaltaControlSobreTrabajoRes = "Bajo"; }
                else if (FaltaControlSobreTrabajo >= 16 && FaltaControlSobreTrabajo < 21) { FaltaControlSobreTrabajoRes = "Medio"; }
                else if (FaltaControlSobreTrabajo >= 21 && FaltaControlSobreTrabajo < 25) { FaltaControlSobreTrabajoRes = "Alto"; }
                else if (FaltaControlSobreTrabajo >= 25) { FaltaControlSobreTrabajoRes = "Muy Alto"; }

                //jornada de trabajo
                JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (85,86) ").FirstOrDefault();

                //resultados en jornada de trabajo
                if (JornadaTrabajo < 1) { JornadaTrabajoRes = "Nulo o Despreciable"; }
                else if (JornadaTrabajo >= 1 && JornadaTrabajo < 2) { JornadaTrabajoRes = "Bajo"; }
                else if (JornadaTrabajo >= 2 && JornadaTrabajo < 4) { JornadaTrabajoRes = "Medio"; }
                else if (JornadaTrabajo >= 4 && JornadaTrabajo < 6) { JornadaTrabajoRes = "Alto"; }
                else if (JornadaTrabajo >= 6) { JornadaTrabajoRes = "Muy Alto"; }


                //Interferencia en la relación trabajo-familia
                InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (87,88,89,90) ").FirstOrDefault();


                //resultados en InfluenciaTrabajoFueraCentroLaboral
                if (InterferenciaRelacionTrabajoFamilia < 4) { InterferenciaRelacionTrabajoFamiliaRes = "Nulo o Despreciable"; }
                else if (InterferenciaRelacionTrabajoFamilia >= 4 && InterferenciaRelacionTrabajoFamilia < 6) { InterferenciaRelacionTrabajoFamiliaRes = "Bajo"; }
                else if (InterferenciaRelacionTrabajoFamilia >= 6 && InterferenciaRelacionTrabajoFamilia < 8) { InterferenciaRelacionTrabajoFamiliaRes = "Medio"; }
                else if (InterferenciaRelacionTrabajoFamilia >= 8 && InterferenciaRelacionTrabajoFamilia < 10) { InterferenciaRelacionTrabajoFamiliaRes = "Alto"; }
                else if (InterferenciaRelacionTrabajoFamilia >= 10) { InterferenciaRelacionTrabajoFamiliaRes = "Muy Alto"; }

                //Liderazgo
                Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();

                //resultados en Liderazgo
                if (Liderazgo < 9) { LiderazgoRes = "Nulo o Despreciable"; }
                else if (Liderazgo >= 9 && Liderazgo < 12) { LiderazgoRes = "Bajo"; }
                else if (Liderazgo >= 12 && Liderazgo < 16) { LiderazgoRes = "Medio"; }
                else if (Liderazgo >= 16 && Liderazgo < 20) { LiderazgoRes = "Alto"; }
                else if (Liderazgo >= 20) { LiderazgoRes = "Muy Alto"; }

                //Relaciones en el trabajo
                RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();

                //resultados en Relaciones en el trabajo
                if (RelacionesTrabajo < 10) { RelacionesTrabajoRes = "Nulo o Despreciable"; }
                else if (RelacionesTrabajo >= 10 && RelacionesTrabajo < 13) { RelacionesTrabajoRes = "Bajo"; }
                else if (RelacionesTrabajo >= 13 && RelacionesTrabajo < 17) { RelacionesTrabajoRes = "Medio"; }
                else if (RelacionesTrabajo >= 17 && RelacionesTrabajo < 21) { RelacionesTrabajoRes = "Alto"; }
                else if (RelacionesTrabajo >= 21) { RelacionesTrabajoRes = "Muy Alto"; }


                //Violencia
                Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();

                //resultados en Violencia
                if (Violencia < 7) { ViolenciaRes = "Nulo o Despreciable"; }
                else if (Violencia >= 7 && Violencia < 10) { ViolenciaRes = "Bajo"; }
                else if (Violencia >= 10 && Violencia < 13) { ViolenciaRes = "Medio"; }
                else if (Violencia >= 13 && Violencia < 16) { ViolenciaRes = "Alto"; }
                else if (Violencia >= 16) { ViolenciaRes = "Muy Alto"; }


                ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();

                //resultados en ReconocimientoDesempeño
                if (ReconocimientoDesempeño < 6) { ReconocimientoDesempeñoRes = "Nulo o Despreciable"; }
                else if (ReconocimientoDesempeño >= 6 && ReconocimientoDesempeño < 10) { ReconocimientoDesempeñoRes = "Bajo"; }
                else if (ReconocimientoDesempeño >= 10 && ReconocimientoDesempeño < 14) { ReconocimientoDesempeñoRes = "Medio"; }
                else if (ReconocimientoDesempeño >= 14 && ReconocimientoDesempeño < 18) { ReconocimientoDesempeñoRes = "Alto"; }
                else if (ReconocimientoDesempeño >= 18) { ReconocimientoDesempeñoRes = "Muy Alto"; }


                //Insuficiente sentido de pertenencia e, inestabilidad
                InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (124,121,122,123) ").FirstOrDefault();

                //resultados en ReconocimientoDesempeño
                if (InsuficienteSentido < 4) { InsuficienteSentidoRes = "Nulo o Despreciable"; }
                else if (InsuficienteSentido >= 4 && InsuficienteSentido < 6) { InsuficienteSentidoRes = "Bajo"; }
                else if (InsuficienteSentido >= 6 && InsuficienteSentido < 8) { InsuficienteSentidoRes = "Medio"; }
                else if (InsuficienteSentido >= 8 && InsuficienteSentido < 10) { InsuficienteSentidoRes = "Alto"; }
                else if (InsuficienteSentido >= 10) { InsuficienteSentidoRes = "Muy Alto"; }



                nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
            }



            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                Paragraph title2 = new Paragraph("CUESTIONARIO III", font1);
                title2.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);
                doc.Add(title2);
                doc.Add(espacio);

                Paragraph Nombre_emp = new Paragraph("NOMBRE DEL EMPLEADO: " + nombreEmpleado, font1);
                Nombre_emp.Alignment = Element.ALIGN_LEFT;
                doc.Add(Nombre_emp);
                doc.Add(espacio);

                Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO.", font2);
                seccion1.Alignment = Element.ALIGN_LEFT;
                doc.Add(seccion1);
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[3] { 150, 30, 30 };
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Dominio", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase(CondicionesAmbienteTrabajo.ToString(), font));
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda5 = new PdfPCell(new Phrase(CargaTrabajo.ToString(), font));
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda6 = new PdfPCell(new Phrase(FaltaControlSobreTrabajo.ToString(), font));
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda7 = new PdfPCell(new Phrase(JornadaTrabajo.ToString(), font));
                celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda8 = new PdfPCell(new Phrase(InterferenciaRelacionTrabajoFamilia.ToString(), font));
                celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda9 = new PdfPCell(new Phrase(Liderazgo.ToString(), font));
                celda9.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda10 = new PdfPCell(new Phrase(RelacionesTrabajo.ToString(), font));
                celda10.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda11 = new PdfPCell(new Phrase(Violencia.ToString(), font));
                celda11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda12 = new PdfPCell(new Phrase(ReconocimientoDesempeño.ToString(), font));
                celda12.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda13 = new PdfPCell(new Phrase(InsuficienteSentido.ToString(), font));
                celda13.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                //Poniendo datos en la la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                tabla.AddCell(celda4);
                tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Carga de trabajo", font)));
                tabla.AddCell(celda5);
                tabla.AddCell(new PdfPCell(new Phrase(CargaTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Falta de control sobre el trabajo", font)));
                tabla.AddCell(celda6);
                tabla.AddCell(new PdfPCell(new Phrase(FaltaControlSobreTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Jornada de trabajo", font)));
                tabla.AddCell(celda7);
                tabla.AddCell(new PdfPCell(new Phrase(JornadaTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Interferencia en la relación trabajo-familia", font)));
                tabla.AddCell(celda8);
                tabla.AddCell(new PdfPCell(new Phrase(InterferenciaRelacionTrabajoFamiliaRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Liderazgo", font)));
                tabla.AddCell(celda9);
                tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Relaciones en el Trabajo", font)));
                tabla.AddCell(celda10);
                tabla.AddCell(new PdfPCell(new Phrase(RelacionesTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Violencia", font)));
                tabla.AddCell(celda11);
                tabla.AddCell(new PdfPCell(new Phrase(ViolenciaRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Reconocimiento del desempeño", font)));
                tabla.AddCell(celda12);
                tabla.AddCell(new PdfPCell(new Phrase(ReconocimientoDesempeñoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Insuficiente sentido de pertenencia e inestabilidad", font)));
                tabla.AddCell(celda13);
                tabla.AddCell(new PdfPCell(new Phrase(InsuficienteSentidoRes.ToString(), font)));

                //Agregando la tabla al documento
                doc.Add(tabla);

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

        public FileResult generarPDFGuiaIIICat(int id)
        {

            string AmbienteTrabajoRes = "";
            string FactoresPropiosActividadRes = "";
            string OrganizacionTiempoTrabajoRes = "";
            string LiderazgoRelacionesTrabajoRes = "";
            string EntornoOrganizacionalRes = "";
            string nombreEmpleado;

            int CondicionesAmbienteTrabajo;
            int CargaTrabajo;
            int FaltaControlSobreTrabajo;
            int JornadaTrabajo;
            int InterferenciaRelacionTrabajoFamilia;
            int Liderazgo;
            int RelacionesTrabajo;
            int Violencia;
            int ReconocimientoDesempeño;
            int InsuficienteSentido;

            int AmbienteTrabajo;
            int FactoresPropiosActividad;
            int OrganizacionTiempoTrabajo;
            int LiderazgoRelacionesTrabajo;
            int EntornoOrganizacional;

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (69,70,71,72,73) ").FirstOrDefault();




                //condiciones en el ambiente de trabajo
                CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();


                //falta de control sobre el trabajo
                FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();


                //Jornada de trabajo
                JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (85,86) ").FirstOrDefault();

                //Interferencia en la relación trabajo-familia
                InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (87,88,89,90) ").FirstOrDefault();

                //Liderazgo
                Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();

                //Relaciones en el trabajo
                RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();

                //Violencia
                Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();

                //Reconocimiento del desempeño
                ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();

                //Insuficiente sentido de pertenencia e, inestabilidad
                InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (124,121,122,123) ").FirstOrDefault();


                nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                //AmbienteTrabajo = CondicionesAmbienteTrabajo;
                //FactoresPropiosActividad = CargaTrabajo + FaltaControlSobreTrabajo;
                //OrganizacionTiempoTrabajo = JornadaTrabajo + InfluenciaTrabajoFueraCentroLaboral;
                //LiderazgoRelacionesTrabajo = Liderazgo + RelacionesTrabajo + Violencia;

                AmbienteTrabajo = CondicionesAmbienteTrabajo;
                FactoresPropiosActividad = CargaTrabajo + FaltaControlSobreTrabajo;
                OrganizacionTiempoTrabajo = JornadaTrabajo + InterferenciaRelacionTrabajoFamilia;
                LiderazgoRelacionesTrabajo = Liderazgo + RelacionesTrabajo + Violencia;
                EntornoOrganizacional = ReconocimientoDesempeño + InsuficienteSentido;

                //resultados en AmbienteTrabajo
                if (AmbienteTrabajo < 5) { AmbienteTrabajoRes = "Nulo o Despreciable"; }
                else if (AmbienteTrabajo >= 5 && AmbienteTrabajo < 9) { AmbienteTrabajoRes = "Bajo"; }
                else if (AmbienteTrabajo >= 9 && AmbienteTrabajo < 11) { AmbienteTrabajoRes = "Medio"; }
                else if (AmbienteTrabajo >= 11 && AmbienteTrabajo < 14) { AmbienteTrabajoRes = "Alto"; }
                else if (AmbienteTrabajo >= 14) { AmbienteTrabajoRes = "Muy Alto"; }

                //resultados en FactoresPropiosActividad
                if (FactoresPropiosActividad < 15) { FactoresPropiosActividadRes = "Nulo o Despreciable"; }
                else if (FactoresPropiosActividad >= 15 && FactoresPropiosActividad < 30) { FactoresPropiosActividadRes = "Bajo"; }
                else if (FactoresPropiosActividad >= 30 && FactoresPropiosActividad < 45) { FactoresPropiosActividadRes = "Medio"; }
                else if (FactoresPropiosActividad >= 45 && FactoresPropiosActividad < 60) { FactoresPropiosActividadRes = "Alto"; }
                else if (FactoresPropiosActividad >= 60) { FactoresPropiosActividadRes = "Muy Alto"; }

                //resultados en OrganizacionTiempoTrabajo
                if (OrganizacionTiempoTrabajo < 5) { OrganizacionTiempoTrabajoRes = "Nulo o Despreciable"; }
                else if (OrganizacionTiempoTrabajo >= 5 && OrganizacionTiempoTrabajo < 7) { OrganizacionTiempoTrabajoRes = "Bajo"; }
                else if (OrganizacionTiempoTrabajo >= 7 && OrganizacionTiempoTrabajo < 10) { OrganizacionTiempoTrabajoRes = "Medio"; }
                else if (OrganizacionTiempoTrabajo >= 10 && OrganizacionTiempoTrabajo < 13) { OrganizacionTiempoTrabajoRes = "Alto"; }
                else if (OrganizacionTiempoTrabajo >= 13) { OrganizacionTiempoTrabajoRes = "Muy Alto"; }

                //resultados en LiderazgoRelacionesTrabajo
                if (LiderazgoRelacionesTrabajo < 14) { LiderazgoRelacionesTrabajoRes = "Nulo o Despreciable"; }
                else if (LiderazgoRelacionesTrabajo >= 14 && LiderazgoRelacionesTrabajo < 29) { LiderazgoRelacionesTrabajoRes = "Bajo"; }
                else if (LiderazgoRelacionesTrabajo >= 29 && LiderazgoRelacionesTrabajo < 42) { LiderazgoRelacionesTrabajoRes = "Medio"; }
                else if (LiderazgoRelacionesTrabajo >= 42 && LiderazgoRelacionesTrabajo < 58) { LiderazgoRelacionesTrabajoRes = "Alto"; }
                else if (LiderazgoRelacionesTrabajo >= 58) { LiderazgoRelacionesTrabajoRes = "Muy Alto"; }

                //resultados en LiderazgoRelacionesTrabajo
                if (EntornoOrganizacional < 10) { EntornoOrganizacionalRes = "Nulo o Despreciable"; }
                else if (EntornoOrganizacional >= 10 && EntornoOrganizacional < 14) { EntornoOrganizacionalRes = "Bajo"; }
                else if (EntornoOrganizacional >= 14 && EntornoOrganizacional < 18) { EntornoOrganizacionalRes = "Medio"; }
                else if (EntornoOrganizacional >= 18 && EntornoOrganizacional < 23) { EntornoOrganizacionalRes = "Alto"; }
                else if (EntornoOrganizacional >= 23) { EntornoOrganizacionalRes = "Muy Alto"; }
            }




            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                Paragraph title2 = new Paragraph("CUESTIONARIO III", font1);
                title2.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);
                doc.Add(title2);
                doc.Add(espacio);

                Paragraph Nombre_emp = new Paragraph("NOMBRE DEL EMPLEADO: " + nombreEmpleado, font1);
                Nombre_emp.Alignment = Element.ALIGN_LEFT;
                doc.Add(Nombre_emp);
                doc.Add(espacio);

                Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO. ", font2);
                seccion1.Alignment = Element.ALIGN_LEFT;
                doc.Add(seccion1);
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(3);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[3] { 150, 30, 30 };
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Categoría", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase(AmbienteTrabajo.ToString(), font));
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda5 = new PdfPCell(new Phrase(FactoresPropiosActividad.ToString(), font));
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda6 = new PdfPCell(new Phrase(OrganizacionTiempoTrabajo.ToString(), font));
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda7 = new PdfPCell(new Phrase(LiderazgoRelacionesTrabajo.ToString(), font));
                celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda8 = new PdfPCell(new Phrase(EntornoOrganizacional.ToString(), font));
                celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                //Poniendo datos en la la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                tabla.AddCell(celda4);
                tabla.AddCell(new PdfPCell(new Phrase(AmbienteTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Factores propios de la actividad", font)));
                tabla.AddCell(celda5);
                tabla.AddCell(new PdfPCell(new Phrase(FactoresPropiosActividadRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Organización del tiempo de trabajo", font)));
                tabla.AddCell(celda6);
                tabla.AddCell(new PdfPCell(new Phrase(OrganizacionTiempoTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Liderazgo y relaciones en el trabajo", font)));
                tabla.AddCell(celda7);
                tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRelacionesTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Entorno organizacional", font)));
                tabla.AddCell(celda8);
                tabla.AddCell(new PdfPCell(new Phrase(EntornoOrganizacionalRes.ToString(), font)));


                //Agregando la tabla al documento
                doc.Add(tabla);

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

        public FileResult generaPDFGuiaIIIFinal(int id)
        {

            int CondicionesAmbienteTrabajo;
            int CargaTrabajo;
            int FaltaControlTrabajo;
            int JornadaTrabajo;
            int InterferenciaRelacionTrabajoFamilia;
            int Liderazgo;
            int RelacionesTrabajo;
            int Violencia;
            int ReconocimientoDesempeño;
            int InsuficienteSentido;
            int CalificacionFinalCuestionario;

            string nombreEmpleado;
            string CalificacionFinalCuestionarioRes = "";
            string riesgo = "";

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (69,70,71,72,73) ").FirstOrDefault();

                //carga de trabajo
                CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();

                //Falta de control sobre el trabajo
                FaltaControlTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();

                //Jornada de trabajo
                JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (85,86) ").FirstOrDefault();

                //Interferencia en la relación trabajo-familia
                InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (87,88,89,90) ").FirstOrDefault();

                //Liderazgo
                Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();

                //Relaciones en el trabajo
                RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();

                //Violencia
                Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();

                //Reconocimiento del desempeño
                ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();

                //Insuficiente sentido de pertenencia e, inestabilidad
                InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                           " from encuesta_det_encuesta, encuesta_resultados " +
                                                           " where denc_encu_id = 3 " +
                                                           " and resu_denc_id = denc_id " +
                                                           " and resu_usua_id = " + id + " " +
                                                           " and denc_id in (124,121,122,123) ").FirstOrDefault();


                nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                CalificacionFinalCuestionario = CondicionesAmbienteTrabajo + CargaTrabajo + FaltaControlTrabajo +
                                                            JornadaTrabajo + InterferenciaRelacionTrabajoFamilia + Liderazgo +
                                                            RelacionesTrabajo + Violencia + ReconocimientoDesempeño +
                                                            InsuficienteSentido;

                if (CalificacionFinalCuestionario < 50) { CalificacionFinalCuestionarioRes = "Nulo o Despreciable"; riesgo = "El riesgo resulta despreciable por lo que no se requiere medidas adicionales."; }
                else if (CalificacionFinalCuestionario >= 50 && CalificacionFinalCuestionario < 75) { CalificacionFinalCuestionarioRes = "Bajo"; riesgo = "Es necesario una mayor difusión de la política de prevención de riesgos psicosociales y programas para: la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral."; }
                else if (CalificacionFinalCuestionario >= 75 && CalificacionFinalCuestionario < 99) { CalificacionFinalCuestionarioRes = "Medio"; riesgo = "Medio	Se requiere revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión, mediante un Programa de intervención."; }
                else if (CalificacionFinalCuestionario >= 99 && CalificacionFinalCuestionario < 140) { CalificacionFinalCuestionarioRes = "Alto"; riesgo = "Se requiere realizar un análisis de cada categoría y dominio, de manera que se puedan determinar las acciones de intervención apropiadas a través de un Programa de intervención, que podrá incluir una evaluación específica1 y deberá incluir una campaña de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión."; }
                else if (CalificacionFinalCuestionario >= 140) { CalificacionFinalCuestionarioRes = "Muy Alto"; riesgo = "Se requiere realizar el análisis de cada categoría y dominio para establecer las acciones de intervención apropiadas, mediante un Programa de intervención que deberá incluir evaluaciones específicas1, y contemplar campañas de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión."; }

            }




            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                Paragraph title2 = new Paragraph("CUESTIONARIO III", font1);
                title2.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);
                doc.Add(title2);
                doc.Add(espacio);

                Paragraph Nombre_emp = new Paragraph("NOMBRE DEL EMPLEADO: " + nombreEmpleado, font1);
                Nombre_emp.Alignment = Element.ALIGN_LEFT;
                doc.Add(Nombre_emp);
                doc.Add(espacio);

                Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO. ", font2);
                seccion1.Alignment = Element.ALIGN_LEFT;
                doc.Add(seccion1);
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[4] { 30, 30, 30, 150 };
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Resultado Final", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase("Necesidad de acción", font));
                celda4.BackgroundColor = new BaseColor(240, 240, 240);
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda4);

                PdfPCell celda5 = new PdfPCell(new Phrase(CalificacionFinalCuestionario.ToString(), font));
                celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda6 = new PdfPCell(new Phrase(CalificacionFinalCuestionarioRes.ToString(), font));
                celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                PdfPCell celda7 = new PdfPCell(new Phrase(riesgo.ToString(), font));
                celda7.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;


                //Poniendo datos en la la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Calificación final del cuestionario", font)));
                tabla.AddCell(celda5);
                tabla.AddCell(celda6);
                tabla.AddCell(celda7);

                //Agregando la tabla al documento
                doc.Add(tabla);

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

        public FileResult PDFResultadoPorEmpresaDom(string ids_usuarios)
        {
            //con el primer registro sabemos de donde son los empleados(la empresa)
            int id_empresa;
            String num_empleados;
            int No_Empleados;
            string nombre_empresa;
            String[] str = ids_usuarios.Split(',');

            double condiciones = 0.00;
            double carga = 0.00;
            double faltaControl = 0.00;
            double jornada = 0.00;
            double influencia = 0.00;
            double liderazgo = 0.00;
            double relaciones = 0.00;
            double violencia = 0.00;
            double reconocimiento = 0.00;
            double insuficiente = 0.00;


            string CondicionesAmbienteTrabajoRes = "";
            string CargaTrabajoRes = "";
            string FaltaControlSobreTrabajoRes = "";
            string JornadaTrabajoRes = "";
            string InterferenciaRelacionTrabajoFamiliaRes = "";
            string LiderazgoRes = "";
            string RelacionesTrabajoRes = "";
            string ViolenciaRes = "";
            string ReconocimientoDesempeñoRes = "";
            string InsuficienteSentidoRes = "";

            using (var db = new csstdura_encuestaEntities())
            {
                id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + str[0]).FirstOrDefault();
                nombre_empresa = db.Database.SqlQuery<String>("select emp_descrip from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                No_Empleados = Convert.ToInt32(num_empleados);
                if (No_Empleados < 51)
                {
                    int _CondicionesAmbienteTrabajo = 0;
                    int _CargaTrabajo = 0;
                    int _FaltaControlSobreTrabajo = 0;
                    int _JornadaTrabajo = 0;
                    int _InfluenciaTrabajoFueraCentroLaboral = 0;
                    int _Liderazgo = 0;
                    int _RelacionesTrabajo = 0;
                    int _Violencia = 0;
                    double valorFinal = 0.00;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                    " from encuesta_det_encuesta, encuesta_resultados " +
                                                                    " where denc_encu_id = 2 " +
                                                                    " and resu_denc_id = denc_id " +
                                                                    " and resu_usua_id = " + value + " " +
                                                                    " and denc_id in (21, 22, 23) ").FirstOrDefault();
                        _CondicionesAmbienteTrabajo = _CondicionesAmbienteTrabajo + CondicionesAmbienteTrabajo;
                    };
                    valorFinal = Convert.ToDouble(_CondicionesAmbienteTrabajo) / Convert.ToDouble(str.Length);
                    condiciones = valorFinal;
                    if (condiciones < 3) { CondicionesAmbienteTrabajoRes = "Nulo o Despreciable"; }
                    else if (condiciones >= 3 && condiciones < 5) { CondicionesAmbienteTrabajoRes = "Bajo"; }
                    else if (condiciones >= 5 && condiciones < 7) { CondicionesAmbienteTrabajoRes = "Medio"; }
                    else if (condiciones >= 7 && condiciones < 9) { CondicionesAmbienteTrabajoRes = "Alto"; }
                    else if (condiciones >= 9) { CondicionesAmbienteTrabajoRes = "Muy Alto"; }


                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();
                        _CargaTrabajo = _CargaTrabajo + CargaTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_CargaTrabajo) / Convert.ToDouble(str.Length);
                    carga = valorFinal;
                    if (carga < 12) { CargaTrabajoRes = "Nulo o Despreciable"; }
                    else if (carga >= 12 && carga < 16) { CargaTrabajoRes = "Bajo"; }
                    else if (carga >= 16 && carga < 20) { CargaTrabajoRes = "Medio"; }
                    else if (carga >= 20 && carga < 24) { CargaTrabajoRes = "Alto"; }
                    else if (carga >= 24) { CargaTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //falta de control sobre el trabajo
                        int FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();
                        _FaltaControlSobreTrabajo = _FaltaControlSobreTrabajo + FaltaControlSobreTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_FaltaControlSobreTrabajo) / Convert.ToDouble(str.Length);
                    faltaControl = valorFinal;
                    if (faltaControl < 5) { FaltaControlSobreTrabajoRes = "Nulo o Despreciable"; }
                    else if (faltaControl >= 5 && faltaControl < 8) { FaltaControlSobreTrabajoRes = "Bajo"; }
                    else if (faltaControl >= 8 && faltaControl < 11) { FaltaControlSobreTrabajoRes = "Medio"; }
                    else if (faltaControl >= 11 && faltaControl < 14) { FaltaControlSobreTrabajoRes = "Alto"; }
                    else if (faltaControl >= 14) { FaltaControlSobreTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //jornada de trabajo
                        int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (34,35) ").FirstOrDefault();
                        _JornadaTrabajo = _JornadaTrabajo + JornadaTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_JornadaTrabajo) / Convert.ToDouble(str.Length);
                    jornada = valorFinal;
                    if (jornada < 1) { JornadaTrabajoRes = "Nulo o Despreciable"; }
                    else if (jornada >= 1 && jornada < 2) { JornadaTrabajoRes = "Bajo"; }
                    else if (jornada >= 2 && jornada < 4) { JornadaTrabajoRes = "Medio"; }
                    else if (jornada >= 4 && jornada < 6) { JornadaTrabajoRes = "Alto"; }
                    else if (jornada >= 6) { JornadaTrabajoRes = "Muy Alto"; }


                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Interferencia en la relación trabajo-familia
                        int InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (36,37) ").FirstOrDefault();
                        _InfluenciaTrabajoFueraCentroLaboral = _InfluenciaTrabajoFueraCentroLaboral + InfluenciaTrabajoFueraCentroLaboral;
                    }
                    valorFinal = Convert.ToDouble(_InfluenciaTrabajoFueraCentroLaboral) / Convert.ToDouble(str.Length);
                    influencia = valorFinal;
                    if (influencia < 1) { InterferenciaRelacionTrabajoFamiliaRes = "Nulo o Despreciable"; }
                    else if (influencia >= 1 && influencia < 2) { InterferenciaRelacionTrabajoFamiliaRes = "Bajo"; }
                    else if (influencia >= 2 && influencia < 4) { InterferenciaRelacionTrabajoFamiliaRes = "Medio"; }
                    else if (influencia >= 4 && influencia < 6) { InterferenciaRelacionTrabajoFamiliaRes = "Alto"; }
                    else if (influencia >= 6) { InterferenciaRelacionTrabajoFamiliaRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Liderazgo
                        int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (43,44,45,47,48) ").FirstOrDefault();
                        _Liderazgo = _Liderazgo + Liderazgo;
                    }
                    valorFinal = Convert.ToDouble(_Liderazgo) / Convert.ToDouble(str.Length);
                    liderazgo = valorFinal;
                    if (liderazgo < 3) { LiderazgoRes = "Nulo o Despreciable"; }
                    else if (liderazgo >= 3 && liderazgo < 5) { LiderazgoRes = "Bajo"; }
                    else if (liderazgo >= 5 && liderazgo < 8) { LiderazgoRes = "Medio"; }
                    else if (liderazgo >= 8 && liderazgo < 11) { LiderazgoRes = "Alto"; }
                    else if (liderazgo >= 11) { LiderazgoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Relaciones en el trabajo
                        int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();
                        _RelacionesTrabajo = _RelacionesTrabajo + RelacionesTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_RelacionesTrabajo) / Convert.ToDouble(str.Length);
                    relaciones = valorFinal;
                    if (relaciones < 5) { RelacionesTrabajoRes = "Nulo o Despreciable"; }
                    else if (relaciones >= 5 && relaciones < 8) { RelacionesTrabajoRes = "Bajo"; }
                    else if (relaciones >= 8 && relaciones < 11) { RelacionesTrabajoRes = "Medio"; }
                    else if (relaciones >= 11 && relaciones < 14) { RelacionesTrabajoRes = "Alto"; }
                    else if (relaciones >= 14) { RelacionesTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Violencia
                        int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = ( " + value + ") " +
                                                                " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();
                        _Violencia = _Violencia + Violencia;
                    }

                    valorFinal = Convert.ToDouble(_Violencia) / Convert.ToDouble(str.Length);
                    violencia = valorFinal;
                    if (violencia < 7) { ViolenciaRes = "Nulo o Despreciable"; }
                    else if (violencia >= 7 && violencia < 10) { ViolenciaRes = "Bajo"; }
                    else if (violencia >= 10 && violencia < 13) { ViolenciaRes = "Medio"; }
                    else if (violencia >= 13 && violencia < 16) { ViolenciaRes = "Alto"; }
                    else if (violencia >= 16) { ViolenciaRes = "Muy Alto"; }
                }
                else
                {

                    double valorFinal = 0.00;
                    int _CondicionesAmbienteTrabajo = 0;
                    int _CargaTrabajo = 0;
                    int _FaltaControlTrabajo = 0;
                    int _JornadaTrabajo = 0;
                    int _InterferenciaRelacionTrabajoFamilia = 0;
                    int _Liderazgo = 0;
                    int _RelacionesTrabajo = 0;
                    int _Violencia = 0;
                    int _ReconocimientoDesempeño = 0;
                    int _InsuficienteSentido = 0;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                    " from encuesta_det_encuesta, encuesta_resultados " +
                                                                    " where denc_encu_id = 3 " +
                                                                    " and resu_denc_id = denc_id " +
                                                                    " and resu_usua_id = " + value + " " +
                                                                    " and denc_id in (69,70,71,72,73) ").FirstOrDefault();
                        _CondicionesAmbienteTrabajo = _CondicionesAmbienteTrabajo + CondicionesAmbienteTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_CondicionesAmbienteTrabajo) / Convert.ToDouble(str.Length);
                    condiciones = valorFinal;
                    if (condiciones < 5) { CondicionesAmbienteTrabajoRes = "Nulo o Despreciable"; }
                    else if (condiciones >= 5 && condiciones < 9) { CondicionesAmbienteTrabajoRes = "Bajo"; }
                    else if (condiciones >= 9 && condiciones < 11) { CondicionesAmbienteTrabajoRes = "Medio"; }
                    else if (condiciones >= 11 && condiciones < 14) { CondicionesAmbienteTrabajoRes = "Alto"; }
                    else if (condiciones >= 14) { CondicionesAmbienteTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //carga de trabajo
                        int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();
                        _CargaTrabajo = _CargaTrabajo + CargaTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_CargaTrabajo) / Convert.ToDouble(str.Length);
                    carga = _CargaTrabajo;

                    if (carga < 15) { CargaTrabajoRes = "Nulo o Despreciable"; }
                    else if (carga >= 15 && carga < 21) { CargaTrabajoRes = "Bajo"; }
                    else if (carga >= 21 && carga < 27) { CargaTrabajoRes = "Medio"; }
                    else if (carga >= 27 && carga < 37) { CargaTrabajoRes = "Alto"; }
                    else if (carga >= 37) { CargaTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Falta de control sobre el trabajo
                        int FaltaControlTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();
                        _FaltaControlTrabajo = _FaltaControlTrabajo + FaltaControlTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_FaltaControlTrabajo) / Convert.ToDouble(str.Length);
                    faltaControl = valorFinal;
                    if (faltaControl < 11) { FaltaControlSobreTrabajoRes = "Nulo o Despreciable"; }
                    else if (faltaControl >= 11 && faltaControl < 16) { FaltaControlSobreTrabajoRes = "Bajo"; }
                    else if (faltaControl >= 16 && faltaControl < 21) { FaltaControlSobreTrabajoRes = "Medio"; }
                    else if (faltaControl >= 21 && faltaControl < 25) { FaltaControlSobreTrabajoRes = "Alto"; }
                    else if (faltaControl >= 25) { FaltaControlSobreTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Jornada de trabajo
                        int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (85,86) ").FirstOrDefault();
                        _JornadaTrabajo = _JornadaTrabajo + JornadaTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_JornadaTrabajo) / Convert.ToDouble(str.Length);
                    jornada = valorFinal;
                    if (jornada < 1) { JornadaTrabajoRes = "Nulo o Despreciable"; }
                    else if (jornada >= 1 && jornada < 2) { JornadaTrabajoRes = "Bajo"; }
                    else if (jornada >= 2 && jornada < 4) { JornadaTrabajoRes = "Medio"; }
                    else if (jornada >= 4 && jornada < 6) { JornadaTrabajoRes = "Alto"; }
                    else if (jornada >= 6) { JornadaTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Interferencia en la relación trabajo-familia
                        int InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (87,88,89,90) ").FirstOrDefault();
                        _InterferenciaRelacionTrabajoFamilia = _InterferenciaRelacionTrabajoFamilia + InterferenciaRelacionTrabajoFamilia;
                    }
                    valorFinal = Convert.ToDouble(_InterferenciaRelacionTrabajoFamilia) / Convert.ToDouble(str.Length);
                    influencia = valorFinal;
                    if (influencia < 4) { InterferenciaRelacionTrabajoFamiliaRes = "Nulo o Despreciable"; }
                    else if (influencia >= 4 && influencia < 6) { InterferenciaRelacionTrabajoFamiliaRes = "Bajo"; }
                    else if (influencia >= 6 && influencia < 8) { InterferenciaRelacionTrabajoFamiliaRes = "Medio"; }
                    else if (influencia >= 8 && influencia < 10) { InterferenciaRelacionTrabajoFamiliaRes = "Alto"; }
                    else if (influencia >= 10) { InterferenciaRelacionTrabajoFamiliaRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Liderazgo
                        int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();
                        _Liderazgo = _Liderazgo + Liderazgo;
                    }
                    valorFinal = Convert.ToDouble(_Liderazgo) / Convert.ToDouble(str.Length);
                    liderazgo = valorFinal;
                    if (liderazgo < 9) { LiderazgoRes = "Nulo o Despreciable"; }
                    else if (liderazgo >= 9 && liderazgo < 12) { LiderazgoRes = "Bajo"; }
                    else if (liderazgo >= 12 && liderazgo < 16) { LiderazgoRes = "Medio"; }
                    else if (liderazgo >= 16 && liderazgo < 20) { LiderazgoRes = "Alto"; }
                    else if (liderazgo >= 20) { LiderazgoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Relaciones en el trabajo
                        int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();
                        _RelacionesTrabajo = _RelacionesTrabajo + RelacionesTrabajo;
                    }
                    valorFinal = Convert.ToDouble(_RelacionesTrabajo) / Convert.ToDouble(str.Length);
                    relaciones = valorFinal;
                    if (relaciones < 10) { RelacionesTrabajoRes = "Nulo o Despreciable"; }
                    else if (relaciones >= 10 && relaciones < 13) { RelacionesTrabajoRes = "Bajo"; }
                    else if (relaciones >= 13 && relaciones < 17) { RelacionesTrabajoRes = "Medio"; }
                    else if (relaciones >= 17 && relaciones < 21) { RelacionesTrabajoRes = "Alto"; }
                    else if (relaciones >= 21) { RelacionesTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Violencia
                        int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                    " from encuesta_det_encuesta, encuesta_resultados " +
                                                                    " where denc_encu_id = 3 " +
                                                                    " and resu_denc_id = denc_id " +
                                                                    " and resu_usua_id = " + value + " " +
                                                                    " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();
                        _Violencia = _Violencia + Violencia;
                    }
                    valorFinal = Convert.ToDouble(_Violencia) / Convert.ToDouble(str.Length);
                    violencia = valorFinal;
                    if (violencia < 7) { ViolenciaRes = "Nulo o Despreciable"; }
                    else if (violencia >= 7 && violencia < 10) { ViolenciaRes = "Bajo"; }
                    else if (violencia >= 10 && violencia < 13) { ViolenciaRes = "Medio"; }
                    else if (violencia >= 13 && violencia < 16) { ViolenciaRes = "Alto"; }
                    else if (violencia >= 16) { ViolenciaRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Reconocimiento del desempeño
                        int ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                    " from encuesta_det_encuesta, encuesta_resultados " +
                                                                    " where denc_encu_id = 3 " +
                                                                    " and resu_denc_id = denc_id " +
                                                                    " and resu_usua_id = " + value + " " +
                                                                    " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();
                        _ReconocimientoDesempeño = _ReconocimientoDesempeño + ReconocimientoDesempeño;
                    }
                    valorFinal = Convert.ToDouble(_ReconocimientoDesempeño) / Convert.ToDouble(str.Length);
                    reconocimiento = valorFinal;
                    if (reconocimiento < 6) { ReconocimientoDesempeñoRes = "Nulo o Despreciable"; }
                    else if (reconocimiento >= 6 && reconocimiento < 10) { ReconocimientoDesempeñoRes = "Bajo"; }
                    else if (reconocimiento >= 10 && reconocimiento < 14) { ReconocimientoDesempeñoRes = "Medio"; }
                    else if (reconocimiento >= 14 && reconocimiento < 18) { ReconocimientoDesempeñoRes = "Alto"; }
                    else if (reconocimiento >= 18) { ReconocimientoDesempeñoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Insuficiente sentido de pertenencia e, inestabilidad
                        int InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                    " from encuesta_det_encuesta, encuesta_resultados " +
                                                                    " where denc_encu_id = 3 " +
                                                                    " and resu_denc_id = denc_id " +
                                                                    " and resu_usua_id = " + value + " " +
                                                                    " and denc_id in (124,121,122,123) ").FirstOrDefault();
                        _InsuficienteSentido = _InsuficienteSentido + InsuficienteSentido;
                    }
                    valorFinal = Convert.ToDouble(_InsuficienteSentido) / Convert.ToDouble(str.Length);
                    insuficiente = valorFinal;
                    if (insuficiente < 4) { InsuficienteSentidoRes = "Nulo o Despreciable"; }
                    else if (insuficiente >= 4 && insuficiente < 6) { InsuficienteSentidoRes = "Bajo"; }
                    else if (insuficiente >= 6 && insuficiente < 8) { InsuficienteSentidoRes = "Medio"; }
                    else if (insuficiente >= 8 && insuficiente < 10) { InsuficienteSentidoRes = "Alto"; }
                    else if (insuficiente >= 10) { InsuficienteSentidoRes = "Muy Alto"; }

                }

            }


            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
            iTextSharp.text.Font font = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

            Document doc = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE, 30, 30, 10, 10);
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {

                if (No_Empleados<51)
                {
                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();
                    Paragraph espacio = new Paragraph(" ");
                    Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 40.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                    Paragraph firma = new Paragraph("FIRMA");
                    Paragraph title = new Paragraph("Consultoría y Soluciones en Seguridad en el Trabajo", font1);
                    title.Alignment = Element.ALIGN_CENTER;
                    Paragraph title2 = new Paragraph("RESULTADOS DE DOMINIO POR EMPRESA", font1);
                    title2.Alignment = Element.ALIGN_CENTER;

                    doc.Add(title);
                    doc.Add(title2);
                    doc.Add(espacio);

                    Paragraph Nombre_emp = new Paragraph("NOMBRE DE LA EMPRESA :" + nombre_empresa, font1);
                    Nombre_emp.Alignment = Element.ALIGN_LEFT;
                    doc.Add(Nombre_emp);
                    doc.Add(espacio);

                    //Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO.", font2);
                    //seccion1.Alignment = Element.ALIGN_LEFT;
                    //doc.Add(seccion1);
                    //doc.Add(espacio);

                    //Creando la tabla
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas
                    float[] valores = new float[3] { 150, 30, 30 };
                    tabla.SetWidths(valores);

                    //Creando celdas agregando contenido
                    PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Dominio", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda1);

                    PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda2);

                    PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                    celda3.BackgroundColor = new BaseColor(240, 240, 240);
                    celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda3);

                    PdfPCell celda4 = new PdfPCell(new Phrase(condiciones.ToString(), font));
                    celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda5 = new PdfPCell(new Phrase(carga.ToString(), font));
                    celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda6 = new PdfPCell(new Phrase(faltaControl.ToString(), font));
                    celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda7 = new PdfPCell(new Phrase(jornada.ToString(), font));
                    celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda8 = new PdfPCell(new Phrase(influencia.ToString(), font));
                    celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda9 = new PdfPCell(new Phrase(liderazgo.ToString(), font));
                    celda9.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda10 = new PdfPCell(new Phrase(relaciones.ToString(), font));
                    celda10.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda11 = new PdfPCell(new Phrase(violencia.ToString(), font));
                    celda11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda12 = new PdfPCell(new Phrase(reconocimiento.ToString(), font));
                    celda12.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda13 = new PdfPCell(new Phrase(insuficiente.ToString(), font));
                    celda13.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    //Poniendo datos en la la tabla
                    tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                    tabla.AddCell(celda4);
                    tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Carga de trabajo", font)));
                    tabla.AddCell(celda5);
                    tabla.AddCell(new PdfPCell(new Phrase(CargaTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Falta de control sobre el trabajo", font)));
                    tabla.AddCell(celda6);
                    tabla.AddCell(new PdfPCell(new Phrase(FaltaControlSobreTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Jornada de trabajo", font)));
                    tabla.AddCell(celda7);
                    tabla.AddCell(new PdfPCell(new Phrase(JornadaTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Interferencia en la relación trabajo-familia", font)));
                    tabla.AddCell(celda8);
                    tabla.AddCell(new PdfPCell(new Phrase(InterferenciaRelacionTrabajoFamiliaRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Liderazgo", font)));
                    tabla.AddCell(celda9);
                    tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Relaciones en el Trabajo", font)));
                    tabla.AddCell(celda10);
                    tabla.AddCell(new PdfPCell(new Phrase(RelacionesTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Violencia", font)));
                    tabla.AddCell(celda11);
                    tabla.AddCell(new PdfPCell(new Phrase(ViolenciaRes.ToString(), font)));

             

                    //Agregando la tabla al documento
                    doc.Add(tabla);

                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(espacio);

                    doc.Add(linea);
                    firma.Alignment = Element.ALIGN_CENTER;
                    doc.Add(firma);
                    doc.Close();

                    buffer = ms.ToArray();
                }
                else 
                {
                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();
                    Paragraph espacio = new Paragraph(" ");
                    Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 40.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                    Paragraph firma = new Paragraph("FIRMA");
                    Paragraph title = new Paragraph("Consultoría y Soluciones en Seguridad en el Trabajo", font1);
                    title.Alignment = Element.ALIGN_CENTER;
                    Paragraph title2 = new Paragraph("RESULTADOS DE DOMINIO POR EMPRESA", font1);
                    title2.Alignment = Element.ALIGN_CENTER;

                    doc.Add(title);
                    doc.Add(title2);
                    doc.Add(espacio);

                    Paragraph Nombre_emp = new Paragraph("NOMBRE DE LA EMPRESA :" + nombre_empresa, font1);
                    Nombre_emp.Alignment = Element.ALIGN_LEFT;
                    doc.Add(Nombre_emp);
                    doc.Add(espacio);

                    //Paragraph seccion1 = new Paragraph("CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO.", font2);
                    //seccion1.Alignment = Element.ALIGN_LEFT;
                    //doc.Add(seccion1);
                    //doc.Add(espacio);

                    //Creando la tabla
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas
                    float[] valores = new float[3] { 150, 30, 30 };
                    tabla.SetWidths(valores);

                    //Creando celdas agregando contenido
                    PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Dominio", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda1);

                    PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda2);

                    PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                    celda3.BackgroundColor = new BaseColor(240, 240, 240);
                    celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda3);

                    PdfPCell celda4 = new PdfPCell(new Phrase(condiciones.ToString(), font));
                    celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda5 = new PdfPCell(new Phrase(carga.ToString(), font));
                    celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda6 = new PdfPCell(new Phrase(faltaControl.ToString(), font));
                    celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda7 = new PdfPCell(new Phrase(jornada.ToString(), font));
                    celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda8 = new PdfPCell(new Phrase(influencia.ToString(), font));
                    celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda9 = new PdfPCell(new Phrase(liderazgo.ToString(), font));
                    celda9.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda10 = new PdfPCell(new Phrase(relaciones.ToString(), font));
                    celda10.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda11 = new PdfPCell(new Phrase(violencia.ToString(), font));
                    celda11.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda12 = new PdfPCell(new Phrase(reconocimiento.ToString(), font));
                    celda12.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda13 = new PdfPCell(new Phrase(insuficiente.ToString(), font));
                    celda13.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    //Poniendo datos en la la tabla
                    tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                    tabla.AddCell(celda4);
                    tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Carga de trabajo", font)));
                    tabla.AddCell(celda5);
                    tabla.AddCell(new PdfPCell(new Phrase(CargaTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Falta de control sobre el trabajo", font)));
                    tabla.AddCell(celda6);
                    tabla.AddCell(new PdfPCell(new Phrase(FaltaControlSobreTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Jornada de trabajo", font)));
                    tabla.AddCell(celda7);
                    tabla.AddCell(new PdfPCell(new Phrase(JornadaTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Interferencia en la relación trabajo-familia", font)));
                    tabla.AddCell(celda8);
                    tabla.AddCell(new PdfPCell(new Phrase(InterferenciaRelacionTrabajoFamiliaRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Liderazgo", font)));
                    tabla.AddCell(celda9);
                    tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Relaciones en el Trabajo", font)));
                    tabla.AddCell(celda10);
                    tabla.AddCell(new PdfPCell(new Phrase(RelacionesTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Violencia", font)));
                    tabla.AddCell(celda11);
                    tabla.AddCell(new PdfPCell(new Phrase(ViolenciaRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Reconocimiento del desempeño", font)));
                    tabla.AddCell(celda12);
                    tabla.AddCell(new PdfPCell(new Phrase(ReconocimientoDesempeñoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Insuficiente sentido de pertenencia e inestabilidad", font)));
                    tabla.AddCell(celda13);
                    tabla.AddCell(new PdfPCell(new Phrase(InsuficienteSentidoRes.ToString(), font)));

                    //Agregando la tabla al documento
                    doc.Add(tabla);

                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(espacio);

                    doc.Add(linea);
                    firma.Alignment = Element.ALIGN_CENTER;
                    doc.Add(firma);
                    doc.Close();

                    buffer = ms.ToArray();
                }

            }
            return File(buffer, "application/pdf");
        }

        public FileResult PDFResultadoPorEmpresaCat(string ids_usuarios)
        {
            //con el primer registro sabemos de donde son los empleados(la empresa)
            int id_empresa;
            String num_empleados;
            int No_Empleados;
            string nombre_empresa;
            String[] str = ids_usuarios.Split(',');

            double condiciones = 0.00;
            double carga = 0.00;
            double faltaControl = 0.00;
            double jornada = 0.00;
            double influencia = 0.00;
            double liderazgo = 0.00;
            double relaciones = 0.00;
            double violencia = 0.00;
            double reconocimiento = 0.00;
            double insuficiente = 0.00;
            double FactoresPropiosActividad = 0.00;
            double OrganizacionTiempoTrabajo = 0.00;
            double LiderazgoRelacionesTrabajo = 0.00;
            double EntornoOrganizacional = 0.00;


            string CondicionesAmbienteTrabajoRes = "";
            string FactoresPropiosActividadRes = "";
            string OrganizacionTiempoTrabajoRes = "";
            string LiderazgoRelacionesTrabajoRes = "";
            string EntornoOrganizacionalRes = "";

            using (var db = new csstdura_encuestaEntities())
            {
                id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + str[0]).FirstOrDefault();
                nombre_empresa = db.Database.SqlQuery<String>("select emp_descrip from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                No_Empleados = Convert.ToInt32(num_empleados);
                if (No_Empleados < 51)
                {
                    double valorFinal1 = 0.00;
                    double valorFinal2 = 0.00;
                    double valorFinal3 = 0.00;
                    double valorFinal4 = 0.00;
                    double valorFinal5 = 0.00;
                    double valorFinal6 = 0.00;
                    double valorFinal7 = 0.00;
                    double valorFinal8 = 0.00;


                    int _CondicionesAmbienteTrabajo = 0;
                    int _CargaTrabajo = 0;
                    int _FaltaControlSobreTrabajo = 0;
                    int _JornadaTrabajo = 0;
                    int _InfluenciaTrabajoFueraCentroLaboral = 0;
                    int _Liderazgo = 0;
                    int _RelacionesTrabajo = 0;
                    int _Violencia = 0;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + value + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();
                        _CondicionesAmbienteTrabajo = _CondicionesAmbienteTrabajo + CondicionesAmbienteTrabajo;
                    }
                    valorFinal1 = Convert.ToDouble(_CondicionesAmbienteTrabajo) / Convert.ToDouble(str.Length);
                    condiciones = valorFinal1;
                    if (condiciones < 3) { CondicionesAmbienteTrabajoRes = "Nulo o Despreciable"; }
                    else if (condiciones >= 3 && condiciones < 5) { CondicionesAmbienteTrabajoRes = "Bajo"; }
                    else if (condiciones >= 5 && condiciones < 7) { CondicionesAmbienteTrabajoRes = "Medio"; }
                    else if (condiciones >= 7 && condiciones < 9) { CondicionesAmbienteTrabajoRes = "Alto"; }
                    else if (condiciones >= 9) { CondicionesAmbienteTrabajoRes = "Muy Alto"; }
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();
                        _CargaTrabajo = _CargaTrabajo + CargaTrabajo;
                    }
                    valorFinal2 = Convert.ToDouble(_CargaTrabajo) / Convert.ToDouble(str.Length);
                    carga = valorFinal2;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //falta de control sobre el trabajo
                        int FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();
                        _FaltaControlSobreTrabajo = _FaltaControlSobreTrabajo + FaltaControlSobreTrabajo;
                    }
                    valorFinal3 = Convert.ToDouble(_FaltaControlSobreTrabajo) / Convert.ToDouble(str.Length);
                    faltaControl = valorFinal3;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //jornada de trabajo
                        int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (34,35) ").FirstOrDefault();
                        _JornadaTrabajo = _JornadaTrabajo + JornadaTrabajo;
                    }
                    valorFinal4 = Convert.ToDouble(_JornadaTrabajo) / Convert.ToDouble(str.Length);
                    jornada = valorFinal4;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Interferencia en la relación trabajo-familia
                        int InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (36,37) ").FirstOrDefault();
                        _InfluenciaTrabajoFueraCentroLaboral = _InfluenciaTrabajoFueraCentroLaboral + InfluenciaTrabajoFueraCentroLaboral;
                    }
                    valorFinal5 = Convert.ToDouble(_InfluenciaTrabajoFueraCentroLaboral) / Convert.ToDouble(str.Length);
                    influencia = valorFinal5;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Liderazgo
                        int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (43,44,45,47,48) ").FirstOrDefault();
                        _Liderazgo = _Liderazgo + Liderazgo;
                    }
                    valorFinal6 = Convert.ToDouble(_Liderazgo) / Convert.ToDouble(str.Length);
                    liderazgo = valorFinal6;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Relaciones en el trabajo
                        int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();
                        _RelacionesTrabajo = _RelacionesTrabajo + RelacionesTrabajo;
                    }

                    valorFinal7 = Convert.ToDouble(_RelacionesTrabajo) / Convert.ToDouble(str.Length);
                    relaciones = valorFinal7;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Violencia
                        int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();
                        _Violencia = _Violencia + Violencia;
                    }
                    valorFinal8 = Convert.ToDouble(_Violencia) / Convert.ToDouble(str.Length);
                    violencia = valorFinal8;
                    // ViewBag.AmbienteTrabajo = valorFinal1;
                    FactoresPropiosActividad = valorFinal2 + valorFinal3;

                    if (FactoresPropiosActividad < 10) { FactoresPropiosActividadRes = "Nulo o Despreciable"; }
                    else if (FactoresPropiosActividad >= 10 && FactoresPropiosActividad < 20) { FactoresPropiosActividadRes = "Bajo"; }
                    else if (FactoresPropiosActividad >= 20 && FactoresPropiosActividad < 30) { FactoresPropiosActividadRes = "Medio"; }
                    else if (FactoresPropiosActividad >= 30 && FactoresPropiosActividad < 40) { FactoresPropiosActividadRes = "Alto"; }
                    else if (FactoresPropiosActividad >= 40) { FactoresPropiosActividadRes = "Muy Alto"; }

                    OrganizacionTiempoTrabajo = valorFinal4 + valorFinal5;

                    if (OrganizacionTiempoTrabajo < 4) { OrganizacionTiempoTrabajoRes = "Nulo o Despreciable"; }
                    else if (OrganizacionTiempoTrabajo >= 4 && OrganizacionTiempoTrabajo < 6) { OrganizacionTiempoTrabajoRes = "Bajo"; }
                    else if (OrganizacionTiempoTrabajo >= 6 && OrganizacionTiempoTrabajo < 9) { OrganizacionTiempoTrabajoRes = "Medio"; }
                    else if (OrganizacionTiempoTrabajo >= 9 && OrganizacionTiempoTrabajo < 12) { OrganizacionTiempoTrabajoRes = "Alto"; }
                    else if (OrganizacionTiempoTrabajo >= 12) { OrganizacionTiempoTrabajoRes = "Muy Alto"; }


                    LiderazgoRelacionesTrabajo = valorFinal6 + valorFinal7 + valorFinal8;

                    if (LiderazgoRelacionesTrabajo < 4) { LiderazgoRelacionesTrabajoRes = "Nulo o Despreciable"; }
                    else if (LiderazgoRelacionesTrabajo >= 4 && LiderazgoRelacionesTrabajo < 6) { LiderazgoRelacionesTrabajoRes = "Bajo"; }
                    else if (LiderazgoRelacionesTrabajo >= 6 && LiderazgoRelacionesTrabajo < 9) { LiderazgoRelacionesTrabajoRes = "Medio"; }
                    else if (LiderazgoRelacionesTrabajo >= 9 && LiderazgoRelacionesTrabajo < 12) { LiderazgoRelacionesTrabajoRes = "Alto"; }
                    else if (LiderazgoRelacionesTrabajo >= 12) { LiderazgoRelacionesTrabajoRes = "Muy Alto"; }

                    //Aqui va el excel

                }
                else
                {

                    double valorFinal1 = 0.00;
                    double valorFinal2 = 0.00;
                    double valorFinal3 = 0.00;
                    double valorFinal4 = 0.00;
                    double valorFinal5 = 0.00;
                    double valorFinal6 = 0.00;
                    double valorFinal7 = 0.00;
                    double valorFinal8 = 0.00;
                    double valorFinal9 = 0.00;
                    double valorFinal10 = 0.00;
                    int _CondicionesAmbienteTrabajo = 0;
                    int _CargaTrabajo = 0;
                    int _FaltaControlTrabajo = 0;
                    int _JornadaTrabajo = 0;
                    int _InterferenciaRelacionTrabajoFamilia = 0;
                    int _Liderazgo = 0;
                    int _RelacionesTrabajo = 0;
                    int _Violencia = 0;
                    int _ReconocimientoDesempeño = 0;
                    int _InsuficienteSentido = 0;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (69,70,71,72,73) ").FirstOrDefault();
                        _CondicionesAmbienteTrabajo = _CondicionesAmbienteTrabajo + CondicionesAmbienteTrabajo;
                    }
                    valorFinal1 = Convert.ToDouble(_CondicionesAmbienteTrabajo) / Convert.ToDouble(str.Length);
                    condiciones = valorFinal1;
                    if (condiciones < 5) { CondicionesAmbienteTrabajoRes = "Nulo o Despreciable"; }
                    else if (condiciones >= 5 && condiciones < 9) { CondicionesAmbienteTrabajoRes = "Bajo"; }
                    else if (condiciones >= 9 && condiciones < 11) { CondicionesAmbienteTrabajoRes = "Medio"; }
                    else if (condiciones >= 11 && condiciones < 14) { CondicionesAmbienteTrabajoRes = "Alto"; }
                    else if (condiciones >= 14) { CondicionesAmbienteTrabajoRes = "Muy Alto"; }

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //carga de trabajo
                        int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();
                        _CargaTrabajo = _CargaTrabajo + CargaTrabajo;
                    }
                    valorFinal2 = Convert.ToDouble(_CargaTrabajo) / Convert.ToDouble(str.Length);
                    carga = valorFinal2;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Falta de control sobre el trabajo
                        int FaltaControlTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();
                        _FaltaControlTrabajo = _FaltaControlTrabajo + FaltaControlTrabajo;
                    }
                    valorFinal3 = Convert.ToDouble(_FaltaControlTrabajo) / Convert.ToDouble(str.Length);
                    faltaControl = valorFinal3;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Jornada de trabajo
                        int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (85,86) ").FirstOrDefault();
                        _JornadaTrabajo = _JornadaTrabajo + JornadaTrabajo;
                    }
                    valorFinal4 = Convert.ToDouble(_JornadaTrabajo) / Convert.ToDouble(str.Length);
                    jornada = valorFinal4;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Interferencia en la relación trabajo-familia
                        int InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (87,88,89,90) ").FirstOrDefault();
                        _InterferenciaRelacionTrabajoFamilia = _InterferenciaRelacionTrabajoFamilia + InterferenciaRelacionTrabajoFamilia;
                    }
                    valorFinal5 = Convert.ToDouble(_InterferenciaRelacionTrabajoFamilia) / Convert.ToDouble(str.Length);
                    influencia = valorFinal5;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Liderazgo
                        int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();
                        _Liderazgo = _Liderazgo + Liderazgo;
                    }
                    valorFinal6 = Convert.ToDouble(_Liderazgo) / Convert.ToDouble(str.Length);
                    liderazgo = valorFinal6;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Relaciones en el trabajo
                        int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();
                        _RelacionesTrabajo = _RelacionesTrabajo + RelacionesTrabajo;
                    }
                    valorFinal7 = Convert.ToDouble(_RelacionesTrabajo) / Convert.ToDouble(str.Length);
                    relaciones = valorFinal7;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Violencia
                        int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();
                        _Violencia = _Violencia + Violencia;
                    }
                    valorFinal8 = Convert.ToDouble(_Violencia) / Convert.ToDouble(str.Length);
                    violencia = valorFinal8;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Reconocimiento del desempeño
                        int ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();
                        _ReconocimientoDesempeño = _ReconocimientoDesempeño + ReconocimientoDesempeño;
                    }
                    valorFinal9 = Convert.ToDouble(_ReconocimientoDesempeño) / Convert.ToDouble(str.Length);
                    reconocimiento = valorFinal9;
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Insuficiente sentido de pertenencia e, inestabilidad
                        int InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (124,121,122,123) ").FirstOrDefault();
                        _InsuficienteSentido = _InsuficienteSentido + InsuficienteSentido;
                    }
                    valorFinal10 = Convert.ToDouble(_InsuficienteSentido) / Convert.ToDouble(str.Length);
                    insuficiente = valorFinal10;
                    // ViewBag.AmbienteTrabajo = valorFinal1;
                    FactoresPropiosActividad = valorFinal2 + valorFinal3;

                    if (FactoresPropiosActividad < 15) { FactoresPropiosActividadRes = "Nulo o Despreciable"; }
                    else if (FactoresPropiosActividad >= 15 && FactoresPropiosActividad < 30) { FactoresPropiosActividadRes = "Bajo"; }
                    else if (FactoresPropiosActividad >= 30 && FactoresPropiosActividad < 45) { FactoresPropiosActividadRes = "Medio"; }
                    else if (FactoresPropiosActividad >= 45 && FactoresPropiosActividad < 60) { FactoresPropiosActividadRes = "Alto"; }
                    else if (FactoresPropiosActividad >= 60) { FactoresPropiosActividadRes = "Muy Alto"; }

                    OrganizacionTiempoTrabajo = valorFinal4 + valorFinal5;

                    if (OrganizacionTiempoTrabajo < 5) { OrganizacionTiempoTrabajoRes = "Nulo o Despreciable"; }
                    else if (OrganizacionTiempoTrabajo >= 5 && OrganizacionTiempoTrabajo < 7) { OrganizacionTiempoTrabajoRes = "Bajo"; }
                    else if (OrganizacionTiempoTrabajo >= 7 && OrganizacionTiempoTrabajo < 10) { OrganizacionTiempoTrabajoRes = "Medio"; }
                    else if (OrganizacionTiempoTrabajo >= 10 && OrganizacionTiempoTrabajo < 13) { OrganizacionTiempoTrabajoRes = "Alto"; }
                    else if (OrganizacionTiempoTrabajo >= 13) { OrganizacionTiempoTrabajoRes = "Muy Alto"; }

                    LiderazgoRelacionesTrabajo = valorFinal6 + valorFinal7 + valorFinal8;

                    if (LiderazgoRelacionesTrabajo < 14) { LiderazgoRelacionesTrabajoRes = "Nulo o Despreciable"; }
                    else if (LiderazgoRelacionesTrabajo >= 14 && LiderazgoRelacionesTrabajo < 29) { LiderazgoRelacionesTrabajoRes = "Bajo"; }
                    else if (LiderazgoRelacionesTrabajo >= 29 && LiderazgoRelacionesTrabajo < 42) { LiderazgoRelacionesTrabajoRes = "Medio"; }
                    else if (LiderazgoRelacionesTrabajo >= 42 && LiderazgoRelacionesTrabajo < 58) { LiderazgoRelacionesTrabajoRes = "Alto"; }
                    else if (LiderazgoRelacionesTrabajo >= 58) { LiderazgoRelacionesTrabajoRes = "Muy Alto"; }

                    EntornoOrganizacional = valorFinal9 + valorFinal10;

                    if (EntornoOrganizacional < 10) { EntornoOrganizacionalRes = "Nulo o Despreciable"; }
                    else if (EntornoOrganizacional >= 10 && EntornoOrganizacional < 14) { EntornoOrganizacionalRes = "Bajo"; }
                    else if (EntornoOrganizacional >= 14 && EntornoOrganizacional < 18) { EntornoOrganizacionalRes = "Medio"; }
                    else if (EntornoOrganizacional >= 18 && EntornoOrganizacional < 23) { EntornoOrganizacionalRes = "Alto"; }
                    else if (EntornoOrganizacional >= 23) { EntornoOrganizacionalRes = "Muy Alto"; }

                }

            }

            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
            iTextSharp.text.Font font = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

            Document doc = new Document(iTextSharp.text.PageSize.A4_LANDSCAPE, 30, 30, 10, 10);
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                if (No_Empleados<51) 
                {

                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();
                    Paragraph espacio = new Paragraph(" ");
                    Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 40.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                    Paragraph firma = new Paragraph("FIRMA");
                    Paragraph title = new Paragraph("Consultoría y Soluciones en Seguridad en el Trabajo", font1);
                    title.Alignment = Element.ALIGN_CENTER;
                    Paragraph title2 = new Paragraph("RESULTADOS DE CATEGORÍA POR EMPRESA", font1);
                    title2.Alignment = Element.ALIGN_CENTER;

                    doc.Add(title);
                    doc.Add(title2);
                    doc.Add(espacio);

                    Paragraph Nombre_emp = new Paragraph("NOMBRE DE LA EMPRESA: " + nombre_empresa, font1);
                    Nombre_emp.Alignment = Element.ALIGN_LEFT;
                    doc.Add(Nombre_emp);
                    doc.Add(espacio);



                    //Creando la tabla
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas
                    float[] valores = new float[3] { 150, 30, 30 };
                    tabla.SetWidths(valores);

                    //Creando celdas agregando contenido
                    PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Categoría", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda1);

                    PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda2);

                    PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                    celda3.BackgroundColor = new BaseColor(240, 240, 240);
                    celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda3);

                    PdfPCell celda4 = new PdfPCell(new Phrase(condiciones.ToString(), font));
                    celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda5 = new PdfPCell(new Phrase(FactoresPropiosActividad.ToString(), font));
                    celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda6 = new PdfPCell(new Phrase(OrganizacionTiempoTrabajo.ToString(), font));
                    celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda7 = new PdfPCell(new Phrase(LiderazgoRelacionesTrabajo.ToString(), font));
                    celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda8 = new PdfPCell(new Phrase(EntornoOrganizacional.ToString(), font));
                    celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    //Poniendo datos en la la tabla
                    tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                    tabla.AddCell(celda4);
                    tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Factores propios de la actividad", font)));
                    tabla.AddCell(celda5);
                    tabla.AddCell(new PdfPCell(new Phrase(FactoresPropiosActividadRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Organización del tiempo de trabajo", font)));
                    tabla.AddCell(celda6);
                    tabla.AddCell(new PdfPCell(new Phrase(OrganizacionTiempoTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Liderazgo y relaciones en el trabajo", font)));
                    tabla.AddCell(celda7);
                    tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRelacionesTrabajoRes.ToString(), font)));

             


                    //Agregando la tabla al documento
                    doc.Add(tabla);

                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(espacio);

                    doc.Add(linea);
                    firma.Alignment = Element.ALIGN_CENTER;
                    doc.Add(firma);
                    doc.Close();

                    buffer = ms.ToArray();
                } 
                else
                {

                    PdfWriter.GetInstance(doc, ms);
                    doc.Open();
                    Paragraph espacio = new Paragraph(" ");
                    Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 40.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)));
                    Paragraph firma = new Paragraph("FIRMA");
                    Paragraph title = new Paragraph("Consultoría y Soluciones en Seguridad en el Trabajo", font1);
                    title.Alignment = Element.ALIGN_CENTER;
                    Paragraph title2 = new Paragraph("RESULTADOS DE CATEGORÍA POR EMPRESA", font1);
                    title2.Alignment = Element.ALIGN_CENTER;

                    doc.Add(title);
                    doc.Add(title2);
                    doc.Add(espacio);

                    Paragraph Nombre_emp = new Paragraph("NOMBRE DE LA EMPRESA: " + nombre_empresa, font1);
                    Nombre_emp.Alignment = Element.ALIGN_LEFT;
                    doc.Add(Nombre_emp);
                    doc.Add(espacio);



                    //Creando la tabla
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas
                    float[] valores = new float[3] { 150, 30, 30 };
                    tabla.SetWidths(valores);

                    //Creando celdas agregando contenido
                    PdfPCell celda1 = new PdfPCell(new Phrase("Resultado de Categoría", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda1);

                    PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda2);

                    PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                    celda3.BackgroundColor = new BaseColor(240, 240, 240);
                    celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda3);

                    PdfPCell celda4 = new PdfPCell(new Phrase(condiciones.ToString(), font));
                    celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda5 = new PdfPCell(new Phrase(FactoresPropiosActividad.ToString(), font));
                    celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda6 = new PdfPCell(new Phrase(OrganizacionTiempoTrabajo.ToString(), font));
                    celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda7 = new PdfPCell(new Phrase(LiderazgoRelacionesTrabajo.ToString(), font));
                    celda7.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda8 = new PdfPCell(new Phrase(EntornoOrganizacional.ToString(), font));
                    celda8.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    //Poniendo datos en la la tabla
                    tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                    tabla.AddCell(celda4);
                    tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Factores propios de la actividad", font)));
                    tabla.AddCell(celda5);
                    tabla.AddCell(new PdfPCell(new Phrase(FactoresPropiosActividadRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Organización del tiempo de trabajo", font)));
                    tabla.AddCell(celda6);
                    tabla.AddCell(new PdfPCell(new Phrase(OrganizacionTiempoTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Liderazgo y relaciones en el trabajo", font)));
                    tabla.AddCell(celda7);
                    tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRelacionesTrabajoRes.ToString(), font)));

                    tabla.AddCell(new PdfPCell(new Phrase("Entorno organizacional", font)));
                    tabla.AddCell(celda8);
                    tabla.AddCell(new PdfPCell(new Phrase(EntornoOrganizacionalRes.ToString(), font)));


                    //Agregando la tabla al documento
                    doc.Add(tabla);

                    doc.Add(espacio);
                    doc.Add(espacio);
                    doc.Add(espacio);

                    doc.Add(linea);
                    firma.Alignment = Element.ALIGN_CENTER;
                    doc.Add(firma);
                    doc.Close();

                    buffer = ms.ToArray();
                }

            }
            return File(buffer, "application/pdf");
        }

        public FileResult PDFResultadoPorEmpresaFin(string ids_usuarios)
        {
            int id_empresa;
            String num_empleados;
            int No_Empleados;
            string nombre_empresa;
            String[] str = ids_usuarios.Split(',');

            double CalificacionFinalCuestionarioIII = 0.00;
            string CalificacionFinalCuestionarioIIIRes = "";
            string riesgo = "";


            using (var db = new csstdura_encuestaEntities())
            {
                //con el primer registro sabemos de donde son los empleados(la empresa)
                id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + str[0]).FirstOrDefault();
                nombre_empresa = db.Database.SqlQuery<String>("select emp_descrip from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                No_Empleados = Convert.ToInt32(num_empleados);


                if (No_Empleados < 51)
                {
                    double valorFinal1 = 0.00;
                    double valorFinal2 = 0.00;
                    double valorFinal3 = 0.00;
                    double valorFinal4 = 0.00;
                    double valorFinal5 = 0.00;
                    double valorFinal6 = 0.00;
                    double valorFinal7 = 0.00;
                    double valorFinal8 = 0.00;
                    int _CondicionesAmbienteTrabajo = 0;
                    int _CargaTrabajo = 0;
                    int _FaltaControlSobreTrabajo = 0;
                    int _JornadaTrabajo = 0;
                    int _InfluenciaTrabajoFueraCentroLaboral = 0;
                    int _Liderazgo = 0;
                    int _RelacionesTrabajo = 0;
                    int _Violencia = 0;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + value + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();
                        _CondicionesAmbienteTrabajo = _CondicionesAmbienteTrabajo + CondicionesAmbienteTrabajo;
                    }
                    valorFinal1 = Convert.ToDouble(_CondicionesAmbienteTrabajo) / Convert.ToDouble(str.Length);
                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();
                        _CargaTrabajo = _CargaTrabajo + CargaTrabajo;
                    }
                    valorFinal2 = Convert.ToDouble(_CargaTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //falta de control sobre el trabajo
                        int FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();
                        _FaltaControlSobreTrabajo = _FaltaControlSobreTrabajo + FaltaControlSobreTrabajo;
                    }
                    valorFinal3 = Convert.ToDouble(_FaltaControlSobreTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //jornada de trabajo
                        int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (34,35) ").FirstOrDefault();
                        _JornadaTrabajo = _JornadaTrabajo + JornadaTrabajo;
                    }
                    valorFinal4 = Convert.ToDouble(_JornadaTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Interferencia en la relación trabajo-familia
                        int InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (36,37) ").FirstOrDefault();
                        _InfluenciaTrabajoFueraCentroLaboral = _InfluenciaTrabajoFueraCentroLaboral + InfluenciaTrabajoFueraCentroLaboral;
                    }
                    valorFinal5 = Convert.ToDouble(_InfluenciaTrabajoFueraCentroLaboral) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Liderazgo
                        int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (43,44,45,47,48) ").FirstOrDefault();
                        _Liderazgo = _Liderazgo + Liderazgo;
                    }
                    valorFinal6 = Convert.ToDouble(_Liderazgo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Relaciones en el trabajo
                        int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();
                        _RelacionesTrabajo = _RelacionesTrabajo + RelacionesTrabajo;
                    }
                    valorFinal7 = Convert.ToDouble(_RelacionesTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Violencia
                        int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 2 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();
                        _Violencia = _Violencia + Violencia;
                    }
                    valorFinal8 = Convert.ToDouble(_Violencia) / Convert.ToDouble(str.Length);

                    CalificacionFinalCuestionarioIII = valorFinal1 + valorFinal2 + valorFinal3 +
                                                            valorFinal4 + valorFinal5 + valorFinal6 +
                                                            valorFinal7 + valorFinal8;

                    if (CalificacionFinalCuestionarioIII < 20)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Nulo o Despreciable";
                        riesgo = "El riesgo resulta despreciable por lo que no se requiere medidas adicionales.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 20 && CalificacionFinalCuestionarioIII < 45)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Bajo";
                        riesgo = "Es necesario una mayor difusión de la política de prevención de riesgos psicosociales y programas para: la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 45 && CalificacionFinalCuestionarioIII < 70)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Medio";
                        riesgo = "Medio	Se requiere revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión, mediante un Programa de intervención.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 70 && CalificacionFinalCuestionarioIII < 90)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Alto";
                        riesgo = "Se requiere realizar un análisis de cada categoría y dominio, de manera que se puedan determinar las acciones de intervención apropiadas a través de un Programa de intervención, que podrá incluir una evaluación específica1 y deberá incluir una campaña de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 90)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Muy Alto";
                        riesgo = "Se requiere realizar el análisis de cada categoría y dominio para establecer las acciones de intervención apropiadas, mediante un Programa de intervención que deberá incluir evaluaciones específicas1, y contemplar campañas de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión.";
                    }
                }
                else
                {
                    double valorFinal1 = 0.00;
                    double valorFinal2 = 0.00;
                    double valorFinal3 = 0.00;
                    double valorFinal4 = 0.00;
                    double valorFinal5 = 0.00;
                    double valorFinal6 = 0.00;
                    double valorFinal7 = 0.00;
                    double valorFinal8 = 0.00;
                    double valorFinal9 = 0.00;
                    double valorFinal10 = 0.00;
                    int _CondicionesAmbienteTrabajo = 0;
                    int _CargaTrabajo = 0;
                    int _FaltaControlTrabajo = 0;
                    int _JornadaTrabajo = 0;
                    int _InterferenciaRelacionTrabajoFamilia = 0;
                    int _Liderazgo = 0;
                    int _RelacionesTrabajo = 0;
                    int _Violencia = 0;
                    int _ReconocimientoDesempeño = 0;
                    int _InsuficienteSentido = 0;

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //condiciones en el ambiente de trabajo
                        int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (69,70,71,72,73) ").FirstOrDefault();
                        _CondicionesAmbienteTrabajo = _CondicionesAmbienteTrabajo + CondicionesAmbienteTrabajo;
                    }
                    valorFinal1 = Convert.ToDouble(_CondicionesAmbienteTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //carga de trabajo
                        int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();
                        _CargaTrabajo = _CargaTrabajo + CargaTrabajo;
                    }
                    valorFinal2 = Convert.ToDouble(_CargaTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Falta de control sobre el trabajo
                        int FaltaControlTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();
                        _FaltaControlTrabajo = _FaltaControlTrabajo + FaltaControlTrabajo;
                    }
                    valorFinal3 = Convert.ToDouble(_FaltaControlTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Jornada de trabajo
                        int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (85,86) ").FirstOrDefault();
                        _JornadaTrabajo = _JornadaTrabajo + JornadaTrabajo;
                    }
                    valorFinal4 = Convert.ToDouble(_JornadaTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Interferencia en la relación trabajo-familia
                        int InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (87,88,89,90) ").FirstOrDefault();
                        _InterferenciaRelacionTrabajoFamilia = _InterferenciaRelacionTrabajoFamilia + InterferenciaRelacionTrabajoFamilia;
                    }
                    valorFinal5 = Convert.ToDouble(_InterferenciaRelacionTrabajoFamilia) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Liderazgo
                        int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();
                        _Liderazgo = _Liderazgo + Liderazgo;
                    }
                    valorFinal6 = Convert.ToDouble(_Liderazgo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Relaciones en el trabajo
                        int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();
                        _RelacionesTrabajo = _RelacionesTrabajo + RelacionesTrabajo;
                    }
                    valorFinal7 = Convert.ToDouble(_RelacionesTrabajo) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Violencia
                        int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();
                        _Violencia = _Violencia + Violencia;
                    }
                    valorFinal8 = Convert.ToDouble(_Violencia) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Reconocimiento del desempeño
                        int ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();
                        _ReconocimientoDesempeño = _ReconocimientoDesempeño + ReconocimientoDesempeño;
                    }
                    valorFinal9 = Convert.ToDouble(_ReconocimientoDesempeño) / Convert.ToDouble(str.Length);

                    for (int x = 0; x < str.Length; x++)
                    {
                        int value = Convert.ToInt32(str[x]);
                        //Insuficiente sentido de pertenencia e, inestabilidad
                        int InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                                " from encuesta_det_encuesta, encuesta_resultados " +
                                                                " where denc_encu_id = 3 " +
                                                                " and resu_denc_id = denc_id " +
                                                                " and resu_usua_id = " + value + " " +
                                                                " and denc_id in (124,121,122,123) ").FirstOrDefault();
                        _InsuficienteSentido = _InsuficienteSentido + InsuficienteSentido;
                    }
                    valorFinal10 = Convert.ToDouble(_InsuficienteSentido) / Convert.ToDouble(str.Length);

                    CalificacionFinalCuestionarioIII = valorFinal1 + valorFinal2 + valorFinal3 +
                                                            valorFinal4 + valorFinal5 + valorFinal6 +
                                                            valorFinal7 + valorFinal8 + valorFinal9 +
                                                            valorFinal10;
                    if (CalificacionFinalCuestionarioIII < 50)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Nulo o Despreciable";
                        riesgo = "El riesgo resulta despreciable por lo que no se requiere medidas adicionales.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 50 && CalificacionFinalCuestionarioIII < 75)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Bajo";
                        riesgo = "Es necesario una mayor difusión de la política de prevención de riesgos psicosociales y programas para: la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 75 && CalificacionFinalCuestionarioIII < 99)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Medio";
                        riesgo = "Medio	Se requiere revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión, mediante un Programa de intervención.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 99 && CalificacionFinalCuestionarioIII < 140)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Alto";
                        riesgo = "Se requiere realizar un análisis de cada categoría y dominio, de manera que se puedan determinar las acciones de intervención apropiadas a través de un Programa de intervención, que podrá incluir una evaluación específica1 y deberá incluir una campaña de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión.";
                    }
                    else if (CalificacionFinalCuestionarioIII >= 140)
                    {
                        CalificacionFinalCuestionarioIIIRes = "Muy Alto";
                        riesgo = "Se requiere realizar el análisis de cada categoría y dominio para establecer las acciones de intervención apropiadas, mediante un Programa de intervención que deberá incluir evaluaciones específicas1, y contemplar campañas de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión.";
                    }




                }

                //aqui va el pdf
                iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
                iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                    Paragraph title2 = new Paragraph("RESULTADOS FINALES POR EMPRESA", font1);
                    title2.Alignment = Element.ALIGN_CENTER;

                    doc.Add(title);
                    doc.Add(title2);
                    doc.Add(espacio);

                    Paragraph Nombre_emp = new Paragraph("NOMBRE DE LA EMPRESA: " + nombre_empresa, font1);
                    Nombre_emp.Alignment = Element.ALIGN_LEFT;
                    doc.Add(Nombre_emp);
                    doc.Add(espacio);

                    //Creando la tabla
                    PdfPTable tabla = new PdfPTable(4);
                    tabla.WidthPercentage = 100f;
                    //Asignando los anchos de las columnas
                    float[] valores = new float[4] { 30, 30, 30, 150 };
                    tabla.SetWidths(valores);

                    //Creando celdas agregando contenido
                    PdfPCell celda1 = new PdfPCell(new Phrase("Resultado Final", font));
                    celda1.BackgroundColor = new BaseColor(240, 240, 240);
                    celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda1);

                    PdfPCell celda2 = new PdfPCell(new Phrase("Suma Total", font));
                    celda2.BackgroundColor = new BaseColor(240, 240, 240);
                    celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda2);

                    PdfPCell celda3 = new PdfPCell(new Phrase("Nivel de Riesgo", font));
                    celda3.BackgroundColor = new BaseColor(240, 240, 240);
                    celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda3);

                    PdfPCell celda4 = new PdfPCell(new Phrase("Necesidad de acción", font));
                    celda4.BackgroundColor = new BaseColor(240, 240, 240);
                    celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    tabla.AddCell(celda4);

                    PdfPCell celda5 = new PdfPCell(new Phrase(CalificacionFinalCuestionarioIII.ToString(), font));
                    celda5.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda6 = new PdfPCell(new Phrase(CalificacionFinalCuestionarioIIIRes.ToString(), font));
                    celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda7 = new PdfPCell(new Phrase(riesgo.ToString(), font));
                    celda7.HorizontalAlignment = PdfPCell.ALIGN_JUSTIFIED;


                    //Poniendo datos en la la tabla
                    tabla.AddCell(new PdfPCell(new Phrase("Calificación final del cuestionario", font)));
                    tabla.AddCell(celda5);
                    tabla.AddCell(celda6);
                    tabla.AddCell(celda7);

                    //Agregando la tabla al documento
                    doc.Add(tabla);

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

        public FileResult PDFAtencionMedica(string ids_usuarios)
        {
            //ViewBag.ids = ids_usuarios;

            List<encuesta_usuariosCLS> listaEmpleado = null;
            String[] str = ids_usuarios.Split(',');
            int id_empresa = 0;
            string nombre_empresa = "";
            using (var db = new csstdura_encuestaEntities())
            {
                id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + str[0]).FirstOrDefault();
                nombre_empresa = db.Database.SqlQuery<String>("select emp_descrip from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();

                List<int> Acontecimiento = new List<int>() { 1, 2, 3, 4, 5, 6 };
                List<int> Recuerdos = new List<int>() { 7, 8 };
                List<int> Esfuerzo = new List<int>() { 9, 10, 11, 12, 13, 14, 15 };
                List<int> Afectación = new List<int>() { 16, 17, 18, 19, 20 };
                List<int> intUsuarios = new List<int>() { };


                for (int x = 0; x < str.Length; x++)
                {
                    int value = Convert.ToInt32(str[x]);
                    intUsuarios.Add(value);
                }


                listaEmpleado = (from resultado in db.encuesta_resultados
                                 join empleado in db.encuesta_usuarios
                                 on resultado.resu_usua_id equals empleado.usua_id
                                 where Acontecimiento.Contains((int)resultado.resu_denc_id)
                                 && resultado.resu_resultado == "SI"
                                 && intUsuarios.Contains((int)resultado.resu_usua_id)
                                 group resultado by new { resultado.resu_usua_id, resultado.resu_resultado, empleado.usua_nombre } into grp
                                 orderby grp.Key.usua_nombre

                                 select new encuesta_usuariosCLS
                                 {
                                     resu_usua_id = grp.Key.resu_usua_id,
                                     resu_resultado = grp.Count(),
                                     usua_nombre = grp.Key.usua_nombre,
                                     resu_seccion_id = 1,
                                     resu_seccion = "I.- Acontecimiento traumático severo"
                                 }).Union
                                 (
                                    from resultado in db.encuesta_resultados
                                    join empleado in db.encuesta_usuarios
                                    on resultado.resu_usua_id equals empleado.usua_id
                                    where Recuerdos.Contains((int)resultado.resu_denc_id)
                                    && resultado.resu_resultado == "SI"
                                    && intUsuarios.Contains((int)resultado.resu_usua_id)
                                    group resultado by new { resultado.resu_usua_id, resultado.resu_resultado, empleado.usua_nombre } into grp
                                    orderby grp.Key.usua_nombre

                                    select new encuesta_usuariosCLS
                                    {
                                        resu_usua_id = grp.Key.resu_usua_id,
                                        resu_resultado = grp.Count(),
                                        usua_nombre = grp.Key.usua_nombre,
                                        resu_seccion_id = 2,
                                        resu_seccion = "II.- Recuerdos persistentes sobre el acontecimiento"
                                    }).Union
                                 (
                                    from resultado in db.encuesta_resultados
                                    join empleado in db.encuesta_usuarios
                                    on resultado.resu_usua_id equals empleado.usua_id
                                    where Esfuerzo.Contains((int)resultado.resu_denc_id)
                                    && resultado.resu_resultado == "SI"
                                    && intUsuarios.Contains((int)resultado.resu_usua_id)
                                    group resultado by new { resultado.resu_usua_id, resultado.resu_resultado, empleado.usua_nombre } into grp
                                    orderby grp.Key.usua_nombre

                                    select new encuesta_usuariosCLS
                                    {
                                        resu_usua_id = grp.Key.resu_usua_id,
                                        resu_resultado = grp.Count(),
                                        usua_nombre = grp.Key.usua_nombre,
                                        resu_seccion_id = 3,
                                        resu_seccion = "III.- Esfuerzo por evitar circunstancias parecidas o asociadas al acontecimiento"
                                    }).Union
                                 (
                                    from resultado in db.encuesta_resultados
                                    join empleado in db.encuesta_usuarios
                                    on resultado.resu_usua_id equals empleado.usua_id
                                    where Afectación.Contains((int)resultado.resu_denc_id)
                                    && resultado.resu_resultado == "SI"
                                    && intUsuarios.Contains((int)resultado.resu_usua_id)
                                    group resultado by new { resultado.resu_usua_id, resultado.resu_resultado, empleado.usua_nombre } into grp
                                    orderby grp.Key.usua_nombre

                                    select new encuesta_usuariosCLS
                                    {
                                        resu_usua_id = grp.Key.resu_usua_id,
                                        resu_resultado = grp.Count(),
                                        usua_nombre = grp.Key.usua_nombre,
                                        resu_seccion_id = 4,
                                        resu_seccion = "IV.- Afectación"
                                    }).Distinct().ToList();

            }
            //aqui va el pdf
            iTextSharp.text.Font font1 = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL);
            iTextSharp.text.Font font2 = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);
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
                Paragraph title2 = new Paragraph("ATENCIÓN MÉDICA POR EMPRESA", font1);
                title2.Alignment = Element.ALIGN_CENTER;

                doc.Add(title);
                doc.Add(title2);
                doc.Add(espacio);

                Paragraph Nombre_emp = new Paragraph("NOMBRE DE LA EMPRESA: " + nombre_empresa, font1);
                Nombre_emp.Alignment = Element.ALIGN_LEFT;
                doc.Add(Nombre_emp);
                doc.Add(espacio);

                //Creando la tabla
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100f;
                //Asignando los anchos de las columnas
                float[] valores = new float[4] { 50, 30, 100, 50 };
                tabla.SetWidths(valores);

                //Creando celdas agregando contenido
                PdfPCell celda1 = new PdfPCell(new Phrase("Nombre", font));
                celda1.BackgroundColor = new BaseColor(240, 240, 240);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Resultado (Suma de SI)", font));
                celda2.BackgroundColor = new BaseColor(240, 240, 240);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Sección", font));
                celda3.BackgroundColor = new BaseColor(240, 240, 240);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda3);

                PdfPCell celda4 = new PdfPCell(new Phrase("Acción", font));
                celda4.BackgroundColor = new BaseColor(240, 240, 240);
                celda4.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                tabla.AddCell(celda4);

                int nroregistros = listaEmpleado.Count();
                string accionRes = "";
                for (int i = 0; i < nroregistros; i++)
                {
                    Console.WriteLine(listaEmpleado[i].resu_seccion);
                    if (listaEmpleado[i].resu_seccion_id.Equals(1))
                    {
                        if (listaEmpleado[i].resu_resultado > 0)
                        {
                            accionRes = "El trabajador REQUIERE atención clínica";
                        }
                        else
                        {
                            accionRes = "El trabajador NO REQUIERE atención clínica";

                        }
                    }
                    if (listaEmpleado[i].resu_seccion_id.Equals(2))
                    {
                        if (listaEmpleado[i].resu_resultado > 0)
                        {
                            accionRes = "El trabajador REQUIERE atención clínica";
                        }
                        else
                        {
                            accionRes = "El trabajador NO REQUIERE atención clínica";

                        }
                    }
                    if (listaEmpleado[i].resu_seccion_id.Equals(3))
                    {
                        if (listaEmpleado[i].resu_resultado > 2)
                        {
                            accionRes = "El trabajador REQUIERE atención clínica";
                        }
                        else
                        {
                            accionRes = "El trabajador NO REQUIERE atención clínica";

                        }
                    }
                    if (listaEmpleado[i].resu_seccion_id.Equals(4))
                    {
                        if (listaEmpleado[i].resu_resultado > 1)
                        {
                            accionRes = "El trabajador REQUIERE atención clínica";
                        }
                        else
                        {
                            accionRes = "El trabajador NO REQUIERE atención clínica";

                        }
                    }
                    PdfPCell celda5 = new PdfPCell(new Phrase(listaEmpleado[i].usua_nombre.ToString(), font));
                    celda5.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell celda6 = new PdfPCell(new Phrase(listaEmpleado[i].resu_resultado.ToString(), font));
                    celda6.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell celda7 = new PdfPCell(new Phrase(listaEmpleado[i].resu_seccion.ToString(), font));
                    celda7.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell celda8 = new PdfPCell(new Phrase(accionRes.ToString(), font));
                    celda8.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    //Poniendo datos en la la tabla
            
                    tabla.AddCell(celda5);
                    tabla.AddCell(celda6);
                    tabla.AddCell(celda7);
                    tabla.AddCell(celda8);
                }


                //Agregando la tabla al documento
                doc.Add(tabla);

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