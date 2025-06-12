using MediatR;

namespace tocaaqui_backend.Profile.Domain.Model.Commands;

public class UploadProfileImageCommand : IRequest<string>
{
    public Guid ProfileId { get; set; }
    public string ImageBase64 { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }

    public UploadProfileImageCommand(Guid profileId, byte[] imageBytes, string fileName, string contentType)
    {
        ProfileId = profileId;
        ImageBase64 = Convert.ToBase64String(imageBytes);
        FileName = fileName;
        ContentType = contentType;
    }
}