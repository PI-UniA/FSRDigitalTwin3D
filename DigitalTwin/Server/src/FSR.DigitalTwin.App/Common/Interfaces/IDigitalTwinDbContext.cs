namespace FSR.DigitalTwin.App.Common.Interfaces;

public interface IDigitalTwinDb {
    public void PushToDb();
    public Task PushToDbAsync();
    public void PullFromDb();
    public Task PullFromDbAsync();

}