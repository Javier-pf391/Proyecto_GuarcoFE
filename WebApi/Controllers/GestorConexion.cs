using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class GestorConexion 
    {
        public HttpClient ConexionApi { get; set; }

        public GestorConexion()
        {
            ConexionApi = new HttpClient();
            EstablecerParametrosBase();
        }

        public void EstablecerParametrosBase()
        {
            ConexionApi.BaseAddress = new Uri("https://localhost:7024");
            ConexionApi.DefaultRequestHeaders.Accept.Clear();
            ConexionApi.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool>Crear_documentos(Documentos_GuarcoModel pDocumentos)
        {
            string rutaApi = @"api/Documentos_Guarco/Crear_documentos";

            HttpResponseMessage resul = await ConexionApi.PostAsJsonAsync(rutaApi, pDocumentos);
            return resul.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarDocumentos(Documentos_GuarcoModel pID)
        {
            string rutaApi = @"api/Documentos_Guarco/ModificarDocumentos";

            ConexionApi.DefaultRequestHeaders.Add("pID", pID.id_documento.ToString());
            HttpResponseMessage result = await ConexionApi.PutAsJsonAsync(rutaApi, pID);
            return result.IsSuccessStatusCode;
        }
        public async Task<List<Documentos_GuarcoModel>> VerDocumentos(int pID)
        {
            List<Documentos_GuarcoModel> lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/VerDocumentos";
            ConexionApi.DefaultRequestHeaders.Add("pID", pID.ToString());

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if (resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }

            return lsDocumentos;
        }

        public async Task<List<Documentos_GuarcoModel>> DocumentosElaboracion()
        {
            List<Documentos_GuarcoModel> lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/DocumentosElaboracion";

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if (resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }

            return lsDocumentos;
        }
        public async Task<List<Documentos_GuarcoModel>> DocumentosRevision()
        {
            List<Documentos_GuarcoModel> lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/DocumentosRevision";

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if (resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }

            return lsDocumentos;
        }
        public async Task<List<Documentos_GuarcoModel>> DocumentosAprobado()
        {
            List<Documentos_GuarcoModel> lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/DocumentosAprobado";

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if (resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }

            return lsDocumentos;
        }
        public async Task<List<Documentos_GuarcoModel>> ConsultarDocumentos()
        {
            List<Documentos_GuarcoModel> lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/ConsultarDocumentos";

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if (resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }

            return lsDocumentos;
        }
        public async Task<List<Documentos_GuarcoModel>> VerHoras()
        {
            List<Documentos_GuarcoModel> lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/VerHoras";

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if (resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }

            return lsDocumentos;
        }


        public  async Task<List<Documentos_GuarcoModel>>BusquedaCodigo(string pCodigo)
        {
           
            List<Documentos_GuarcoModel>lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/BusquedaCodigo";
            ConexionApi.DefaultRequestHeaders.Add("pCodigo", pCodigo);

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if(resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }
            return lsDocumentos;
        }
        public async Task<List<Documentos_GuarcoModel>> AprobacionArea(string pAproArea)
        {
          
            List<Documentos_GuarcoModel> lsDocumentos = new List<Documentos_GuarcoModel>();
            string rutaApi = @"api/Documentos_Guarco/AprobacionArea";
            ConexionApi.DefaultRequestHeaders.Add("pAproArea", pAproArea);

            HttpResponseMessage resul = await ConexionApi.GetAsync(rutaApi);
            if (resul.IsSuccessStatusCode)
            {
                string jsonstring = await resul.Content.ReadAsStringAsync();
                lsDocumentos = JsonConvert.DeserializeObject<List<Documentos_GuarcoModel>>(jsonstring);
            }
            return lsDocumentos;
        }
        public async Task<bool> Eliminar_documentos(int pID)
        {
            string rutaApi = @"api/Documentos_Guarco/Eliminar_documentos";
            ConexionApi.DefaultRequestHeaders.Add("pID", pID.ToString());

            HttpResponseMessage resultado = await ConexionApi.DeleteAsync(rutaApi);
            return resultado.IsSuccessStatusCode;
        }

    }
}
