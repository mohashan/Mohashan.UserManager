namespace Mohashan.UserManager.API.Utility;

[AttributeUsage(AttributeTargets.Method)]
public class FileResultContentTypeAttribute:System.Attribute
{
    public FileResultContentTypeAttribute(string contentType)
    {
        ContentType = contentType;
    }

    public string ContentType { get; }
}
