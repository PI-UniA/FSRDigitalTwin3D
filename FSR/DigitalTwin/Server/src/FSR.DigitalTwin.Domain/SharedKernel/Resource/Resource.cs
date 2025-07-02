namespace FSR.DigitalTwin.Domain.SharedKernel.Resource;

public abstract class Resource {

    public abstract string Name { get; init; }
    public abstract string LocalName { get; }
    public abstract Uri Uri { get; init; }
    public abstract StreamReader GetStreamReader();
    public virtual byte[] GetBytes() => [];
    public virtual int GetContentLength() => -1;
    public override bool Equals(object? other) => other != null && other is Resource && ((Resource) other).Uri == Uri;
    public override int GetHashCode() => Uri.GetHashCode();
}