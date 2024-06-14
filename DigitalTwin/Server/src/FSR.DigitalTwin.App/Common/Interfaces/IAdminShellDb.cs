using AasCore.Aas3_0;

namespace FSR.DigitalTwin.App.Common.Interfaces;

public interface IAdminShellDb {
    public void PushToDb(IEnvironment environment);
    public Task PushToDbAsync(IEnvironment environment);
    public IEnvironment LoadFromDb();
    public Task<IEnvironment> LoadFromDbAsync();

}