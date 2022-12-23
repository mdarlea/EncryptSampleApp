namespace CriptText.Models
{
    public class AesEncryptModel
    {
        public string? EncryptedText { get; set; }
        public string? KeyBase64 { get; set; }
        public string? VectorBase64 { get; set; }
    }
}
