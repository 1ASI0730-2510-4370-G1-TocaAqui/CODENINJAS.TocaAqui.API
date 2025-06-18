using MediatR;

namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.Commands;

public class UploadProfileImageCommand : IRequest<string>
{
    public int ProfileId { get; set; }
    public string ImageBase64 { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }

    public UploadProfileImageCommand(int profileId, byte[] imageBytes, string fileName, string contentType)
    {
        ProfileId = profileId;
        ImageBase64 = Convert.ToBase64String(imageBytes);
        FileName = fileName;
        ContentType = contentType;
    }
}