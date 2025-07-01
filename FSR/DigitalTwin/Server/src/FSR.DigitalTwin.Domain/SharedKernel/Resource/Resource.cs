namespace FSR.DigitalTwin.Domain.SharedKernel.Resource;

public abstract class Resource {

    public abstract string Name { get; init; }
    public abstract Uri Uri { get; init; }
    public abstract StreamReader GetStreamReader();
    public virtual byte[] GetBytes() => [];
    public virtual int GetContentLength() => -1;

}