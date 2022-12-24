using CommunityToolkit.Mvvm.Messaging.Messages;
using CriptText.Models;

namespace CriptText.ViewModels.Messages
{
	public class RsaTextEncryptedMessage : ValueChangedMessage<RsaEncryptModel>
	{
		public RsaTextEncryptedMessage(RsaEncryptModel value, string? timeFileName) : base(value)
		{
			TimeFileName = timeFileName;
		}

		public string? TimeFileName { get; }
	}
}
