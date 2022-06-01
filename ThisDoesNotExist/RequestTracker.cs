namespace ThisDoesNotExist;

public interface IRequestTracker
{
    public DateTime TimeOfLastRequest { get; }
    public void Add(HttpContext context);
}

public class RequestTracker : IRequestTracker
{
    public DateTime TimeOfLastRequest { get; private set; }

    public void Add(HttpContext context)
    {
        TimeOfLastRequest = DateTime.Now;
    }
}