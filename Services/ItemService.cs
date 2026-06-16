using Microsoft.EntityFrameworkCore;
using TemplateApi.Data;
using TemplateApi.DTOs;
using TemplateApi.Entities;

namespace TemplateApi.Services;

public class ItemService : IItemService
{
    private readonly AppDbContext _context;
    public ItemService(AppDbContext context) => _context = context;
    
    public async Task<ItemGetDto?> GetItemAsync(int id)
    {
        return await _context.Speakers
            .Where(i => i.SpeakerId == id)
            .Select(i => new ItemGetDto
            {
                SpeakerId = i.SpeakerId,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Bio = i.Bio,
                Email = i.Email,
                
                Workshops = i.Workshops.Select(w => new WorkshopDto
                {
                    WorkshopId = w.WorkShopId,
                    Title = w.Title,
                    Description = w.Description,
                    WorkshopDate =  w.WorkshopDate,
                    MaxCapacity =  w.MaxCapacity,
                    Venue = new VenueDto
                    {
                        Name = w.Venue.Name,
                        Address = w.Venue.Address,
                        Capacity = w.Venue.Capacity,
                        HasProject = w.Venue.HasProj
                    }
                }).ToList(),
            })
            .FirstOrDefaultAsync();
    }
    
    public async Task<OpResult> CreateItemAsync(int ownerId, CreateItemDto dto)
    {
        var owner = await _context.Participants.FirstOrDefaultAsync(o => o.ParticipantId == ownerId);
        if (owner is null) return OpResult.NotFound;

        await using var tx = await _context.Database.BeginTransactionAsync();
        try
        {
            var item = new Participant()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
            };
            _context.Participants.Add(item);

            await _context.SaveChangesAsync();
            await tx.CommitAsync();
            return OpResult.Success;
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
    }
}

