using System.IO;


namespace FaceRecogService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ImageUploadService : IImageUpload
    {

        public ImageUploadService()
        {
            
        }

        public void FileUpload(string fileName, Stream fileStream)
        {

            FileStream fileToupload = new FileStream("C:\\ImageProcessing\\Images\\Destination\\" + fileName, FileMode.Create);

            byte[] bytearray = new byte[5000000];
            int bytesRead, totalBytesRead = 0;
            fileToupload.Position = 0;

            do
            {
                bytesRead = fileStream.Read(bytearray, 0, bytearray.Length);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);

            fileToupload.Write(bytearray, 0, totalBytesRead);
            fileToupload.Close();
            fileToupload.Dispose();

            MailingModule mm = new MailingModule();
            mm.sendMailModule("C:\\ImageProcessing\\Images\\Destination\\" + fileName, false);
        }
    }
}
