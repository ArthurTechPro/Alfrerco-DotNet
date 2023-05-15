using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    internal class Propertis
    {
        private const string AlfrescoApiUrl = "https://your-alfresco-instance.com/alfresco/api/-default-/public/alfresco/versions/1";

        // Este método sube un documento PDF a Alfresco y le asigna metadatos para su búsqueda posterior.
        public async Task UploadPdfToAlfresco(string filePath, string fileName, string author, string description)
        {
            try
            {
                // Crear una instancia de HttpClient para conectarse con la API REST de Alfresco
                using (var client = new HttpClient())
                {
                    // Crear la solicitud HTTP para subir el documento
                    using (var formData = new MultipartFormDataContent())
                    {
                        var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                        formData.Add(fileContent, "filedata", fileName);

                        // Agregar metadatos al documento
                        var properties = new JObject
                    {
                        {"cm:title", fileName},
                        {"cm:description", description},
                        {"cm:author", author},
                        {"cm:created", DateTime.UtcNow.ToString("o")}
                    };
                        var propertiesContent = new StringContent(properties.ToString());
                        propertiesContent.Headers.ContentType = null;
                        formData.Add(propertiesContent, "cm:properties");

                        // Enviar la solicitud HTTP a Alfresco
                        var requestUri = $"{AlfrescoApiUrl}/nodes/-my-/children";
                        var response = await client.PostAsync(requestUri, formData);
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception($"Error al subir el documento a Alfresco: {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al subir el documento a Alfresco: {ex.Message}");
            }
        }
    }
}
