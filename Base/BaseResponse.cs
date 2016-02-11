namespace MegaplanAPILibrary.Base
{
	public abstract class BaseResponse
	{
		public ResponseStatus status {get; set;}
		public Error Error {get; set;}
	}
	
	public class ResponseStatus 
	{
		public string code {get; set;}
		public string message {get; set;}
	}
}
