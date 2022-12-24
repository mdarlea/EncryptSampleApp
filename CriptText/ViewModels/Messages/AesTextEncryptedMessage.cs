using CommunityToolkit.Mvvm.Messaging.Messages;
using CriptText.Models;

namespace CriptText.ViewModels.Messages
{
    public class AesTextEncryptedMessage : ValueChangedMessage<AesEncryptModel>
    {
        public AesTextEncryptedMessage(AesEncryptModel value, string? timeFileName) : base(value)
        {
			TimeFileName = timeFileName;
		}

		public string? TimeFileName { get; }
	}
}
