using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class Documentos_GuarcoController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Crear_documentos(Documentos_GuarcoModel pDocumentos, string action)
        {
            if (!ModelState.IsValid)
            {
               
                return View(pDocumentos);
            }


            var obj = new GestorConexion();
            pDocumentos.Fecha_inicio = DateTime.Now;

            if (action == "Guardar y Salir")
            {
                pDocumentos.estado = "Elaboración";
               
            }
            else if (action == "Finalizar")
            {
                pDocumentos.estado = "Revision";
                pDocumentos.Fecha_finalizacion = DateTime.Now;
                pDocumentos.Fecha_revision_inicio = DateTime.Now;
              
            }

            await obj.Crear_documentos(pDocumentos);
          
            string asunto = "📄 Documento creado";

            string cuerpo = $@"
    <h3>Nuevo documento registrado</h3>
    <ul>
        <li><strong>Código:</strong> {pDocumentos.codigo}</li>
        <li><strong>Estado:</strong> {pDocumentos.estado}</li>
        <li><strong>Nombre:</strong> {pDocumentos.nombre}</li>
        <li><strong>Área:</strong> {pDocumentos.nombre_area}</li>
    </ul>
    <p style='color:red;'><em>⚠️ No contestar este correo, ha sido generado automáticamente.</em></p>
";
            await _emailService.SendEmailAsync("javierpadillafallas@gmail.com", asunto, cuerpo);

          
            return RedirectToAction("BusquedaCodigo");
        }
        public IActionResult Inicio()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> VerDocumentos(int pID)
        {
            var obj = new GestorConexion();
            var lista = await obj.VerDocumentos(pID); 
            var documento = lista.FirstOrDefault(); 

            if (documento == null)
                return NotFound();

            return View(documento); 
        }
        [HttpGet]
        public async Task<IActionResult> ModificarDocumentos(int pID)
        {
            var obj = new GestorConexion();
            var lista = await obj.VerDocumentos(pID); 

            var documento = lista.FirstOrDefault(); 

            if (documento == null)
                return NotFound();

            return View(documento);
        }
        [HttpPost]
        public async Task<IActionResult> ModificarDocumentos(Documentos_GuarcoModel pID, string Action)
        {
            if (!ModelState.IsValid)
                return View(pID); 
            var obj = new GestorConexion();

            if (pID.estado == "Elaboración")
            {
                if (Action == "Guardar y Salir")
                {
                    await obj.ModificarDocumentos(pID);
                    string asunto = $"📌 Documento actualizado - Estado: {pID.estado}";

                    string cuerpo = $@"
    <h3>Actualización del Documento</h3>
    <ul>
        <li><strong>Código:</strong> {pID.codigo}</li>
        <li><strong>Estado:</strong> {pID.estado}</li>
        <li><strong>Nombre:</strong> {pID.nombre}</li>
        <li><strong>Área:</strong> {pID.nombre_area}</li>
    </ul>
    <p style='color:red;'><em>⚠️ No contestar este correo, ha sido generado automáticamente.</em></p>
";
                    await _emailService.SendEmailAsync("javierpadillafallas@gmail.com", asunto, cuerpo);
                    return RedirectToAction("BusquedaCodigo");
                }
                else if(Action == "Finalizar")
                {
                    pID.estado = "Revision";
                    pID.Fecha_finalizacion = DateTime.Now;
                    pID.Fecha_revision_inicio = DateTime.Now;
                    await obj.ModificarDocumentos(pID);
                    string asunto = $"📌 Documento actualizado - Estado: {pID.estado}";

                    string cuerpo = $@"
    <h3>Actualización del Documento</h3>
    <ul>
        <li><strong>Código:</strong> {pID.codigo}</li>
        <li><strong>Estado:</strong> {pID.estado}</li>
        <li><strong>Nombre:</strong> {pID.nombre}</li>
        <li><strong>Área:</strong> {pID.nombre_area}</li>
    </ul>
    <p style='color:red;'><em>⚠️ No contestar este correo, ha sido generado automáticamente.</em></p>
";
                    await _emailService.SendEmailAsync("javierpadillafallas@gmail.com", asunto, cuerpo);

                    return RedirectToAction("BusquedaCodigo");

                }


                
            }

            if (pID.estado == "Revision")
            {
                if (Action == "Guardar y Salir")
                {
                    await obj.ModificarDocumentos(pID);
                    string asunto = $"📌 Documento actualizado - Estado: {pID.estado}";

                    string cuerpo = $@"
    <h3>Actualización del Documento</h3>
    <ul>
        <li><strong>Código:</strong> {pID.codigo}</li>
        <li><strong>Estado:</strong> {pID.estado}</li>
        <li><strong>Nombre:</strong> {pID.nombre}</li>
        <li><strong>Área:</strong> {pID.nombre_area}</li>
    </ul>
    <p style='color:red;'><em>⚠️ No contestar este correo, ha sido generado automáticamente.</em></p>
";
                    await _emailService.SendEmailAsync("javierpadillafallas@gmail.com", asunto, cuerpo);
                    return RedirectToAction("BusquedaCodigo");
                }
                else if (Action == "Finalizar")
                {
                    pID.estado = "Aprobado";
                    pID.Fecha_revision_finalizacion = DateTime.Now;
                    pID.Fecha_aprobacion = DateTime.Now;
                    await obj.ModificarDocumentos(pID);
                    string asunto = $"📌 Documento actualizado - Estado: {pID.estado}";

                    string cuerpo = $@"
    <h3>Actualización del Documento</h3>
    <ul>
        <li><strong>Código:</strong> {pID.codigo}</li>
        <li><strong>Estado:</strong> {pID.estado}</li>
        <li><strong>Nombre:</strong> {pID.nombre}</li>
        <li><strong>Área:</strong> {pID.nombre_area}</li>
    </ul>
    <p style='color:red;'><em>⚠️ No contestar este correo, ha sido generado automáticamente.</em></p>
";
                    await _emailService.SendEmailAsync("javierpadillafallas@gmail.com", asunto, cuerpo);
                    return RedirectToAction("BusquedaCodigo");
                }

                
            }

            
           
            
            return View(pID);
        }


       
        public async Task<IActionResult> DocumentosElaboracion()
        {
            GestorConexion obj = new GestorConexion();
            List<Documentos_GuarcoModel> resul = await obj.DocumentosElaboracion();
            return View(resul);
        }
        public async Task<IActionResult> DocumentosRevision()
        {
            GestorConexion obj = new GestorConexion();
            List<Documentos_GuarcoModel> resul = await obj.DocumentosRevision();
            return View(resul);
        }
        public async Task<IActionResult> DocumentosAprobado()
        {
            GestorConexion obj = new GestorConexion();
            List<Documentos_GuarcoModel> resul = await obj.DocumentosAprobado();
            return View(resul);
        }
        public async Task<IActionResult> ConsultarDocumentos()
        {
            GestorConexion obj = new GestorConexion();
            List<Documentos_GuarcoModel> resul = await obj.ConsultarDocumentos();
            return View(resul);
        }

        public async Task<IActionResult> BusquedaCodigo(string pCodigo)
        {
           
            Documentos_GuarcoModel model = new Documentos_GuarcoModel {codigo= pCodigo };
            GestorConexion obj = new GestorConexion();
            List<Documentos_GuarcoModel>resul = await obj.BusquedaCodigo(pCodigo);
            return View(resul);
        }

        public IActionResult Crear_documentos()
        {
            var modelo = new Documentos_GuarcoModel
            {
                Fecha_inicio = DateTime.Now,
              
            };

            return View(modelo);

        }
        public async Task<IActionResult> VerHoras()
        {
            GestorConexion obj = new GestorConexion();
            List<Documentos_GuarcoModel> documentos = await obj.VerHoras(); 

            double totalHorasInicioFinal = 0, totalHorasRevision = 0, totalHorasAprobacion = 0;
            int countInicioFinal = 0, countRevision = 0, countAprobacion = 0;

            foreach (var doc in documentos)
            {
                if (doc.Fecha_inicio.HasValue && doc.Fecha_finalizacion.HasValue)
                {
                    totalHorasInicioFinal += (doc.Fecha_finalizacion - doc.Fecha_inicio).Value.TotalHours;
                    countInicioFinal++;
                }

                if (doc.Fecha_revision_inicio.HasValue && doc.Fecha_revision_finalizacion.HasValue)
                {
                    totalHorasRevision += (doc.Fecha_revision_finalizacion - doc.Fecha_revision_inicio).Value.TotalHours;
                    countRevision++;
                }

            
                if (doc.Fecha_aprobacion.HasValue && doc.Fecha_revision_inicio.HasValue)
                {
                    totalHorasAprobacion += (doc.Fecha_aprobacion - doc.Fecha_revision_inicio).Value.TotalHours;
                    countAprobacion++;
                }
            }

            var modeloPromedio = new
            {
                PromedioInicioFinal = countInicioFinal > 0 ? totalHorasInicioFinal / countInicioFinal : 0,
                PromedioRevision = countRevision > 0 ? totalHorasRevision / countRevision : 0,
                PromedioAprobacion = countAprobacion > 0 ? totalHorasAprobacion / countAprobacion : 0
            };

      
            Console.WriteLine($"Inicio-Final: {modeloPromedio.PromedioInicioFinal}");
            Console.WriteLine($"Revision: {modeloPromedio.PromedioRevision}");
            Console.WriteLine($"Aprobacion: {modeloPromedio.PromedioAprobacion}");

            return View(modeloPromedio);
        }

        private readonly EmailService _emailService;

        public Documentos_GuarcoController(EmailService emailService)
        {
            _emailService = emailService;

        }

        public async Task<IActionResult> Eliminar_documentos(int pID)
        {
            Documentos_GuarcoModel model = new Documentos_GuarcoModel { id_documento = pID };
            GestorConexion objconexion = new GestorConexion();
            await objconexion.Eliminar_documentos(pID);
            return RedirectToAction("BusquedaCodigo", "Documentos_Guarco");
        }

    }
}
