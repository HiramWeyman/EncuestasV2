using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EncuestasV2.Filters;
using EncuestasV2.Models;
using System.Transactions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Security.Cryptography;
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
    public class AdminController : Controller
    {

        List<SelectListItem> listaEmpresa;
        List<SelectListItem> listaDepto;
        List<SelectListItem> listaCentro;
        List<SelectListItem> listaSexo;
        List<SelectListItem> listaEdad;
        List<SelectListItem> listaEdoCivil;
        List<SelectListItem> listaOpciones;
        List<SelectListItem> listaProceso;
        List<SelectListItem> listaPuesto;
        List<SelectListItem> listaContrata;
        List<SelectListItem> listaPersonal;
        List<SelectListItem> listaJornada;
        List<SelectListItem> listaRotacion;
        List<SelectListItem> listaTiempo;
        List<SelectListItem> listaExpLab;



        //Catalogos
        private void llenarEmpresa()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaEmpresa = (from emp in db.encuesta_empresa
                                select new SelectListItem
                                {
                                    Value = emp.emp_id.ToString(),
                                    Text = emp.emp_descrip,
                                    Selected = false

                                }).ToList();
                listaEmpresa.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
        private void llenarSexo()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaSexo = (from sexo in db.encuesta_sexo
                             select new SelectListItem
                             {
                                 Value = sexo.sexo_id.ToString(),
                                 Text = sexo.sexo_desc,
                                 Selected = false

                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarEdad()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaEdad = (from edad in db.encuesta_edades
                             select new SelectListItem
                             {
                                 Value = edad.edad_id.ToString(),
                                 Text = edad.edad_desc,
                                 Selected = false

                             }).ToList();
                listaEdad.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarEdoCivil()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaEdoCivil = (from edo in db.encuesta_edocivil
                                 select new SelectListItem
                                 {
                                     Value = edo.edocivil_id.ToString(),
                                     Text = edo.edocivil_desc,
                                     Selected = false

                                 }).ToList();
                listaEdoCivil.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarOpciones()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaOpciones = (from op in db.encuaesta_opciones
                                 select new SelectListItem
                                 {
                                     Value = op.opcion_id.ToString(),
                                     Text = op.opcion_desc,
                                     Selected = false

                                 }).ToList();
                listaOpciones.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarProcesoEdu()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaProceso = (from proc in db.encuesta_procesoedu
                                select new SelectListItem
                                {
                                    Value = proc.procesoedu_id.ToString(),
                                    Text = proc.procesoedu_desc,
                                    Selected = false

                                }).ToList();
                listaProceso.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarTipoPuesto()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaPuesto = (from puesto in db.encuesta_tipopuesto
                               select new SelectListItem
                               {
                                   Value = puesto.tipopuesto_id.ToString(),
                                   Text = puesto.tipopuesto_desc,
                                   Selected = false

                               }).ToList();
                listaPuesto.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarTipoContratacion()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaContrata = (from contra in db.encuesta_tipocontrata
                                 select new SelectListItem
                                 {
                                     Value = contra.tipocont_id.ToString(),
                                     Text = contra.tipocont_desc,
                                     Selected = false

                                 }).ToList();
                listaContrata.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarTipoPersonal()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaPersonal = (from personal in db.encuesta_tipopersonal
                                 select new SelectListItem
                                 {
                                     Value = personal.tipoperson_id.ToString(),
                                     Text = personal.tipoperson_desc,
                                     Selected = false

                                 }).ToList();
                listaPersonal.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarTipoJornada()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaJornada = (from jornada in db.encuesta_tipojornada
                                select new SelectListItem
                                {
                                    Value = jornada.tipojornada_id.ToString(),
                                    Text = jornada.tipojornada_desc,
                                    Selected = false

                                }).ToList();
                listaJornada.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarRotacionTurno()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaRotacion = (from rotacion in db.encuaesta_rotacion
                                 select new SelectListItem
                                 {
                                     Value = rotacion.rotacionturno_id.ToString(),
                                     Text = rotacion.rotacionturno_desc,
                                     Selected = false

                                 }).ToList();
                listaRotacion.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
        private void llenarTiempoEmp()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaTiempo = (from tiempo in db.encuesta_tiempopuesto
                               select new SelectListItem
                               {
                                   Value = tiempo.tiempopue_id.ToString(),
                                   Text = tiempo.tiempopue_desc,
                                   Selected = false

                               }).ToList();
                listaTiempo.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        private void llenarDepto()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaDepto = (from dep in db.encuaesta_departamento
                              select new SelectListItem
                              {
                                  Value = dep.dep_id.ToString(),
                                  Text = dep.dep_desc,
                                  Selected = false

                              }).ToList();
                listaDepto.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }


        private void llenarCentro()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaCentro = (from centro in db.encuaesta_centro
                               select new SelectListItem
                               {
                                   Value = centro.centro_id.ToString(),
                                   Text = centro.centro_desc,
                                   Selected = false

                               }).ToList();
                listaCentro.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }
        private void llenarExpLab()
        {
            using (var db = new csstdura_encuestaEntities())
            {
                listaExpLab = (from exp in db.encuesta_explab
                               select new SelectListItem
                               {
                                   Value = exp.explab_id.ToString(),
                                   Text = exp.explab_desc,
                                   Selected = false

                               }).ToList();
                listaExpLab.Insert(0, new SelectListItem { Text = "Seleccione", Value = "" });
            }
        }

        public void listarCombos()
        {

            llenarEmpresa();
            llenarDepto();
            llenarCentro();
            llenarSexo();
            llenarEdad();
            llenarEdoCivil();
            llenarOpciones();
            llenarProcesoEdu();
            llenarTipoPuesto();
            llenarTipoContratacion();
            llenarTipoPersonal();
            llenarTipoJornada();
            llenarRotacionTurno();
            llenarTiempoEmp();
            llenarExpLab();
        }
        // GET: Admin
        [AccederAdmin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Empleados(encuesta_usuariosCLS empleados_)
        {
            int id_empresa = empleados_.usua_empresa;
            int id_genero = empleados_.usua_genero;
            int id_edo_civ = empleados_.usua_edo_civil;
            int id_puesto = empleados_.usua_tipo_puesto;
            int id_contrata = empleados_.usua_tipo_contratacion;
            int id_personal = empleados_.usua_tipo_personal;
            int id_jornada = empleados_.usua_tipo_jornada;
            int id_tiempo = empleados_.usua_tiempo_puesto;
            int id_expLab = empleados_.usua_exp_laboral;

            listarCombos();

            ViewBag.listaEmpresa = listaEmpresa;
            ViewBag.listaSexo = listaSexo;
            ViewBag.listaEdad = listaEdad;
            ViewBag.listaEdoCivil = listaEdoCivil;
            ViewBag.listaOpciones = listaOpciones;
            ViewBag.listaProceso = listaProceso;
            ViewBag.listaPuesto = listaPuesto;
            ViewBag.listaContrata = listaContrata;
            ViewBag.listaPersonal = listaPersonal;
            ViewBag.listaJornada = listaJornada;
            ViewBag.listaRotacion = listaRotacion;
            ViewBag.listaTiempo = listaTiempo;
            ViewBag.listaExpLab = listaExpLab;

            List<encuesta_usuariosCLS> listaEmpleado = null;
            List<encuesta_usuariosCLS> listaRpta = null;
            using (var db = new csstdura_encuestaEntities())
            {
                listaEmpleado = (from empleado in db.encuesta_usuarios
                                 join empresa in db.encuesta_empresa
                                 on empleado.usua_empresa equals empresa.emp_id
                                 join genero in db.encuesta_sexo
                                 on empleado.usua_genero equals genero.sexo_id
                                 join edad_emp in db.encuesta_edades
                                 on empleado.usua_edad equals edad_emp.edad_id
                                 join edo in db.encuesta_edocivil
                                 on empleado.usua_edo_civil equals edo.edocivil_id
                                 join op in db.encuaesta_opciones
                                 on empleado.usua_sin_forma equals op.opcion_id
                                 join primaria in db.encuesta_procesoedu
                                 on empleado.usua_primaria equals primaria.procesoedu_id
                                 join secundaria in db.encuesta_procesoedu
                                 on empleado.usua_secundaria equals secundaria.procesoedu_id
                                 join prepa in db.encuesta_procesoedu
                                 on empleado.usua_preparatoria equals prepa.procesoedu_id
                                 join tecnico in db.encuesta_procesoedu
                                 on empleado.usua_tecnico equals tecnico.procesoedu_id
                                 join lic in db.encuesta_procesoedu
                                 on empleado.usua_licenciatura equals lic.procesoedu_id
                                 join maestria in db.encuesta_procesoedu
                                 on empleado.usua_maestria equals maestria.procesoedu_id
                                 join doc in db.encuesta_procesoedu
                                 on empleado.usua_doctorado equals doc.procesoedu_id
                                 join tipopuesto in db.encuesta_tipopuesto
                                 on empleado.usua_tipo_puesto equals tipopuesto.tipopuesto_id
                                 join tipocont in db.encuesta_tipocontrata
                                 on empleado.usua_tipo_contratacion equals tipocont.tipocont_id
                                 join tipopersonal in db.encuesta_tipopersonal
                                 on empleado.usua_tipo_personal equals tipopersonal.tipoperson_id
                                 join tipojornada in db.encuesta_tipojornada
                                 on empleado.usua_tipo_jornada equals tipojornada.tipojornada_id
                                 join rota in db.encuaesta_rotacion
                                 on empleado.usua_rotacion_turno equals rota.rotacionturno_id
                                 join tiempo in db.encuesta_tiempopuesto
                                 on empleado.usua_tiempo_puesto equals tiempo.tiempopue_id
                                 join exp in db.encuesta_explab
                                 on empleado.usua_exp_laboral equals exp.explab_id
                                 select new encuesta_usuariosCLS
                                 {
                                     usua_id = empleado.usua_id,
                                     usua_nombre = empleado.usua_nombre,
                                     usua_f_aplica = (DateTime)empleado.usua_f_aplica,
                                     usua_estatus = empleado.usua_estatus,
                                     usua_n_usuario = empleado.usua_n_usuario,
                                     usua_p_usuario = empleado.usua_p_usuario,
                                     usua_f_alta = (DateTime)empleado.usua_f_alta,
                                     usua_f_cancela = empleado.usua_f_cancela,
                                     usua_empresa = (int)empleado.usua_empresa,
                                     usua_genero = (int)empleado.usua_genero,
                                     usua_edad = (int)empleado.usua_edad,
                                     usua_edo_civil = (int)empleado.usua_edo_civil,
                                     usua_presento = empleado.usua_presento,
                                     empleado_empresa = empresa.emp_descrip,
                                     empleado_genero = genero.sexo_desc,
                                     empleado_edad = edad_emp.edad_desc,
                                     empleado_edocivil = edo.edocivil_desc,
                                     empleado_sinformacion = op.opcion_desc,
                                     empleado_primaria = primaria.procesoedu_desc,
                                     empleado_secundaria = secundaria.procesoedu_desc,
                                     empleado_preparatoria = prepa.procesoedu_desc,
                                     empleado_tecnico = tecnico.procesoedu_desc,
                                     empleado_licenciatura = lic.procesoedu_desc,
                                     empleado_maestria = maestria.procesoedu_desc,
                                     empleado_doctorado = doc.procesoedu_desc,
                                     empleado_tipopuesto = tipopuesto.tipopuesto_desc,
                                     empleado_tipocontata = tipocont.tipocont_desc,
                                     empleado_tipopersonal = tipopersonal.tipoperson_desc,
                                     empleado_tipojornada = tipojornada.tipojornada_desc,
                                     empleado_rotacion = rota.rotacionturno_desc,
                                     empleado_tiempopuesto = tiempo.tiempopue_desc,
                                     empleado_explab = exp.explab_desc

                                 }).ToList();
                Session["ListaUser"] = listaEmpleado;
                if (empleados_.usua_id == 0 && empleados_.usua_empresa == 0 && empleados_.usua_genero == 0 && empleados_.usua_edad == 0 && empleados_.usua_edo_civil == 0
                    && empleados_.usua_tipo_puesto == 0 && empleados_.usua_tipo_contratacion == 0 && empleados_.usua_tipo_personal == 0
                    && empleados_.usua_tipo_jornada == 0 && empleados_.usua_tiempo_puesto == 0 && empleados_.usua_exp_laboral == 0)
                {

                    listaRpta = listaEmpleado;
                    Session["ListaUser"] = listaEmpleado;
                }
                else
                {
                    if (empleados_.usua_empresa != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_empresa.Equals(empleados_.usua_empresa)).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_genero != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_genero.ToString().Contains(empleados_.usua_genero.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_edad != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_edad.ToString().Contains(empleados_.usua_edad.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_edo_civil != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_edo_civil.ToString().Contains(empleados_.usua_edo_civil.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_tipo_puesto != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_tipo_puesto.ToString().Contains(empleados_.usua_tipo_puesto.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_tipo_contratacion != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_tipo_contratacion.ToString().Contains(empleados_.usua_tipo_contratacion.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_tipo_personal != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_tipo_personal.ToString().Contains(empleados_.usua_tipo_personal.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_tipo_jornada != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_tipo_jornada.ToString().Contains(empleados_.usua_tipo_jornada.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_tiempo_puesto != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_tiempo_puesto.ToString().Contains(empleados_.usua_tiempo_puesto.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_exp_laboral != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_exp_laboral.ToString().Contains(empleados_.usua_exp_laboral.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }
                    Session["ListaUser"] = listaEmpleado;
                    listaRpta = listaEmpleado;

                }


            }
            return View(listaRpta);
        }

        public ActionResult DesactivarUsuarios(encuesta_usuariosCLS empleados_)
        {
            listarCombos();
            ViewBag.listaEmpresa = listaEmpresa;
            List<encuesta_usuariosCLS> listaEmpleado = null;
            using (var db = new csstdura_encuestaEntities())
            {
                if (empleados_.usua_empresa != 0)
                {
                    listaEmpleado = (from empleado in db.encuesta_usuarios
                                     join empresa in db.encuesta_empresa
                                     on empleado.usua_empresa equals empresa.emp_id
                                     join genero in db.encuesta_sexo
                                     on empleado.usua_genero equals genero.sexo_id
                                     join edad_emp in db.encuesta_edades
                                     on empleado.usua_edad equals edad_emp.edad_id
                                     join edo in db.encuesta_edocivil
                                     on empleado.usua_edo_civil equals edo.edocivil_id
                                     join op in db.encuaesta_opciones
                                     on empleado.usua_sin_forma equals op.opcion_id
                                     join primaria in db.encuesta_procesoedu
                                     on empleado.usua_primaria equals primaria.procesoedu_id
                                     join secundaria in db.encuesta_procesoedu
                                     on empleado.usua_secundaria equals secundaria.procesoedu_id
                                     join prepa in db.encuesta_procesoedu
                                     on empleado.usua_preparatoria equals prepa.procesoedu_id
                                     join tecnico in db.encuesta_procesoedu
                                     on empleado.usua_tecnico equals tecnico.procesoedu_id
                                     join lic in db.encuesta_procesoedu
                                     on empleado.usua_licenciatura equals lic.procesoedu_id
                                     join maestria in db.encuesta_procesoedu
                                     on empleado.usua_maestria equals maestria.procesoedu_id
                                     join doc in db.encuesta_procesoedu
                                     on empleado.usua_doctorado equals doc.procesoedu_id
                                     join tipopuesto in db.encuesta_tipopuesto
                                     on empleado.usua_tipo_puesto equals tipopuesto.tipopuesto_id
                                     join tipocont in db.encuesta_tipocontrata
                                     on empleado.usua_tipo_contratacion equals tipocont.tipocont_id
                                     join tipopersonal in db.encuesta_tipopersonal
                                     on empleado.usua_tipo_personal equals tipopersonal.tipoperson_id
                                     join tipojornada in db.encuesta_tipojornada
                                     on empleado.usua_tipo_jornada equals tipojornada.tipojornada_id
                                     join rota in db.encuaesta_rotacion
                                     on empleado.usua_rotacion_turno equals rota.rotacionturno_id
                                     join tiempo in db.encuesta_tiempopuesto
                                     on empleado.usua_tiempo_puesto equals tiempo.tiempopue_id
                                     join exp in db.encuesta_explab
                                     on empleado.usua_exp_laboral equals exp.explab_id
                                     where empleado.usua_empresa == empleados_.usua_empresa
                                     select new encuesta_usuariosCLS
                                     {
                                         usua_id = empleado.usua_id,
                                         usua_nombre = empleado.usua_nombre,
                                         usua_f_aplica = (DateTime)empleado.usua_f_aplica,
                                         usua_estatus = empleado.usua_estatus,
                                         usua_n_usuario = empleado.usua_n_usuario,
                                         usua_p_usuario = empleado.usua_p_usuario,
                                         usua_f_alta = (DateTime)empleado.usua_f_alta,
                                         usua_f_cancela = empleado.usua_f_cancela,
                                         usua_empresa = (int)empleado.usua_empresa,
                                         usua_genero = (int)empleado.usua_genero,
                                         usua_edad = (int)empleado.usua_edad,
                                         usua_edo_civil = (int)empleado.usua_edo_civil,
                                         usua_presento = empleado.usua_presento,
                                         empleado_empresa = empresa.emp_descrip,
                                         empleado_genero = genero.sexo_desc,
                                         empleado_edad = edad_emp.edad_desc,
                                         empleado_edocivil = edo.edocivil_desc,
                                         empleado_sinformacion = op.opcion_desc,
                                         empleado_primaria = primaria.procesoedu_desc,
                                         empleado_secundaria = secundaria.procesoedu_desc,
                                         empleado_preparatoria = prepa.procesoedu_desc,
                                         empleado_tecnico = tecnico.procesoedu_desc,
                                         empleado_licenciatura = lic.procesoedu_desc,
                                         empleado_maestria = maestria.procesoedu_desc,
                                         empleado_doctorado = doc.procesoedu_desc,
                                         empleado_tipopuesto = tipopuesto.tipopuesto_desc,
                                         empleado_tipocontata = tipocont.tipocont_desc,
                                         empleado_tipopersonal = tipopersonal.tipoperson_desc,
                                         empleado_tipojornada = tipojornada.tipojornada_desc,
                                         empleado_rotacion = rota.rotacionturno_desc,
                                         empleado_tiempopuesto = tiempo.tiempopue_desc,
                                         empleado_explab = exp.explab_desc

                                     }).ToList();
                }

            }

            return View(listaEmpleado);

        }

        public ActionResult Desactivar(string id)
        {
            int idx = 0;
            if (id != null)
            {
                idx = Int32.Parse(id);
            }
            encuesta_usuariosCLS Oencuesta_usuarioCLS = new encuesta_usuariosCLS();

            int res = 0;
            using (var db = new csstdura_encuestaEntities())
            {
                Console.WriteLine("Valor del id: " + idx);
                List<encuesta_usuarios> results = (from p in db.encuesta_usuarios where p.usua_empresa == idx select p).ToList();
                foreach (encuesta_usuarios p in results)
                {
                    p.usua_estatus = "INACTIVO";
                }
                //encuesta_usuarios Oencuesta_usuario = db.encuesta_usuarios.SqlQuery("SELECT *  FROM encuesta_usuarios  where usua_empresa=@id_empresa",new SqlParameter("@id_empresa",idx)).ToList<encuesta_usuarios>;
                //encuesta_usuarios Oencuesta_usuario = db.encuesta_usuarios.Where(p => p.usua_empresa== idx).FirstOrDefault();
                //encuesta_usuarios Oencuesta_usuario =<encuesta_usuarios> db.Database.SqlQuery<string>("Select usua_n_usuario from encuesta_usuarios where usua_n_usuario=@usuario", new SqlParameter("@usuario", idx))
                //     .FirstOrDefault();
                // Oencuesta_usuario.usua_estatus = "INACTIVO";
                res = db.SaveChanges();

            }
            if (res == 1)
            {

                return Content("<script language='javascript' type='text/javascript'>alert('Usuarios Desactivados!');window.location = '/Admin/DesactivarUsuarios';</script>");

            }
            else
            {

                return Content("<script language='javascript' type='text/javascript'>alert('Ocurrio un error!');window.location = '/Admin/DesactivarUsuarios';</script>");

            }

        }



        public ActionResult CatalogoEmpresa()
        {

            //ViewBag.user = Session["Usuario"].ToString();
            return View();
            //var test = Session["Usuario"].ToString();
            //if (Session["Usuario"] != null)
            //{
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Admin");
            //}

        }
        [HttpPost]
        public ActionResult InsertCatalogoEmp(encuesta_empresaCLS Oencuesta_empresaCLS)
        {
            int res = 0;
            using (var db = new csstdura_encuestaEntities())
            {
                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        encuesta_empresa empresa = new encuesta_empresa();
                        empresa.emp_descrip = Oencuesta_empresaCLS.emp_descrip;
                        empresa.emp_estatus = "A";
                        empresa.emp_u_alta = Oencuesta_empresaCLS.emp_u_alta;
                        empresa.emp_f_alta = DateTime.Now;
                        empresa.emp_u_cancela = "";
                        empresa.emp_f_cancela = null;
                        empresa.emp_no_trabajadores = Oencuesta_empresaCLS.emp_no_trabajadores;
                        empresa.emp_direccion = Oencuesta_empresaCLS.emp_direccion;
                        empresa.emp_telefono = Oencuesta_empresaCLS.emp_telefono;
                        empresa.emp_person_contac = Oencuesta_empresaCLS.emp_person_contac;
                        empresa.emp_correo = Oencuesta_empresaCLS.emp_correo;
                        empresa.emp_cp = Oencuesta_empresaCLS.emp_cp;
                        db.encuesta_empresa.Add(empresa);
                        res = db.SaveChanges();
                        transaction.Complete();


                    }
                    catch (DbEntityValidationException dbEx)
                    {

                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property: {0} Error: {1}",
                                    validationError.PropertyName,
                                    validationError.ErrorMessage);
                            }
                        }

                    }
                    if (res == 1)
                    {

                        return Content("<script language='javascript' type='text/javascript'>alert('Registro exitoso!');window.location = '/Admin/CatalogoEmpresa';</script>");

                    }
                    else
                    {

                        return Content("<script language='javascript' type='text/javascript'>alert('Ocurrio un error!');window.location = '/Admin/CatalogoEmpresa';</script>");

                    }

                }
            }

        }
        public ActionResult ListarEmpresa(encuesta_empresaCLS oEmpresa)
        {

            List<encuesta_empresaCLS> listaEmpresa = null;
            string nombre_empresa = oEmpresa.emp_descrip;
            using (var db = new csstdura_encuestaEntities())
            {
                if (oEmpresa.emp_descrip == null)
                {
                    listaEmpresa = (from empresa in db.encuesta_empresa
                                    select new encuesta_empresaCLS
                                    {
                                        emp_id = empresa.emp_id,
                                        emp_descrip = empresa.emp_descrip,
                                        emp_estatus = empresa.emp_estatus,
                                        emp_u_alta = empresa.emp_u_alta,
                                        emp_f_alta = (DateTime)empresa.emp_f_alta,
                                        emp_u_cancela = empresa.emp_u_cancela,
                                        emp_f_cancela = (DateTime)empresa.emp_f_cancela,
                                        emp_no_trabajadores = empresa.emp_no_trabajadores,
                                        emp_direccion = empresa.emp_direccion,
                                        emp_telefono = empresa.emp_telefono,
                                        emp_person_contac = empresa.emp_person_contac,
                                        emp_correo = empresa.emp_correo,
                                        emp_cp = empresa.emp_cp
                                    }).ToList();
                    Session["ListaEmp"] = listaEmpresa;
                }
                else
                {

                    listaEmpresa = (from empresa in db.encuesta_empresa
                                    where empresa.emp_descrip.Contains(nombre_empresa)
                                    select new encuesta_empresaCLS
                                    {
                                        emp_id = empresa.emp_id,
                                        emp_descrip = empresa.emp_descrip,
                                        emp_estatus = empresa.emp_estatus,
                                        emp_u_alta = empresa.emp_u_alta,
                                        emp_f_alta = (DateTime)empresa.emp_f_alta,
                                        emp_u_cancela = empresa.emp_u_cancela,
                                        emp_f_cancela = (DateTime)empresa.emp_f_cancela,
                                        emp_no_trabajadores = empresa.emp_no_trabajadores,
                                        emp_direccion = empresa.emp_direccion,
                                        emp_telefono = empresa.emp_telefono,
                                        emp_person_contac = empresa.emp_person_contac,
                                        emp_correo = empresa.emp_correo,
                                        emp_cp = empresa.emp_cp
                                    }).ToList();
                    Session["ListaEmp"] = listaEmpresa;
                }

            }
            return View(listaEmpresa);
        }
        public ActionResult EditarEmpresa(int id)
        {
            encuesta_empresaCLS Oencuesta_empresaCLS = new encuesta_empresaCLS();

            using (var db = new csstdura_encuestaEntities())
            {
                encuesta_empresa Oencuesta_empresa = db.encuesta_empresa.Where(p => p.emp_id.Equals(id)).First();
                Oencuesta_empresaCLS.emp_id = Oencuesta_empresa.emp_id;
                Oencuesta_empresaCLS.emp_descrip = Oencuesta_empresa.emp_descrip;
                Oencuesta_empresaCLS.emp_estatus = Oencuesta_empresa.emp_estatus;
                Oencuesta_empresaCLS.emp_no_trabajadores = Oencuesta_empresa.emp_no_trabajadores;
                Oencuesta_empresaCLS.emp_direccion = Oencuesta_empresa.emp_direccion;
                Oencuesta_empresaCLS.emp_telefono = Oencuesta_empresa.emp_telefono;
                Oencuesta_empresaCLS.emp_person_contac = Oencuesta_empresa.emp_person_contac;
                Oencuesta_empresaCLS.emp_correo = Oencuesta_empresa.emp_correo;
                Oencuesta_empresaCLS.emp_cp = Oencuesta_empresa.emp_cp;
            }
            return View(Oencuesta_empresaCLS);

        }
        [HttpPost]
        public ActionResult EditarEmpresa(encuesta_empresaCLS Oencuesta_EmpresaCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(Oencuesta_EmpresaCLS);
            }
            int id_empresa = Oencuesta_EmpresaCLS.emp_id;
            using (var db = new csstdura_encuestaEntities())
            {
                encuesta_empresa Oencuesta_empresa = db.encuesta_empresa.Where(p => p.emp_id.Equals(id_empresa)).First();
                Oencuesta_empresa.emp_descrip = Oencuesta_EmpresaCLS.emp_descrip;
                Oencuesta_empresa.emp_estatus = Oencuesta_EmpresaCLS.emp_estatus;
                Oencuesta_empresa.emp_no_trabajadores = Oencuesta_EmpresaCLS.emp_no_trabajadores;
                Oencuesta_empresa.emp_direccion = Oencuesta_EmpresaCLS.emp_direccion;
                Oencuesta_empresa.emp_telefono = Oencuesta_EmpresaCLS.emp_telefono;
                Oencuesta_empresa.emp_person_contac = Oencuesta_EmpresaCLS.emp_person_contac;
                Oencuesta_empresa.emp_correo = Oencuesta_EmpresaCLS.emp_correo;
                Oencuesta_empresa.emp_cp = Oencuesta_EmpresaCLS.emp_cp;
                db.SaveChanges();

            }
            return RedirectToAction("ListarEmpresa");
        }

        public ActionResult EliminarEmpresa(int id)
        {
            encuesta_empresaCLS Oencuesta_empresaCLS = new encuesta_empresaCLS();

            using (var db = new csstdura_encuestaEntities())
            {
                encuesta_empresa Oencuesta_empresa = db.encuesta_empresa.Where(p => p.emp_id.Equals(id)).First();
                Oencuesta_empresaCLS.emp_id = Oencuesta_empresa.emp_id;
                Oencuesta_empresaCLS.emp_descrip = Oencuesta_empresa.emp_descrip;
                Oencuesta_empresaCLS.emp_estatus = Oencuesta_empresa.emp_estatus;
                Oencuesta_empresaCLS.emp_no_trabajadores = Oencuesta_empresa.emp_no_trabajadores;
                Oencuesta_empresaCLS.emp_direccion = Oencuesta_empresa.emp_direccion;
                Oencuesta_empresaCLS.emp_telefono = Oencuesta_empresa.emp_telefono;
                Oencuesta_empresaCLS.emp_person_contac = Oencuesta_empresa.emp_person_contac;
                Oencuesta_empresaCLS.emp_correo = Oencuesta_empresa.emp_correo;
                Oencuesta_empresaCLS.emp_cp = Oencuesta_empresa.emp_cp;
            }
            return View(Oencuesta_empresaCLS);

        }

        [HttpPost]
        public ActionResult EliminarEmpresa(encuesta_empresaCLS Oencuesta_EmpresaCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(Oencuesta_EmpresaCLS);
            }
            int id_empresa = Oencuesta_EmpresaCLS.emp_id;
            using (var db = new csstdura_encuestaEntities())
            {
                encuesta_empresa Oencuesta_empresa = db.encuesta_empresa.Where(p => p.emp_id.Equals(id_empresa)).First();
                Oencuesta_empresa.emp_estatus = "B";
                Oencuesta_empresa.emp_f_cancela = DateTime.Now;

                db.SaveChanges();

            }
            return RedirectToAction("ListarEmpresa");
        }


        public ActionResult InsertaUsuario()
        {
            listarCombos();
            ViewBag.listaEmpresa = listaEmpresa;
            ViewBag.listaSexo = listaSexo;
            ViewBag.listaEdad = listaEdad;
            ViewBag.listaEdoCivil = listaEdoCivil;
            ViewBag.listaOpciones = listaOpciones;
            ViewBag.listaProceso = listaProceso;
            ViewBag.listaPuesto = listaPuesto;
            ViewBag.listaContrata = listaContrata;
            ViewBag.listaPersonal = listaPersonal;
            ViewBag.listaJornada = listaJornada;
            ViewBag.listaRotacion = listaRotacion;
            ViewBag.listaTiempo = listaTiempo;
            ViewBag.listaExpLab = listaExpLab;
            return View();
        }


        [HttpPost]
        public ActionResult InsertaUsuario(encuesta_usuariosCLS Oencuesta_usuariosCLS)
        {
            using (var db = new csstdura_encuestaEntities())
            {
                using (var transaction = new TransactionScope())
                {
                    if (!ModelState.IsValid)
                    {
                        llenarEmpresa();
                        llenarSexo();
                        llenarEdad();
                        llenarEdoCivil();
                        llenarOpciones();
                        llenarProcesoEdu();
                        llenarTipoPuesto();
                        llenarTipoContratacion();
                        llenarTipoPersonal();
                        llenarTipoJornada();
                        llenarRotacionTurno();
                        llenarTiempoEmp();
                        llenarExpLab();
                        ViewBag.listaSexo = listaSexo;
                        ViewBag.listaEdad = listaEdad;
                        ViewBag.listaEdoCivil = listaEdoCivil;
                        ViewBag.listaOpciones = listaOpciones;
                        ViewBag.listaProceso = listaProceso;
                        ViewBag.listaPuesto = listaPuesto;
                        ViewBag.listaContrata = listaContrata;
                        ViewBag.listaPersonal = listaPersonal;
                        ViewBag.listaJornada = listaJornada;
                        ViewBag.listaRotacion = listaRotacion;
                        ViewBag.listaTiempo = listaTiempo;
                        ViewBag.listaExpLab = listaExpLab;
                        return View(Oencuesta_usuariosCLS);
                    }
                    //Usando clase de entity framework
                    encuesta_usuarios usuarios = new encuesta_usuarios();
                    usuarios.usua_nombre = Oencuesta_usuariosCLS.usua_nombre;
                    usuarios.usua_empresa = Oencuesta_usuariosCLS.usua_empresa;
                    usuarios.usua_f_aplica = DateTime.Now;
                    usuarios.usua_tipo = "U";
                    usuarios.usua_estatus = "ACTIVO";
                    usuarios.usua_n_usuario = Oencuesta_usuariosCLS.usua_n_usuario;

                    //Cifrando el password
                    SHA256Managed sha = new SHA256Managed();
                    byte[] byteContra = Encoding.Default.GetBytes(Oencuesta_usuariosCLS.usua_p_usuario);
                    byte[] byteContraCifrado = sha.ComputeHash(byteContra);
                    string contraCifrada = BitConverter.ToString(byteContraCifrado).Replace("-", "");
                    usuarios.usua_p_usuario = contraCifrada;

                    int periodo = db.Database.SqlQuery<int>("Select periodo_id from encuaesta_periodo where periodo_estatus='A'")
                      .FirstOrDefault();
                    //usuarios.usua_p_usuario = Oencuesta_usuariosCLS.usua_p_usuario;
                    usuarios.usua_u_alta = "";
                    usuarios.usua_f_alta = DateTime.Now;
                    usuarios.usua_u_cancela = "";
                    usuarios.usua_f_cancela = null;
                    usuarios.usua_genero = Oencuesta_usuariosCLS.usua_genero;
                    usuarios.usua_edad = Oencuesta_usuariosCLS.usua_edad;
                    usuarios.usua_edo_civil = Oencuesta_usuariosCLS.usua_edo_civil;
                    usuarios.usua_sin_forma = Oencuesta_usuariosCLS.usua_sin_forma;
                    usuarios.usua_primaria = Oencuesta_usuariosCLS.usua_primaria;
                    usuarios.usua_secundaria = Oencuesta_usuariosCLS.usua_secundaria;
                    usuarios.usua_preparatoria = Oencuesta_usuariosCLS.usua_preparatoria;
                    usuarios.usua_tecnico = Oencuesta_usuariosCLS.usua_tecnico;
                    usuarios.usua_licenciatura = Oencuesta_usuariosCLS.usua_licenciatura;
                    usuarios.usua_maestria = Oencuesta_usuariosCLS.usua_maestria;
                    usuarios.usua_doctorado = Oencuesta_usuariosCLS.usua_doctorado;
                    usuarios.usua_tipo_puesto = Oencuesta_usuariosCLS.usua_tipo_puesto;
                    usuarios.usua_tipo_contratacion = Oencuesta_usuariosCLS.usua_tipo_contratacion;
                    usuarios.usua_tipo_personal = Oencuesta_usuariosCLS.usua_tipo_personal;
                    usuarios.usua_tipo_jornada = Oencuesta_usuariosCLS.usua_tipo_jornada;
                    usuarios.usua_rotacion_turno = Oencuesta_usuariosCLS.usua_rotacion_turno;
                    usuarios.usua_tiempo_puesto = Oencuesta_usuariosCLS.usua_tiempo_puesto;
                    usuarios.usua_exp_laboral = Oencuesta_usuariosCLS.usua_exp_laboral;
                    usuarios.usua_presento = "N";
                    usuarios.usua_departamento = Oencuesta_usuariosCLS.usua_departamento;
                    usuarios.usua_centro_trabajo = Oencuesta_usuariosCLS.usua_centro_trabajo;
                    usuarios.usua_periodo = periodo;
                    db.encuesta_usuarios.Add(usuarios);
                    int res = db.SaveChanges();
                    transaction.Complete();
                    if (res == 1)
                    {

                        return Content("<script language='javascript' type='text/javascript'>alert('Registro exitoso!');window.location = '/Admin/Empleados';</script>");

                    }
                    else
                    {

                        return Content("<script language='javascript' type='text/javascript'>alert('Ocurrio un error!');window.location = '/Usuarios/Agregar';</script>");

                    }


                }


            }


        }


        public ActionResult EditarUsuarios(int id)
        {
            listarCombos();
            ViewBag.listaEmpresa = listaEmpresa;
            ViewBag.listaDepto = listaDepto;
            ViewBag.listaCentro = listaCentro;
            ViewBag.listaSexo = listaSexo;
            ViewBag.listaEdad = listaEdad;
            ViewBag.listaEdoCivil = listaEdoCivil;
            ViewBag.listaOpciones = listaOpciones;
            ViewBag.listaProceso = listaProceso;
            ViewBag.listaPuesto = listaPuesto;
            ViewBag.listaContrata = listaContrata;
            ViewBag.listaPersonal = listaPersonal;
            ViewBag.listaJornada = listaJornada;
            ViewBag.listaRotacion = listaRotacion;
            ViewBag.listaTiempo = listaTiempo;
            ViewBag.listaExpLab = listaExpLab;

            encuesta_usuariosCLS Oencuesta_usuarioCLS = new encuesta_usuariosCLS();
            //List<encuesta_usuariosCLS> oUsuarios = null;
            using (var db = new csstdura_encuestaEntities())
            {

                encuesta_usuarios oUsuarios = db.encuesta_usuarios.Where(p => p.usua_id.Equals(id)).First();



                Oencuesta_usuarioCLS.usua_id = oUsuarios.usua_id;
                Oencuesta_usuarioCLS.usua_nombre = oUsuarios.usua_nombre;
                Oencuesta_usuarioCLS.usua_empresa = (int)oUsuarios.usua_empresa;
                Oencuesta_usuarioCLS.usua_departamento = (int)oUsuarios.usua_departamento;
                Oencuesta_usuarioCLS.usua_centro_trabajo = (int)oUsuarios.usua_centro_trabajo;
                //Oencuesta_usuarioCLS.usua_tipo = oUsuarios.usua_tipo;
                Oencuesta_usuarioCLS.usua_n_usuario = oUsuarios.usua_n_usuario;
                Oencuesta_usuarioCLS.usua_genero = (int)oUsuarios.usua_genero;
                Oencuesta_usuarioCLS.usua_edad = (int)oUsuarios.usua_edad;
                Oencuesta_usuarioCLS.usua_edo_civil = (int)oUsuarios.usua_edo_civil;
                Oencuesta_usuarioCLS.usua_sin_forma = (int)oUsuarios.usua_sin_forma;
                Oencuesta_usuarioCLS.usua_primaria = (int)oUsuarios.usua_primaria;
                Oencuesta_usuarioCLS.usua_secundaria = (int)oUsuarios.usua_secundaria;
                Oencuesta_usuarioCLS.usua_preparatoria = (int)oUsuarios.usua_preparatoria;
                Oencuesta_usuarioCLS.usua_tecnico = (int)oUsuarios.usua_tecnico;
                Oencuesta_usuarioCLS.usua_licenciatura = (int)oUsuarios.usua_licenciatura;
                Oencuesta_usuarioCLS.usua_maestria = (int)oUsuarios.usua_maestria;
                Oencuesta_usuarioCLS.usua_doctorado = (int)oUsuarios.usua_doctorado;
                Oencuesta_usuarioCLS.usua_tipo_puesto = (int)oUsuarios.usua_tipo_puesto;
                Oencuesta_usuarioCLS.usua_tipo_contratacion = (int)oUsuarios.usua_tipo_contratacion;
                Oencuesta_usuarioCLS.usua_tipo_personal = (int)oUsuarios.usua_tipo_personal;
                Oencuesta_usuarioCLS.usua_tipo_jornada = (int)oUsuarios.usua_tipo_jornada;
                Oencuesta_usuarioCLS.usua_rotacion_turno = (int)oUsuarios.usua_rotacion_turno;
                Oencuesta_usuarioCLS.usua_tiempo_puesto = (int)oUsuarios.usua_tiempo_puesto;
                Oencuesta_usuarioCLS.usua_exp_laboral = (int)oUsuarios.usua_exp_laboral;
            }
            return View(Oencuesta_usuarioCLS);

        }

        [HttpPost]
        public ActionResult EditarUsuarios(encuesta_usuariosCLS Oencuesta_usuariosCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(Oencuesta_usuariosCLS);
            }
            int id = Oencuesta_usuariosCLS.usua_id;
            using (var db = new csstdura_encuestaEntities())
            {
                //encuesta_usuarios Oencuesta_usuario = db.encuesta_usuarios.Where(p => p.usua_id.Equals(id_usuario)).FirstOrDefault();
                encuesta_usuarios Oencuesta_usuario = db.encuesta_usuarios.Where(p => p.usua_id.Equals(id)).First();

                Oencuesta_usuario.usua_nombre = Oencuesta_usuariosCLS.usua_nombre;
                Oencuesta_usuario.usua_empresa = Oencuesta_usuariosCLS.usua_empresa;
                Oencuesta_usuario.usua_departamento = Oencuesta_usuariosCLS.usua_departamento;
                Oencuesta_usuario.usua_centro_trabajo = Oencuesta_usuariosCLS.usua_centro_trabajo;
                Oencuesta_usuario.usua_n_usuario = Oencuesta_usuariosCLS.usua_n_usuario;

                //Cifrando el password
                SHA256Managed sha = new SHA256Managed();
                byte[] byteContra = Encoding.Default.GetBytes(Oencuesta_usuariosCLS.usua_p_usuario);
                byte[] byteContraCifrado = sha.ComputeHash(byteContra);
                string contraCifrada = BitConverter.ToString(byteContraCifrado).Replace("-", "");
                Oencuesta_usuario.usua_p_usuario = contraCifrada;

                Oencuesta_usuario.usua_genero = Oencuesta_usuariosCLS.usua_genero;
                Oencuesta_usuario.usua_edad = Oencuesta_usuariosCLS.usua_edad;
                Oencuesta_usuario.usua_edo_civil = Oencuesta_usuariosCLS.usua_edo_civil;
                Oencuesta_usuario.usua_sin_forma = Oencuesta_usuariosCLS.usua_sin_forma;
                Oencuesta_usuario.usua_primaria = Oencuesta_usuariosCLS.usua_primaria;
                Oencuesta_usuario.usua_secundaria = Oencuesta_usuariosCLS.usua_secundaria;
                Oencuesta_usuario.usua_preparatoria = Oencuesta_usuariosCLS.usua_preparatoria;
                Oencuesta_usuario.usua_tecnico = Oencuesta_usuariosCLS.usua_tecnico;
                Oencuesta_usuario.usua_licenciatura = Oencuesta_usuariosCLS.usua_licenciatura;
                Oencuesta_usuario.usua_maestria = Oencuesta_usuariosCLS.usua_maestria;
                Oencuesta_usuario.usua_doctorado = Oencuesta_usuariosCLS.usua_doctorado;
                Oencuesta_usuario.usua_tipo_puesto = Oencuesta_usuariosCLS.usua_tipo_puesto;
                Oencuesta_usuario.usua_tipo_contratacion = Oencuesta_usuariosCLS.usua_tipo_contratacion;
                Oencuesta_usuario.usua_tipo_personal = Oencuesta_usuariosCLS.usua_tipo_personal;
                Oencuesta_usuario.usua_tipo_jornada = Oencuesta_usuariosCLS.usua_tipo_jornada;
                Oencuesta_usuario.usua_rotacion_turno = Oencuesta_usuariosCLS.usua_rotacion_turno;
                Oencuesta_usuario.usua_tiempo_puesto = Oencuesta_usuariosCLS.usua_tiempo_puesto;
                Oencuesta_usuario.usua_exp_laboral = Oencuesta_usuariosCLS.usua_exp_laboral;
                db.SaveChanges();

            }
            return RedirectToAction("Empleados");
        }

        public ActionResult EliminarUsuarios(int id)
        {
            listarCombos();
            ViewBag.listaEmpresa = listaEmpresa;
            ViewBag.listaSexo = listaSexo;
            ViewBag.listaEdad = listaEdad;
            ViewBag.listaEdoCivil = listaEdoCivil;
            ViewBag.listaOpciones = listaOpciones;
            ViewBag.listaProceso = listaProceso;
            ViewBag.listaPuesto = listaPuesto;
            ViewBag.listaContrata = listaContrata;
            ViewBag.listaPersonal = listaPersonal;
            ViewBag.listaJornada = listaJornada;
            ViewBag.listaRotacion = listaRotacion;
            ViewBag.listaTiempo = listaTiempo;
            ViewBag.listaExpLab = listaExpLab;

            encuesta_usuariosCLS Oencuesta_usuarioCLS = new encuesta_usuariosCLS();

            using (var db = new csstdura_encuestaEntities())
            {


                encuesta_usuarios oUsuarios = db.encuesta_usuarios.Where(p => p.usua_id.Equals(id)).First();



                Oencuesta_usuarioCLS.usua_id = oUsuarios.usua_id;
                Oencuesta_usuarioCLS.usua_nombre = oUsuarios.usua_nombre;
                Oencuesta_usuarioCLS.usua_empresa = (int)oUsuarios.usua_empresa;
                //Oencuesta_usuarioCLS.usua_tipo = oUsuarios.usua_tipo;
                Oencuesta_usuarioCLS.usua_n_usuario = oUsuarios.usua_n_usuario;
                Oencuesta_usuarioCLS.usua_genero = (int)oUsuarios.usua_genero;
                Oencuesta_usuarioCLS.usua_edad = (int)oUsuarios.usua_edad;
                Oencuesta_usuarioCLS.usua_edo_civil = (int)oUsuarios.usua_edo_civil;
                Oencuesta_usuarioCLS.usua_sin_forma = (int)oUsuarios.usua_sin_forma;
                Oencuesta_usuarioCLS.usua_primaria = (int)oUsuarios.usua_primaria;
                Oencuesta_usuarioCLS.usua_secundaria = (int)oUsuarios.usua_secundaria;
                Oencuesta_usuarioCLS.usua_preparatoria = (int)oUsuarios.usua_preparatoria;
                Oencuesta_usuarioCLS.usua_tecnico = (int)oUsuarios.usua_tecnico;
                Oencuesta_usuarioCLS.usua_licenciatura = (int)oUsuarios.usua_licenciatura;
                Oencuesta_usuarioCLS.usua_maestria = (int)oUsuarios.usua_maestria;
                Oencuesta_usuarioCLS.usua_doctorado = (int)oUsuarios.usua_doctorado;
                Oencuesta_usuarioCLS.usua_tipo_puesto = (int)oUsuarios.usua_tipo_puesto;
                Oencuesta_usuarioCLS.usua_tipo_contratacion = (int)oUsuarios.usua_tipo_contratacion;
                Oencuesta_usuarioCLS.usua_tipo_personal = (int)oUsuarios.usua_tipo_personal;
                Oencuesta_usuarioCLS.usua_tipo_jornada = (int)oUsuarios.usua_tipo_jornada;
                Oencuesta_usuarioCLS.usua_rotacion_turno = (int)oUsuarios.usua_rotacion_turno;
                Oencuesta_usuarioCLS.usua_tiempo_puesto = (int)oUsuarios.usua_tiempo_puesto;
                Oencuesta_usuarioCLS.usua_exp_laboral = (int)oUsuarios.usua_exp_laboral;
            }
            return View(Oencuesta_usuarioCLS);

        }

        public ActionResult ListarEncuesta(encuesta_usuariosCLS empleados_)
        {

            int id_empresa = empleados_.usua_empresa;

            listarCombos();

            ViewBag.listaEmpresa = listaEmpresa;
            ViewBag.listaSexo = listaSexo;
            ViewBag.listaEdad = listaEdad;
            ViewBag.listaEdoCivil = listaEdoCivil;
            

            List<encuesta_usuariosCLS> listaEmpleado = null;
            List<encuesta_usuariosCLS> listaRpta = null;
            using (var db = new csstdura_encuestaEntities())

            {
                int id_estatus = db.Database.SqlQuery<int>("select periodo_id from encuaesta_periodo where periodo_estatus = 'A'").FirstOrDefault();
                

                listaEmpleado = (from empleado in db.encuesta_usuarios
                                 where empleado.usua_presento == "S"
                                 && empleado.usua_periodo == id_estatus
                                 join empresa in db.encuesta_empresa
                                 on empleado.usua_empresa equals empresa.emp_id
                                 join genero in db.encuesta_sexo
                                 on empleado.usua_genero equals genero.sexo_id
                                 join edad_emp in db.encuesta_edades
                                 on empleado.usua_edad equals edad_emp.edad_id
                                 join edo in db.encuesta_edocivil
                                 on empleado.usua_edo_civil equals edo.edocivil_id
                                 //from empleados in db.encuesta_usuarios
                                 join resultado in db.encuesta_resultados
                                 on empleado.usua_id equals resultado.resu_usua_id


                                 select new encuesta_usuariosCLS
                                 {
                                     usua_id = empleado.usua_id,
                                     usua_nombre = empleado.usua_nombre,
                                     usua_estatus = empleado.usua_estatus,
                                     usua_n_usuario = empleado.usua_n_usuario,
                                     usua_p_usuario = empleado.usua_p_usuario,
                                     usua_empresa = (int)empleado.usua_empresa,
                                     usua_genero = (int)empleado.usua_genero,
                                     usua_edad = (int)empleado.usua_edad,
                                     usua_edo_civil = (int)empleado.usua_edo_civil,
                                     empleado_empresa = empresa.emp_descrip,
                                     empleado_genero = genero.sexo_desc,
                                     empleado_edad = edad_emp.edad_desc,
                                     empleado_edocivil = edo.edocivil_desc

                                 }).Distinct().ToList();

                Session["ListaUser"] = listaEmpleado;

                if (empleados_.usua_id == 0 && empleados_.usua_empresa == 0 && empleados_.usua_genero == 0 && empleados_.usua_edad == 0 && empleados_.usua_edo_civil == 0)
                {

                    listaRpta = listaEmpleado;
                    Session["ListaUser"] = listaEmpleado;
                }
                else
                {
                    if (empleados_.usua_empresa != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_empresa.Equals(empleados_.usua_empresa)).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_genero != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_genero.ToString().Contains(empleados_.usua_genero.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }
                    if (empleados_.usua_edad != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_edad.ToString().Contains(empleados_.usua_edad.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }

                    if (empleados_.usua_edo_civil != 0)
                    {
                        listaEmpleado = listaEmpleado.Where(p => p.usua_edo_civil.ToString().Contains(empleados_.usua_edo_civil.ToString())).ToList();
                        Session["ListaUser"] = listaEmpleado;
                    }
                    Session["ListaUser"] = listaEmpleado;
                    listaRpta = listaEmpleado;
                }

            }
            return View(listaRpta);
        }

        public ActionResult VerResultadoUsuario(int id)
        {
            ViewBag.id_usuario = id;
            List<encuesta_mostrarPreguntas2CLS> list;
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
                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                int id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                String num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;
                ViewBag.num_empleados = num_empleados;
            }
            return View(list);

        }

        public ActionResult VerResultadoUsuario2(int id)
        {
            ViewBag.id_usuario = id;
            List<encuesta_mostrarPreguntas2CLS> list;
            using (var db = new csstdura_encuestaEntities())
            {
                list = (from resultados in db.encuesta_resultados
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
                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;
            }
            return View(list);

        }

        public ActionResult VerResultadoUsuario3(int id)
        {
            ViewBag.id_usuario = id;
            List<encuesta_mostrarPreguntas2CLS> list;
            using (var db = new csstdura_encuestaEntities())
            {
                list = (from resultados in db.encuesta_resultados
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
                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;
            }
            return View(list);

        }

        public ActionResult VerResultadoUsuario4(int id)
        {
            ViewBag.id_usuario = id;

            List<encuesta_mostrarPreguntas2CLS> list;
            using (var db = new csstdura_encuestaEntities())
            {
                list = (from resultados in db.encuesta_resultados
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
                ViewBag.nombreEmpleado = nombreEmpleado;
                ViewBag.num_empleados = num_empleados;
            }
            return View(list);

        }

        public ActionResult VerResultadoUsuarioGuiaII(int id)
        {
            ViewBag.id_usuario = id;

            using (var db = new csstdura_encuestaEntities())
            {

                //condiciones en el ambiente de trabajo
                int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();
                ViewBag.CondicionesAmbienteTrabajo = CondicionesAmbienteTrabajo;

                //condiciones en el ambiente de trabajo
                int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();
                ViewBag.CargaTrabajo = CargaTrabajo;

                //falta de control sobre el trabajo
                int FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();
                ViewBag.FaltaControlSobreTrabajo = FaltaControlSobreTrabajo;

                //jornada de trabajo
                int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (34,35) ").FirstOrDefault();
                ViewBag.JornadaTrabajo = JornadaTrabajo;

                //Interferencia en la relación trabajo-familia
                int InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (36,37) ").FirstOrDefault();
                ViewBag.InfluenciaTrabajoFueraCentroLaboral = InfluenciaTrabajoFueraCentroLaboral;

                //Liderazgo
                int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (43,44,45,47,48) ").FirstOrDefault();
                ViewBag.Liderazgo = Liderazgo;

                //Relaciones en el trabajo
                int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();
                ViewBag.RelacionesTrabajo = RelacionesTrabajo;

                //Violencia
                int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();
                ViewBag.Violencia = Violencia;


                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;
            }
            return View();

        }

        public ActionResult VerResultadoUsuarioGuiaIICategoria(int id)
        {
            ViewBag.id_usuario = id;

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();

                //condiciones en el ambiente de trabajo
                int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();

                //falta de control sobre el trabajo
                int FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();

                //jornada de trabajo
                int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (34,35) ").FirstOrDefault();

                //Interferencia en la relación trabajo-familia
                int InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (36,37) ").FirstOrDefault();

                //Liderazgo
                int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (43,44,45,47,48) ").FirstOrDefault();

                //Relaciones en el trabajo
                int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();

                //Violencia
                int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();

                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;

                ViewBag.AmbienteTrabajo = CondicionesAmbienteTrabajo;
                ViewBag.FactoresPropiosActividad = CargaTrabajo + FaltaControlSobreTrabajo;
                ViewBag.OrganizacionTiempoTrabajo = JornadaTrabajo + InfluenciaTrabajoFueraCentroLaboral;
                ViewBag.LiderazgoRelacionesTrabajo = Liderazgo + RelacionesTrabajo + Violencia;
            }

            return View();
        }

        public ActionResult VerResultadoUsuarioGuiaIIFinal(int id)
        {
            ViewBag.id_usuario = id;

            using (var db = new csstdura_encuestaEntities())
            {
                //condiciones en el ambiente de trabajo
                int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (21, 22, 23) ").FirstOrDefault();

                //condiciones en el ambiente de trabajo
                int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (24,29,25,26,27,28,61,62,63,30,31,32,33) ").FirstOrDefault();

                //falta de control sobre el trabajo
                int FaltaControlSobreTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (40,41,42,38,39,68,46) ").FirstOrDefault();

                //jornada de trabajo
                int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (34,35) ").FirstOrDefault();

                //Interferencia en la relación trabajo-familia
                int InfluenciaTrabajoFueraCentroLaboral = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (36,37) ").FirstOrDefault();

                //Liderazgo
                int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (43,44,45,47,48) ").FirstOrDefault();

                //Relaciones en el trabajo
                int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (49,50,51,65,66,67) ").FirstOrDefault();

                //Violencia
                int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 2 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (52,53,54,55,56,57,58,59) ").FirstOrDefault();

                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;

                ViewBag.CalificacionFinalCuestionario = CondicionesAmbienteTrabajo + CargaTrabajo + FaltaControlSobreTrabajo +
                                                        JornadaTrabajo + InfluenciaTrabajoFueraCentroLaboral + Liderazgo +
                                                        RelacionesTrabajo + Violencia;
            }

            return View();
        }

        public ActionResult VerResultadoUsuarioGuiaIII(int id)
        {
            ViewBag.id_usuario = id;

            using (var db = new csstdura_encuestaEntities())
            {

                //condiciones en el ambiente de trabajo
                int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (69,70,71,72,73) ").FirstOrDefault();
                ViewBag.CondicionesAmbienteTrabajo = CondicionesAmbienteTrabajo;

                //carga de trabajo
                int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();
                ViewBag.CargaTrabajo = CargaTrabajo;

                //Falta de control sobre el trabajo
                int FaltaControlTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();
                ViewBag.FaltaControlTrabajo = FaltaControlTrabajo;

                //Jornada de trabajo
                int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (85,86) ").FirstOrDefault();
                ViewBag.JornadaTrabajo = JornadaTrabajo;

                //Interferencia en la relación trabajo-familia
                int InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (87,88,89,90) ").FirstOrDefault();
                ViewBag.InterferenciaRelacionTrabajoFamilia = InterferenciaRelacionTrabajoFamilia;

                //Liderazgo
                int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();
                ViewBag.Liderazgo = Liderazgo;

                //Relaciones en el trabajo
                int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();
                ViewBag.RelacionesTrabajo = RelacionesTrabajo;

                //Violencia
                int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();
                ViewBag.Violencia = Violencia;

                //Reconocimiento del desempeño
                int ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();
                ViewBag.ReconocimientoDesempeño = ReconocimientoDesempeño;

                //Insuficiente sentido de pertenencia e, inestabilidad
                int InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (124,121,122,123) ").FirstOrDefault();
                ViewBag.InsuficienteSentido = InsuficienteSentido;

                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;
            }
            return View();

        }

        public ActionResult VerResultadoUsuarioGuiaIIICategoria(int id)
        {
            ViewBag.id_usuario = id;

            using (var db = new csstdura_encuestaEntities())
            {

                //condiciones en el ambiente de trabajo
                int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (69,70,71,72,73) ").FirstOrDefault();

                //carga de trabajo
                int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();

                //Falta de control sobre el trabajo
                int FaltaControlTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();

                //Jornada de trabajo
                int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (85,86) ").FirstOrDefault();

                //Interferencia en la relación trabajo-familia
                int InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (87,88,89,90) ").FirstOrDefault();

                //Liderazgo
                int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();

                //Relaciones en el trabajo
                int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();

                //Violencia
                int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();

                //Reconocimiento del desempeño
                int ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();

                //Insuficiente sentido de pertenencia e, inestabilidad
                int InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (124,121,122,123) ").FirstOrDefault();

                ViewBag.AmbienteTrabajo = CondicionesAmbienteTrabajo;
                ViewBag.FactoresPropiosActividad = CargaTrabajo + FaltaControlTrabajo;
                ViewBag.OrganizacionTiempoTrabajo = JornadaTrabajo + InterferenciaRelacionTrabajoFamilia;
                ViewBag.LiderazgoRelacionesTrabajo = Liderazgo + RelacionesTrabajo + Violencia;
                ViewBag.EntornoOrganizacional = ReconocimientoDesempeño + InsuficienteSentido;

                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;
            }
            return View();

        }

        public ActionResult VerResultadoUsuarioGuiaIIIFinal(int id)
        {
            ViewBag.id_usuario = id;

            using (var db = new csstdura_encuestaEntities())
            {

                //condiciones en el ambiente de trabajo
                int CondicionesAmbienteTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (69,70,71,72,73) ").FirstOrDefault();

                //carga de trabajo
                int CargaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (74,80,75,76,77,78,79,134,135,136,137,81,82,83,84) ").FirstOrDefault();

                //Falta de control sobre el trabajo
                int FaltaControlTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (93,94,95,96,91,92,97,98,103,104) ").FirstOrDefault();

                //Jornada de trabajo
                int JornadaTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (85,86) ").FirstOrDefault();

                //Interferencia en la relación trabajo-familia
                int InterferenciaRelacionTrabajoFamilia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (87,88,89,90) ").FirstOrDefault();

                //Liderazgo
                int Liderazgo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (99,100,101,102,105,106,107,108,109) ").FirstOrDefault();

                //Relaciones en el trabajo
                int RelacionesTrabajo = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (110,111,112,113,114,139,140,141,142) ").FirstOrDefault();

                //Violencia
                int Violencia = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (125,126,127,128,129,130,131,132) ").FirstOrDefault();

                //Reconocimiento del desempeño
                int ReconocimientoDesempeño = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (115,116,117,118,119,120) ").FirstOrDefault();

                //Insuficiente sentido de pertenencia e, inestabilidad
                int InsuficienteSentido = db.Database.SqlQuery<int>("select sum(convert(int, resu_resultado)) " +
                                                            " from encuesta_det_encuesta, encuesta_resultados " +
                                                            " where denc_encu_id = 3 " +
                                                            " and resu_denc_id = denc_id " +
                                                            " and resu_usua_id = " + id + " " +
                                                            " and denc_id in (124,121,122,123) ").FirstOrDefault();

                ViewBag.CalificacionFinalCuestionarioIII = CondicionesAmbienteTrabajo + CargaTrabajo + FaltaControlTrabajo +
                                                            JornadaTrabajo + InterferenciaRelacionTrabajoFamilia + Liderazgo +
                                                            RelacionesTrabajo + Violencia + ReconocimientoDesempeño +
                                                            InsuficienteSentido;

                string nombreEmpleado = db.Database.SqlQuery<string>("select usua_nombre from encuesta_usuarios where usua_id =" + id).FirstOrDefault();
                ViewBag.nombreEmpleado = nombreEmpleado;
            }
            return View();

        }

        public ActionResult VerResultadoPorEmpresa(string ids_usuarios)
        {

            if (ids_usuarios != null)
            {
                ViewBag.ids = ids_usuarios;
                String[] str = ids_usuarios.Split(',');

                using (var db = new csstdura_encuestaEntities())
                {
                    //con el primer registro sabemos de donde son los empleados(la empresa)
                    int id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + str[0]).FirstOrDefault();
                    String num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                    int No_Empleados = Convert.ToInt32(num_empleados);
                    ViewBag.numeroEmpleados = num_empleados;

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
                        ViewBag.CondicionesAmbienteTrabajo = valorFinal;

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
                        ViewBag.CargaTrabajo = valorFinal;

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
                        ViewBag.FaltaControlSobreTrabajo = valorFinal;

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
                        ViewBag.JornadaTrabajo = valorFinal;

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
                        ViewBag.InfluenciaTrabajoFueraCentroLaboral = valorFinal;

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
                        ViewBag.Liderazgo = valorFinal;

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
                        ViewBag.RelacionesTrabajo = valorFinal;

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
                        ViewBag.Violencia = valorFinal;
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
                        ViewBag.CondicionesAmbienteTrabajo = valorFinal;

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
                        ViewBag.CargaTrabajo = _CargaTrabajo;

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
                        ViewBag.FaltaControlTrabajo = valorFinal;

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
                        ViewBag.JornadaTrabajo = valorFinal;

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
                        ViewBag.InterferenciaRelacionTrabajoFamilia = valorFinal;

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
                        ViewBag.Liderazgo = valorFinal;

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
                        ViewBag.RelacionesTrabajo = valorFinal;

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
                        ViewBag.Violencia = valorFinal;

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
                        ViewBag.ReconocimientoDesempeño = valorFinal;

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
                        ViewBag.InsuficienteSentido = valorFinal;

                    }

                }
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Esta empresa aun no tiene algun empleado que presento.');</script>");
            }

            
            
        }

        public ActionResult VerResultadoPorEmpresaCategoria(string ids_usuarios)
        {
            ViewBag.ids = ids_usuarios;
            String[] str = ids_usuarios.Split(',');

            using (var db = new csstdura_encuestaEntities())
            {
                //con el primer registro sabemos de donde son los empleados(la empresa)
                int id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + str[0]).FirstOrDefault();
                String num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                int No_Empleados = Convert.ToInt32(num_empleados);
                ViewBag.numeroEmpleados = num_empleados;

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
                
                    ViewBag.AmbienteTrabajo = valorFinal1;
                    ViewBag.FactoresPropiosActividad = valorFinal2 + valorFinal3;
                    ViewBag.OrganizacionTiempoTrabajo = valorFinal4 + valorFinal5;
                    ViewBag.LiderazgoRelacionesTrabajo = valorFinal6 + valorFinal7 + valorFinal8;
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

                    ViewBag.AmbienteTrabajo = valorFinal1;
                    ViewBag.FactoresPropiosActividad = valorFinal2 + valorFinal3;
                    ViewBag.OrganizacionTiempoTrabajo = valorFinal4 + valorFinal5;
                    ViewBag.LiderazgoRelacionesTrabajo = valorFinal6 + valorFinal7 + valorFinal8;
                    ViewBag.EntornoOrganizacional = valorFinal9 + valorFinal10;
                }
                    

            }
                return View();
        }

        public ActionResult VerResultadoPorEmpresaFinal(string ids_usuarios)
        {
            ViewBag.ids = ids_usuarios;
            String[] str = ids_usuarios.Split(',');

            using (var db = new csstdura_encuestaEntities())
            {
                //con el primer registro sabemos de donde son los empleados(la empresa)
                int id_empresa = db.Database.SqlQuery<int>("select usua_empresa from encuesta_usuarios where usua_id =" + str[0]).FirstOrDefault();
                String num_empleados = db.Database.SqlQuery<String>("select emp_no_trabajadores from encuesta_empresa where emp_id = '" + id_empresa + "'").FirstOrDefault();
                int No_Empleados = Convert.ToInt32(num_empleados);
                ViewBag.numeroEmpleados = num_empleados;

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

                    ViewBag.CalificacionFinalCuestionario = valorFinal1 + valorFinal2 + valorFinal3 +
                                                            valorFinal4 + valorFinal5 + valorFinal6 +
                                                            valorFinal7 + valorFinal8;
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

                    ViewBag.CalificacionFinalCuestionarioIII = valorFinal1 + valorFinal2 + valorFinal3 +
                                                            valorFinal4 + valorFinal5 + valorFinal6 +
                                                            valorFinal7 + valorFinal8 + valorFinal9 +
                                                            valorFinal10;
                }
            }

            return View();
        }

        public ActionResult VerAtencionMedica(string ids_usuarios)
        {
            ViewBag.ids = ids_usuarios;
            
            List<encuesta_usuariosCLS> listaEmpleado = null;

            using (var db = new csstdura_encuestaEntities())
            {
           
                List<int> Acontecimiento = new List<int>() { 1, 2, 3, 4, 5, 6 };
                List<int> Recuerdos = new List<int>() { 7, 8 };
                List<int> Esfuerzo = new List<int>() { 9, 10, 11, 12, 13, 14, 15 };
                List<int> Afectación = new List<int>() { 16, 17, 18, 19, 20 };
                List<int> intUsuarios = new List<int>() { };
                
                String[] str = ids_usuarios.Split(',');
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
                                        resu_seccion = "IV Afectación"
                                    }).Distinct().ToList();

            }
            return View(listaEmpleado);

        }

    }
}