using MTOM.Service.DTO;
using MTOM.Service.Interfaces;
using System;
using System.IO;
using System.IO.Pipes;
using System.ServiceModel.Web;
using System.Xml.Serialization;

namespace MTOM.Service
{
    public class UploadService : IUploadService
    {
        public bool Upload(UploadRequest request)
        {
            try
            {
                /*
                 * process your upload here
                 * request.Content - your file upload bytes
                 * request.Attachment - your Attachment Metadata which I mimicked as much as I could based on your attached xml
                 */

                File.WriteAllBytes("C:\\Recovery\\dummy.pdf", request.Content);
                using (var writer = new StringWriter())
                {
                    new XmlSerializer(request.Attachment.GetType()).Serialize(writer, request.Attachment);
                    File.WriteAllText("C:\\Recovery\\request.xml", writer.ToString());
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
