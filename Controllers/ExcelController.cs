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

    public class ExcelController : Controller
    {
        // GET: Excel
        public ActionResult Index()
        {
            return View();
        }

        public FileResult generarExcelEmpleados()
        {

            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                
                //Crear una hoja
                ep.Workbook.Worksheets.Add("Reporte de Empleados");
                ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                //Ponemos nombres de las columnas
                ew.Cells[1, 1].Value = "ID";
                ew.Cells[1, 2].Value = "Nombre";
                ew.Cells[1, 3].Value = "Empresa";
                ew.Cells[1, 4].Value = "Fecha de aplicación";
                ew.Cells[1, 5].Value = "Estatus";
                ew.Cells[1, 6].Value = "Nombre de usuario";
                ew.Cells[1, 7].Value = "Fecha de Alta";
                ew.Cells[1, 8].Value = "Fecha de cancelación";
                ew.Cells[1, 9].Value = "Genero";
                ew.Cells[1, 10].Value = "Edad";
                ew.Cells[1, 11].Value = "Estado Civil";
                ew.Cells[1, 12].Value = "Sin formación";
                ew.Cells[1, 13].Value = "Primaria";
                ew.Cells[1, 14].Value = "Secunadaria";
                ew.Cells[1, 15].Value = "Preparatoria";
                ew.Cells[1, 16].Value = "Técnico";
                ew.Cells[1, 17].Value = "Licenciatura";
                ew.Cells[1, 18].Value = "Maestría";
                ew.Cells[1, 19].Value = "Doctorado";
                ew.Cells[1, 20].Value = "Tipo de puesto";
                ew.Cells[1, 21].Value = "Tipo de contratación";
                ew.Cells[1, 22].Value = "Tipo de personal ";
                ew.Cells[1, 23].Value = "Tipo de jornada";
                ew.Cells[1, 24].Value = "Rotación de turno";
                ew.Cells[1, 25].Value = "Tiempo en puesto";
                ew.Cells[1, 26].Value = "Experiencia laboral";
                ew.Cells[1, 27].Value = "Presento Encuesta";

                ew.Column(1).Width = 10;
                ew.Column(2).Width = 30;
                ew.Column(3).Width = 30;
                ew.Column(4).Width = 30;
                ew.Column(5).Width = 10;
                ew.Column(6).Width = 30;
                ew.Column(7).Width = 30;
                ew.Column(8).Width = 30;
                ew.Column(9).Width = 10;
                ew.Column(10).Width = 10;
                ew.Column(11).Width = 10;
                ew.Column(12).Width = 10;
                ew.Column(13).Width = 20;
                ew.Column(14).Width = 20;
                ew.Column(15).Width = 20;
                ew.Column(16).Width = 20;
                ew.Column(17).Width = 20;
                ew.Column(18).Width = 20;
                ew.Column(19).Width = 20;
                ew.Column(20).Width = 20;
                ew.Column(21).Width = 40;
                ew.Column(22).Width = 40;
                ew.Column(23).Width = 50;
                ew.Column(24).Width = 10;
                ew.Column(25).Width = 20;
                ew.Column(26).Width = 20;
                ew.Column(27).Width = 30;

                using (var range = ew.Cells[1, 1, 1, 27])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                List<encuesta_usuariosCLS> listaUser = (List<encuesta_usuariosCLS>)Session["ListaUser"];
                int nroregistros = listaUser.Count();
                for (int i = 0; i < nroregistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = listaUser[i].usua_id;
                    ew.Cells[i + 2, 2].Value = listaUser[i].usua_nombre;
                    ew.Cells[i + 2, 3].Value = listaUser[i].empleado_empresa;
                    ew.Cells[i + 2, 4].Style.Numberformat.Format = "yyyy-mm-dd";
                    ew.Cells[i + 2, 4].Value = listaUser[i].usua_f_aplica;
                    ew.Cells[i + 2, 5].Value = listaUser[i].usua_estatus;
                    ew.Cells[i + 2, 6].Value = listaUser[i].usua_n_usuario;
                    ew.Cells[i + 2, 7].Style.Numberformat.Format = "yyyy-mm-dd";
                    ew.Cells[i + 2, 7].Value = listaUser[i].usua_f_alta;
                    ew.Cells[i + 2, 8].Style.Numberformat.Format = "yyyy-mm-dd";
                    ew.Cells[i + 2, 8].Value = listaUser[i].usua_f_cancela;
                    ew.Cells[i + 2, 9].Value = listaUser[i].empleado_genero;
                    ew.Cells[i + 2, 10].Value = listaUser[i].empleado_edad;
                    ew.Cells[i + 2, 11].Value = listaUser[i].empleado_edocivil;
                    ew.Cells[i + 2, 12].Value = listaUser[i].empleado_sinformacion;
                    ew.Cells[i + 2, 13].Value = listaUser[i].empleado_primaria;
                    ew.Cells[i + 2, 14].Value = listaUser[i].empleado_secundaria;
                    ew.Cells[i + 2, 15].Value = listaUser[i].empleado_preparatoria;
                    ew.Cells[i + 2, 16].Value = listaUser[i].empleado_tecnico;
                    ew.Cells[i + 2, 17].Value = listaUser[i].empleado_licenciatura;
                    ew.Cells[i + 2, 18].Value = listaUser[i].empleado_maestria;
                    ew.Cells[i + 2, 19].Value = listaUser[i].empleado_doctorado;
                    ew.Cells[i + 2, 20].Value = listaUser[i].empleado_tipopuesto;
                    ew.Cells[i + 2, 21].Value = listaUser[i].empleado_tipocontata;
                    ew.Cells[i + 2, 22].Value = listaUser[i].empleado_tipopersonal;
                    ew.Cells[i + 2, 23].Value = listaUser[i].empleado_tipojornada;
                    ew.Cells[i + 2, 24].Value = listaUser[i].empleado_rotacion;
                    ew.Cells[i + 2, 25].Value = listaUser[i].empleado_tiempopuesto;
                    ew.Cells[i + 2, 26].Value = listaUser[i].empleado_explab;
                    ew.Cells[i + 2, 27].Value = listaUser[i].usua_presento;
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Lista_Empleados.xlsx");

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FileResult generarExcelEmpresas()
        {

            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear una hoja
                ep.Workbook.Worksheets.Add("Reporte de Empresas");
                ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                //Ponemos nombres de las columnas
                ew.Cells[1, 1].Value = "ID";
                ew.Cells[1, 2].Value = "Descripción";
                ew.Cells[1, 3].Value = "Estatus";
                ew.Cells[1, 4].Value = "Empleados";
                ew.Cells[1, 5].Value = "Dirección";
                ew.Cells[1, 6].Value = "Telefono";
                ew.Cells[1, 7].Value = "Contacto";
                ew.Cells[1, 8].Value = "Correo";
                ew.Cells[1, 9].Value = "C.P.";

                ew.Column(1).Width = 10;
                ew.Column(2).Width = 50;
                ew.Column(3).Width = 10;
                ew.Column(4).Width = 10;
                ew.Column(5).Width = 50;
                ew.Column(6).Width = 40;
                ew.Column(7).Width = 40;
                ew.Column(8).Width = 40;
                ew.Column(9).Width = 10;

                using (var range = ew.Cells[1, 1, 1, 9])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                List<encuesta_empresaCLS> listaEmp = (List<encuesta_empresaCLS>)Session["ListaEmp"];
                int nroregistros = listaEmp.Count();
                for (int i = 0; i < nroregistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = listaEmp[i].emp_id;
                    ew.Cells[i + 2, 2].Value = listaEmp[i].emp_descrip;
                    ew.Cells[i + 2, 3].Value = listaEmp[i].emp_estatus;
                    ew.Cells[i + 2, 4].Value = listaEmp[i].emp_no_trabajadores;
                    ew.Cells[i + 2, 5].Value = listaEmp[i].emp_direccion;
                    ew.Cells[i + 2, 6].Value = listaEmp[i].emp_telefono;
                    ew.Cells[i + 2, 7].Value = listaEmp[i].emp_person_contac;
                    ew.Cells[i + 2, 8].Value = listaEmp[i].emp_correo;
                    ew.Cells[i + 2, 9].Value = listaEmp[i].emp_cp;
                }
                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Lista_Empresas.xlsx");

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FileResult generarExcelResultados1(int id)
        {
            List<encuesta_mostrarPreguntas2CLS> list;
            List<encuesta_mostrarPreguntas2CLS> list2;
            List<encuesta_mostrarPreguntas2CLS> list3;
            List<encuesta_mostrarPreguntas2CLS> list4;

            int x = 0;
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

                byte[] buffer;
                using (MemoryStream ms = new MemoryStream())
                {
                    //Todo el documento excel
                    ExcelPackage ep = new ExcelPackage();
                    //Crear una hoja
                    ep.Workbook.Worksheets.Add("Reporte Excel de Encuesta 1");
                    ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                    //Ponemos nombres de las columnas
                    ew.Cells[1, 1].Value = "CUESTIONARIO PARA IDENTIFICAR A LOS TRABAJADORES QUE FUERON SUJETOS A ACONTECIMIENTOS TRAUMÁTICOS SEVEROS.";
                    ew.Cells[2, 1].Value = "Nombre del Empleado: " + nombreEmpleado;
                    ew.Cells[3, 1].Value = "Pregunta";
                    ew.Cells[3, 2].Value = "Respuesta";
             

                    ew.Column(1).Width = 150;
                    ew.Column(2).Width = 30;

                    //Para dar formato al titulo
                    using (var range = ew.Cells[1, 1])
                    {
                        //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Font.Bold = true;
                        //.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                    }

                    //Para dar color a las columnas
                    using (var range = ew.Cells[3, 1, 3, 2])
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Font.Color.SetColor(Color.White);
                        range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                    }

                    //Para dar color a las celdas
                    using (var range = ew.Cells[25,1])
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //range.Style.Font.Color.SetColor(Color.Yellow);
                        range.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                    }

                    List<encuesta_usuariosCLS> listaUser = (List<encuesta_usuariosCLS>)Session["ListaUser"];
                    int nroregistros = list.Count();
                    int nroregistros2 = list2.Count();
                    int nroregistros3 = list3.Count();
                    int nroregistros4 = list4.Count();

                    for (int i = 0; i < nroregistros; i++)
                    {
                        if (list[i].resu_resultado == "SI") {
                            x = 1;
                        }
                        ew.Cells[i + 4, 1].Value = list[i].denc_descrip;
                        ew.Cells[i + 4, 2].Value = list[i].resu_resultado;
                        if (x.Equals(1))
                        {

                            ew.Cells[25, 1].Value = "El Trabajador requiere valoración CLINICA";
                        }
                        else
                        {

                            ew.Cells[25, 1].Value = "El Trabajador NO requiere valoración CLINICA";

                        }
                    }

                    for (int i = 0; i < nroregistros2; i++) {

                        ew.Cells[i + 10, 1].Value = list2[i].denc_descrip;
                        ew.Cells[i + 10, 2].Value = list2[i].resu_resultado;
                    }

                    for (int i = 0; i < nroregistros3; i++)
                    {

                        ew.Cells[i + 12, 1].Value = list3[i].denc_descrip;
                        ew.Cells[i + 12, 2].Value = list3[i].resu_resultado;
                    }

                    for (int i = 0; i < nroregistros4; i++)
                    {

                        ew.Cells[i + 19, 1].Value = list4[i].denc_descrip;
                        ew.Cells[i + 19, 2].Value = list4[i].resu_resultado;
                    }
                    ep.SaveAs(ms);
                    buffer = ms.ToArray();
                }

                return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Cuestionario1_"+ nombreEmpleado + ".xlsx");

            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FileResult generarExcelGuiaII(int id)
        {

            string CondicionesAmbienteTrabajoRes="";
            string CargaTrabajoRes="";
            string FaltaControlSobreTrabajoRes="";
            string JornadaTrabajoRes="";
            string InfluenciaTrabajoFueraCentroLaboralRes="";
            string LiderazgoRes="";
            string RelacionesTrabajoRes="";
            string ViolenciaRes="";
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
                else if (CondicionesAmbienteTrabajo >= 3 && CondicionesAmbienteTrabajo<=5) { CondicionesAmbienteTrabajoRes = "Bajo"; }
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



                byte[] buffer;
                using (MemoryStream ms = new MemoryStream())
                {
                    //Todo el documento excel
                    ExcelPackage ep = new ExcelPackage();
                    //Crear una hoja
                    ep.Workbook.Worksheets.Add("Reporte Excel de Encuesta 1");
                    ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                    //Ponemos nombres de las columnas
                    ew.Cells[1, 1].Value = "CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL EN LOS CENTROS DE TRABAJO.";
                    ew.Cells[2, 1].Value = "Nombre del Empleado: " + nombreEmpleado;
                    ew.Cells[3, 1].Value = "Resultado del Dominio";
                    ew.Cells[3, 2].Value = "Suma Total";
                    ew.Cells[3, 3].Value = "Nivel de Riesgo";

                    ew.Cells[4, 1].Value = "Condiciones en el ambiente de trabajo";
                    ew.Cells[4, 2].Value =  CondicionesAmbienteTrabajo;
                    ew.Cells[4, 3].Value =  CondicionesAmbienteTrabajoRes;

                    ew.Cells[5, 1].Value = "Carga de trabajo";
                    ew.Cells[5, 2].Value = CargaTrabajo;
                    ew.Cells[5, 3].Value = CargaTrabajoRes;

                    ew.Cells[6, 1].Value = "Falta de control sobre el trabajo";
                    ew.Cells[6, 2].Value = FaltaControlSobreTrabajo;
                    ew.Cells[6, 3].Value = FaltaControlSobreTrabajoRes;

                    ew.Cells[7, 1].Value = "Jornada de trabajo";
                    ew.Cells[7, 2].Value = JornadaTrabajo;
                    ew.Cells[7, 3].Value = JornadaTrabajoRes;

                    ew.Cells[8, 1].Value = "Interferencia en la relación trabajo-familia";
                    ew.Cells[8, 2].Value = InfluenciaTrabajoFueraCentroLaboral;
                    ew.Cells[8, 3].Value = InfluenciaTrabajoFueraCentroLaboralRes;

                    ew.Cells[9, 1].Value = "Liderazgo";
                    ew.Cells[9, 2].Value = Liderazgo;
                    ew.Cells[9, 3].Value = LiderazgoRes;

                    ew.Cells[10, 1].Value = "Relaciones en el Trabajo";
                    ew.Cells[10, 2].Value = RelacionesTrabajo;
                    ew.Cells[10, 3].Value = RelacionesTrabajoRes;

                    ew.Cells[11, 1].Value = "Violencia";
                    ew.Cells[11, 2].Value = Violencia;
                    ew.Cells[11, 3].Value = ViolenciaRes;

                    ew.Column(1).Width = 100;
                    ew.Column(2).Width = 30;
                    ew.Column(3).Width = 40;    

                //Para dar formato al titulo
                using (var range = ew.Cells[1, 1])
                    {
                        //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Font.Bold = true;
                        //.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                    }

                    //Para dar color a las columnas
                    using (var range = ew.Cells[3, 1, 3, 2])
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Font.Color.SetColor(Color.White);
                        range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                    }

                    using (var range = ew.Cells[3, 3])
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Font.Color.SetColor(Color.White);
                        range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                     }

                ep.SaveAs(ms);
                    buffer = ms.ToArray();
                }

                return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuestionario2_Dominio_" + nombreEmpleado + ".xlsx");

            }

        public FileResult generaExcelGuiaIICat(int id) {

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



            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear una hoja
                ep.Workbook.Worksheets.Add("Reporte Excel de Encuesta 1");
                ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                //Ponemos nombres de las columnas
                ew.Cells[1, 1].Value = "CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL EN LOS CENTROS DE TRABAJO.";
                ew.Cells[2, 1].Value = "Nombre del Empleado: " + nombreEmpleado;
                ew.Cells[3, 1].Value = "Resultado de Categoría";
                ew.Cells[3, 2].Value = "Suma Total";
                ew.Cells[3, 3].Value = "Nivel de Riesgo";

                ew.Cells[4, 1].Value = "Ambiente de trabajo";
                ew.Cells[4, 2].Value = AmbienteTrabajo;
                ew.Cells[4, 3].Value = AmbienteTrabajoRes;

                ew.Cells[5, 1].Value = "Factores propios de la actividad";
                ew.Cells[5, 2].Value = FactoresPropiosActividad;
                ew.Cells[5, 3].Value = FactoresPropiosActividadRes;

                ew.Cells[6, 1].Value = "Organización del tiempo de trabajo";
                ew.Cells[6, 2].Value = OrganizacionTiempoTrabajo;
                ew.Cells[6, 3].Value = OrganizacionTiempoTrabajoRes;

                ew.Cells[7, 1].Value = "Liderazgo y relaciones en el trabajo";
                ew.Cells[7, 2].Value = LiderazgoRelacionesTrabajo;
                ew.Cells[7, 3].Value = LiderazgoRelacionesTrabajoRes;

                ew.Column(1).Width = 100;
                ew.Column(2).Width = 30;
                ew.Column(3).Width = 40;

                //Para dar formato al titulo
                using (var range = ew.Cells[1, 1])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Bold = true;
                    //.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }

                //Para dar color a las columnas
                using (var range = ew.Cells[3, 1, 3, 2])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                using (var range = ew.Cells[3, 3])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuestionario2_Categoría_" + nombreEmpleado + ".xlsx");


        }

        public FileResult generaExcelGuiaIIFinal(int id) {

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
            string CalificacionFinalCuestionarioRes="";
            string riesgo="";

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
                else if (CalificacionFinalCuestionario >= 45 && CalificacionFinalCuestionario < 70) { CalificacionFinalCuestionarioRes = "Medio"; riesgo = "Medio	Se requiere revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión, mediante un Programa de intervención.";}
                else if (CalificacionFinalCuestionario >= 70 && CalificacionFinalCuestionario < 90) { CalificacionFinalCuestionarioRes = "Alto";  riesgo = "Se requiere realizar un análisis de cada categoría y dominio, de manera que se puedan determinar las acciones de intervención apropiadas a través de un Programa de intervención, que podrá incluir una evaluación específica1 y deberá incluir una campaña de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión.";}
                else if (CalificacionFinalCuestionario >= 90) { CalificacionFinalCuestionarioRes = "Muy Alto"; riesgo = "Se requiere realizar el análisis de cada categoría y dominio para establecer las acciones de intervención apropiadas, mediante un Programa de intervención que deberá incluir evaluaciones específicas1, y contemplar campañas de sensibilización, revisar la política de prevención de riesgos psicosociales y programas para la prevención de los factores de riesgo psicosocial, la promoción de un entorno organizacional favorable y la prevención de la violencia laboral, así como reforzar su aplicación y difusión.";}

            }



            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear una hoja
                ep.Workbook.Worksheets.Add("Reporte Excel de Encuesta 1");
                ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                //Ponemos nombres de las columnas
                ew.Cells[1, 1].Value = "CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL EN LOS CENTROS DE TRABAJO.";
                ew.Cells[2, 1].Value = "Nombre del Empleado: " + nombreEmpleado;
                ew.Cells[3, 1].Value = "Resultado de Final";
                ew.Cells[3, 2].Value = "Suma Total";
                ew.Cells[3, 3].Value = "Nivel de Riesgo";
                ew.Cells[3, 4].Value = "Necesidad de accion";

                ew.Cells[4, 1].Value = "Calificacion final del cuestionario";
                ew.Cells[4, 2].Value = CalificacionFinalCuestionario;
                ew.Cells[4, 3].Value = CalificacionFinalCuestionarioRes;
                ew.Cells[4, 4].Style.WrapText = true;
                ew.Cells[4, 4].Value = riesgo;



                ew.Column(1).Width = 100;
                ew.Column(2).Width = 20;
                ew.Column(3).Width = 30;
                ew.Column(4).Width = 150;
                ew.Row(4).Height = 80;

                //Para dar formato al titulo
                using (var range = ew.Cells[1, 1])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Bold = true;
                    //.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }

                //Para dar color a las columnas
                using (var range = ew.Cells[3, 1, 3, 2])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                using (var range = ew.Cells[3, 3,3,4])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuestionario2_Final_" + nombreEmpleado + ".xlsx");


        }

        public FileResult generarExcelGuiaIII(int id)
        {

            string CondicionesAmbienteTrabajoRes = "";
            string CargaTrabajoRes = "";
            string FaltaControlSobreTrabajoRes = "";
            string JornadaTrabajoRes = "";
            string InterferenciaRelacionTrabajoFamiliaRes = "";
            string LiderazgoRes = "";
            string RelacionesTrabajoRes = "";
            string ViolenciaRes = "";
            string ReconocimientoDesempeñoRes="";
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
                else if (FaltaControlSobreTrabajo >=11 && FaltaControlSobreTrabajo < 16) { FaltaControlSobreTrabajoRes = "Bajo"; }
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



            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear una hoja
                ep.Workbook.Worksheets.Add("Reporte Excel de Encuesta 1");
                ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                //Ponemos nombres de las columnas
                ew.Cells[1, 1].Value = "CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO.";
                ew.Cells[2, 1].Value = "Nombre del Empleado: " + nombreEmpleado;
                ew.Cells[3, 1].Value = "Resultado del Dominio";
                ew.Cells[3, 2].Value = "Suma Total";
                ew.Cells[3, 3].Value = "Nivel de Riesgo";

                ew.Cells[4, 1].Value = "Condiciones en el ambiente de trabajo";
                ew.Cells[4, 2].Value = CondicionesAmbienteTrabajo;
                ew.Cells[4, 3].Value = CondicionesAmbienteTrabajoRes;

                ew.Cells[5, 1].Value = "Carga de trabajo";
                ew.Cells[5, 2].Value = CargaTrabajo;
                ew.Cells[5, 3].Value = CargaTrabajoRes;

                ew.Cells[6, 1].Value = "Falta de control sobre el trabajo";
                ew.Cells[6, 2].Value = FaltaControlSobreTrabajo;
                ew.Cells[6, 3].Value = FaltaControlSobreTrabajoRes;

                ew.Cells[7, 1].Value = "Jornada de trabajo";
                ew.Cells[7, 2].Value = JornadaTrabajo;
                ew.Cells[7, 3].Value = JornadaTrabajoRes;

                ew.Cells[8, 1].Value = "Interferencia en la relación trabajo-familia";
                ew.Cells[8, 2].Value = InterferenciaRelacionTrabajoFamilia;
                ew.Cells[8, 3].Value = InterferenciaRelacionTrabajoFamiliaRes;

                ew.Cells[9, 1].Value = "Liderazgo";
                ew.Cells[9, 2].Value = Liderazgo;
                ew.Cells[9, 3].Value = LiderazgoRes;

                ew.Cells[10, 1].Value = "Relaciones en el Trabajo";
                ew.Cells[10, 2].Value = RelacionesTrabajo;
                ew.Cells[10, 3].Value = RelacionesTrabajoRes;

                ew.Cells[11, 1].Value = "Violencia";
                ew.Cells[11, 2].Value = Violencia;
                ew.Cells[11, 3].Value = ViolenciaRes;

                ew.Cells[12, 1].Value = "Reconocimiento del desempeño";
                ew.Cells[12, 2].Value = ReconocimientoDesempeño;
                ew.Cells[12, 3].Value = ReconocimientoDesempeñoRes;

                ew.Cells[13, 1].Value = "Insuficiente sentido de pertenencia e, inestabilidad";
                ew.Cells[13, 2].Value = InsuficienteSentido;
                ew.Cells[13, 3].Value = InsuficienteSentidoRes;

                ew.Column(1).Width = 130;
                ew.Column(2).Width = 20;
                ew.Column(3).Width = 20;

                //Para dar formato al titulo
                using (var range = ew.Cells[1, 1])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Bold = true;
                    //.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }

                //Para dar color a las columnas
                using (var range = ew.Cells[3, 1, 3, 2])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                using (var range = ew.Cells[3, 3])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuestionario3_Dominio_" + nombreEmpleado + ".xlsx");

        }

        public FileResult generarExcelGuiaIIICat(int id) {

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



            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear una hoja
                ep.Workbook.Worksheets.Add("Reporte Excel de Encuesta 1");
                ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                //Ponemos nombres de las columnas
                ew.Cells[1, 1].Value = "CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO";
                ew.Cells[2, 1].Value = "Nombre del Empleado: " + nombreEmpleado;
                ew.Cells[3, 1].Value = "Resultado de Categoría";
                ew.Cells[3, 2].Value = "Suma Total";
                ew.Cells[3, 3].Value = "Nivel de Riesgo";

                ew.Cells[4, 1].Value = "Ambiente de trabajo";
                ew.Cells[4, 2].Value = AmbienteTrabajo;
                ew.Cells[4, 3].Value = AmbienteTrabajoRes;

                ew.Cells[5, 1].Value = "Factores propios de la actividad";
                ew.Cells[5, 2].Value = FactoresPropiosActividad;
                ew.Cells[5, 3].Value = FactoresPropiosActividadRes;

                ew.Cells[6, 1].Value = "Organización del tiempo de trabajo";
                ew.Cells[6, 2].Value = OrganizacionTiempoTrabajo;
                ew.Cells[6, 3].Value = OrganizacionTiempoTrabajoRes;

                ew.Cells[7, 1].Value = "Liderazgo y relaciones en el trabajo";
                ew.Cells[7, 2].Value = LiderazgoRelacionesTrabajo;
                ew.Cells[7, 3].Value = LiderazgoRelacionesTrabajoRes;

                ew.Cells[8, 1].Value = "Entorno organizacional";
                ew.Cells[8, 2].Value = EntornoOrganizacional;
                ew.Cells[8, 3].Value = EntornoOrganizacionalRes;

                ew.Column(1).Width = 130;
                ew.Column(2).Width = 20;
                ew.Column(3).Width = 20;

                //Para dar formato al titulo
                using (var range = ew.Cells[1, 1])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Bold = true;
                    //.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }

                //Para dar color a las columnas
                using (var range = ew.Cells[3, 1, 3, 2])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                using (var range = ew.Cells[3, 3])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuestionario3_Categoría_" + nombreEmpleado + ".xlsx");


        }

        public FileResult generaExcelGuiaIIIFinal(int id)
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



            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear una hoja
                ep.Workbook.Worksheets.Add("Reporte Excel de Encuesta 1");
                ExcelWorksheet ew = ep.Workbook.Worksheets[1];

                //Ponemos nombres de las columnas
                ew.Cells[1, 1].Value = "CUESTIONARIO PARA IDENTIFICAR LOS FACTORES DE RIESGO PSICOSOCIAL Y EVALUAR EL ENTORNO ORGANIZACIONAL EN LOS CENTROS DE TRABAJO";
                ew.Cells[2, 1].Value = "Nombre del Empleado: " + nombreEmpleado;
                ew.Cells[3, 1].Value = "Resultado de Final";
                ew.Cells[3, 2].Value = "Suma Total";
                ew.Cells[3, 3].Value = "Nivel de Riesgo";
                ew.Cells[3, 4].Value = "Necesidad de accion";

                ew.Cells[4, 1].Value = "Calificacion final del cuestionario";
                ew.Cells[4, 2].Value = CalificacionFinalCuestionario;
                ew.Cells[4, 3].Value = CalificacionFinalCuestionarioRes;
                ew.Cells[4, 4].Style.WrapText = true;
                ew.Cells[4, 4].Value = riesgo;



                ew.Column(1).Width = 130;
                ew.Column(2).Width = 20;
                ew.Column(3).Width = 20;
                ew.Column(4).Width = 150;
                ew.Row(4).Height = 80;

                //Para dar formato al titulo
                using (var range = ew.Cells[1, 1])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Bold = true;
                    //.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }

                //Para dar color a las columnas
                using (var range = ew.Cells[3, 1, 3, 2])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                using (var range = ew.Cells[3, 3, 3, 4])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }

                ep.SaveAs(ms);
                buffer = ms.ToArray();
            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Cuestionario3_Final_" + nombreEmpleado + ".xlsx");


        }
    }


    }

