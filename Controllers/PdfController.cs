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



                //Poniendo datos en la la tabla
                tabla.AddCell(new PdfPCell(new Phrase("Condiciones en el ambiente de trabajo", font)));
                tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajo.ToString(), font)));
                tabla.AddCell(new PdfPCell(new Phrase(CondicionesAmbienteTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Carga de trabajo", font)));
                tabla.AddCell(new PdfPCell(new Phrase(CargaTrabajo.ToString(), font)));
                tabla.AddCell(new PdfPCell(new Phrase(CargaTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Falta de control sobre el trabajo", font)));
                tabla.AddCell(new PdfPCell(new Phrase(FaltaControlSobreTrabajo.ToString(), font)));
                tabla.AddCell(new PdfPCell(new Phrase(FaltaControlSobreTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Jornada de trabajo", font)));
                tabla.AddCell(new PdfPCell(new Phrase(JornadaTrabajo.ToString(), font)));
                tabla.AddCell(new PdfPCell(new Phrase(JornadaTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Interferencia en la relación trabajo-familia", font)));
                tabla.AddCell(new PdfPCell(new Phrase(InfluenciaTrabajoFueraCentroLaboral.ToString(), font)));
                tabla.AddCell(new PdfPCell(new Phrase(InfluenciaTrabajoFueraCentroLaboralRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Liderazgo", font)));
                tabla.AddCell(new PdfPCell(new Phrase(Liderazgo.ToString(), font)));
                tabla.AddCell(new PdfPCell(new Phrase(LiderazgoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Relaciones en el Trabajo", font)));
                tabla.AddCell(new PdfPCell(new Phrase(RelacionesTrabajo.ToString(), font)));
                tabla.AddCell(new PdfPCell(new Phrase(RelacionesTrabajoRes.ToString(), font)));

                tabla.AddCell(new PdfPCell(new Phrase("Violencia", font)));
                tabla.AddCell(new PdfPCell(new Phrase(Violencia.ToString(), font)));
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

    }
}