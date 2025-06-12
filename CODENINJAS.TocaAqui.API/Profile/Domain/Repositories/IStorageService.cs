namespace CODENINJAS.TocaAqui.API.Profile.Domain.Repositories;

public interface IStorageService
{
    /// <summary>
    /// Sube un archivo al almacenamiento externo.
    /// </summary>
    /// <param name="fileBytes">Contenido del archivo en bytes.</param>
    /// <param name="fileName">Nombre con el que se guardará el archivo.</param>
    /// <param name="contentType">Tipo MIME (ej. image/png, image/jpeg).</param>
    /// <returns>URL pública o identificador del recurso almacenado.</returns>
    Task<string> UploadFileAsync(byte[] fileBytes, string fileName, string contentType);

    /// <summary>
    /// Elimina un archivo del almacenamiento.
    /// </summary>
    /// <param name="fileUrl">URL o identificador del archivo a eliminar.</param>
    Task DeleteFileAsync(string fileUrl);
}
