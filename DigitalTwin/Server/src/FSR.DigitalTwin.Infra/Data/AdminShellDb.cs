using AasCore.Aas3_0;
using AutoMapper;
using FSR.Aas.GRPC.Lib.V3;
using FSR.DigitalTwin.App.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FSR.DigitalTwin.Infra.Data;

public class AdminShellDb : IAdminShellDb
{
    private readonly AdminShellDbContext _db;
    private readonly IMapper _mapper;
    private readonly string _dbName = "AdminShellV3";

    public AdminShellDb(IMongoClient client, IMapper mapper) {
        var dbContextOptions =
            new DbContextOptionsBuilder<AdminShellDbContext>().UseMongoDB(client, _dbName);
        _db = new AdminShellDbContext(dbContextOptions.Options);
        _mapper = mapper;
    }

    public IEnvironment LoadFromDb()
    {
        throw new NotImplementedException();
    }

    public Task<IEnvironment> LoadFromDbAsync()
    {
        throw new NotImplementedException();
    }

    public void PushToDb(IEnvironment environment)
    {
        foreach (var aas in environment.AssetAdministrationShells ?? []) {
            _db.Add(_mapper.Map<AssetAdministrationShellDTO>(aas));
        }
        // foreach (var sm in environment.Submodels ?? []) {
        //     _db.Add(_mapper.Map<SubmodelDTO>(sm));
        // }
        foreach (var cd in environment.ConceptDescriptions ?? []) {
            _db.Add(_mapper.Map<ConceptDescriptionDTO>(cd));
        }
        _db.SaveChanges();
    }

    public async Task PushToDbAsync(IEnvironment environment)
    {
        foreach (var aas in environment.AssetAdministrationShells ?? []) {
            _db.Add(_mapper.Map<AssetAdministrationShellDTO>(aas));
        }
        // foreach (var sm in environment.Submodels ?? []) {
        //     _db.Add(_mapper.Map<SubmodelDTO>(sm));
        // }
        foreach (var cd in environment.ConceptDescriptions ?? []) {
            _db.Add(_mapper.Map<ConceptDescriptionDTO>(cd));
        }
        await _db.SaveChangesAsync();
    }
}