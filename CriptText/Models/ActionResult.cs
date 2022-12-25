namespace CriptText.Models
{
	public class ActionResult<T>
	{
		public ActionResult(T result) 
		{
			Result = result;
		}

		public T Result { get; }
		public string? Error { get; set; }
	}
}
