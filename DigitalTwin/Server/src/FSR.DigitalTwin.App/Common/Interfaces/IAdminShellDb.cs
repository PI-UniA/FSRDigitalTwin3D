using AasCore.Aas3_0;

namespace FSR.DigitalTwin.App.Common.Interfaces;

public interface IAdminShellDb {
    public IEnvironment PushToDb();
    public Task<IEnvironment> PushToDbAsync();
    public IEnvironment LoadFromDb();
    public Task<IEnvironment> LoadFromDbAsync();

}